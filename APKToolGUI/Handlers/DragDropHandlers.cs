using APKToolGUI.ApkTool;
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

            DragEventHandler adbEventHandler = new DragEventHandler((sender, e) => { DropApkToInstall(e); });
            Register(main.tabPageAdb, null, adbEventHandler, new string[] { ".apk" });
            Register(main.installApkBtn, null, adbEventHandler, new string[] { ".apk" });
        }

        void Register(Control ctrl, Control extCtrl, DragEventHandler dragHandler, string[] extension)
        {
            if (extCtrl == null)
                extCtrl = ctrl;
            ctrl.DragLeave += new EventHandler((sender, e) => extCtrl.BackColor = Color.White);
            ctrl.DragEnter += new DragEventHandler((sender, e) => e.CheckDragEnter(extension));
            ctrl.DragOver += new DragEventHandler((sender, e) => { if (e.CheckManyDragOver(extension)) extCtrl.BackColor = Color.LightGreen; });
            ctrl.DragDrop += dragHandler;
        }

        private async void DropApkToDec(DragEventArgs e)
        {
            string[] apkFiles = null;
            if (e.DropManyByEnd(file => apkFiles = file, apks))
            {
                main.decPanel.BackColor = Color.White;

                foreach (var apkFile in apkFiles)
                {
                    main.textBox_DECODE_InputAppPath.Text = apkFile;

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
        }

        private async void DropDirToCom(DragEventArgs e)
        {
            string[] folders = null;
            if (e.DropManyByEnd(file => folders = file, null))
            {
                foreach (var folder in folders)
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
        }

        private async void DropApkToAlign(DragEventArgs e)
        {
            string[] apkFiles = null;
            if (e.DropManyByEnd(file => apkFiles = file, apks))
            {
                main.zipalignPanel.BackColor = Color.White;

                foreach (var apkFile in apkFiles)
                {
                    main.textBox_ZIPALIGN_InputFile.Text = apkFile;

                    await main.Align(apkFile);
                }
            }
        }

        private async void DropApkToSign(DragEventArgs e)
        {
            string[] apkFiles = null;
            if (e.DropManyByEnd(file => apkFiles = file, apks))
            {
                main.signPanel.BackColor = Color.White;

                foreach (var apkFile in apkFiles)
                {
                    main.textBox_SIGN_InputFile.Text = apkFile;

                    await main.Sign(apkFile);
                }
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
        
        private async void DropApkToInstall(DragEventArgs e)
        {
            string dir = null;
            if (e.DropOneByEnd(file => dir = file, ".apk"))
            {
                main.apkPathAdbTxtBox.Text = dir;
                main.tabPageAdb.BackColor = Color.White;
                await main.Install(dir);
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
