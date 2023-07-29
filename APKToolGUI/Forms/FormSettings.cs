using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using APKToolGUI.Languages;
using APKToolGUI.Utils;
using Ookii.Dialogs.WinForms;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Shapes;
using static APKToolGUI.UpdateChecker;
using APKToolGUI.Properties;
using APKToolGUI.Controls;

namespace APKToolGUI
{
    public partial class FormSettings : Form
    {
        string currentLanguage;
        bool currentUseApktoolChk;
        string currentApktoolPath;
        int currentTheme;

        public FormSettings()
        {
            InitializeComponent();

            if (Program.IsDarkTheme())
                DarkTheme.SetTheme(Controls, this);

            currentUseApktoolChk = useCustomApktoolChk.Checked;
            currentApktoolPath = customApkToolTxtBox.Text;

            if (!AdminUtils.IsAdministrator())
            {
                SetButtonShield(buttonAddContextMenu, true);
                SetButtonShield(buttonRemoveContextMenu, true);
            }

            int themeInt = (themeComboBox.Items.Count + 1 > Settings.Default.Theme) ? Settings.Default.Theme : 0;
            themeComboBox.SelectedIndex = themeInt;
            currentTheme = themeInt;
        }

        #region GUI

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void buttonОК_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private static void SetButtonShield(Button btn, bool showShield)
        {
            // BCM_SETSHIELD = 0x0000160C
            SendMessage(new HandleRef(btn, btn.Handle), 0x160C, IntPtr.Zero, showShield ? new IntPtr(1) : IntPtr.Zero);
        }

        private void buttonAddContextMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.DoYouRealyWantToInstallCM, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                RunAsAdmin(Application.ExecutablePath, "ccm");
        }

        private void buttonRemoveContextMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.DoYouRealyWantToRemoveCM, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                RunAsAdmin(Application.ExecutablePath, "rcm");
        }

        #endregion

        private void LoadSettings()
        {
            String sysLang = Language.SystemLanguage;

            comboBox1.Items.Add(sysLang);
            comboBox1.Items.Add(CultureInfo.GetCultureInfo("en"));
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            String _culture = Properties.Settings.Default.Culture;
            foreach (CultureInfo culture in cultures)
            {
                foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    string[] cultNamw = resourceName.Split('.');
                    if (cultNamw[1] == culture.Name)
                    {
                        string lang = String.Format("{0} [{1}]", culture.DisplayName, culture.Name);
                        comboBox1.Items.Add(lang);

                        if (culture.Name == _culture)
                            comboBox1.SelectedItem = lang;
                    }
                }
            }

            comboBox1.DisplayMember = "NativeName"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NativeName
            comboBox1.ValueMember = "Name"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").Name

            if (_culture.Equals("Auto"))
            {
                currentLanguage = sysLang;
                comboBox1.SelectedItem = sysLang;
            }
            else
            {
                try
                {
                    currentLanguage = Properties.Settings.Default.Culture;
                    comboBox1.SelectedItem = _culture;
                }
                catch { }
            }
        }

        private void SaveSettings()
        {
            try
            {
                if (Language.SystemLanguage.Equals(comboBox1.SelectedItem.ToString()))
                    Settings.Default.Culture = "Auto";
                else
                    Settings.Default.Culture = StringExt.Regex(@"(?<=\[)(.*?)(?=\])", comboBox1.SelectedItem.ToString());

                Settings.Default.Theme = themeComboBox.SelectedIndex;
                Settings.Default.Save();

                if (!comboBox1.SelectedItem.ToString().Contains(currentLanguage) || themeComboBox.SelectedIndex != currentTheme)
                    if (MessageBox.Show(Language.RestartApplicationPrompt, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Application.Restart();

                if (currentUseApktoolChk != useCustomApktoolChk.Checked || currentApktoolPath != customApkToolTxtBox.Text)
                {
                    FormMain.Instance.SetApktoolPath();
                }
            }
            catch (Exception ex)
            {
                Log.e(ex.ToString());
            }
        }

        public static void RunAsAdmin(string aFileName, string anArguments)
        {
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();

            processInfo.FileName = aFileName;
            processInfo.Arguments = anArguments;
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas";

            try
            {
                System.Diagnostics.Process.Start(processInfo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCustomJavaLocation_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openJavaExe = new OpenFileDialog())
            {
                openJavaExe.Filter = "java.exe|java.exe";
                if (openJavaExe.ShowDialog() == DialogResult.OK)
                    textBoxCustomJavaLocation.Text = Program.GetPortablePath(openJavaExe.FileName);
            }
        }

        private void buttonCustomTempLocation_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog())
            {
                if (!String.IsNullOrWhiteSpace(customTempLocationTxtBox.Text))
                    fbd.SelectedPath = customTempLocationTxtBox.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    customTempLocationTxtBox.Text = fbd.SelectedPath;
                    //Clear temp folder
                    DirectoryUtils.Delete(Program.TEMP_PATH);

                    //Create new temp folder
                    Program.TEMP_PATH = Program.RandTempDirectory();
                    Directory.CreateDirectory(Program.TEMP_PATH);
                }
            }
        }

        private async void customApktoolBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Apktool (*.jar)|*.jar";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    customApkToolTxtBox.Text = ofd.FileName;
                }
            }
        }
    }
}
