using APKToolGUI.Languages;
using APKToolGUI.Properties;
using APKToolGUI.Utils;
using SaveToGameWpf.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace APKToolGUI.Handlers
{
    class DragDropHandlers
    {
        private static FormMain main;
        public DragDropHandlers(FormMain Main)
        {
            main = Main;

            //Decode
            DragEventHandler decEventHandler = new DragEventHandler((sender, e) => { DropApkToDec(e); });
            Register(main.decPanel, ".apk", decEventHandler);
            Register(main.textBox_DECODE_InputAppPath, ".apk", decEventHandler, main.decPanel);
            Register(main.button_DECODE_Decode, ".apk", decEventHandler, main.decPanel);

            DragEventHandler comEventHandler = new DragEventHandler((sender, e) => { DropDirToCom(e); });
            Register(main.comPanel, "", comEventHandler);
            Register(main.textBox_BUILD_InputProjectDir, "", comEventHandler, main.comPanel);
            Register(main.button_BUILD_Build, "", comEventHandler, main.comPanel);

            DragEventHandler alignEventHandler = new DragEventHandler((sender, e) => { DropApkToAlign(e); });
            Register(main.zipalignPanel, ".apk", alignEventHandler);
            Register(main.textBox_ZIPALIGN_InputFile, ".apk", alignEventHandler, main.zipalignPanel);
            Register(main.button_ZIPALIGN_Align, ".apk", alignEventHandler, main.zipalignPanel);

            DragEventHandler signEventHandler = new DragEventHandler((sender, e) => { DropApkToSign(e); });
            Register(main.signPanel, ".apk", signEventHandler);
            Register(main.textBox_SIGN_InputFile, ".apk", signEventHandler, main.signPanel);
            Register(main.button_SIGN_Sign, ".apk", signEventHandler, main.signPanel);

            DragEventHandler baksmaliEventHandler = new DragEventHandler((sender, e) => { DropDexToBaksmali(e); });
            Register(main.bakSmaliGroupBox, ".dex", baksmaliEventHandler);
            main.bakSmaliGroupBox.AllowDrop = true;

            DragEventHandler smaliEventHandler = new DragEventHandler((sender, e) => { DropDirToSmali(e); });
            Register(main.smaliGroupBox, "", smaliEventHandler);
            main.smaliGroupBox.AllowDrop = true;

            DragEventHandler apkInfoEventHandler = new DragEventHandler((sender, e) => { DropApkToGetInfo(e); });
            Register(main.tabPageApkInfo, ".apk", apkInfoEventHandler);
            Register(main.fileTxtBox, ".apk", apkInfoEventHandler);
        }

        void Register(Control ctrl, string extension, DragEventHandler dragHandler, Control extCtrl = null)
        {
            if (extCtrl == null)
                extCtrl = ctrl;
            ctrl.DragLeave += new EventHandler((sender, e) => extCtrl.BackColor = Color.White);
            ctrl.DragEnter += new DragEventHandler((sender, e) => e.CheckDragEnter(extension));
            ctrl.DragOver += new DragEventHandler((sender, e) => { if (e.CheckDragOver(extension)) extCtrl.BackColor = Color.LightGreen; });
            ctrl.DragDrop += dragHandler;
        }

        private async void DropApkToDec(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(".apk", file => apkFile = file))
            {
                main.GetApkInfo(apkFile);
                main.textBox_DECODE_InputAppPath.Text = apkFile;
                main.decPanel.BackColor = Color.White;

                await main.Decompile(apkFile);
            }
        }

        private async void DropDirToCom(DragEventArgs e)
        {
            string folder = null;
            if (e.DropOneByEnd("", file => folder = file))
            {
                if (File.Exists(Path.Combine(folder, "AndroidManifest.xml")))
                {
                    main.textBox_BUILD_InputProjectDir.Text = folder;
                    main.comPanel.BackColor = Color.White;
                    await main.Build(folder);
                }
                else
                    main.ToLog(ApktoolEventType.Error, Language.ErrorNotAnApk);
            }
        }

        private async void DropApkToAlign(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(".apk", file => apkFile = file))
            {
                main.textBox_ZIPALIGN_InputFile.Text = apkFile;
                main.zipalignPanel.BackColor = Color.White;

                try
                {
                    main.Running();

                    await Task.Factory.StartNew(() =>
                    {
                        string outputDir = apkFile;
                        if (Settings.Default.Zipalign_UseOutputDir)
                            outputDir = Path.Combine(Settings.Default.Zipalign_OutputDir, Path.GetFileName(apkFile));

                        if (!Settings.Default.Zipalign_OverwriteOutputFile)
                            outputDir = PathUtils.GetDirectoryNameWithoutExtension(outputDir) + " aligned.apk";

                        if (main.Align(apkFile, outputDir) == 0)
                            main.ToLog(ApktoolEventType.Information, String.Format(Language.ZipalignFileSavedTo, outputDir));
                        else
                            main.ToLog(ApktoolEventType.Error, Language.ErrorZipalign);
                    });
                }
                catch (Exception ex)
                {
                    main.ToLog(ApktoolEventType.Error, ex.Message);
                }
                main.Done();
            }
        }

        private async void DropApkToSign(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(".apk", file => apkFile = file))
            {
                main.textBox_SIGN_InputFile.Text = apkFile;
                main.signPanel.BackColor = Color.White;

                try
                {
                    main.Running();

                    await Task.Factory.StartNew(() =>
                    {
                        string inputFile = apkFile;
                        string outputDir = apkFile;
                        if (Settings.Default.Zipalign_UseOutputDir)
                            outputDir = Path.Combine(Settings.Default.Sign_OutputDir, Path.GetFileName(inputFile));

                        if (main.Sign(inputFile, outputDir) == 0)
                            if (Settings.Default.Zipalign_UseOutputDir)
                                main.ToLog(ApktoolEventType.Information, String.Format(Language.SignSuccessfullyCompleted, inputFile));
                            else
                                main.ToLog(ApktoolEventType.Information, String.Format(Language.SignSuccessfullyCompleted, outputDir));
                        else
                            main.ToLog(ApktoolEventType.Error, String.Format(Language.ErrorSigning, outputDir));
                    });
                }
                catch (Exception ex)
                {
                    main.ToLog(ApktoolEventType.Error, ex.Message);
                }
                main.Done();
            }
        }

        private async void DropDexToBaksmali(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(".dex", file => apkFile = file))
            {
                main.baksmaliBrowseInputDexTxtBox.Text = apkFile;
                main.bakSmaliGroupBox.BackColor = Color.White;
               await main.Baksmali(apkFile);
            }
        }

        private async void DropDirToSmali(DragEventArgs e)
        {
            string dir = null;
            if (e.DropOneByEnd("", file => dir = file))
            {
                main.smaliBrowseInputDirTxtBox.Text = dir;
                main.smaliGroupBox.BackColor = Color.White;
                await main.Smali(dir + ".dex");
            }
        }

        private void DropApkToGetInfo(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(".apk", file => apkFile = file))
            {
                main.smaliBrowseInputDirTxtBox.Text = apkFile;
                main.tabPageApkInfo.BackColor = Color.White;
                main.GetApkInfo(apkFile);
            }
        }
    }
}
