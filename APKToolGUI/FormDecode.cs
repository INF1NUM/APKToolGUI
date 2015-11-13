using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APKToolGUI
{
    public partial class FormDecode : Form
    {
        public FormDecode(string[] args)
        {
            Program.SetLanguage();
            InitializeComponent();
            this.Icon = Properties.Resources.android_thin;
            this.Text = Application.ProductName;

            textBoxOutputProjectDir.Multiline = true;
            textBoxOutputProjectDir.MinimumSize = new Size(textBoxOutputProjectDir.Size.Width, textBoxOutputProjectDir.Size.Height);
            textBoxOutputProjectDir.Size = new Size(textBoxOutputProjectDir.Size.Width, textBoxOutputProjectDir.Size.Height);
            textBoxOutputProjectDir.Multiline = false;

            this.apkPath = args[1];
        }

        private string apkPath;
        private Apktool apktool;
        private Apktool apktoolSync;
        bool StartButtonEnabled
        {
            set
            {
                if (buttonStart.InvokeRequired)
                    buttonStart.BeginInvoke(new Action(() =>
                    {
                        buttonStart.Enabled = value;
                    }));
                else
                    buttonStart.Enabled = value;
            }
        }
        ProgressBarStyle progressBarStyle
        {
            set
            {
                if (toolStripProgressBar1.GetCurrentParent().InvokeRequired)
                {
                    toolStripProgressBar1.GetCurrentParent().BeginInvoke(new Action(() =>
                    {
                        toolStripProgressBar1.Style = value;
                    }));
                }
                else
                    toolStripProgressBar1.Style = value;
            }
        }

        private void ToLog(string time, string message, Image statusImage, Color backColor)
        {
            if (dataGridView1.InvokeRequired)
                dataGridView1.BeginInvoke(new Action(() =>
                {
                    int i = dataGridView1.Rows.Add(statusImage, time, message);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = backColor;
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                }));
            else
            {
                int i = dataGridView1.Rows.Add(statusImage, time, message);
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = backColor;
                dataGridView1.FirstDisplayedScrollingRowIndex = i;
            }
        }

        private void ToLog(ApktoolEventType eventType, String message)
        {
            switch (eventType)
            {
                case ApktoolEventType.Information:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Properties.Resources.info, Color.FromKnownColor(KnownColor.Window));
                    //ToStatus(result.Message, Properties.Resources.info);
                    break;
                case ApktoolEventType.Error:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Properties.Resources.error, Color.FromKnownColor(KnownColor.LightPink));
                    //ToStatus(result.Message, Properties.Resources.error);
                    break;
                case ApktoolEventType.Warning:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Properties.Resources.warning, Color.FromKnownColor(KnownColor.LightYellow));
                    //ToStatus(result.Message, Properties.Resources.warning);
                    break;
                default:
                    break;
            }
        }

        #region Form event handlers

        private void FormDecompile_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.JavaExe))
            {
                MessageBox.Show("Java location is not specified in the settings. Please, configure program first.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (!System.IO.File.Exists(Program.APKTOOL_PATH))
            {
                MessageBox.Show(String.Format("Apktool not fount in '{0}'.", Program.APKTOOL_PATH), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            //apktoolSync = new Apktool(Properties.Settings.Default.JavaExe, Program.APKTOOL_PATH);
            apktool = new Apktool(Properties.Settings.Default.JavaExe, Program.APKTOOL_PATH);
            apktool.ApktoolOutputDataRecieved += apktool_ApktoolOutputDataRecieved;
            apktool.ApktoolErrorDataRecieved += apktool_ApktoolErrorDataRecieved;
            apktool.DecompilingCompleted += apktool_DecompilingCompleted;
        }

        private void FormDecompile_Shown(object sender, EventArgs e)
        {
            this.Update();

            textBoxOutputProjectDir.Text = System.IO.Path.GetDirectoryName(apkPath) + "\\" + System.IO.Path.GetFileNameWithoutExtension(apkPath);

            Version javaVersion = apktool.GetJavaVersion();
            if (javaVersion != null)
            {
                ToLog(ApktoolEventType.Information, String.Format("Java version \"{0} Update {1}\"", javaVersion.Minor, javaVersion.Revision));
                string apktoolVersion = apktool.GetVersion();
                if (!String.IsNullOrWhiteSpace(apktoolVersion))
                    ToLog(ApktoolEventType.Information, String.Format("Apktool version \"{0}\"", apktoolVersion));
                else
                    ToLog(ApktoolEventType.Error, "Can't detect apktool version.");
            }
            else
                MessageBox.Show(Language.ErrorJavaDetect, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormDecompile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        #endregion

        #region apktool event handlers

        void apktool_ApktoolOutputDataRecieved(object sender, ApktoolDataReceivedEventArgs e)
        {
            ToLog(e.EventType, e.Message);
        }

        void apktool_ApktoolErrorDataRecieved(object sender, ApktoolDataReceivedEventArgs e)
        {
            ToLog(e.EventType, e.Message);
        }

        void apktool_DecompilingCompleted(object sender, ApktoolEventCompletedEventArgs e)
        {
            if (e.ExitCode == 0)
                ToLog(ApktoolEventType.Information, "Декомпиляция успешно завршена.");
            else
                ToLog(ApktoolEventType.Warning, String.Format("Внимание! При декомпиляции приложения произошла ошибка. Код выхода: '{0}'.", e.ExitCode));
            StartButtonEnabled = true;
            progressBarStyle = ProgressBarStyle.Continuous;
        }

        #endregion

        private void buttonFramePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogFrameworks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxFrameworkPath.Text = folderBrowserDialogFrameworks.SelectedPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DecompileOptions options = new DecompileOptions(apkPath);
            options.NoResource = checkBoxNoRes.Checked;
            options.NoSource = checkBoxNoSrc.Checked;
            options.Force = checkBoxForce.Checked;
            options.KeepBrokenResource = checkBoxKeepBrokenResource.Checked;
            options.MatchOriginal = checkBoxMatchOriginal.Checked;
            if (checkBoxFrameworkPath.Checked)
            {
                if (System.IO.Directory.Exists(textBoxFrameworkPath.Text))
                    options.FrameworkPath = textBoxFrameworkPath.Text;
                else
                {
                    MessageBox.Show("Указанной директорию расположения фреймворков не существует.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            options.OutputDirectory = textBoxOutputProjectDir.Text;

            bool started = false;
#if !DEBUG 
            try
                {
#endif
            started = apktool.Decompile(options);
#if !DEBUG
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#endif
            if (started)
            {
                progressBarStyle = ProgressBarStyle.Marquee;
                StartButtonEnabled = false;
            }
        }

        private void buttonBrowseOutputProjectDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialogProjectDir.SelectedPath = System.IO.Path.GetDirectoryName(apkPath);
            if (folderBrowserDialogProjectDir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxOutputProjectDir.Text = folderBrowserDialogProjectDir.SelectedPath;
        }
    }
}