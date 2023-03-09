using APKToolGUI.ApkTool;
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
    class SignControlEventHandlers
    {
        private static FormMain main;

        public SignControlEventHandlers(FormMain Main)
        {
            main = Main;
            main.button_SIGN_BrowsePublicKey.Click += button_SIGN_BrowsePublicKey_Click;
            main.button_SIGN_BrowsePrivateKey.Click += button_SIGN_BrowsePrivateKey_Click;
            main.button_SIGN_BrowsePrivateKey.Click += button_SIGN_BrowsePrivateKey_Click;
            main.button_SIGN_BrowseInputFile.Click += button_SIGN_BrowseInputFile_Click;
            main.button_SIGN_BrowseOutputFile.Click += button_SIGN_BrowseOutputFile_Click;
            main.schemev1ComboBox.SelectedIndexChanged += schemeComboBoxChanged;
            main.schemev2ComboBox.SelectedIndexChanged += schemeComboBoxChanged;
            main.schemev3ComboBox.SelectedIndexChanged += schemeComboBoxChanged;
            main.schemev4ComboBox.SelectedIndexChanged += schemeComboBoxChanged;
            main.button_SIGN_Sign.Click += button_SIGN_Sign_Click;
            main.selectKeyStoreFileBtn.Click += selectKeyStoreFileBtn_Click;
        }

        internal void button_SIGN_BrowsePublicKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.pem|*.pem";
                if (File.Exists(main.textBox_SIGN_PublicKey.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(main.textBox_SIGN_PublicKey.Text);
                    ofd.FileName = Path.GetFileNameWithoutExtension(main.textBox_SIGN_PublicKey.Text);
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                    main.textBox_SIGN_PublicKey.Text = Program.GetPortablePath(ofd.FileName);
            }
        }

        internal void button_SIGN_BrowsePrivateKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.pk8|*.pk8";
                if (File.Exists(main.textBox_SIGN_PrivateKey.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(main.textBox_SIGN_PrivateKey.Text);
                    ofd.FileName = Path.GetFileNameWithoutExtension(main.textBox_SIGN_PrivateKey.Text);
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                    main.textBox_SIGN_PrivateKey.Text = Program.GetPortablePath(ofd.FileName);
            }
        }

        internal void button_SIGN_BrowseOutputFile_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                main.textBox_SIGN_OutputFile.Text = dlg.SelectedPath;
            }
        }

        internal void button_SIGN_BrowseInputFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "(*.apk;*.jar;*.zip)|*.apk;*.jar;*.zip";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    main.textBox_SIGN_InputFile.Text = ofd.FileName;
                    main.GetApkInfo(ofd.FileName);
                    main.textBox_SIGN_OutputFile.Text =
                        String.Format("{0}{1}{2}_signed{3}",
                        Path.GetDirectoryName(main.textBox_SIGN_InputFile.Text),
                        Path.DirectorySeparatorChar,
                        Path.GetFileNameWithoutExtension(main.textBox_SIGN_InputFile.Text),
                        Path.GetExtension(main.textBox_SIGN_InputFile.Text));
                }
            }
        }

        internal async void button_SIGN_Sign_Click(object sender, EventArgs e)
        {
            try
            {
                main.Save();
                if (!File.Exists(Settings.Default.Sign_PublicKey))
                {
                    main.ShowMessage(Language.SignPublicKeyNotFound, MessageBoxIcon.Warning);
                    return;
                }
                if (!File.Exists(Settings.Default.Sign_PrivateKey))
                {
                    main.ShowMessage(Language.SignPrivateKeyNotFound, MessageBoxIcon.Warning);
                    return;
                }
                if (!File.Exists(main.textBox_SIGN_InputFile.Text))
                {
                    main.ShowMessage(Language.SignInputFileNotFound, MessageBoxIcon.Warning);
                    return;
                }

                await main.Sign(Settings.Default.Sign_InputFile);
            }
            catch (Exception ex)
            {
                main.ToLog(ApktoolEventType.Error, ex.Message);
            }
        }

        internal void selectKeyStoreFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Keystore|*.keystore;*.jks";
                if (ofd.ShowDialog() == DialogResult.OK)
                    main.keyStoreFileTxtBox.Text = ofd.FileName;
            }
        }

        private void schemeComboBoxChanged(object sender, EventArgs e)
        {
            Settings.Default.Sign_Schemev1 = main.schemev1ComboBox.SelectedIndex;
            Settings.Default.Sign_Schemev2 = main.schemev2ComboBox.SelectedIndex;
            Settings.Default.Sign_Schemev3 = main.schemev3ComboBox.SelectedIndex;
            Settings.Default.Sign_Schemev4 = main.schemev4ComboBox.SelectedIndex;
        }
    }
}
