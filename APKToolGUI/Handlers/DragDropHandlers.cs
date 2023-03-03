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

        string[] apks = { ".apk", ".xapk", ".zip", ".apks", ".apkm" };

        public DragDropHandlers(FormMain Main)
        {
            main = Main;

            //Decode
            DragEventHandler decEventHandler = new DragEventHandler((sender, e) => { DropApkToDec(e); });
            Register(main.decPanel, null, decEventHandler, apks);
            Register(main.textBox_DECODE_InputAppPath, main.decPanel, decEventHandler, apks);
            Register(main.button_DECODE_Decode, main.decPanel, decEventHandler, apks);

            DragEventHandler comEventHandler = new DragEventHandler((sender, e) => { DropDirToCom(e); });
            Register(main.comPanel, null, comEventHandler, null);
            Register(main.textBox_BUILD_InputProjectDir, main.comPanel, comEventHandler, null);
            Register(main.button_BUILD_Build, main.comPanel, comEventHandler, null);

            DragEventHandler alignEventHandler = new DragEventHandler((sender, e) => { DropApkToAlign(e); });
            Register(main.zipalignPanel, null, alignEventHandler, apks);
            Register(main.textBox_ZIPALIGN_InputFile, main.zipalignPanel, alignEventHandler, apks);
            Register(main.button_ZIPALIGN_Align, main.zipalignPanel, alignEventHandler, apks);

            DragEventHandler signEventHandler = new DragEventHandler((sender, e) => { DropApkToSign(e); });
            Register(main.signPanel, null, signEventHandler, apks);
            Register(main.textBox_SIGN_InputFile, main.signPanel, signEventHandler, apks);
            Register(main.button_SIGN_Sign, main.signPanel, signEventHandler, apks);

            DragEventHandler baksmaliEventHandler = new DragEventHandler((sender, e) => { DropDexToBaksmali(e); });
            Register(main.bakSmaliGroupBox, null, baksmaliEventHandler, new string[] { ".dex" });
            main.bakSmaliGroupBox.AllowDrop = true;

            DragEventHandler smaliEventHandler = new DragEventHandler((sender, e) => { DropDirToSmali(e); });
            Register(main.smaliGroupBox, null, smaliEventHandler, null);
            main.smaliGroupBox.AllowDrop = true;

            DragEventHandler apkInfoEventHandler = new DragEventHandler((sender, e) => { DropApkToGetInfo(e); });
            Register(main.basicInfoTabPage, null, apkInfoEventHandler, apks);
            Register(main.fileTxtBox, null, apkInfoEventHandler, apks);
        }

        void Register(Control ctrl, Control extCtrl, DragEventHandler dragHandler, string[] extension)
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
            if (e.DropOneByEnd(file => apkFile = file, apks))
            {
                main.textBox_DECODE_InputAppPath.Text = apkFile;
                main.decPanel.BackColor = Color.White;

                await main.GetApkInfo(apkFile);

                if (apkFile.ContainsAny(".xapk", ".zip", ".apks", ".apkm"))
                {
                    if (Settings.Default.Decode_UseApkEditorMergeApk)
                    {
                        await main.MergeUsingApkEditor(apkFile);
                    }
                    else
                    {
                        await main.Merge(apkFile);
                    }
                }
                else
                    await main.Decompile(apkFile);
            }
        }

        private async void DropDirToCom(DragEventArgs e)
        {
            string folder = null;
            if (e.DropOneByEnd(file => folder = file, null))
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
            if (e.DropOneByEnd(file => apkFile = file, apks))
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
                            main.ToLog(ApktoolEventType.None, String.Format(Language.ZipalignFileSavedTo, outputDir));
                        else
                            main.ToLog(ApktoolEventType.Error, Language.ErrorZipalign);
                    });
                }
                catch (Exception ex)
                {
                    main.ToLog(ApktoolEventType.Error, ex.Message);
                }
                main.Done(printTimer: true);
            }
        }

        private async void DropApkToSign(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(file => apkFile = file, apks))
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
                        if (!Settings.Default.Sign_OverwriteInputFile)
                            outputDir = PathUtils.GetDirectoryNameWithoutExtension(outputDir) + "_signed.apk";

                        if (main.Sign(inputFile, outputDir) == 0)
                        {
                            if (Settings.Default.Zipalign_UseOutputDir)
                                main.ToLog(ApktoolEventType.None, String.Format(Language.SignSuccessfullyCompleted, inputFile));
                            else
                                main.ToLog(ApktoolEventType.None, String.Format(Language.SignSuccessfullyCompleted, outputDir));

                            if (Settings.Default.AutoDeleteIdsigFile)
                            {
                                main.ToLog(ApktoolEventType.None, String.Format(Language.DeleteFile, outputDir + ".idsig"));
                                FileUtils.Delete(outputDir + ".idsig");
                            }
                        }
                        else
                            main.ToLog(ApktoolEventType.Error, String.Format(Language.ErrorSigning, outputDir));
                    });
                }
                catch (Exception ex)
                {
                    main.ToLog(ApktoolEventType.Error, ex.Message);
                }
                main.Done(printTimer: true);
            }
        }

        private async void DropDexToBaksmali(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(file => apkFile = file, ".dex"))
            {
                main.baksmaliBrowseInputDexTxtBox.Text = apkFile;
                main.bakSmaliGroupBox.BackColor = Color.White;
                await main.Baksmali(apkFile);
            }
        }

        private async void DropDirToSmali(DragEventArgs e)
        {
            string dir = null;
            if (e.DropOneByEnd(file => dir = file, null))
            {
                main.smaliBrowseInputDirTxtBox.Text = dir;
                main.smaliGroupBox.BackColor = Color.White;
                await main.Smali(dir);
            }
        }

        private void DropApkToGetInfo(DragEventArgs e)
        {
            string apkFile = null;
            if (e.DropOneByEnd(file => apkFile = file, apks))
            {
                main.smaliBrowseInputDirTxtBox.Text = apkFile;
                main.basicInfoTabPage.BackColor = Color.White;
                main.GetApkInfo(apkFile);
            }
        }
    }
}
