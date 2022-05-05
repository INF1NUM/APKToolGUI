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
    class DecodeControlEventHandlers
    {
        private static FormMain main;
        public DecodeControlEventHandlers(FormMain Main)
        {
            main = Main;
        }

        internal void button_DECODE_BrowseFrameDir_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (!String.IsNullOrWhiteSpace(main.textBox_DECODE_FrameDir.Text))
                    fbd.SelectedPath = main.textBox_DECODE_FrameDir.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                    main.textBox_DECODE_FrameDir.Text = fbd.SelectedPath;
            }
        }

        internal void button_DECODE_BrowseOutputDirectory_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (!String.IsNullOrWhiteSpace(main.textBox_DECODE_OutputDirectory.Text))
                    fbd.SelectedPath = main.textBox_DECODE_OutputDirectory.Text;
                else
                    if (!String.IsNullOrWhiteSpace(main.textBox_DECODE_InputAppPath.Text))
                    fbd.SelectedPath = Path.GetDirectoryName(main.textBox_DECODE_InputAppPath.Text);
                if (fbd.ShowDialog() == DialogResult.OK)
                    main.textBox_DECODE_OutputDirectory.Text = fbd.SelectedPath;
            }
        }

        internal void button_DECODE_BrowseInputAppPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    main.textBox_DECODE_InputAppPath.Text = ofd.FileName;
                    main.GetApkInfo(ofd.FileName);
                    if (main.checkBox_DECODE_OutputDirectory.Checked)
                    {
                        main.textBox_DECODE_OutputDirectory.Text = Path.Combine(Path.GetDirectoryName(main.textBox_DECODE_InputAppPath.Text), Path.GetFileNameWithoutExtension(main.textBox_DECODE_InputAppPath.Text));
                    }
                }
            }
        }

        internal async void button_DECODE_Decode_Click(object sender, EventArgs e)
        {
            if (File.Exists(main.textBox_DECODE_InputAppPath.Text))
            {
                if (main.checkBox_DECODE_UseFramework.Checked && !Directory.Exists(main.textBox_DECODE_FrameDir.Text))
                {
                    main.ShowMessage(Language.DecodeSelectedFrameworkNotExist, MessageBoxIcon.Warning);
                    return;
                }
                if (main.checkBox_DECODE_OutputDirectory.Checked)
                {
                    if (String.IsNullOrWhiteSpace(main.textBox_DECODE_OutputDirectory.Text))
                    {
                        main.ShowMessage(Language.DecodeDirNotSelected, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        if (!PathUtils.IsValidPath(main.textBox_DECODE_OutputDirectory.Text))
                    {
                        main.ShowMessage(Language.DecodeCouldNotCreate, MessageBoxIcon.Warning);
                        return;
                    }
                }

                await main.Decompile(main.textBox_DECODE_InputAppPath.Text);
            }
            else
                MessageBox.Show(Language.WarningFileForDecodingNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Directory.Exists(main.textBox_DECODE_OutputDirectory.Text))
                Process.Start("explorer.exe", main.textBox_DECODE_OutputDirectory.Text);
            else
            {
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedOutputFolderNotExist);
            }
        }
    }
}
