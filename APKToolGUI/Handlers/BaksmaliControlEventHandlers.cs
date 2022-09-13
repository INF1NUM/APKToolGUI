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
    class BaksmaliControlEventHandlers
    {
        private static FormMain main;
        public BaksmaliControlEventHandlers(FormMain Main)
        {
            main = Main;
            main.baksmaliBrowseOutputBtn.Click += baksmaliBrowseOutputBtn_Click;
            main.baksmaliBrowseInputDexBtn.Click += baksmaliBrowseInputDexBtn_Click;
            main.decSmaliBtn.Click += decSmaliBtn_Click;
        }

        internal void baksmaliBrowseOutputBtn_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               main.baksmaliBrowseOutputTxtBox.Text = dlg.SelectedPath;
            }
        }

        internal void baksmaliBrowseInputDexBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "dex|*.dex";

                if (ofd.ShowDialog() == DialogResult.OK)
                    main.baksmaliBrowseInputDexTxtBox.Text = ofd.FileName;
            }
        }

        internal async void decSmaliBtn_Click(object sender, EventArgs e)
        {
            if (main.baksmaliUseOutputChkBox.Checked)
            {
                if (String.IsNullOrWhiteSpace(main.baksmaliBrowseOutputTxtBox.Text) || !Directory.Exists(main.baksmaliBrowseOutputTxtBox.Text))
                {
                    main.ShowMessage(Language.ErrorSelectedOutputFolderNotExist, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!File.Exists(main.baksmaliBrowseInputDexTxtBox.Text))
            {
                main.ShowMessage(Language.ErrorSelectedFileNotExist, MessageBoxIcon.Warning);
                return;
            }

            await main.Baksmali(Settings.Default.Baksmali_InputDexFile);
        }
    }
}
