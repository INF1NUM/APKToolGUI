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
    class SmaliControlEventHandlers
    {
        private static FormMain main;
        public SmaliControlEventHandlers(FormMain Main)
        {
            main = Main;
        }

        internal void smaliBrowseOutputBtn_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.smaliBrowseOutputTxtBox.Text = dlg.SelectedPath;
            }
        }

        internal void smaliBrowseInputDirBtn_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.smaliBrowseInputDirTxtBox.Text = dlg.SelectedPath;
            }
        }

        internal void comSmaliBtn_Click(object sender, EventArgs e)
        {
            if (main.smaliUseOutputChkBox.Checked)
            {
                if (String.IsNullOrWhiteSpace(main.smaliBrowseOutputTxtBox.Text) || !Directory.Exists(main.smaliBrowseOutputTxtBox.Text))
                {
                    main.ShowMessage(Language.ErrorSelectedOutputFolderNotExist, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!Directory.Exists(main.smaliBrowseInputDirTxtBox.Text))
            {
                main.ShowMessage(Language.ErrorSelectedFileNotExist, MessageBoxIcon.Warning);
                return;
            }

            main.Smali(Settings.Default.Smali_InputDir + ".dex");
        }
    }
}
