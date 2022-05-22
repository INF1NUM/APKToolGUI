using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Java;
using APKToolGUI.Languages;
using APKToolGUI.Properties;
using APKToolGUI.ApkTool;
using APKToolGUI.Utils;
using System.Threading.Tasks;
using System.Collections.Generic;
using APKToolGUI.Handlers;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Media;

namespace APKToolGUI
{
    public partial class FormMain : Form
    {
        internal Apktool apktool;
        internal Signapk signapk;
        internal Baksmali baksmali;
        internal Smali smali;
        internal Zipalign zipalign;
        internal UpdateChecker updateCheker;
        internal AaptParser aapt;

        private DecodeControlEventHandlers decodeHandlers;
        private BuildControlEventHandlers buildHandlers;
        private SignControlEventHandlers signHandlers;
        private ZipalignControlEventHandlers zipalignHandlers;
        private FrameworkControlEventHandlers frameworkHandlers;
        private BaksmaliControlEventHandlers baksmaliHandlers;
        private SmaliControlEventHandlers smaliHandlers;
        private DragDropHandlers dragDropHandlers;

        private bool IgnoreOutputDirContextMenu;
        private bool isRunning;

        private Stopwatch stopwatch;
        private string lastStartedDate;

        public FormMain()
        {
            Program.SetLanguage();
            InitializeComponent();
            this.Text += " - v" + ProductVersion;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            if (!File.Exists(Settings.Default.Decode_InputAppPath))
                Settings.Default.Decode_InputAppPath = "";
            if (!Directory.Exists(Settings.Default.Build_InputDir))
                Settings.Default.Build_InputDir = "";
            if (!File.Exists(Settings.Default.Sign_InputFile))
                Settings.Default.Sign_InputFile = "";
            if (!File.Exists(Settings.Default.Zipalign_InputFile))
                Settings.Default.Zipalign_InputFile = "";

            if (!File.Exists(Settings.Default.Sign_PrivateKey) || String.IsNullOrEmpty(Settings.Default.Sign_PrivateKey))
                Settings.Default.Sign_PrivateKey = Program.SIGNAPK_KEYPRIVATE;
            if (!File.Exists(Settings.Default.Sign_PublicKey) || String.IsNullOrEmpty(Settings.Default.Sign_PublicKey))
                Settings.Default.Sign_PublicKey = Program.SIGNAPK_KEYPUBLIC;

            psLinkBtn.Image = new Bitmap(Resources.playstore, new Size(psLinkBtn.Height - 7, psLinkBtn.Height - 7));
            apkComboLinkBtn.Image = new Bitmap(Resources.apkcombo, new Size(apkComboLinkBtn.Height - 7, apkComboLinkBtn.Height - 7));
            apkPureLinkBtn.Image = new Bitmap(Resources.apkpure, new Size(apkPureLinkBtn.Height - 7, apkPureLinkBtn.Height - 7));
            apkAioLinkBtn.Image = new Bitmap(Resources.apkaio, new Size(apkAioLinkBtn.Height - 7, apkAioLinkBtn.Height - 7));

            int v1 = (schemev1ComboBox.Items.Count + 1 > Settings.Default.Sign_Schemev1) ? Settings.Default.Sign_Schemev1 : 0;
            schemev1ComboBox.SelectedIndex = v1;
            Settings.Default.Sign_Schemev1 = v1;

            int v2 = (schemev2ComboBox.Items.Count + 1 > Settings.Default.Sign_Schemev2) ? Settings.Default.Sign_Schemev2 : 0;
            schemev2ComboBox.SelectedIndex = v2;
            Settings.Default.Sign_Schemev2 = v2;

            int v3 = (schemev3ComboBox.Items.Count + 1 > Settings.Default.Sign_Schemev3) ? Settings.Default.Sign_Schemev3 : 0;
            schemev3ComboBox.SelectedIndex = v3;
            Settings.Default.Sign_Schemev3 = v3;

            int v4 = (schemev4ComboBox.Items.Count + 1 > Settings.Default.Sign_Schemev4) ? Settings.Default.Sign_Schemev4 : 2;
            schemev4ComboBox.SelectedIndex = v4;
            Settings.Default.Sign_Schemev4 = v4;

            decodeHandlers = new DecodeControlEventHandlers(this);
            

            buildHandlers = new BuildControlEventHandlers(this);
            button_BUILD_BrowseAaptPath.Click += buildHandlers.button_BUILD_BrowseAaptPath_Click;
            button_BUILD_BrowseFrameDir.Click += buildHandlers.button_BUILD_BrowseFrameDir_Click;
            button_BUILD_BrowseOutputAppPath.Click += buildHandlers.button_BUILD_BrowseOutputAppPath_Click;
            button_BUILD_BrowseInputProjectDir.Click += buildHandlers.button_BUILD_BrowseInputProjectDir_Click;
            button_BUILD_Build.Click += buildHandlers.button_BUILD_Build_Click;
            comApkOpenDir.Click += buildHandlers.comApkOpenDir_Click;

            signHandlers = new SignControlEventHandlers(this);
            button_SIGN_BrowsePublicKey.Click += signHandlers.button_SIGN_BrowsePublicKey_Click;
            button_SIGN_BrowsePrivateKey.Click += signHandlers.button_SIGN_BrowsePrivateKey_Click;
            button_SIGN_BrowsePrivateKey.Click += signHandlers.button_SIGN_BrowsePrivateKey_Click;
            button_SIGN_BrowseInputFile.Click += signHandlers.button_SIGN_BrowseInputFile_Click;
            button_SIGN_BrowseOutputFile.Click += signHandlers.button_SIGN_BrowseOutputFile_Click;
            button_SIGN_Sign.Click += signHandlers.button_SIGN_Sign_Click;
            selectKeyStoreFileBtn.Click += signHandlers.selectKeyStoreFileBtn_Click;
            signApkOpenDirBtn.Click += signHandlers.signApkOpenDirBtn_Click;

            zipalignHandlers = new ZipalignControlEventHandlers(this);
            checkBox_ZIPALIGN_CheckAlignment.Click += zipalignHandlers.checkBox_ZIPALIGN_CheckAlignment_CheckedChanged;
            button_ZIPALIGN_BrowseOutputFile.Click += zipalignHandlers.button_ZIPALIGN_BrowseOutputFile_Click;
            button_ZIPALIGN_BrowseInputFile.Click += zipalignHandlers.button_ZIPALIGN_BrowseInputFile_Click;
            button_ZIPALIGN_Align.Click += zipalignHandlers.button_ZIPALIGN_Align_Click;
            alignApkOpenDirBtn.Click += zipalignHandlers.alignApkOpenDirBtn_Click;

            frameworkHandlers = new FrameworkControlEventHandlers(this);
            button_IF_BrowseFrameDir.Click += frameworkHandlers.button_IF_BrowseFrameDir_Click;
            button_IF_BrowseInputFramePath.Click += frameworkHandlers.button_IF_BrowseInputFramePath_Click;
            button_IF_InstallFramework.Click += frameworkHandlers.button_IF_InstallFramework_Click;
            clearFwBtn.Click += frameworkHandlers.clearFwBtn_Click;
            openFwFolderBtn.Click += frameworkHandlers.openFwFolderBtn_Click;

            baksmaliHandlers = new BaksmaliControlEventHandlers(this);
            baksmaliBrowseOutputBtn.Click += baksmaliHandlers.baksmaliBrowseOutputBtn_Click;
            baksmaliBrowseInputDexBtn.Click += baksmaliHandlers.baksmaliBrowseInputDexBtn_Click;
            decSmaliBtn.Click += baksmaliHandlers.decSmaliBtn_Click;

            smaliHandlers = new SmaliControlEventHandlers(this);
            smaliBrowseOutputBtn.Click += smaliHandlers.smaliBrowseOutputBtn_Click;
            smaliBrowseInputDirBtn.Click += smaliHandlers.smaliBrowseInputDirBtn_Click;
            comSmaliBtn.Click += smaliHandlers.comSmaliBtn_Click;

            dragDropHandlers = new DragDropHandlers(this);

            stopwatch = new Stopwatch();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Update();

            Settings.Default.JavaExe = JavaUtils.GetJavaPath();

            InitializeUpdateChecker();
            InitializeAPKTool();
            InitializeZipalign();
            InitializeSignapk();
            InitializeBaksmali();
            InitializeSmali();

            smali = new Smali(Settings.Default.JavaExe, Program.SMALI_PATH);

            string javaVersion = apktool.GetJavaVersion();
            if (javaVersion != null)
            {
                ToLog(ApktoolEventType.Information, String.Format("{0}", javaVersion));
                string apktoolVersion = apktool.GetVersion();
                if (!String.IsNullOrWhiteSpace(apktoolVersion))
                    ToLog(ApktoolEventType.Information, String.Format(Language.APKToolVersion + " \"{0}\"", apktoolVersion));
                else
                    ToLog(ApktoolEventType.Error, Language.CantDetectApktoolVersion);
            }
            else
                MessageBox.Show(Language.ErrorJavaDetect, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (AdminUtils.IsAdministrator())
                ToLog(ApktoolEventType.Warning, Language.DragDropNotSupported);
            else
                ToLog(ApktoolEventType.Information, Language.DragDropSupported);

            TimeSpan updateInterval = DateTime.Now - Settings.Default.LastUpdateCheck;
            if (updateInterval.Days > 0 && Settings.Default.CheckForUpdateAtStartup)
                updateCheker.CheckAsync(true);

            ToStatus(Language.Done, Resources.done);

            string decApkPath = Settings.Default.Decode_InputAppPath;
            if (File.Exists(decApkPath))
            {
                GetApkInfo(decApkPath);
            }

            RunCmdArgs();
        }

        private async void RunCmdArgs()
        {
            try
            {
                if (Environment.GetCommandLineArgs().Length == 3)
                {
                    if (Settings.Default.IgnoreOutputDirContextMenu)
                        IgnoreOutputDirContextMenu = true;

                    string file = Environment.GetCommandLineArgs()[2];
                    switch (Environment.GetCommandLineArgs()[1])
                    {
                        case "decapk":
                            if (await Decompile(file) == 0)
                                Close();
                            break;
                        case "comapk":
                            if (await Build(file) == 0)
                                Close();
                            break;
                        case "sign":
                            Running();

                            await Task.Factory.StartNew(() =>
                            {
                                string inputFile = file;
                                string outputDir = file;
                                if (Settings.Default.Zipalign_UseOutputDir && !IgnoreOutputDirContextMenu)
                                    outputDir = Path.Combine(Settings.Default.Sign_OutputDir, Path.GetFileName(inputFile));

                                if (Sign(inputFile, outputDir) == 0)
                                {
                                    if (Settings.Default.Zipalign_UseOutputDir && !IgnoreOutputDirContextMenu)
                                        ToLog(ApktoolEventType.Information, String.Format(Language.SignSuccessfullyCompleted, inputFile));
                                    else
                                        ToLog(ApktoolEventType.Information, String.Format(Language.SignSuccessfullyCompleted, outputDir));
                                    Close();
                                }
                                else
                                    ToLog(ApktoolEventType.Error, String.Format(Language.ErrorSigning, outputDir));
                            });

                            Done();
                            break;
                        case "zipalign":
                            Running();

                            await Task.Factory.StartNew(() =>
                            {
                                string outputDir = file;
                                if (Settings.Default.Zipalign_UseOutputDir && !IgnoreOutputDirContextMenu)
                                    outputDir = Path.Combine(Settings.Default.Zipalign_OutputDir, Path.GetFileName(file));

                                if (!Settings.Default.Zipalign_OverwriteOutputFile)
                                    outputDir = PathUtils.GetDirectoryNameWithoutExtension(outputDir) + " aligned.apk";

                                if (Align(file, outputDir) == 0)
                                    Close();
                                else
                                    ToLog(ApktoolEventType.Error, Language.ErrorZipalign);
                            });

                            Done();
                            break;
                        case "baksmali":
                            if (await Baksmali(file) == 0)
                                Close();
                            break;
                        case "smali":
                            if (await Smali(file + ".dex") == 0)
                                Close();
                            break;
                        case "apkinfo":
                            GetApkInfo(file);
                            tabControlMain.SelectedIndex = 1;
                            break;
                        default: //Fix when running app as Release from Visual studio
                            IgnoreOutputDirContextMenu = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ToLog(ApktoolEventType.Error, ex.Message);
            }
        }

        #region Get APK Info
        internal async void GetApkInfo(string file)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    aapt = new AaptParser();

                    if (aapt.Parse(file))
                    {
                        Invoke(new Action(delegate ()
                        {
                            if (apkIconPicBox.Image != null)
                            {
                                apkIconPicBox.Image.Dispose();
                                apkIconPicBox.Image = null;
                            }
                            fileTxtBox.Text = aapt.ApkFile;
                            appTxtBox.Text = aapt.AppName;
                            packNameTxtBox.Text = aapt.PackageName;
                            verTxtBox.Text = aapt.VersionName;
                            buildTxtBox.Text = aapt.VersionCode;
                            minSdkTxtBox.Text = aapt.SdkVersion;
                            targetSdkTxtBox.Text = aapt.TargetSdkVersion;
                            screenTxtBox.Text = aapt.Screens;
                            densityTxtBox.Text = aapt.Densities;
                            permTxtBox.Text = aapt.Permissions;
                            localsTxtBox.Text = aapt.Locales;
                            ZipUtils.ExtractFile(file, aapt.AppIcon, Path.Combine(Program.TEMP_DIR, aapt.PackageName));

                            string icon = Path.Combine(Program.TEMP_DIR, aapt.PackageName, Path.GetFileName(aapt.AppIcon));
                            if (File.Exists(icon))
                                apkIconPicBox.Image = Image.FromFile(icon);
                        }));
                    }
                });
            }
            catch (Exception ex)
            {
#if DEBUG
                ToLog(ApktoolEventType.Warning, Language.ErrorGettingApkInfo + "\n" + ex.ToString());
#else
                ToLog(ApktoolEventType.Warning, Language.ErrorGettingApkInfo);
#endif
            }
        }

        private void selApkFileInfoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    GetApkInfo(ofd.FileName);
                }
            }
        }

        private void psLinkBtn_Click(object sender, EventArgs e)
        {
            if (aapt != null)
                Process.Start(aapt.PlayStoreLink);
        }

        private void apkComboLinkBtn_Click(object sender, EventArgs e)
        {
            if (aapt != null)
                Process.Start(aapt.ApkComboLink);
        }

        private void apkPureLinkBtn_Click(object sender, EventArgs e)
        {
            if (aapt != null)
                Process.Start(aapt.ApkPureLink);
        }

        private void apkAioLinkBtn_Click(object sender, EventArgs e)
        {
            if (aapt != null)
                Process.Start(aapt.ApkAioLink);
        }
        #endregion

        #region Update checker
        private void InitializeUpdateChecker()
        {
            updateCheker = new UpdateChecker("https://repo.andnixsh.com/tools/APKToolGUI/version.txt", Version.Parse(Application.ProductVersion));
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
                        if (MessageBox.Show(Language.UpdateNewVersion + "\n\n" + result.Changelog, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            Process.Start("https://repo.andnixsh.com/tools/APKToolGUI/APKToolGUI.zip");
                        break;
                    case UpdateChecker.State.NoUpdate:
                        if (!result.Silently)
                            MessageBox.Show(Language.UpdateNoUpdates, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case UpdateChecker.State.Error:
                        if (!result.Silently)
                            MessageBox.Show(Language.ErrorUpdateChecking + " " + Environment.NewLine + result.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                Settings.Default.LastUpdateCheck = DateTime.Now;
            }
        }
        #endregion

        #region Log & Status
        internal void ToStatus(string message, Image statusImage)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                toolStripStatusLabelStateText.Text = message;
                toolStripStatusLabelStateImage.Image = statusImage;
            }));
        }

        internal void ToLog(string time, string message, Image statusImage, Color backColor)
        {
            Size size = new Size();
            size.Width = 20;
            size.Height = 20;
            if (logGridView.InvokeRequired)
                logGridView.BeginInvoke(new Action(() =>
                {
                    int i = logGridView.Rows.Add(new Bitmap(statusImage, size), time, message);
                    logGridView.Rows[i].DefaultCellStyle.BackColor = backColor;
                    logGridView.FirstDisplayedScrollingRowIndex = i;
                }));
            else
            {
                int i = logGridView.Rows.Add(new Bitmap(statusImage, size), time, message);
                logGridView.Rows[i].DefaultCellStyle.BackColor = backColor;
                logGridView.FirstDisplayedScrollingRowIndex = i;
            }
        }

        internal void ToLog(ApktoolEventType eventType, string message)
        {
            if (String.IsNullOrWhiteSpace(message))
                return;

            switch (eventType)
            {
                case ApktoolEventType.Information:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Resources.info, Color.FromKnownColor(KnownColor.Window));
                    break;
                case ApktoolEventType.Error:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Resources.error, Color.FromKnownColor(KnownColor.LightPink));
                    break;
                case ApktoolEventType.Warning:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Resources.warning, Color.FromKnownColor(KnownColor.LightYellow));
                    break;
                case ApktoolEventType.Unknown:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Resources.error, Color.FromKnownColor(KnownColor.LightPink));
                    break;
                default:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Resources.info, Color.FromKnownColor(KnownColor.LightBlue));
                    break;
            }
        }

        internal void Running()
        {
            isRunning = true;
            stopwatch.Reset();
            stopwatch.Start();
            lastStartedDate = DateTime.Now.ToString();

            Invoke(new Action(delegate ()
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate, Handle);
                toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                ActionButtonsEnabled = false;
                ClearLog();
            }));
        }

        internal void Done()
        {
            isRunning = false;

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            ToLog(ApktoolEventType.Information, "Time started: " + lastStartedDate);
            ToLog(ApktoolEventType.Information, "Time elapsed: " + ts.ToString("mm\\:ss"));

            if (Settings.Default.PlaySoundWhenDone)
                SystemSounds.Beep.Play();

            TaskbarManager.Instance.SetProgressValue(1, 1);
            if (statusStrip1.InvokeRequired)
                statusStrip1.BeginInvoke(new Action(delegate { toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous; }));
            else
                toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            ActionButtonsEnabled = true;

            ToStatus(Language.Done, Resources.done);
        }

        internal void ClearLog()
        {
            if (Settings.Default.ClearLogBeforeAction)
                logGridView.Rows.Clear();
        }
        #endregion

        #region Signapk
        private void InitializeSignapk()
        {
            signapk = new Signapk(Settings.Default.JavaExe, Program.APKSIGNER_PATH);
            signapk.SignapkOutputDataRecieved += SignApkOutputDataRecieved;
            signapk.SignapkErrorDataRecieved += SignApkErrorDataRecieved;
        }

        void SignApkErrorDataRecieved(object sender, SignapkDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void SignApkOutputDataRecieved(object sender, SignapkDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Information, e.Message);
        }

        internal int Sign(string input, string output)
        {
            Invoke(new Action(delegate ()
            {
                ToLog(ApktoolEventType.Information, "=====[" + Language.Signing + "]=====");
                ToStatus(String.Format(Language.Signing + " \"{0}\"...", Path.GetFileName(input)), Resources.waiting);
            }));

            return signapk.Sign(input, output);
        }
        #endregion

        #region Apktool
        private void InitializeAPKTool()
        {
            apktool = new Apktool(Settings.Default.JavaExe, Program.APKTOOL_PATH);
            apktool.ApktoolOutputDataRecieved += apktool_ApktoolOutputDataRecieved;
            apktool.ApktoolErrorDataRecieved += apktool_ApktoolErrorDataRecieved;
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

        internal async Task<int> Decompile(string inputApk)
        {
            int code = 0;
            try
            {
                Running();

                await Task.Factory.StartNew(() =>
                {
                    if (Settings.Default.Framework_ClearBeforeDecode)
                    {
                        if (ClearFramework() == 0)
                            ToLog(ApktoolEventType.Information, Language.FrameworkCacheCleared);
                        else
                            ToLog(ApktoolEventType.Error, Language.ErrorClearingFw);
                    }

                    Invoke(new Action(delegate ()
                    {
                        ToLog(ApktoolEventType.Information, "=====[" + Language.Decoding + "]=====");
                        ToStatus(String.Format(Language.Decoding + " \"{0}\"...", Path.GetFileName(inputApk)), Resources.waiting);
                    }));

                    string outputDir = PathUtils.GetDirectoryNameWithoutExtension(inputApk);
                    if (Settings.Default.Decode_UseOutputDir && !IgnoreOutputDirContextMenu)
                        outputDir = Path.Combine(Settings.Default.Decode_OutputDir, Path.GetFileNameWithoutExtension(inputApk));

                    code = apktool.Decompile(inputApk, outputDir);

                    if (code == 0)
                    {
                        textBox_BUILD_InputProjectDir.BeginInvoke(new Action(delegate
                        {
                            textBox_BUILD_InputProjectDir.Text = outputDir;
                        }));

                        ToLog(ApktoolEventType.Information, String.Format(Language.DecompilingSuccessfullyCompleted, outputDir));
                        if (Settings.Default.Decode_FixError)
                        {
                            if (ApkFixer.ChangeSdkTo29(outputDir))
                                ToLog(ApktoolEventType.Information, Language.ChangedTargetSdkTo29);
                            if (ApkFixer.FixAndroidManifest(outputDir))
                                ToLog(ApktoolEventType.Information, Language.FixAndroidManifest);
                            if (ApkFixer.RemoveApkToolDummies(outputDir))
                                ToLog(ApktoolEventType.Information, Language.RemoveApkToolDummies);
                        }
                        ToLog(ApktoolEventType.Information, Language.AllDone);
                    }
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorDecompiling);
                });

            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.Message);
            }

            Done();

            return code;
        }

        internal int ClearFramework()
        {
            Invoke(new Action(delegate ()
            {
                ToLog(ApktoolEventType.Information, "=====[" + Language.ClearingFramework + "]=====");
                ToStatus(Language.ClearingFramework + "...", Resources.waiting);
            }));

            return apktool.ClearFramework();
        }

        internal async Task<int> Build(string inputFile)
        {
            int code = 0;

            Running();
            ToLog(ApktoolEventType.Information, "=====[" + Language.Build + "]=====");
            ToStatus(String.Format(Language.Build + " \"{0}\"...", Path.GetFileName(textBox_BUILD_InputProjectDir.Text)), Resources.waiting);

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    string outputFile = inputFile + " compiled.apk";
                    if (Settings.Default.Build_SignAfterBuild)
                        outputFile = inputFile + " signed.apk";
                    if (Settings.Default.Build_UseOutputAppPath && !IgnoreOutputDirContextMenu)
                    {
                        outputFile = Path.Combine(Settings.Default.Build_OutputAppPath, Path.GetFileName(inputFile)) + ".apk";
                        if (Settings.Default.Build_SignAfterBuild)
                            outputFile = Path.Combine(Settings.Default.Build_OutputAppPath, Path.GetFileName(inputFile)) + " signed.apk";
                    }
                    code = apktool.Build(outputFile);

                    if (code == 0)
                    {
                        ToLog(ApktoolEventType.Information, String.Format(Language.CompilingSuccessfullyCompleted, outputFile));

                        if (Settings.Default.Build_ZipalignAfterBuild)
                        {
                            if (Align(outputFile, outputFile) != 0)
                            {
                                ToLog(ApktoolEventType.Error, Language.ErrorZipalign);
                                Done();
                                return;
                            }
                            else
                            {
                                if (Settings.Default.Build_CreateUnsignedApk)
                                {
                                    ToLog(ApktoolEventType.Information, Language.CreateUnsignedApk);
                                    if (Directory.Exists(Path.Combine(inputFile, "original", "META-INF")))
                                    {
                                        ZipUtils.UpdateDirectory(outputFile, Path.Combine(inputFile, "original", "META-INF"), "META-INF");
                                        File.Copy(outputFile, Path.Combine(Path.GetDirectoryName(outputFile), Path.GetFileName(inputFile) + " unsigned.apk"), true);
                                    }
                                    else
                                        ToLog(ApktoolEventType.Warning, Language.MetainfNotExist);
                                }
                                ToLog(ApktoolEventType.Information, Language.Done);
                            }
                        }
                        if (Settings.Default.Build_SignAfterBuild)
                        {
                            if (Sign(outputFile, outputFile) != 0)
                            {
                                ToLog(ApktoolEventType.Error, Language.ErrorSigning);
                                Done();
                                return;
                            }
                            else
                                ToLog(ApktoolEventType.Information, Language.Done);
                        }
                        ToLog(ApktoolEventType.Information, Language.AllDone);
                    }
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorCompiling);
                });
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.Message);
            }
            Done();

            return code;
        }
        #endregion

        #region Baksmali
        private void InitializeBaksmali()
        {
            baksmali = new Baksmali(Settings.Default.JavaExe, Program.BAKSMALI_PATH);
            baksmali.BaksmaliOutputDataRecieved += BaksmaliOutputDataRecieved;
            baksmali.BaksmaliErrorDataRecieved += BaksmaliErrorDataRecieved;
        }

        void BaksmaliErrorDataRecieved(object sender, BaksmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void BaksmaliOutputDataRecieved(object sender, BaksmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Information, e.Message);
        }


        internal async Task<int> Baksmali(string inputFile)
        {
            int code = 0;
            try
            {
                Running();
                ToLog(ApktoolEventType.Information, "=====[" + Language.DecompilingDex + "]=====");
                ToStatus(String.Format(Language.DecompilingDex + "...", Path.GetFileName(baksmaliBrowseInputDexTxtBox.Text)), Resources.waiting);

                await Task.Factory.StartNew(() =>
                {
                    string outputDir = String.Format("{0}", Path.Combine(Path.GetDirectoryName(inputFile), "dexout", Path.GetFileNameWithoutExtension(inputFile)));
                    if (Settings.Default.Baksmali_UseOutputDir && !IgnoreOutputDirContextMenu)
                        outputDir = String.Format("{0}", Path.Combine(Settings.Default.Baksmali_OutputDir, Path.GetFileNameWithoutExtension(inputFile)));

                    code = baksmali.Disassemble(outputDir);
                    if (code == 0)
                    {
                        textBox_BUILD_InputProjectDir.BeginInvoke(new Action(delegate
                        {
                            smaliBrowseInputDirTxtBox.Text = outputDir;
                        }));
                        ToLog(ApktoolEventType.Information, String.Format(Language.DecompilingSuccessfullyCompleted, outputDir));
                    }
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorDecompiling);
                });
                Done();
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.Message);
            }

            return code;
        }
        #endregion

        #region Smali
        private void InitializeSmali()
        {
            smali = new Smali(Settings.Default.JavaExe, Program.SMALI_PATH);
            smali.SmaliOutputDataRecieved += SmaliOutputDataRecieved;
            smali.SmaliErrorDataRecieved += SmaliErrorDataRecieved;
        }

        void SmaliErrorDataRecieved(object sender, SmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void SmaliOutputDataRecieved(object sender, SmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Information, e.Message);
        }

        internal async Task<int> Smali(string inputDir)
        {
            int code = 0;
            try
            {
                Running();
                ToLog(ApktoolEventType.Information, "=====[" + Language.CompilingDex + "]=====");
                ToStatus(String.Format(Language.DecompilingDex + "...", Path.GetFileName(smaliBrowseInputDirTxtBox.Text)), Resources.waiting);

                await Task.Factory.StartNew(() =>
                {
                    string outputDir = String.Format("{0}", inputDir);
                    if (Settings.Default.Smali_UseOutputDir && !IgnoreOutputDirContextMenu)
                        outputDir = String.Format("{0}", Path.Combine(Settings.Default.Smali_OutputDir, Path.GetFileNameWithoutExtension(inputDir)));

                    code = smali.Assemble(outputDir);
                    if (smali.Assemble(outputDir) == 0)
                        ToLog(ApktoolEventType.Information, String.Format(Language.CompilingSuccessfullyCompleted, outputDir));
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorCompiling);
                });
                Done();
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.Message);
            }

            return code;
        }
        #endregion

        #region Zipalign
        private void InitializeZipalign()
        {
            zipalign = new Zipalign(Program.ZIPALIGN_PATH);
            zipalign.OutputDataReceived += zipalign_OutputDataReceived;
            zipalign.ErrorDataReceived += zipalign_ErrorDataReceived;
        }

        void zipalign_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Information, e.Data);
        }

        void zipalign_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Data);
        }

        internal int Align(string input, string output)
        {
            Invoke(new Action(delegate ()
            {
                ToLog(ApktoolEventType.Information, "=====[" + Language.Aligning + "]=====");
                ToStatus(String.Format(Language.Aligning + " \"{0}\"...", Path.GetFileName(input)), Resources.waiting);
            }));

            return zipalign.Align(input, output);
        }
        #endregion

        #region Main menu event handlers
        private void saveLogItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = "APK Tool GUI logs";
                sfd.Filter = Language.TextFile + " (*.txt)|*.txt";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter TW = new StreamWriter(sfd.FileName))
                    {
                        for (int i = 0; i < logGridView.Rows.Count; i++)
                        {
                            string dateTime = (string)logGridView.Rows[i].Cells[1].Value;
                            string text = (string)logGridView.Rows[i].Cells[2].Value;
                            TW.WriteLine($"{dateTime} {text}");
                        }
                    }
                }
            }
        }

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

        private void apktoolIssueItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iBotPeaches/Apktool/issues");
        }
        #endregion

        #region Control event handlers
        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logGridView.Rows.Clear();
        }
        private void openAndroidMainfestBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(textBox_BUILD_InputProjectDir.Text, "AndroidManifest.xml")))
                Process.Start("explorer.exe", Path.Combine(textBox_BUILD_InputProjectDir.Text, "AndroidManifest.xml"));
            else
                ToLog(ApktoolEventType.Error, Language.AndroidManifestNotExist);
        }

        private void openApktoolYmlBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(textBox_BUILD_InputProjectDir.Text, "apktool.yml")))
                Process.Start("explorer.exe", Path.Combine(textBox_BUILD_InputProjectDir.Text, "apktool.yml"));
            else
                ToLog(ApktoolEventType.Error, Language.AndroidManifestNotExist);
        }

        private void selectedApkOpenDirBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Settings.Default.Decode_InputAppPath))
            {
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", Settings.Default.Decode_InputAppPath));
            }
            else
                ToLog(ApktoolEventType.Error, Language.ErrorSelectedFileNotExist);
        }

        private void button_OpenMainActivity_Click(object sender, EventArgs e)
        {
            string decPath = textBox_BUILD_InputProjectDir.Text;
            if (Directory.Exists(decPath))
            {
                var launchActivityList = new List<string>
                {
                    aapt != null ? aapt.LaunchableActivity : CommonUtils.GetActivityFromManifest(decPath),
                    "com\\unity3d\\player\\UnityPlayerActivity",
                    CommonUtils.GetApplicationNameFromManifest(decPath)
                };

                foreach (string launchActivity in launchActivityList)
                {
                    if (String.IsNullOrEmpty(launchActivity))
                        continue;

                    Debug.WriteLine(launchActivity);

                    string path = null;
                    bool activityFound = false;
                    for (int i = 1; i < 100; i++)
                    {
                        string smaliFolder = (i == 1) ? "smali" : "smali_classes" + i;
                        path = Path.Combine(decPath, smaliFolder, launchActivity.Replace(".", "\\") + ".smali");
                        if (File.Exists(path))
                        {
                            Debug.WriteLine(path);
                            activityFound = true;
                            break;
                        }
                    }

                    if (activityFound && !CommonUtils.OnCreateExists(path))
                        continue;

                    if (activityFound)
                    {
                        ToLog(ApktoolEventType.Information, String.Format(Language.MainActivityFound, path));
                        Process.Start("explorer.exe", path);
                        return;
                    }
                    else
                        continue;
                }

                ToLog(ApktoolEventType.Warning, Language.MainActivityNotFoundPleaseFindManually);
            }
            else
                ToLog(ApktoolEventType.Error, Language.DecompiledAPKNotExist);
        }
        #endregion

        #region Form handlers
        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (!isRunning)
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //For debugging purposes
            try
            {
                using (TextWriter TW = new StreamWriter(Path.Combine(Program.TEMP_DIR, "logs.txt")))
                {
                    for (int i = 0; i < logGridView.Rows.Count; i++)
                    {
                        string dateTime = (string)logGridView.Rows[i].Cells[1].Value;
                        string text = (string)logGridView.Rows[i].Cells[2].Value;
                        TW.WriteLine($"{dateTime} {text}");
                    }
                }
            }
            catch
            {

            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Save();
        }

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

                if (button_SIGN_Sign.InvokeRequired)
                    button_SIGN_Sign.BeginInvoke(new Action(delegate
                    {
                        button_SIGN_Sign.Enabled = value;
                    }));
                else
                    button_SIGN_Sign.Enabled = value;

                if (decSmaliBtn.InvokeRequired)
                    decSmaliBtn.BeginInvoke(new Action(delegate
                    {
                        decSmaliBtn.Enabled = value;
                    }));
                else
                    decSmaliBtn.Enabled = value;

                if (comSmaliBtn.InvokeRequired)
                    comSmaliBtn.BeginInvoke(new Action(delegate
                    {
                        comSmaliBtn.Enabled = value;
                    }));
                else
                    comSmaliBtn.Enabled = value;
            }
        }

        internal void ShowMessage(string message, MessageBoxIcon status)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, status);
        }
        #endregion

        #region Config
        internal void Save()
        {
            Settings.Default.Sign_Schemev1 = schemev1ComboBox.SelectedIndex;
            Settings.Default.Sign_Schemev2 = schemev2ComboBox.SelectedIndex;
            Settings.Default.Sign_Schemev3 = schemev3ComboBox.SelectedIndex;
            Settings.Default.Sign_Schemev4 = schemev4ComboBox.SelectedIndex;
            Settings.Default.Save();
        }
        #endregion
    }
}