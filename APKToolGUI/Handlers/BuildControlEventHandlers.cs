using APKToolGUI.Languages;
using APKToolGUI.Properties;
using APKToolGUI.Utils;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APKToolGUI.Handlers
{
    class BuildControlEventHandlers
    {
        private static FormMain main;

        public BuildControlEventHandlers(FormMain Main)
        {
            main = Main;
        }

        internal void button_BUILD_BrowseAaptPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Language.ExecutableFile + "|*.exe";
                if (!String.IsNullOrWhiteSpace(main.textBox_BUILD_AaptPath.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(main.textBox_BUILD_AaptPath.Text);
                    ofd.FileName = Path.GetFileName(main.textBox_BUILD_AaptPath.Text);
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                    main.textBox_BUILD_AaptPath.Text = ofd.FileName;
            }
        }

        internal void button_BUILD_BrowseFrameDir_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (!String.IsNullOrWhiteSpace(main.textBox_BUILD_FrameDir.Text))
                    fbd.SelectedPath = main.textBox_BUILD_FrameDir.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                    main.textBox_BUILD_FrameDir.Text = fbd.SelectedPath;
            }
        }

        internal void button_BUILD_BrowseOutputAppPath_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.textBox_BUILD_OutputAppPath.Text = dlg.SelectedPath;
            }
        }

        internal void button_BUILD_BrowseInputProjectDir_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.textBox_BUILD_InputProjectDir.Text = dlg.SelectedPath;
            }
        }

        internal async void button_BUILD_Build_Click(object sender, EventArgs e)
        {
            string decApkDir = main.textBox_BUILD_InputProjectDir.Text;
            if (Directory.Exists(main.textBox_BUILD_InputProjectDir.Text))
            {
                await main.Build(decApkDir);
            }
            else
                MessageBox.Show(Language.WarningDecodingFolderNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
