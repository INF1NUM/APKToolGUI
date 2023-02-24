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
    class FrameworkControlEventHandlers
    {
        private static FormMain main;

        public FrameworkControlEventHandlers(FormMain Main)
        {
            main = Main;
            main.button_IF_BrowseFrameDir.Click += button_IF_BrowseFrameDir_Click;
            main.button_IF_BrowseInputFramePath.Click += button_IF_BrowseInputFramePath_Click;
            main.button_IF_InstallFramework.Click += button_IF_InstallFramework_Click;
            main.clearFwBtn.Click += clearFwBtn_Click;
            main.openFwFolderBtn.Click += openFwFolderBtn_Click;
        }

        internal void button_IF_BrowseFrameDir_Click(object sender, EventArgs e)
        {
            main.clearFwBeforeDecodeChkBox.Checked = false;
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.textBox_IF_FrameDir.Text = dlg.SelectedPath;
            }
        }

        internal void button_IF_BrowseInputFramePath_Click(object sender, EventArgs e)
        {
            main.clearFwBeforeDecodeChkBox.Checked = false;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (File.Exists(main.textBox_IF_InputFramePath.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(main.textBox_IF_InputFramePath.Text);
                    ofd.FileName = Path.GetFileNameWithoutExtension(main.textBox_IF_InputFramePath.Text);
                }
                ofd.Filter = "apk|*.apk";

                if (ofd.ShowDialog() == DialogResult.OK)
                    main.textBox_IF_InputFramePath.Text = ofd.FileName;
            }
        }

        internal async void button_IF_InstallFramework_Click(object sender, EventArgs e)
        {
            if (main.checkBox_IF_FramePath.Checked)
            {
                if (String.IsNullOrWhiteSpace(main.textBox_IF_FrameDir.Text) || !Directory.Exists(main.textBox_IF_FrameDir.Text))
                {
                    main.ShowMessage(Language.ErrorSelectingFrameworkDirectory, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (main.checkBox_IF_Tag.Checked && String.IsNullOrWhiteSpace(main.textBox_IF_Tag.Text))
            {
                main.ShowMessage(Language.ErrorEnteringFrameworkTag, MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(main.textBox_IF_InputFramePath.Text))
            {
                main.ShowMessage(Language.ErrorSelectingFrameworkFile, MessageBoxIcon.Warning);
                return;
            }

            main.Running();
            main.ToLog(ApktoolEventType.None, Language.InstallingFramework + " " + Path.GetFileName(main.textBox_IF_InputFramePath.Text));
            main.ToStatus(String.Format(Language.InstallingFramework + " \"{0}\"...", Path.GetFileName(main.textBox_IF_InputFramePath.Text)), Resources.waiting);

            await Task.Factory.StartNew(() =>
            {
                if (main.apktool.InstallFramework() == 0)
                    main.ToLog(ApktoolEventType.None, Language.FrameworkInstalled);
                else
                    main.ToLog(ApktoolEventType.Error, Language.FrameworkInstallationNotStarted);
            });
            main.Done(printTimer: true);
        }

        internal async void clearFwBtn_Click(object sender, EventArgs e)
        {
            main.Running();

            await Task.Factory.StartNew(() =>
            {
                if (main.ClearFramework() == 0)
                    main.ToLog(ApktoolEventType.None, Language.Done);
            });
           
            main.Done();
        }

        internal void openFwFolderBtn_Click(object sender, EventArgs e)
        {
            if (main.checkBox_IF_FramePath.Checked && Directory.Exists(main.textBox_IF_FrameDir.Text))
                Process.Start("explorer.exe", main.textBox_IF_FrameDir.Text);
            else if (Directory.Exists(Program.FRAMEWORK_DIR))
                Process.Start("explorer.exe", Program.FRAMEWORK_DIR);
            else
                main.ToLog(ApktoolEventType.Error, Language.ErrorSelectedFolderNotExist);
        }
    }
}
