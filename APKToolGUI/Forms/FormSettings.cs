using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using APKToolGUI.Languages;
using APKToolGUI.Utils;

namespace APKToolGUI
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            if (!AdminUtils.IsAdministrator())
            {
                SetButtonShield(buttonAddContextMenu, true);
                SetButtonShield(buttonRemoveContextMenu, true);
            }
        }

        #region GUI

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void buttonОК_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
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
            if(MessageBox.Show(Language.DoYouRealyWantToInstallCM, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                RunAsAdmin(Application.ExecutablePath, "ccm");
        }

        private void buttonRemoveContextMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.DoYouRealyWantToRemoveCM, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                RunAsAdmin(Application.ExecutablePath, "rcm");
        }

        #endregion

        private void LoadSettings()
        {
            //textBox1.Font = Properties.Settings.Default.FontLogMainWindow;
            //textBox2.Font = Properties.Settings.Default.FontLogContextMenuWindow;
            //textBox1.Text = textBox1.Font.Name + ", " + textBox1.Font.Size;
            //textBox2.Text = textBox2.Font.Name + ", " + textBox2.Font.Size;

            String sysLang = Language.SystemLanguage;
            comboBox1.Items.Add(sysLang);
            comboBox1.Items.Add(System.Globalization.CultureInfo.GetCultureInfo("ru"));
            comboBox1.Items.Add(System.Globalization.CultureInfo.GetCultureInfo("en"));
            //comboBox1.Items.Add(System.Globalization.CultureInfo.GetCultureInfo("uk"));
            //comboBox1.Items.Add(System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));
            //comboBox1.Items.Add(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            //comboBox1.Items.Add(System.Globalization.CultureInfo.GetCultureInfo("uk-UA"));
            
            comboBox1.DisplayMember = "NativeName"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NativeName
            comboBox1.ValueMember = "Name"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").Name

            // Если в настройках есть язык, выбираем его в списке.
            String _culture = Properties.Settings.Default.Culture;
            if (_culture.Equals("Auto"))
                comboBox1.SelectedItem = sysLang;
            else
            {
                var qwe = System.Globalization.CultureInfo.GetCultureInfo(_culture);
                comboBox1.SelectedItem = qwe;
            }
            
        }

        private void SaveSettings()
        {
            //Properties.Settings.Default.FontLogMainWindow = textBox1.Font;
            //Properties.Settings.Default.FontLogContextMenuWindow = textBox2.Font;

            if (Language.SystemLanguage.Equals(comboBox1.SelectedItem.ToString()))
                Properties.Settings.Default.Culture = "Auto";
            else
                Properties.Settings.Default.Culture = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        public static void RunAsAdmin(string aFileName, string anArguments)
        {
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();

            processInfo.FileName = aFileName;
            processInfo.Arguments = anArguments;
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas"; // здесь вся соль

            try
            {
                System.Diagnostics.Process.Start(processInfo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FontDialog fontDialog1 = new FontDialog();
        //    fontDialog1.Font = textBox1.Font;
        //    if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        textBox1.Text = fontDialog1.Font.Name + ", " + fontDialog1.Font.Size;
        //        textBox1.Font = fontDialog1.Font;
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    FontDialog fontDialog1 = new FontDialog();
        //    fontDialog1.Font = textBox2.Font;
        //    if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        textBox2.Text = fontDialog1.Font.Name + ", " + fontDialog1.Font.Size;
        //        textBox2.Font = fontDialog1.Font;
        //    }
        //}
        
        private void buttonCustomJavaLocation_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openJavaExe = new OpenFileDialog())
            {
                openJavaExe.Filter = "java.exe|java.exe";
                if (openJavaExe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBoxCustomJavaLocation.Text = Program.GetPortablePath(openJavaExe.FileName);
            }

            //OpenFileDialog openJavaExe = new OpenFileDialog()
            //{
            //    Multiselect = false,
            //    Filter = "java.exe|java.exe"
            //};
            //if (openJavaExe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    textBoxCustomJavaLocation.Text = openJavaExe.FileName;
            //}
        }
    }
}
