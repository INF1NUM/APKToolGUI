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
    public partial class FormBuild : Form
    {
        public FormBuild(string[] args)
        {
            Program.SetLanguage();
            InitializeComponent();
            this.Icon = Properties.Resources.android_thin;
            this.Text = Application.ProductName;
            projectDir = args[1];
        }

        private string projectDir;
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

        private void FormBuild_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.JavaExe))
            {
                MessageBox.Show("Java location is not specified in the settings. Please, configure program first.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            if (!System.IO.File.Exists(Program.APKTOOL_PATH))
            {
                MessageBox.Show(String.Format("apktool не найден в каталоге назначения '{0}'.", Program.APKTOOL_PATH), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            apktoolSync = new Apktool(Properties.Settings.Default.JavaExe, Program.APKTOOL_PATH);
            apktool = new Apktool(Properties.Settings.Default.JavaExe, Program.APKTOOL_PATH);
            apktool.ApktoolOutputDataRecieved += apktool_ApktoolOutputDataRecieved;
            apktool.ApktoolErrorDataRecieved += apktool_ApktoolErrorDataRecieved;
            apktool.BuildCompleted += apktool_BuildCompleted;
        }

        private void FormBuild_Shown(object sender, EventArgs e)
        {
            this.Update();

            textBoxOutputApkPath.Text = String.Format("{0}\\{1}_{2}.apk", System.IO.Path.GetDirectoryName(projectDir), projectDir.Replace(System.IO.Path.GetDirectoryName(projectDir) + "\\", String.Empty), DateTime.Now.ToString("yyyyMMdd_HH-mm-ss"), System.IO.Path.GetExtension(projectDir));

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

        private void FormBuild_FormClosed(object sender, FormClosedEventArgs e)
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

        void apktool_BuildCompleted(object sender, ApktoolEventCompletedEventArgs e)
        {
            if (e.ExitCode == 0)
                ToLog(ApktoolEventType.Information, "Сборка успешно завршена.");
            else
                ToLog(ApktoolEventType.Warning, String.Format("Внимание! При сборке приложения произошла ошибка. Код выхода: '{0}'.", e.ExitCode));
            StartButtonEnabled = true;
            progressBarStyle = ProgressBarStyle.Continuous;
        }
        #endregion

        private void buttonBsowseAaptPath_Click(object sender, EventArgs e)
        {
            if (openFileDialogBrowseAapt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxAaptPath.Text = openFileDialogBrowseAapt.FileName;
        }

        private void buttonBrowseFrameworkPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogFrameworks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxFrameworkPath.Text = folderBrowserDialogFrameworks.SelectedPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            BuildOptions options = new BuildOptions(projectDir);
            options.ForceAll = checkBoxForceAll.Checked;
            options.CopyOriginal = checkBoxCopyOriginal.Checked;
            if (checkBoxCustomAapt.Checked)
            {
                if (System.IO.File.Exists(textBoxAaptPath.Text))
                    options.AaptPath = textBoxAaptPath.Text;
                else
                {
                    MessageBox.Show("Указанного файла aapt не существует.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (checkBoxUseFramework.Checked)
                options.FrameworkPath = textBoxFrameworkPath.Text;
            options.AppPath = textBoxOutputApkPath.Text;

            bool started = false;
#if !DEBUG 
            try
                {
#endif
            started = apktool.Build(options);
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

        private void buttonBrowseOutputApk_Click(object sender, EventArgs e)
        {
            saveFileDialogApk.InitialDirectory = System.IO.Path.GetDirectoryName(projectDir);
            string foldername = projectDir.Replace(System.IO.Path.GetDirectoryName(projectDir) + "\\", String.Empty);
            saveFileDialogApk.FileName = String.Format("{0}_{1}", foldername, DateTime.Now.ToString("yyyyMMdd_HH-mm-ss"));
            if (saveFileDialogApk.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxOutputApkPath.Text = saveFileDialogApk.FileName;
        }
    }
}
