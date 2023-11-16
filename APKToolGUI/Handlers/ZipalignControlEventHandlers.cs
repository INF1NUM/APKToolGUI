﻿using APKToolGUI.Languages;
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
    class ZipalignControlEventHandlers
    {
        private static FormMain main;

        public ZipalignControlEventHandlers(FormMain Main)
        {
            main = Main;
            CheckAlignSwitch = !Settings.Default.Zipalign_CheckOnly;
            main.checkBox_ZIPALIGN_CheckAlignment.Click += checkBox_ZIPALIGN_CheckAlignment_CheckedChanged;
            main.button_ZIPALIGN_BrowseOutputFile.Click += button_ZIPALIGN_BrowseOutputFile_Click;
            main.button_ZIPALIGN_BrowseInputFile.Click += button_ZIPALIGN_BrowseInputFile_Click;
            main.button_ZIPALIGN_Align.Click += button_ZIPALIGN_Align_Click;
        }

        internal bool CheckAlignSwitch
        {
            set
            {
                main.checkBox_ZIPALIGN_Recompress.Enabled = value;
                main.checkBox_ZIPALIGN_OverwriteOutputFile.Enabled = value;
            }
        }

        internal void checkBox_ZIPALIGN_CheckAlignment_CheckedChanged(object sender, EventArgs e)
        {
            CheckAlignSwitch = !main.checkBox_ZIPALIGN_CheckAlignment.Checked;
        }

        internal void button_ZIPALIGN_BrowseOutputFile_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.textBox_ZIPALIGN_OutputFile.Text = dlg.SelectedPath;
            }
        }

        internal void button_ZIPALIGN_BrowseInputFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // ofd.Filter = "ZIP archives(*.apk;*.zip;*.jar)|*.apk;*.zip;*.jar";
                ofd.Filter = Language.ZIPArchives + " (*.apk)|*.apk";
                if (File.Exists(main.textBox_ZIPALIGN_InputFile.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(main.textBox_ZIPALIGN_InputFile.Text);
                    ofd.FileName = Path.GetFileName(main.textBox_ZIPALIGN_InputFile.Text);
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    main.textBox_ZIPALIGN_InputFile.Text = ofd.FileName;
                    main.GetApkInfo(ofd.FileName);
                    if (!main.checkBox_ZIPALIGN_CheckAlignment.Checked)
                        main.textBox_ZIPALIGN_OutputFile.Text = String.Format("{0}\\{1}_zipaligned{2}",
                            Path.GetDirectoryName(ofd.FileName),
                            Path.GetFileNameWithoutExtension(ofd.FileName),
                            Path.GetExtension(ofd.FileName));
                }
            }
        }

        internal async void button_ZIPALIGN_Align_Click(object sender, EventArgs e)
        {
            if (!File.Exists(main.textBox_ZIPALIGN_InputFile.Text))
            {
                main.ShowMessage(Language.ErrorSelectedFileNotExist, MessageBoxIcon.Warning);
                return;
            }

            string inputFile = Settings.Default.Zipalign_InputFile;

            await main.Align(inputFile);
        }
    }
}
