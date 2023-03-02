using APKToolGUI.Languages;
using APKToolGUI.Properties;
using APKToolGUI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APKToolGUI.Handlers
{
    internal class MainWindowEventHandlers
    {
        private static FormMain main;
        public MainWindowEventHandlers(FormMain Main)
        {
            main = Main;
            main.clearLogToolStripMenuItem.Click += clearLogToolStripMenuItem_Click;
            main.copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            main.openAndroidMainfestBtn.Click += openAndroidMainfestBtn_Click;
            main.openApktoolYmlBtn.Click += openApktoolYmlBtn_Click;
            main.compileOutputOpenDirBtn.Click += compiledApkOpenDirBtn_Click;
            main.button_OpenMainActivity.Click += button_OpenMainActivity_Click;
            main.decApkOpenDirBtn.Click += decApkOpenDirBtn_Click;
            main.decOutOpenDirBtn.Click += decOutOpenDirBtn_Click;
            main.comApkOpenDir.Click += comApkOpenDir_Click;
            main.signApkOpenDirBtn.Click += signApkOpenDirBtn_Click;
            main.alignApkOpenDirBtn.Click += alignApkOpenDirBtn_Click;
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.logTxtBox.Text = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(main.logTxtBox.SelectedText);
            }
            catch (Exception ex)
            {
                main.ToLog(ApktoolEventType.Error, ex.Message);
            }
        }


        internal void decApkOpenDirBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(main.textBox_BUILD_InputProjectDir.Text))
                Process.Start("explorer.exe", main.textBox_BUILD_InputProjectDir.Text);
            else
            {
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedFileNotExist);
            }
        }

        internal void decOutOpenDirBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Settings.Default.Decode_OutputDir))
                Process.Start("explorer.exe", Settings.Default.Decode_OutputDir);
            else
            {
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedOutputFolderNotExist);
            }
        }

        private void openAndroidMainfestBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(main.textBox_BUILD_InputProjectDir.Text, "AndroidManifest.xml")))
                Process.Start("explorer.exe", Path.Combine(main.textBox_BUILD_InputProjectDir.Text, "AndroidManifest.xml"));
            else
                main.ToLog(ApktoolEventType.Error, Language.AndroidManifestNotExist);
        }

        private void openApktoolYmlBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(main.textBox_BUILD_InputProjectDir.Text, "apktool.yml")))
                Process.Start("explorer.exe", Path.Combine(main.textBox_BUILD_InputProjectDir.Text, "apktool.yml"));
            else
                main.ToLog(ApktoolEventType.Error, Language.AndroidManifestNotExist);
        }

        private void compiledApkOpenDirBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Settings.Default.Build_OutputAppPath))
            {
                Process.Start("explorer.exe", Settings.Default.Build_OutputAppPath);
            }
            else
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedFileNotExist);
        }

        private void button_OpenMainActivity_Click(object sender, EventArgs e)
        {
            string decPath = main.textBox_BUILD_InputProjectDir.Text;
            if (Directory.Exists(decPath))
            {
                var launchActivityList = new List<string>
                {
                    main.aapt != null ? main.aapt.LaunchableActivity : CommonUtils.GetActivityFromManifest(decPath),
                    "com\\unity3d\\player\\UnityPlayerActivity",
                    CommonUtils.GetApplicationNameFromManifest(decPath)
                };

                foreach (string launchActivity in launchActivityList)
                {
                    if (String.IsNullOrEmpty(launchActivity))
                        continue;

                    Debug.WriteLine(launchActivity);

                    string path = null;
                    bool activityFound = false;
                    for (int i = 1; i < 100; i++)
                    {
                        string smaliFolder = (i == 1) ? "smali" : "smali_classes" + i;
                        path = Path.Combine(decPath, smaliFolder, launchActivity.Replace(".", "\\") + ".smali");
                        if (File.Exists(path))
                        {
                            Debug.WriteLine(path);
                            activityFound = true;
                            break;
                        }
                    }

                    if (activityFound && !CommonUtils.OnCreateExists(path))
                        continue;

                    if (activityFound)
                    {
                        main.ToLog(ApktoolEventType.None, String.Format(Language.MainActivityFound, path));
                        Process.Start("explorer.exe", path);
                        return;
                    }
                    else
                        continue;
                }

                main.ToLog(ApktoolEventType.Warning, Language.MainActivityNotFoundPleaseFindManually);
            }
            else
                main.ToLog(ApktoolEventType.Error, Language.DecompiledAPKNotExist);
        }

        internal void comApkOpenDir_Click(object sender, EventArgs e)
        {
            string decApkDir = main.textBox_BUILD_InputProjectDir.Text;

            string outputFile = decApkDir + " compiled.apk";
            if (Settings.Default.Build_SignAfterBuild)
                outputFile = decApkDir + " signed.apk";
            if (Settings.Default.Build_UseOutputAppPath)
            {
                outputFile = Path.Combine(Settings.Default.Build_OutputAppPath, Path.GetFileName(decApkDir)) + ".apk";
                if (Settings.Default.Build_SignAfterBuild)
                    outputFile = Path.Combine(Settings.Default.Build_OutputAppPath, Path.GetFileName(decApkDir)) + " signed.apk";
            }

            if (File.Exists(outputFile))
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", outputFile));
            else
            {
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedFileNotExist);
            }
        }

        internal void signApkOpenDirBtn_Click(object sender, EventArgs e)
        {
            string inputFile = Settings.Default.Sign_InputFile;
            string outputFile = inputFile;
            if (Settings.Default.Zipalign_UseOutputDir)
                outputFile = Path.Combine(Settings.Default.Sign_OutputDir, Path.GetFileName(inputFile));

            if (File.Exists(outputFile))
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", outputFile));
            else
            {
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedFileNotExist);
            }
        }

        internal void alignApkOpenDirBtn_Click(object sender, EventArgs e)
        {
            string inputFile = Settings.Default.Zipalign_InputFile;

            string outputFile = inputFile;
            if (!String.IsNullOrEmpty(outputFile))
            {
                if (Settings.Default.Zipalign_UseOutputDir)
                    outputFile = Path.Combine(Settings.Default.Zipalign_OutputDir, Path.GetFileName(inputFile));

                if (!Settings.Default.Zipalign_OverwriteOutputFile)
                    outputFile = PathUtils.GetDirectoryNameWithoutExtension(outputFile) + " aligned.apk";
            }
            if (File.Exists(outputFile))
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", outputFile));
            else
            {
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedFileNotExist);
            }
        }
    }
}
