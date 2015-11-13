using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Java;

namespace APKToolGUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            Program.SetLanguage();
            InitializeComponent();
            this.Icon = Properties.Resources.android_thin;
            this.Text += " - v" + ProductVersion;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            CheckAlignSwitch = !Properties.Settings.Default.MAIN_Zipalign_CheckOnly;
        }

        //private void FormMain_Shown(object sender, EventArgs e)
        //{
        //    this.Update();
        //    if (!JavaSearch.TrySearchJava(ref javaExe))
        //    {
        //        if (MessageBox.Show(Language.DoYouWantToSelectJavaLocation, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            OpenFileDialog openJavaExe = new OpenFileDialog()
        //            {
        //                Multiselect = false,
        //                Filter = "java.exe|java.exe"
        //            };
        //            if (openJavaExe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //            {
        //                Properties.Settings.Default.JavaExe = openJavaExe.FileName;
        //                Properties.Settings.Default.Save();
        //                Application.Restart();
        //            }
        //            else
        //                Application.Exit();
        //        }
        //        else
        //            Application.Exit();
        //    }
        //    ToLog(ApktoolEventType.Information, "Java location: " + javaExe);

        //    InitializeUpdateChecker();
        //    InitializeAPKTool();
        //    InitializeSignApk();
        //    InitializeZipalign();

        //    String javaVersion = apktoolSync.GetJavaVersionSync();
        //    if (javaVersion != null)
        //    {
        //        ToLog(ApktoolEventType.Information, "Java version: " + javaVersion);

        //        string apktoolVersion = apktoolSync.GetVersionSync();

        //        if (apktoolVersion != null)
        //            ToLog(ApktoolEventType.Information, "APKTool version: " + apktoolVersion);
        //    }
        //    else
        //    {
        //        MessageBox.Show(Language.ErrorJavaDetect, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    TimeSpan updateInterval = DateTime.Now - Properties.Settings.Default.LastUpdateCheck;
        //    if (updateInterval.Days > 0 && Properties.Settings.Default.CheckForUpdateAtStartup)
        //        updateCheker.CheckAsync(true);
        //    ToStatus(Language.Done, Properties.Resources.done);
        //}

        private void GetJavaPath()
        {
            if (!File.Exists(Properties.Settings.Default.JavaExe))
            {
                javaExe = JavaUtils.SearchPath();
                if (!File.Exists(javaExe))
                {
                    if (MessageBox.Show(Language.DoYouWantToSelectJavaLocation, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        using (OpenFileDialog openJavaExe = new OpenFileDialog())
                        {
                            openJavaExe.Filter = "java.exe|java.exe";
                            if (openJavaExe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                javaExe = Program.GetPortablePath(openJavaExe.FileName);
                                Properties.Settings.Default.JavaExe = javaExe;
                                Properties.Settings.Default.Save();
                            }
                            else
                                Environment.Exit(0);
                        }
                    }
                    else
                        Environment.Exit(0);
                }
                else
                {
                    Properties.Settings.Default.JavaExe = javaExe;
                    Properties.Settings.Default.Save();
                }
            }

            ToLog(ApktoolEventType.Information, String.Format("Java path \"{0}\"", javaExe/*"Java path: " + javaExe*/));
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Update();
            GetJavaPath();

            InitializeUpdateChecker();
            InitializeAPKTool();
            InitializeSignApk();
            InitializeZipalign();

            Version javaVer = apktool.GetJavaVersion();
            if (javaVer != null)
            {
                ToLog(ApktoolEventType.Information, String.Format("Java version \"{0} Update {1}\"", javaVer.Minor, javaVer.Revision));
                string apktoolVersion = apktool.GetVersion();
                if (!String.IsNullOrWhiteSpace(apktoolVersion))
                    ToLog(ApktoolEventType.Information, String.Format("Apktool version \"{0}\"", apktoolVersion));
                else
                    ToLog(ApktoolEventType.Error, "Can't detect apktool version.");
            }
            else
                MessageBox.Show(Language.ErrorJavaDetect, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            TimeSpan updateInterval = DateTime.Now - Properties.Settings.Default.LastUpdateCheck;
            if (updateInterval.Days > 0 && Properties.Settings.Default.CheckForUpdateAtStartup)
                updateCheker.CheckAsync(true);
            ToStatus(Language.Done, Properties.Resources.done);
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private string javaExe = Properties.Settings.Default.JavaExe;
        Apktool apktool;
        Signapk signapk;
        Zipalign zipalign;
        UpdateChecker updateCheker;

        #region UpdateChecker

        private void InitializeUpdateChecker()
        {
            updateCheker = new UpdateChecker("http://infinum.orgfree.com/_Update/APKToolGUI/version.txt", Version.Parse(Application.ProductVersion));
            updateCheker.Completed += new RunWorkerCompletedEventHandler(updateCheker_Completed);
        }

        private void updateCheker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is UpdateChecker.Result)
            {
                UpdateChecker.Result result = (UpdateChecker.Result)e.Result;
                switch (result.State)
                {
                    case UpdateChecker.State.NeedUpdate:
                        if (MessageBox.Show(Language.UpdateNewVersion, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            Process.Start("http://4pda.ru/forum/index.php?showtopic=452034");
                        break;
                    case UpdateChecker.State.NoUpdate:
                        if (!result.Silently)
                            MessageBox.Show(Language.UpdateNoUpdates, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case UpdateChecker.State.Error:
                        if (!result.Silently)
                            MessageBox.Show("Error update checking:" + Environment.NewLine + result.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                Properties.Settings.Default.LastUpdateCheck = DateTime.Now;
            }
        }

        #endregion

        #region Log&Status

        private void ToStatus(string message, Image statusImage)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                toolStripStatusLabelStateText.Text = message;
                toolStripStatusLabelStateImage.Image = statusImage;
            }));
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
                case ApktoolEventType.Unknown:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Properties.Resources.error, Color.FromKnownColor(KnownColor.LightPink));
                    //ToStatus(result.Message, Properties.Resources.warning);
                    break;
                default:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Properties.Resources.info, Color.FromKnownColor(KnownColor.LightBlue));
                    break;
            }
        }

        private void Done()
        {
            if (statusStrip1.InvokeRequired)
                statusStrip1.BeginInvoke(new Action(delegate { toolStripProgressBar1.Style = ProgressBarStyle.Continuous; }));

            ActionButtonsEnabled = true;

            ToStatus(Language.Done, Properties.Resources.done);
        }

        private void ClearLog()
        {
            if (Properties.Settings.Default.ClearLogBeforeAction)
                dataGridView1.Rows.Clear();
        }

        #endregion

        #region signapk

        private void InitializeSignApk()
        {
            signapk = new Signapk(javaExe, Program.SIGNAPK_PATH);
            signapk.Exited += signapk_SignapkExited;
        }

        void signapk_SignapkExited(object sender, SignapkExitedEventArgs e)
        {
            if (e.ExitCode == 0)
            {
                ToLog(ApktoolEventType.Information, String.Format("Signing successfully completed. File saved to \"{0}\".", e.OutFilePath));
            }
            Done();
        }

        private bool Singning()
        {
            return signapk.Sign(textBox_SIGN_PublicKey.Text, textBox_SIGN_PrivateKey.Text, textBox_SIGN_InputFile.Text, textBox_SIGN_OutputFile.Text);
        }

        #endregion

        #region apktool

        private void InitializeAPKTool()
        {
            apktool = new Apktool(javaExe, Program.APKTOOL_PATH);
            apktool.ApktoolOutputDataRecieved += apktool_ApktoolOutputDataRecieved;
            apktool.ApktoolErrorDataRecieved += apktool_ApktoolErrorDataRecieved;
            apktool.DecompilingCompleted += apktool_DecompilingCompleted;
            apktool.BuildCompleted += apktool_BuildCompleted;
            apktool.InstallFrameworkCompleted += apktool_InstallFrameworkCompleted;
        }

        void apktool_InstallFrameworkCompleted(object sender, ApktoolEventCompletedEventArgs e)
        {
            Done();
        }

        void apktool_BuildCompleted(object sender, ApktoolEventCompletedEventArgs e)
        {
            Done();
        }

        void apktool_DecompilingCompleted(object sender, ApktoolEventCompletedEventArgs e)
        {
            if (e.ExitCode == 0)
            {
                ToLog(ApktoolEventType.Information, String.Format("Decompiling successfully completed. Output directory \"{0}\".", e.ProjectDir));
            }
            Done();
        }

        void apktool_ApktoolErrorDataRecieved(object sender, ApktoolDataReceivedEventArgs e)
        {
            if (e.EventType == ApktoolEventType.Unknown)
                ToLog(ApktoolEventType.Error, e.Message);
            else
                ToLog(e.EventType, e.Message);
        }

        void apktool_ApktoolOutputDataRecieved(object sender, ApktoolDataReceivedEventArgs e)
        {
            ToLog(e.EventType, e.Message);
        }

        private bool InstallFramework()
        {
            InstallFrameworkOptions options = new InstallFrameworkOptions(textBox_IF_InputFramePath.Text);
            if (checkBox_IF_FramePath.Checked)
                options.FrameDir = textBox_IF_FrameDir.Text;
            if (checkBox_IF_Tag.Checked)
                options.Tag = textBox_IF_Tag.Text;

            return apktool.InstallFramework(options);
        }

        private bool Decompiling()
        {
            //string projectDir = Path.GetDirectoryName(textBox_DECODE_InputAppPath.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(textBox_DECODE_InputAppPath.Text);

            DecompileOptions options = new DecompileOptions(textBox_DECODE_InputAppPath.Text);
            options.NoSource = checkBox_DECODE_NoSrc.Checked;
            options.NoResource = checkBox_DECODE_NoRes.Checked;
            options.Force = checkBox_DECODE_Force.Checked;
            options.KeepBrokenResource = checkBox_DECODE_KeepBrokenRes.Checked;
            options.MatchOriginal = checkBox_DECODE_MatchOriginal.Checked;
            if (checkBox_DECODE_UseFramework.Checked)
                options.FrameworkPath = textBox_DECODE_FrameDir.Text;
            if (checkBox_DECODE_OutputDirectory.Checked)
                options.OutputDirectory = textBox_DECODE_OutputDirectory.Text;

            return apktool.Decompile(options);
        }

        private bool Build()
        {
            //String outputAPK = textBox_BUILD_InputProjectDir.Text + DateTime.Now.ToString("_yyyyMMdd_HH-mm-ss") + ".apk";

            BuildOptions options = new BuildOptions(textBox_BUILD_InputProjectDir.Text);
            options.ForceAll = checkBox_BUILD_ForceAll.Checked;
            options.CopyOriginal = checkBox_BUILD_CopyOriginal.Checked;
            if (checkBox_BUILD_UseAapt.Checked)
                options.AaptPath = textBox_BUILD_AaptPath.Text;
            if (checkBox_BUILD_UseFramework.Checked)
                options.FrameworkPath = textBox_BUILD_FrameDir.Text;
            if (checkBox_BUILD_OutputAppPath.Checked)
                options.AppPath = textBox_BUILD_OutputAppPath.Text;

            return apktool.Build(options);
        }

        #endregion

        #region zipalign

        private void InitializeZipalign()
        {
            zipalign = new Zipalign(Program.ZIPALIGN_PATH);
            zipalign.OutputDataReceived += zipalign_OutputDataReceived;
            zipalign.ErrorDataReceived += zipalign_ErrorDataReceived;
            zipalign.Exited += zipalign_Exited;
        }

        void zipalign_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.Data))
                ToLog(ApktoolEventType.Information, e.Data);
        }

        void zipalign_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.Data))
                ToLog(ApktoolEventType.Error, e.Data);
        }

        void zipalign_Exited(object sender, EventArgs e)
        {
            Zipalign za = (Zipalign)sender;
            if (za.ExitCode == 0)
                ToLog(ApktoolEventType.Information, "File saved to " + za.Options.OutputFile);
            else
                ToLog(ApktoolEventType.Warning, "Exit code: " + za.ExitCode);
            Done();
            //ActionButtonsEnabled = true;
        }

        private bool Align()
        {
            ZipalignOptions options = new ZipalignOptions(textBox_ZIPALIGN_InputFile.Text, Convert.ToInt32(numericUpDown_ZIPALIGN_AlignmentBytes.Value));
            options.CheckOnly = checkBox_ZIPALIGN_CheckAlignment.Checked;
            options.OverwriteOutputFile = checkBox_ZIPALIGN_OverwriteOutputFile.Checked;
            options.Recompress = checkBox_ZIPALIGN_Recompress.Checked;
            options.VerboseOut = checkBox_ZIPALIGN_VerboseOutput.Checked;
            options.OutputFile = textBox_ZIPALIGN_OutputFile.Text;

            return zipalign.Align(options);
        }

        //void zipalign_ZipalignExited(object sender, ZipalignExitedEventArgs e)
        //{
        //    ToLog_Done();
        //}

        //private void ZipAlign(string inputFilePath)
        //{
        //    string outputFile = Path.GetDirectoryName(inputFilePath) + @"\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_zipaligned.apk";
        //    zipalign.Align(inputFilePath, outputFile, 4, true, false, false);
        //}

        #endregion

        private bool ActionButtonsEnabled
        {
            set
            {
                if (button_BUILD_Build.InvokeRequired)
                    button_BUILD_Build.BeginInvoke(new Action(delegate
                    {
                        button_BUILD_Build.Enabled = value;
                    }));
                else
                    button_BUILD_Build.Enabled = value;

                if (button_DECODE_Decode.InvokeRequired)
                    button_DECODE_Decode.BeginInvoke(new Action(delegate
                    {
                        button_DECODE_Decode.Enabled = value;
                    }));
                else
                    button_DECODE_Decode.Enabled = value;

                if (button_IF_InstallFramework.InvokeRequired)
                    button_IF_InstallFramework.BeginInvoke(new Action(delegate
                    {
                        button_IF_InstallFramework.Enabled = value;
                    }));
                else
                    button_IF_InstallFramework.Enabled = value;
                if (button_ZIPALIGN_Align.InvokeRequired)
                    button_ZIPALIGN_Align.BeginInvoke(new Action(delegate
                    {
                        button_ZIPALIGN_Align.Enabled = value;
                    }));
                else
                    button_ZIPALIGN_Align.Enabled = value;
            }
        }

        private void ShowMessage(string message, MessageBoxIcon status)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, status);
        }

        private bool IsValidPath(string path)
        {
            try
            {
                Path.GetFileName(path);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;

            //if (path.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
            //    return false;
            //else
            //    return true;
        }



        #region Main menu event handlers

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings();
            frm.ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemCheckUpdate_Click(object sender, EventArgs e)
        {
            updateCheker.CheckAsync();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            FormAboutBox frm = new FormAboutBox();
            frm.ShowDialog();
        }

        #endregion

        #region Control event handlers

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        #region DECODE

        private void button_DECODE_BrowseFrameDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (!String.IsNullOrWhiteSpace(textBox_DECODE_FrameDir.Text))
                    fbd.SelectedPath = textBox_DECODE_FrameDir.Text;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_DECODE_FrameDir.Text = fbd.SelectedPath;
            }
        }

        private void button_DECODE_BrowseOutputDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {

                if (!String.IsNullOrWhiteSpace(textBox_DECODE_OutputDirectory.Text))
                    fbd.SelectedPath = textBox_DECODE_OutputDirectory.Text;
                else
                    if (!String.IsNullOrWhiteSpace(textBox_DECODE_InputAppPath.Text))
                        fbd.SelectedPath = Path.GetDirectoryName(textBox_DECODE_InputAppPath.Text);
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_DECODE_OutputDirectory.Text = fbd.SelectedPath;
            }
        }

        private void button_DECODE_BrowseInputAppPath_Click(object sender, EventArgs e)
        {
            if (openFileDialogApk.ShowDialog() == DialogResult.OK)
            {
                textBox_DECODE_InputAppPath.Text = openFileDialogApk.FileName;
                //textBox_BUILD_InputProjectDir.Text = Path.GetDirectoryName(textBox_DECODE_InputAppPath.Text) + @"\" + Path.GetFileNameWithoutExtension(textBox_DECODE_InputAppPath.Text);
                if (checkBox_DECODE_OutputDirectory.Checked)
                    textBox_DECODE_OutputDirectory.Text = Path.GetDirectoryName(textBox_DECODE_InputAppPath.Text) + "\\" + System.IO.Path.GetFileNameWithoutExtension(textBox_DECODE_InputAppPath.Text);
            }
            else
                return;
        }

        private void button_DECODE_Decode_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox_DECODE_InputAppPath.Text))
            {
                if (checkBox_DECODE_UseFramework.Checked && !Directory.Exists(textBox_DECODE_FrameDir.Text))
                {
                    ShowMessage("Выбранный каталог фреймворков не существует.", MessageBoxIcon.Warning);
                    return;
                }
                if (checkBox_DECODE_OutputDirectory.Checked)
                {
                    if (String.IsNullOrWhiteSpace(textBox_DECODE_OutputDirectory.Text))
                    {
                        ShowMessage("Не выбран каталог декомпиляции.", MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        if (!IsValidPath(textBox_DECODE_OutputDirectory.Text))
                        {
                            ShowMessage("Выбранный каталог декомпиляции не может быть создан, т.к. содержит недопустимые символы.", MessageBoxIcon.Warning);
                            return;
                        }
                }
                bool started = Decompiling();
                if (started)
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    ClearLog();
                    ToLog(ApktoolEventType.Information, "Decoding " + Path.GetFileName(textBox_DECODE_InputAppPath.Text));
                    ToStatus(String.Format("Decoding \"{0}\"...", Path.GetFileName(textBox_DECODE_InputAppPath.Text)), Properties.Resources.waiting);
                    ActionButtonsEnabled = false;
                }
                else
                    ToLog(ApktoolEventType.Error, "Error. Decoding is not started.");
            }
            else
                MessageBox.Show(Language.WarningFileForDecodingNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region BUILD

        private void button_BUILD_BrowseAaptPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executable file|*.exe";
                if (!String.IsNullOrWhiteSpace(textBox_BUILD_AaptPath.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(textBox_BUILD_AaptPath.Text);
                    ofd.FileName = Path.GetFileName(textBox_BUILD_AaptPath.Text);
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_BUILD_AaptPath.Text = ofd.FileName;
            }
        }

        private void button_BUILD_BrowseFrameDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (!String.IsNullOrWhiteSpace(textBox_BUILD_FrameDir.Text))
                    fbd.SelectedPath = textBox_BUILD_FrameDir.Text;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_BUILD_FrameDir.Text = fbd.SelectedPath;
            }
        }

        private void button_BUILD_BrowseOutputAppPath_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (!String.IsNullOrWhiteSpace(textBox_BUILD_OutputAppPath.Text))
                {
                    sfd.InitialDirectory = Path.GetDirectoryName(textBox_BUILD_OutputAppPath.Text);
                    sfd.FileName = Path.GetFileNameWithoutExtension(textBox_BUILD_OutputAppPath.Text);
                    sfd.DefaultExt = Path.GetExtension(textBox_BUILD_OutputAppPath.Text);
                }

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_BUILD_OutputAppPath.Text = sfd.FileName;
            }
        }

        private void button_BUILD_BrowseInputProjectDir_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_BUILD_InputProjectDir.Text))
                folderBrowserDialogBuild.SelectedPath = textBox_BUILD_InputProjectDir.Text;
            if (folderBrowserDialogBuild.ShowDialog() == DialogResult.OK)
            {
                textBox_BUILD_InputProjectDir.Text = folderBrowserDialogBuild.SelectedPath;
                if (checkBox_BUILD_OutputAppPath.Checked)
                    textBox_BUILD_OutputAppPath.Text = textBox_BUILD_InputProjectDir.Text + DateTime.Now.ToString("_yyyyMMdd_HH-mm-ss") + ".apk";
                //String outputAPK = textBox_BUILD_InputProjectDir.Text + DateTime.Now.ToString("_yyyyMMdd_HH-mm-ss") + ".apk";
            }
        }

        private void button_BUILD_Build_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_BUILD_InputProjectDir.Text))
            {
                bool started = Build();
                if (started)
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    ActionButtonsEnabled = false;
                    ClearLog();
                    ToLog(ApktoolEventType.Information, "Build " + Path.GetFileName(textBox_BUILD_InputProjectDir.Text));
                    ToStatus(String.Format("Build \"{0}\"...", textBox_BUILD_InputProjectDir.Text.Replace(Path.GetDirectoryName(textBox_BUILD_InputProjectDir.Text) + @"\", String.Empty)), Properties.Resources.waiting);
                }
                else
                    ToLog(ApktoolEventType.Error, "Error. Build is not started.");
            }
            else
                MessageBox.Show(Language.WarningDecodingFolderNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region INSTALL FRAMEWORK

        private void button_IF_BrowseFrameDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (Directory.Exists(textBox_IF_FrameDir.Text))
                    fbd.SelectedPath = textBox_IF_FrameDir.Text;
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_IF_FrameDir.Text = fbd.SelectedPath;
            }
        }

        private void button_IF_BrowseInputFramePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (File.Exists(textBox_IF_InputFramePath.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(textBox_IF_InputFramePath.Text);
                    ofd.FileName = Path.GetFileNameWithoutExtension(textBox_IF_InputFramePath.Text);
                }
                ofd.Filter = "apk|*.apk|jar|*.jar";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_IF_InputFramePath.Text = ofd.FileName;
            }
        }

        private void button_IF_InstallFramework_Click(object sender, EventArgs e)
        {
            if (checkBox_IF_FramePath.Checked)
            {
                if (String.IsNullOrWhiteSpace(textBox_IF_FrameDir.Text) || !Directory.Exists(textBox_IF_FrameDir.Text))
                {
                    ShowMessage("Ошибка выбора директории фреймворка.", MessageBoxIcon.Warning);
                    return;
                }
            }
            if (checkBox_IF_Tag.Checked && String.IsNullOrWhiteSpace(textBox_IF_Tag.Text))
            {
                ShowMessage("Ошибка ввода тега фреймворка.", MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(textBox_IF_InputFramePath.Text))
            {
                ShowMessage("Ошибка выбора файла фреймворка. Файл не существует.", MessageBoxIcon.Warning);
                return;
            }

            bool started = InstallFramework();
            if (started)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                ActionButtonsEnabled = false;
                ClearLog();
                ToLog(ApktoolEventType.Information, "Installing framework " + Path.GetFileName(textBox_IF_InputFramePath.Text));
                ToStatus(String.Format("Installing framework \"{0}\"...", Path.GetFileName(textBox_IF_InputFramePath.Text)), Properties.Resources.waiting);
            }
            else
                ToLog(ApktoolEventType.Error, "Error. Framework installation is not started.");

        }

        #endregion

        #region SIGN

        private void button_SIGN_BrowsePublicKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.pem|*.pem";
                if (File.Exists(textBox_SIGN_PublicKey.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(textBox_SIGN_PublicKey.Text);
                    ofd.FileName = Path.GetFileNameWithoutExtension(textBox_SIGN_PublicKey.Text);
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_SIGN_PublicKey.Text = Program.GetPortablePath(ofd.FileName);
            }
        }

        private void button_SIGN_BrowsePrivateKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.pk8|*.pk8";
                if (File.Exists(textBox_SIGN_PrivateKey.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(textBox_SIGN_PrivateKey.Text);
                    ofd.FileName = Path.GetFileNameWithoutExtension(textBox_SIGN_PrivateKey.Text);
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_SIGN_PrivateKey.Text = Program.GetPortablePath(ofd.FileName);
            }
        }

        private void button_SIGN_BrowseOutputFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "(*.apk)|*.apk|(*.jar)|*.jar|(*.zip)|*.zip";

                if (File.Exists(textBox_SIGN_InputFile.Text))
                {
                    sfd.Filter = String.Format("(*{0})|*{0}", Path.GetExtension(textBox_SIGN_InputFile.Text));
                    sfd.InitialDirectory = Path.GetDirectoryName(textBox_SIGN_InputFile.Text);
                    sfd.FileName = String.Format("{0}_signed{1}", Path.GetFileNameWithoutExtension(textBox_SIGN_InputFile.Text), Path.GetExtension(textBox_SIGN_InputFile.Text));
                }

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox_SIGN_OutputFile.Text = sfd.FileName;
                }
            }
        }

        private void button_SIGN_BrowseInputFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "(*.apk;*.jar;*.zip)|*.apk;*.jar;*.zip";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox_SIGN_InputFile.Text = ofd.FileName;
                    textBox_SIGN_OutputFile.Text =
                        String.Format("{0}{1}{2}_signed{3}",
                        Path.GetDirectoryName(textBox_SIGN_InputFile.Text),
                        Path.DirectorySeparatorChar,
                        Path.GetFileNameWithoutExtension(textBox_SIGN_InputFile.Text),
                        Path.GetExtension(textBox_SIGN_InputFile.Text));
                }
            }
        }

        private void button_SIGN_Sign_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_SIGN_PublicKey.Text))
            {
                ShowMessage("Public key not found.", MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(textBox_SIGN_PrivateKey.Text))
            {
                ShowMessage("Private key not found.", MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(textBox_SIGN_InputFile.Text))
            {
                ShowMessage("Input file not found.", MessageBoxIcon.Warning);
                return;
            }

            bool started = Singning();
            if (started)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                ActionButtonsEnabled = false;
                ClearLog();
                ToLog(ApktoolEventType.Information, "Signing " + Path.GetFileName(textBox_SIGN_InputFile.Text));
                ToStatus(String.Format("Signing \"{0}\"...", Path.GetFileName(textBox_SIGN_InputFile.Text)), Properties.Resources.waiting);
            }
            else
                ToLog(ApktoolEventType.Error, "Error. Signing is not started.");
        }

        #endregion

        #region ZIPALIGN

        private bool CheckAlignSwitch
        {
            set
            {
                checkBox_ZIPALIGN_Recompress.Enabled = value;
                checkBox_ZIPALIGN_OverwriteOutputFile.Enabled = value;
                tableLayoutPanel_ZIPALIGN_OutputFile.Enabled = value;
            }
        }

        private void checkBox_ZIPALIGN_CheckAlignment_CheckedChanged(object sender, EventArgs e)
        {
            CheckAlignSwitch = !checkBox_ZIPALIGN_CheckAlignment.Checked;
        }

        private void button_ZIPALIGN_BrowseOutputFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (File.Exists(textBox_ZIPALIGN_InputFile.Text))
                {
                    sfd.InitialDirectory = Path.GetDirectoryName(textBox_ZIPALIGN_InputFile.Text);
                    sfd.Filter = String.Format("{0}|*.{0}", Path.GetExtension(textBox_ZIPALIGN_InputFile.Text).Replace(".", String.Empty));
                    sfd.FileName = String.Format("{0}_zipaligned", Path.GetFileNameWithoutExtension(textBox_ZIPALIGN_InputFile.Text));
                }
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBox_ZIPALIGN_OutputFile.Text = sfd.FileName;
            }
        }

        private void button_ZIPALIGN_BrowseInputFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "ZIP archives(*.apk;*.zip;*.jar)|*.apk;*.zip;*.jar";
                if (File.Exists(textBox_ZIPALIGN_InputFile.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(textBox_ZIPALIGN_InputFile.Text);
                    ofd.FileName = Path.GetFileName(textBox_ZIPALIGN_InputFile.Text);
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox_ZIPALIGN_InputFile.Text = ofd.FileName;
                    if (!checkBox_ZIPALIGN_CheckAlignment.Checked)
                        textBox_ZIPALIGN_OutputFile.Text = String.Format("{0}\\{1}_zipaligned{2}",
                            Path.GetDirectoryName(ofd.FileName),
                            Path.GetFileNameWithoutExtension(ofd.FileName),
                            Path.GetExtension(ofd.FileName));
                }
            }
        }

        private void button_ZIPALIGN_Align_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_ZIPALIGN_InputFile.Text))
            {
                ShowMessage("Ошибка. Выбранный файл не существует.", MessageBoxIcon.Warning);
                return;
            }

            bool started = Align();
            if (started)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                ActionButtonsEnabled = false;
                ClearLog();
                ToLog(ApktoolEventType.Information, "Aligning " + Path.GetFileName(textBox_ZIPALIGN_InputFile.Text));
                ToStatus(String.Format("Aligning \"{0}\"...", Path.GetFileName(textBox_ZIPALIGN_InputFile.Text)), Properties.Resources.waiting);
            }
            else
                ToLog(ApktoolEventType.Error, "Error. Aligning is not started.");
        }

        #endregion

        #endregion
    }
}