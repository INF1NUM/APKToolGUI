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
using APKSMerger.AndroidRes;
using Ionic.Zip;
using System.Linq;
using System.Threading;

namespace APKToolGUI
{
    public partial class FormMain : Form
    {
        internal ApkEditor apkeditor;
        internal Apktool apktool;
        internal Signapk signapk;
        internal Baksmali baksmali;
        internal Smali smali;
        internal Zipalign zipalign;
        internal UpdateChecker updateCheker;
        internal AaptParser aapt;

        private bool IgnoreOutputDirContextMenu;
        private bool isRunning;

        private Stopwatch stopwatch;
        private string lastStartedDate;

        internal static FormMain Instance { get; private set; }

        public FormMain()
        {
            Instance = this;

            Program.SetLanguage();

            InitializeComponent();

            Text += " - v" + ProductVersion;
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

            new DecodeControlEventHandlers(this);
            new BuildControlEventHandlers(this);
            new SignControlEventHandlers(this);
            new ZipalignControlEventHandlers(this);
            new FrameworkControlEventHandlers(this);
            new BaksmaliControlEventHandlers(this);
            new SmaliControlEventHandlers(this);
            new DragDropHandlers(this);
            new ApkinfoControlEventHandlers(this);
            new MainWindowEventHandlers(this);

            stopwatch = new Stopwatch();
        }

        private async void FormMain_Shown(object sender, EventArgs e)
        {
            Update();

            await Task.Factory.StartNew(() =>
            {
                InitializeUpdateChecker();
                InitializeZipalign();
                InitializeBaksmali();
                InitializeSmali();
                InitializeAPKTool();
                InitializeSignapk();
                InitializeApkEditor();

                string javaVersion = apktool.GetJavaVersion();
                if (javaVersion != null)
                {
                    ToLog(ApktoolEventType.None, String.Format("{0}", javaVersion));
                    string apktoolVersion = apktool.GetVersion();
                    if (!String.IsNullOrWhiteSpace(apktoolVersion))
                        ToLog(ApktoolEventType.None, String.Format(Language.APKToolVersion + " \"{0}\"", apktoolVersion));
                    else
                        ToLog(ApktoolEventType.Error, Language.CantDetectApktoolVersion);
                }
                else
                    ToLog(ApktoolEventType.Error, Language.ErrorJavaDetect);

                if (AdminUtils.IsAdministrator())
                    ToLog(ApktoolEventType.Warning, Language.DragDropNotSupported);
                else
                    ToLog(ApktoolEventType.None, Language.DragDropSupported);

                ToLog(ApktoolEventType.None, String.Format(Language.TempDirectory, Program.TEMP_PATH));

                TimeSpan updateInterval = DateTime.Now - Settings.Default.LastUpdateCheck;
                if (updateInterval.Days > 0 && Settings.Default.CheckForUpdateAtStartup)
                    updateCheker.CheckAsync(true);
            });

            ToStatus(Language.Done, Resources.done);

            string decApkPath = Settings.Default.Decode_InputAppPath;

            await GetApkInfo(decApkPath);

            RunCmdArgs();
        }

        #region Context menu args
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
                            if (file.ContainsAny(".xapk", ".zip", ".apks", ".apkm"))
                            {
                                if (Settings.Default.Decode_UseApkEditorMergeApk)
                                {
                                    if (await MergeUsingApkEditor(file) == 0)
                                        Close();
                                }
                                else
                                {
                                    if (await Merge(file) == 0)
                                        Close();
                                }
                            }
                            else
                            {
                                if (await Decompile(file) == 0)
                                    Close();
                            }
                            break;
                        case "comapk":
                            if (await Build(file) == 0)
                                Close();
                            break;
                        case "sign":
                            if (await Sign(file) == 0)
                                Close();
                            break;
                        case "zipalign":
                            if (await Align(file) == 0)
                                Close();
                            break;
                        case "baksmali":
                            if (await Baksmali(file) == 0)
                                Close();
                            break;
                        case "smali":
                            if (await Smali(file) == 0)
                                Close();
                            break;
                        case "apkinfo":
                            await GetApkInfo(file);
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
        #endregion

        #region Get APK Info
        internal async Task GetApkInfo(string file)
        {
            if (File.Exists(file))
            {
                ToLog(ApktoolEventType.None, Language.ParsingApkInfo);
                ToStatus(Language.ParsingApkInfo, Resources.waiting);

                try
                {
                    string splitPath = Path.Combine(Program.TEMP_PATH, "SplitInfo");
                    string arch = null;

                    await Task.Factory.StartNew(() =>
                    {
                        DirectoryUtils.Delete(splitPath);
                        if (file.ContainsAny(".xapk", ".zip", ".apks", ".apkm"))
                        {
                            Directory.CreateDirectory(splitPath);

                            using (ZipFile zipDest = ZipFile.Read(file))
                            {
                                bool mainApkFound = false;
                                foreach (ZipEntry entry in zipDest.Entries)
                                {
                                    if (!mainApkFound && !entry.FileName.Contains("config.") && entry.FileName.EndsWith(".apk"))
                                    {
                                        Debug.WriteLine("Found main APK" + entry.FileName);
                                        entry.Extract(splitPath, ExtractExistingFileAction.OverwriteSilently);
                                        file = Path.Combine(splitPath, entry.FileName);
                                        mainApkFound = true;
                                    }
                                    if (entry.FileName.Contains("lib/armeabi-v7a"))
                                    {
                                        arch += "armeabi-v7a, ";
                                    }
                                    if (entry.FileName.Contains("lib/arm64-v8a"))
                                    {
                                        arch += "arm64-v8a, ";
                                    }
                                    if (entry.FileName.Contains("lib/x86"))
                                    {
                                        arch += "x86, ";
                                    }
                                    if (entry.FileName.Contains("lib/x86_64"))
                                    {
                                        arch += "x86_64, ";
                                    }
                                }
                            }
                        }
                    });

                    bool parsed = false;
                    await Task.Factory.StartNew(() =>
                    {
                        aapt = new AaptParser();
                        parsed = aapt.Parse(file);
                    });

                    if (parsed)
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
                        minSdkTxtBox.Text = aapt.MinSdkVersionDetailed;
                        targetSdkTxtBox.Text = aapt.TargetSdkVersionDetailed;
                        screenTxtBox.Text = aapt.Screens;
                        densityTxtBox.Text = aapt.Densities;
                        permTxtBox.Text = aapt.Permissions;
                        localsTxtBox.Text = aapt.Locales;
                        fullInfoTextBox.Text = aapt.FullInfo;
                        if (!String.IsNullOrEmpty(aapt.NativeCode))
                            archSdkTxtBox.Text = aapt.NativeCode;
                        else
                            archSdkTxtBox.Text = arch.RemoveLast(", ");
                        launchActivityTxtBox.Text = aapt.LaunchableActivity;

                        if (aapt.AppIcon != null)
                        {
                            await Task.Factory.StartNew(() =>
                            {
                                ZipUtils.ExtractFile(file, aapt.AppIcon, Path.Combine(Program.TEMP_PATH, aapt.PackageName));
                            });
                            string icon = Path.Combine(Program.TEMP_PATH, aapt.PackageName, Path.GetFileName(aapt.AppIcon));
                            if (File.Exists(icon))
                            {
                                apkIconPicBox.Image = BitmapUtils.LoadBitmap(icon);
                            }
                        }

                        DirectoryUtils.Delete(splitPath);
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    ToLog(ApktoolEventType.Warning, Language.ErrorGettingApkInfo + "\n" + ex.ToString());
#else
                    ToLog(ApktoolEventType.Warning, Language.ErrorGettingApkInfo);
#endif
                }
                ToLog(ApktoolEventType.Done, Language.Done);
                ToStatus(Language.Done, Resources.done);
            }
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

        internal void ToLog(string time, string message, Color backColor)
        {
            Debug.WriteLine(time + " " + message);

            if (logTxtBox.InvokeRequired)
                Invoke(new Action(delegate ()
                {
                    //richTextBox1.SelectionColor = color ?? Color.Black;
                    logTxtBox.SelectionColor = backColor;
                    logTxtBox.AppendText(time + " " + message + Environment.NewLine);
                }));
            else
            {
                logTxtBox.SelectionColor = backColor;
                logTxtBox.AppendText(time + " " + message + Environment.NewLine);
            }
        }

        internal void ToLog(ApktoolEventType eventType, string message)
        {
            if (String.IsNullOrWhiteSpace(message))
                return;

            switch (eventType)
            {
                case ApktoolEventType.None:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Color.Black);
                    break;
                case ApktoolEventType.Done:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Color.DarkGreen);
                    break;
                case ApktoolEventType.Infomation:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Color.Blue);
                    break;
                case ApktoolEventType.Error:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Color.Red);
                    break;
                case ApktoolEventType.Warning:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Color.DarkOrange);
                    break;
                case ApktoolEventType.Unknown:
                    ToLog(DateTime.Now.ToString("[HH:mm:ss]"), message, Color.Red);
                    break;
                default:
                    ToLog(DateTime.Now.ToString("[dd.MM.yyyy HH:mm:ss]"), message, Color.Blue);
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

        internal void Done(bool printTimer = false)
        {
            isRunning = false;

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            if (printTimer)
            {
                ToLog(ApktoolEventType.None, "Time started: " + lastStartedDate);
                ToLog(ApktoolEventType.None, "Time elapsed: " + ts.ToString("mm\\:ss"));
            }

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
                logTxtBox.Text = "";
        }
        #endregion

        #region Merge APK
        internal async Task<int> Merge(string inputSplitApk)
        {
            int code = 0;

            Running();

            string apkFileName = Path.GetFileName(inputSplitApk);

            string tempApk = Path.Combine(Program.TEMP_PATH, "dec.apk");

            string extractedSplitDir = Path.Combine(Program.TEMP_PATH, "SplitApk");
            string decompileDir = Path.Combine(Program.TEMP_PATH, "Decompiled");
            string mergedDir = Path.Combine(Program.TEMP_PATH, "Merged");

            string outputDir = PathUtils.GetDirectoryNameWithoutExtension(inputSplitApk);
            if (Settings.Default.Decode_UseOutputDir && !IgnoreOutputDirContextMenu)
                outputDir = Path.Combine(Settings.Default.Decode_OutputDir, Path.GetFileNameWithoutExtension(inputSplitApk));

            try
            {
                DirectoryUtils.Delete(extractedSplitDir);
                Directory.CreateDirectory(extractedSplitDir);
                DirectoryUtils.Delete(mergedDir);
                Directory.CreateDirectory(mergedDir);

                await Task.Factory.StartNew(() =>
                {
                    if (Settings.Default.Framework_ClearBeforeDecode)
                    {
                        if (ClearFramework() == 0)
                            ToLog(ApktoolEventType.None, Language.FrameworkCacheCleared);
                        else
                            ToLog(ApktoolEventType.Error, Language.ErrorClearingFw);
                    }

                    ToLog(ApktoolEventType.Infomation, "=====[ " + Language.MergingApk + " ]=====");
                    ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputSplitApk));
                    ToStatus(String.Format(Language.MergingApk + " \"{0}\"...", Path.GetFileName(inputSplitApk)), Resources.waiting);

                    //Extract all apk files
                    ToLog(ApktoolEventType.None, Language.ExtractingAllApkFiles);
                    ZipUtils.ExtractAll(inputSplitApk, extractedSplitDir, true);

                    //Decompile all apk files
                    ToLog(ApktoolEventType.None, Language.DecompilingAllApkFiles);

                    List<DirectoryInfo> splitDirs = new List<DirectoryInfo>();
                    var apkfiles = Directory.EnumerateFiles(extractedSplitDir, "*.apk");

                    foreach (string apk in apkfiles)
                    {
                        string output = Path.Combine(decompileDir, Path.GetFileNameWithoutExtension(apk));

                        code = apktool.Decompile(apk, output);
                        if (code != 0)
                        {
                            ToLog(ApktoolEventType.Error, Language.ErrorDecompiling);
                            throw new Exception();
                        }

                        if (Directory.Exists(Path.Combine(output, "smali")) || File.Exists(Path.Combine(output, "classes.dex")))
                        {
                            ToLog(ApktoolEventType.Infomation, String.Format(Language.DetectedAsBase, apk));

                            ToLog(ApktoolEventType.None, String.Format(Language.MovingBasedirectory, decompileDir));
                            DirectoryUtils.Move(output, mergedDir);
                            continue;
                        }

                        DirectoryInfo splitI = new DirectoryInfo(output);
                        ToLog(ApktoolEventType.Infomation, String.Format(Language.DetectedAsSplit, apk));
                        splitDirs.Add(splitI);
                    }

                    AndroidMerger merger = new AndroidMerger();
                    DirectoryInfo baseDir = new DirectoryInfo(mergedDir);

                    Dictionary<string, string> locales, abis;

                    ToLog(ApktoolEventType.None, Language.MergingApk);
                    merger.CollectCapabilities(out locales, out abis, baseDir, splitDirs.ToArray());
                    merger.MergeSplits(baseDir, splitDirs.ToArray());

                    ToLog(ApktoolEventType.None, String.Format(Language.MergeFinishedMoveDir, outputDir));
                    DirectoryUtils.Move(mergedDir, outputDir);
                });
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.ToString());
            }

            Done(printTimer: true);

            return code;
        }
        #endregion

        #region ApkEditor
        private void InitializeApkEditor()
        {
            apkeditor = new ApkEditor(JavaUtils.GetJavaPath(), Program.APKEDITOR_PATH);
            apkeditor.ApkEditorOutputDataRecieved += ApkEditorOutputDataRecieved;
            apkeditor.ApkEditorErrorDataRecieved += ApkEditorErrorDataRecieved;
        }

        void ApkEditorErrorDataRecieved(object sender, ApkEditorDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void ApkEditorOutputDataRecieved(object sender, ApkEditorDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.None, e.Message);
        }

        internal async Task<int> MergeUsingApkEditor(string inputSplitApk)
        {
            int code = 0;

            Running();

            string apkFileName = Path.GetFileName(inputSplitApk);

            string tempApk = Path.Combine(Program.TEMP_PATH, "dec.apk");
            string tempDecApk = Path.Combine(Program.TEMP_PATH, "dec");
            string decOrigDir = Path.Combine(tempDecApk, "original");

            string splitDir = Path.Combine(Program.TEMP_PATH, "SplitTmp");
            string extractedDir = Path.Combine(splitDir, "ExtractedApks");
            string mergedDir = Path.Combine(splitDir, "Merged");

            string outputDir = PathUtils.GetDirectoryNameWithoutExtension(inputSplitApk);
            if (Settings.Default.Decode_UseOutputDir && !IgnoreOutputDirContextMenu)
                outputDir = Path.Combine(Settings.Default.Decode_OutputDir, Path.GetFileNameWithoutExtension(inputSplitApk));

            try
            {
                DirectoryUtils.Delete(splitDir);
                Directory.CreateDirectory(splitDir);

                await Task.Factory.StartNew(() =>
                {
                    if (Settings.Default.Framework_ClearBeforeDecode)
                    {
                        if (ClearFramework() == 0)
                            ToLog(ApktoolEventType.None, Language.FrameworkCacheCleared);
                        else
                            ToLog(ApktoolEventType.Error, Language.ErrorClearingFw);
                    }

                    ToLog(ApktoolEventType.Infomation, "=====[ " + Language.MergingApk + " ]=====");
                    ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputSplitApk));
                    ToStatus(String.Format(Language.MergingApk + " \"{0}\"...", Path.GetFileName(inputSplitApk)), Resources.waiting);

                    //Extract all apk files
                    ToLog(ApktoolEventType.None, Language.ExtractingAllApkFiles);
                    ZipUtils.ExtractAll(inputSplitApk, extractedDir, true);

                    var apkfiles = Directory.EnumerateFiles(extractedDir, "*.apk");

                    ToLog(ApktoolEventType.None, Language.MergingApkEditor);
                    code = apkeditor.Merge(extractedDir, tempApk);
                    if (code == 0)
                    {
                        code = apktool.Decompile(tempApk, tempDecApk);

                        if (code == 0)
                        {
                            ToLog(ApktoolEventType.None, Language.ExtractOrigSignature);

                            foreach (string apk in apkfiles)
                            {
                                ZipUtils.ExtractDirectory(apk, "META-INF", decOrigDir);
                                ZipUtils.ExtractFile(apk, "stamp-cert-sha256", decOrigDir);
                                break;
                            }

                            ToLog(ApktoolEventType.None, String.Format(Language.MoveTempApkFileToOutput, tempDecApk, outputDir));
                            DirectoryUtils.Delete(outputDir);
                            DirectoryUtils.Copy(tempDecApk, outputDir);

                            textBox_BUILD_InputProjectDir.BeginInvoke(new Action(delegate
                            {
                                textBox_BUILD_InputProjectDir.Text = outputDir;
                            }));

                            ToLog(ApktoolEventType.None, String.Format(Language.DecompilingSuccessfullyCompleted, outputDir));
                            if (Settings.Default.Decode_FixError)
                            {
                                if (ApkFixer.ChangeSdkTo29(outputDir))
                                    ToLog(ApktoolEventType.None, Language.ChangedTargetSdkTo29);
                                if (ApkFixer.FixAndroidManifest(outputDir))
                                    ToLog(ApktoolEventType.None, Language.FixAndroidManifest);
                                if (ApkFixer.RemoveApkToolDummies(outputDir))
                                    ToLog(ApktoolEventType.None, Language.RemoveApkToolDummies);
                            }
                            ToLog(ApktoolEventType.None, String.Format(Language.MergeFinishedMoveDir, outputDir));
                            ToLog(ApktoolEventType.Done, "=====[ " + Language.AllDone + " ]=====");
                        }
                        else
                            ToLog(ApktoolEventType.Error, Language.ErrorDecompiling);
                    }
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorMerging);
                });
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.ToString());
            }

            Done(printTimer: true);

            return code;
        }
        #endregion

        #region Apktool
        private void InitializeAPKTool()
        {
            apktool = new Apktool(JavaUtils.GetJavaPath(), Program.APKTOOL_PATH);
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

            Running();

            string apkFileName = Path.GetFileName(inputApk);
            string outputDir = PathUtils.GetDirectoryNameWithoutExtension(inputApk);
            if (Settings.Default.Decode_UseOutputDir && !IgnoreOutputDirContextMenu)
                outputDir = Path.Combine(Settings.Default.Decode_OutputDir, Path.GetFileNameWithoutExtension(inputApk));

            string tempApk = Path.Combine(Program.TEMP_PATH, "dec.apk");
            string outputTempDir = tempApk.Replace(".apk", "");

            try
            {
                if (!Settings.Default.Decode_Force && Directory.Exists(outputDir))
                {
                    ToLog(ApktoolEventType.Error, String.Format(Language.DecodeDesDirExists, outputDir));
                    return 1;
                }
                await Task.Factory.StartNew(() =>
                {
                    DirectoryUtils.Delete(outputTempDir);

                    if (Settings.Default.Framework_ClearBeforeDecode)
                    {
                        if (ClearFramework() == 0)
                            ToLog(ApktoolEventType.None, Language.FrameworkCacheCleared);
                        else
                            ToLog(ApktoolEventType.Error, Language.ErrorClearingFw);
                    }

                    Invoke(new Action(delegate ()
                    {
                        ToLog(ApktoolEventType.Infomation, "=====[ " + Language.Decoding + " ]=====");
                        ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputApk));
                        ToStatus(String.Format(Language.Decoding + " \"{0}\"...", Path.GetFileName(inputApk)), Resources.waiting);
                    }));

                    if (Settings.Default.Utf8FilenameSupport)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.CopyFileToTemp, inputApk, tempApk));

                        FileUtils.Copy(inputApk, tempApk, true);

                        code = apktool.Decompile(tempApk, outputTempDir);
                    }
                    else
                        code = apktool.Decompile(inputApk, outputDir);

                    if (code == 0)
                    {
                        if (Settings.Default.Utf8FilenameSupport)
                        {
                            ToLog(ApktoolEventType.None, String.Format(Language.MoveTempApkFileToOutput, outputTempDir, outputDir));
                            DirectoryUtils.Delete(outputDir);
                            DirectoryUtils.Copy(outputTempDir, outputDir);
                        }

                        textBox_BUILD_InputProjectDir.BeginInvoke(new Action(delegate
                        {
                            textBox_BUILD_InputProjectDir.Text = outputDir;
                        }));

                        ToLog(ApktoolEventType.None, String.Format(Language.DecompilingSuccessfullyCompleted, outputDir));
                        if (Settings.Default.Decode_FixError)
                        {
                            if (ApkFixer.ChangeSdkTo29(outputDir))
                                ToLog(ApktoolEventType.None, Language.ChangedTargetSdkTo29);
                            if (ApkFixer.FixAndroidManifest(outputDir))
                                ToLog(ApktoolEventType.None, Language.FixAndroidManifest);
                            if (ApkFixer.RemoveApkToolDummies(outputDir))
                                ToLog(ApktoolEventType.None, Language.RemoveApkToolDummies);
                        }
                        ToLog(ApktoolEventType.Done, "=====[ " + Language.AllDone + " ]=====");
                    }
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorDecompiling);
                });

            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.ToString());
            }

            Done(printTimer: true);

            return code;
        }

        internal int ClearFramework()
        {
            Invoke(new Action(delegate ()
            {
                ToLog(ApktoolEventType.Infomation, "=====[ " + Language.ClearingFramework + " ]=====");
                ToStatus(Language.ClearingFramework + "...", Resources.waiting);
            }));

            return apktool.ClearFramework();
        }

        internal async Task<int> Build(string inputFolder)
        {
            int code = 0;

            Running();
            ToLog(ApktoolEventType.Infomation, "=====[ " + Language.Build + " ]=====");
            ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputFolder));
            ToStatus(String.Format(Language.Build + " \"{0}\"...", Path.GetFileName(textBox_BUILD_InputProjectDir.Text)), Resources.waiting);

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    string outputFile = inputFolder + " compiled.apk";
                    if (Settings.Default.Build_SignAfterBuild)
                        outputFile = inputFolder + " signed.apk";
                    if (Settings.Default.Build_UseOutputAppPath && !IgnoreOutputDirContextMenu)
                    {
                        outputFile = Path.Combine(Settings.Default.Build_OutputAppPath, Path.GetFileName(inputFolder)) + ".apk";
                        if (Settings.Default.Build_SignAfterBuild)
                            outputFile = Path.Combine(Settings.Default.Build_OutputAppPath, Path.GetFileName(inputFolder)) + " signed.apk";
                    }
                    string outputCompiledApkFile = outputFile;

                    string tempDecApkFolder = Path.Combine(Program.TEMP_PATH, "dec");
                    string outputTempApk = tempDecApkFolder + ".apk";

                    if (Settings.Default.Utf8FilenameSupport)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.CopyFolderToTemp, inputFolder, tempDecApkFolder));
                        DirectoryUtils.Delete(tempDecApkFolder);
                        DirectoryUtils.Copy(inputFolder, tempDecApkFolder);

                        inputFolder = tempDecApkFolder;
                        outputFile = outputTempApk;
                    }

                    code = apktool.Build(inputFolder, outputFile);

                    if (code == 0)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.CompilingSuccessfullyCompleted, outputFile));

                        if (Settings.Default.Build_ZipalignAfterBuild)
                        {
                            Invoke(new Action(delegate ()
                            {
                                ToLog(ApktoolEventType.Infomation, "=====[ " + Language.Aligning + " ]=====");
                                ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputFolder));
                                ToStatus(String.Format(Language.Aligning + " \"{0}\"...", Path.GetFileName(inputFolder)), Resources.waiting);
                            }));

                            if (zipalign.Align(outputFile, outputFile) != 0)
                            {
                                ToLog(ApktoolEventType.Error, Language.ErrorZipalign);
                                Done(printTimer: true);
                                return;
                            }
                            else
                            {
                                ToLog(ApktoolEventType.None, Language.Done);
                                if (Settings.Default.Build_CreateUnsignedApk)
                                {
                                    ToLog(ApktoolEventType.Infomation, "=====[ " + Language.CreateUnsignedApk + " ]=====");
                                    if (Directory.Exists(Path.Combine(inputFolder, "original", "META-INF")))
                                    {
                                        ZipUtils.UpdateDirectory(outputFile, Path.Combine(inputFolder, "original", "META-INF"), "META-INF");
                                        File.Copy(outputFile, Path.Combine(Path.GetDirectoryName(outputFile), Path.GetFileName(inputFolder) + " unsigned.apk"), true);
                                        ToLog(ApktoolEventType.None, Language.Done);
                                    }
                                    else
                                        ToLog(ApktoolEventType.Warning, Language.MetainfNotExist);
                                }
                            }
                        }
                        if (Settings.Default.Build_SignAfterBuild)
                        {
                            Invoke(new Action(delegate ()
                            {
                                ToLog(ApktoolEventType.Infomation, "=====[ " + Language.Signing + " ]=====");
                                ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputFolder));
                                ToStatus(String.Format(Language.Signing + " \"{0}\"...", Path.GetFileName(inputFolder)), Resources.waiting);
                            }));

                            if (signapk.Sign(outputFile, outputFile) == 0)
                            {
                                ToLog(ApktoolEventType.None, Language.Done);

                                if (Settings.Default.AutoDeleteIdsigFile)
                                {
                                    ToLog(ApktoolEventType.None, String.Format(Language.DeleteFile, outputFile + ".idsig"));
                                    FileUtils.Delete(outputFile + ".idsig");
                                }
                            }
                            else
                            {
                                ToLog(ApktoolEventType.Error, Language.ErrorSigning);
                                Done(printTimer: true);
                                return;
                            }
                        }

                        if (Settings.Default.Utf8FilenameSupport)
                        {
                            ToLog(ApktoolEventType.None, String.Format(Language.MoveTempApkToOutput, outputTempApk, outputCompiledApkFile));
                            FileUtils.Move(outputTempApk, outputCompiledApkFile, true);
                        }

                        ToLog(ApktoolEventType.Done, "=====[ " + Language.AllDone + " ]=====");
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
            Done(printTimer: true);

            return code;
        }
        #endregion

        #region Baksmali
        private void InitializeBaksmali()
        {
            baksmali = new Baksmali(JavaUtils.GetJavaPath(), Program.BAKSMALI_PATH);
            baksmali.BaksmaliOutputDataRecieved += BaksmaliOutputDataRecieved;
            baksmali.BaksmaliErrorDataRecieved += BaksmaliErrorDataRecieved;
        }

        void BaksmaliErrorDataRecieved(object sender, BaksmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void BaksmaliOutputDataRecieved(object sender, BaksmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.None, e.Message);
        }

        internal async Task<int> Baksmali(string inputFile)
        {
            int code = 0;
            try
            {
                Running();
                ToLog(ApktoolEventType.Infomation, "=====[ " + Language.DecompilingDex + " ]=====");
                ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputFile));

                ToStatus(String.Format(Language.DecompilingDex + "...", Path.GetFileName(baksmaliBrowseInputDexTxtBox.Text)), Resources.waiting);

                await Task.Factory.StartNew(() =>
                {
                    string outputDir = String.Format("{0}", Path.Combine(Path.GetDirectoryName(inputFile), "dexout", Path.GetFileNameWithoutExtension(inputFile)));
                    if (Settings.Default.Baksmali_UseOutputDir && !IgnoreOutputDirContextMenu)
                        outputDir = String.Format("{0}", Path.Combine(Settings.Default.Baksmali_OutputDir, Path.GetFileNameWithoutExtension(inputFile)));

                    code = baksmali.Disassemble(inputFile, outputDir);
                    if (code == 0)
                    {
                        textBox_BUILD_InputProjectDir.BeginInvoke(new Action(delegate
                        {
                            smaliBrowseInputDirTxtBox.Text = outputDir;
                        }));
                        ToLog(ApktoolEventType.None, String.Format(Language.DecompilingSuccessfullyCompleted, outputDir));
                    }
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorDecompiling);
                });
                Done(printTimer: true);
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
            smali = new Smali(JavaUtils.GetJavaPath(), Program.SMALI_PATH);
            smali.SmaliOutputDataRecieved += SmaliOutputDataRecieved;
            smali.SmaliErrorDataRecieved += SmaliErrorDataRecieved;
        }

        void SmaliErrorDataRecieved(object sender, SmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void SmaliOutputDataRecieved(object sender, SmaliDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.None, e.Message);
        }

        internal async Task<int> Smali(string inputDir)
        {
            int code = 0;
            try
            {
                Running();

                ToLog(ApktoolEventType.Infomation, "=====[ " + Language.CompilingDex + " ]=====");
                ToLog(ApktoolEventType.None, String.Format(Language.InputDirectory, inputDir));
                ToStatus(String.Format(Language.DecompilingDex + "...", Path.GetFileName(smaliBrowseInputDirTxtBox.Text)), Resources.waiting);

                await Task.Factory.StartNew(() =>
                {
                    string outputDir = String.Format("{0}.dex", inputDir);
                    if (Settings.Default.Smali_UseOutputDir && !IgnoreOutputDirContextMenu)
                        outputDir = String.Format("{0}.dex", Path.Combine(Settings.Default.Smali_OutputDir, Path.GetFileNameWithoutExtension(inputDir)));

                    code = smali.Assemble(inputDir, outputDir);
                    if (code == 0)
                        ToLog(ApktoolEventType.None, String.Format(Language.CompilingSuccessfullyCompleted, outputDir));
                    else
                        ToLog(ApktoolEventType.Error, Language.ErrorCompiling);
                });
                Done(printTimer: true);
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
            ToLog(ApktoolEventType.None, e.Data);
        }

        void zipalign_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Data);
        }

        internal async Task<int> Align(string inputFile)
        {
            int code = 0;

            Running();

            string outputDir = inputFile;
            if (Settings.Default.Zipalign_UseOutputDir && !IgnoreOutputDirContextMenu)
                outputDir = Path.Combine(Settings.Default.Zipalign_OutputDir, Path.GetFileName(inputFile));

            if (!Settings.Default.Zipalign_OverwriteOutputFile)
                outputDir = PathUtils.GetDirectoryNameWithoutExtension(outputDir) + " aligned.apk";

            ToLog(ApktoolEventType.Infomation, "=====[ " + Language.Aligning + " ]=====");
            ToLog(ApktoolEventType.None, String.Format(Language.InputFile, inputFile));
            ToStatus(String.Format(Language.Aligning + " \"{0}\"...", Path.GetFileName(inputFile)), Resources.waiting);

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    string tempApk = Path.Combine(Program.TEMP_PATH, "tempapk.apk");
                    string outputApkFile = outputDir;

                    if (Settings.Default.Utf8FilenameSupport)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.CopyFileToTemp, inputFile, tempApk));
                        FileUtils.Copy(inputFile, tempApk, true);
                        inputFile = tempApk;
                        outputDir = tempApk;
                    }

                    code = zipalign.Align(inputFile, outputDir);
                    if (code == 0)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.ZipalignFileSavedTo, outputDir));
                        if (Settings.Default.Utf8FilenameSupport)
                        {
                            ToLog(ApktoolEventType.None, String.Format(Language.MoveTempApkToOutput, tempApk, outputApkFile));
                            FileUtils.Move(tempApk, outputApkFile, true);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.Message);
            }

            Done(printTimer: true);

            return code;
        }
        #endregion

        #region Signapk
        private void InitializeSignapk()
        {
            signapk = new Signapk(JavaUtils.GetJavaPath(), Program.APKSIGNER_PATH);
            signapk.SignapkOutputDataRecieved += SignApkOutputDataRecieved;
            signapk.SignapkErrorDataRecieved += SignApkErrorDataRecieved;
        }

        void SignApkErrorDataRecieved(object sender, SignapkDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.Error, e.Message);
        }

        void SignApkOutputDataRecieved(object sender, SignapkDataReceivedEventArgs e)
        {
            ToLog(ApktoolEventType.None, e.Message);
        }

        internal async Task<int> Sign(string input)
        {
            int code = 0;

            Running();

            string outputDir = input;
            if (Settings.Default.Zipalign_UseOutputDir && !IgnoreOutputDirContextMenu)
                outputDir = Path.Combine(Settings.Default.Sign_OutputDir, Path.GetFileName(input));
            if (!Settings.Default.Sign_OverwriteInputFile)
                outputDir = PathUtils.GetDirectoryNameWithoutExtension(outputDir) + "_signed.apk";

            string tempApk = Path.Combine(Program.TEMP_PATH, "tempapk.apk");
            string outputApkFile = outputDir;

            ToLog(ApktoolEventType.Infomation, "=====[ " + Language.Signing + " ]=====");
            ToLog(ApktoolEventType.None, String.Format(Language.InputFile, input));
            ToStatus(String.Format(Language.Signing + " \"{0}\"...", Path.GetFileName(input)), Resources.waiting);

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    if (Settings.Default.Utf8FilenameSupport)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.CopyFileToTemp, input, tempApk));
                        FileUtils.Copy(input, tempApk, true);
                        input = tempApk;
                        outputDir = tempApk;
                    }

                    code = signapk.Sign(input, outputDir);

                    if (code == 0)
                    {
                        ToLog(ApktoolEventType.None, String.Format(Language.SignSuccessfullyCompleted, outputDir));

                        if (Settings.Default.AutoDeleteIdsigFile)
                        {
                            ToLog(ApktoolEventType.None, String.Format(Language.DeleteFile, outputDir + ".idsig"));
                            FileUtils.Delete(outputDir + ".idsig");
                        }

                        if (Settings.Default.Utf8FilenameSupport)
                        {
                            ToLog(ApktoolEventType.None, String.Format(Language.MoveTempApkToOutput, tempApk, outputApkFile));
                            FileUtils.Move(tempApk, outputApkFile, true);
                        }
                    }
                    else
                        ToLog(ApktoolEventType.Error, String.Format(Language.ErrorSigning, outputDir));
                });
            }
            catch (Exception ex)
            {
                code = 1;
                ToLog(ApktoolEventType.Error, ex.Message);
            }

            Done(printTimer: true);

            return code;
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
                    File.WriteAllText(sfd.FileName, logTxtBox.Text);
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

        private void openTempFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", Program.TEMP_PATH);
            }
            catch (Exception ex)
            {
                ToLog(ApktoolEventType.Error, ex.Message);
            }
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

        private void apktoolIssuesLinkItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iBotPeaches/Apktool/issues?q=is%3Aissue");
        }

        private void baksmaliIssuesLinkItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JesusFreke/smali/issues?q=is%3Aissue");
        }
        #endregion

        #region Form handlers
        private void logTxtBox_TextChanged(object sender, EventArgs e)
        {
            logTxtBox.SelectionStart = logTxtBox.Text.Length;
            logTxtBox.ScrollToCaret();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (!isRunning)
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Save();

            //Clear temp folder
            DirectoryUtils.Delete(Program.TEMP_PATH);
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

        #region Cancel
        private void toolStripStatusLabelStateText_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.CancelProcess, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                CancelProcess();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.CancelProcess, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                CancelProcess();
        }

        private void CancelProcess()
        {
            try
            {
                ToStatus(Language.PleaseWait, Resources.waiting);

                apkeditor.Cancel();
                apktool.Cancel();
                baksmali.Cancel();
                smali.Cancel();
                zipalign.Cancel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ActionButtonsEnabled = true;
            }
        }
        #endregion
    }
}