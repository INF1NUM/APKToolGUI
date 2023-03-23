namespace APKToolGUI
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.comApkOpenDir = new System.Windows.Forms.Button();
            this.decOutOpenDirBtn = new System.Windows.Forms.Button();
            this.signApkOpenDirBtn = new System.Windows.Forms.Button();
            this.alignApkOpenDirBtn = new System.Windows.Forms.Button();
            this.decApkOpenDirBtn = new System.Windows.Forms.Button();
            this.compileOutputOpenDirBtn = new System.Windows.Forms.Button();
            this.button_OpenMainActivity = new System.Windows.Forms.Button();
            this.openApktoolYmlBtn = new System.Windows.Forms.Button();
            this.openAndroidMainfestBtn = new System.Windows.Forms.Button();
            this.signPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_SIGN_InputFile = new System.Windows.Forms.TextBox();
            this.button_SIGN_BrowseInputFile = new System.Windows.Forms.Button();
            this.button_SIGN_Sign = new System.Windows.Forms.Button();
            this.zipalignPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ZIPALIGN_Align = new System.Windows.Forms.Button();
            this.button_ZIPALIGN_BrowseInputFile = new System.Windows.Forms.Button();
            this.textBox_ZIPALIGN_InputFile = new System.Windows.Forms.TextBox();
            this.comPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button_BUILD_BrowseInputProjectDir = new System.Windows.Forms.Button();
            this.button_BUILD_Build = new System.Windows.Forms.Button();
            this.textBox_BUILD_InputProjectDir = new System.Windows.Forms.TextBox();
            this.decPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_DECODE_InputAppPath = new System.Windows.Forms.TextBox();
            this.button_DECODE_Decode = new System.Windows.Forms.Button();
            this.button_DECODE_BrowseInputAppPath = new System.Windows.Forms.Button();
            this.tabPageApkInfo = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.basicInfoTabPage = new System.Windows.Forms.TabPage();
            this.launchActivityTxtBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.archSdkTxtBox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.apkDlLinkBtn = new System.Windows.Forms.Button();
            this.apkSosLinkBtn = new System.Windows.Forms.Button();
            this.apkMirrorLinkBtn = new System.Windows.Forms.Button();
            this.apkSupportLinkBtn = new System.Windows.Forms.Button();
            this.apkGkLinkBtn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.localsTxtBox = new System.Windows.Forms.RichTextBox();
            this.selApkFileInfoBtn = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.appTxtBox = new System.Windows.Forms.TextBox();
            this.permTxtBox = new System.Windows.Forms.RichTextBox();
            this.apkComboLinkBtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.fileTxtBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.densityTxtBox = new System.Windows.Forms.TextBox();
            this.apkAioLinkBtn = new System.Windows.Forms.Button();
            this.packNameTxtBox = new System.Windows.Forms.TextBox();
            this.apkPureLinkBtn = new System.Windows.Forms.Button();
            this.verTxtBox = new System.Windows.Forms.TextBox();
            this.psLinkBtn = new System.Windows.Forms.Button();
            this.minSdkTxtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.targetSdkTxtBox = new System.Windows.Forms.TextBox();
            this.screenTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buildTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.apkIconPicBox = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fullInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPageDecode = new System.Windows.Forms.TabPage();
            this.groupBox_DECODE_Options = new System.Windows.Forms.GroupBox();
            this.checkBox_DECODE_UseApkEditorMerge = new System.Windows.Forms.CheckBox();
            this.decApiLvlUpDown = new System.Windows.Forms.NumericUpDown();
            this.decSetApiLvlChkBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_DECODE_FixError = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_OnlyMainClasses = new System.Windows.Forms.CheckBox();
            this.textBox_DECODE_FrameDir = new System.Windows.Forms.TextBox();
            this.button_DECODE_BrowseOutputDirectory = new System.Windows.Forms.Button();
            this.checkBox_DECODE_UseFramework = new System.Windows.Forms.CheckBox();
            this.button_DECODE_BrowseFrameDir = new System.Windows.Forms.Button();
            this.checkBox_DECODE_MatchOriginal = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_OutputDirectory = new System.Windows.Forms.CheckBox();
            this.textBox_DECODE_OutputDirectory = new System.Windows.Forms.TextBox();
            this.checkBox_DECODE_KeepBrokenRes = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_NoSrc = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_Force = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_NoRes = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_NoDebugInfo = new System.Windows.Forms.CheckBox();
            this.tabPageBuild = new System.Windows.Forms.TabPage();
            this.groupBox_BUILD_Options = new System.Windows.Forms.GroupBox();
            this.useAapt2ChkBox = new System.Windows.Forms.CheckBox();
            this.buildApiLvlUpDown = new System.Windows.Forms.NumericUpDown();
            this.buildSetApiLvlChkBox = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.createUnsignApkChkBox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.signAfterBuildChkBox = new System.Windows.Forms.CheckBox();
            this.zipalignAfterBuildChkBox = new System.Windows.Forms.CheckBox();
            this.checkBox_BUILD_NoCrunch = new System.Windows.Forms.CheckBox();
            this.button_BUILD_BrowseOutputAppPath = new System.Windows.Forms.Button();
            this.checkBox_BUILD_ForceAll = new System.Windows.Forms.CheckBox();
            this.button_BUILD_BrowseFrameDir = new System.Windows.Forms.Button();
            this.button_BUILD_BrowseAaptPath = new System.Windows.Forms.Button();
            this.checkBox_BUILD_OutputAppPath = new System.Windows.Forms.CheckBox();
            this.checkBox_BUILD_CopyOriginal = new System.Windows.Forms.CheckBox();
            this.textBox_BUILD_OutputAppPath = new System.Windows.Forms.TextBox();
            this.checkBox_BUILD_UseAapt = new System.Windows.Forms.CheckBox();
            this.textBox_BUILD_AaptPath = new System.Windows.Forms.TextBox();
            this.textBox_BUILD_FrameDir = new System.Windows.Forms.TextBox();
            this.checkBox_BUILD_UseFramework = new System.Windows.Forms.CheckBox();
            this.tabPageSign = new System.Windows.Forms.TabPage();
            this.groupBox_SIGN_Options = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.autoDelIdsigChkBox = new System.Windows.Forms.CheckBox();
            this.schemev4ComboBox = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.schemev3ComboBox = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.schemev2ComboBox = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.schemev1ComboBox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.selectKeyStoreFileBtn = new System.Windows.Forms.Button();
            this.aliasTxtBox = new System.Windows.Forms.TextBox();
            this.useAliasChkBox = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.keyStoreFileTxtBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.useKeyStoreChkBox = new System.Windows.Forms.CheckBox();
            this.useSigningOutputDir = new System.Windows.Forms.CheckBox();
            this.label_SIGN_PrivateKey = new System.Windows.Forms.Label();
            this.label_SIGN_PublicKey = new System.Windows.Forms.Label();
            this.button_SIGN_BrowseOutputFile = new System.Windows.Forms.Button();
            this.textBox_SIGN_OutputFile = new System.Windows.Forms.TextBox();
            this.button_SIGN_BrowsePublicKey = new System.Windows.Forms.Button();
            this.button_SIGN_BrowsePrivateKey = new System.Windows.Forms.Button();
            this.textBox_SIGN_PublicKey = new System.Windows.Forms.TextBox();
            this.textBox_SIGN_PrivateKey = new System.Windows.Forms.TextBox();
            this.tabPageZipAlign = new System.Windows.Forms.TabPage();
            this.groupBox_ZIPALIGN_Options = new System.Windows.Forms.GroupBox();
            this.zipalignOutputDirChkBox = new System.Windows.Forms.CheckBox();
            this.signAfterZipalignChkBox = new System.Windows.Forms.CheckBox();
            this.checkBox_ZIPALIGN_Recompress = new System.Windows.Forms.CheckBox();
            this.label_ZIPALIGN_AlignmentBytes = new System.Windows.Forms.Label();
            this.button_ZIPALIGN_BrowseOutputFile = new System.Windows.Forms.Button();
            this.checkBox_ZIPALIGN_CheckAlignment = new System.Windows.Forms.CheckBox();
            this.textBox_ZIPALIGN_OutputFile = new System.Windows.Forms.TextBox();
            this.checkBox_ZIPALIGN_VerboseOutput = new System.Windows.Forms.CheckBox();
            this.numericUpDown_ZIPALIGN_AlignmentBytes = new System.Windows.Forms.NumericUpDown();
            this.checkBox_ZIPALIGN_OverwriteOutputFile = new System.Windows.Forms.CheckBox();
            this.tabPageInstallFramework = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFwFolderBtn = new System.Windows.Forms.Button();
            this.clearFwBtn = new System.Windows.Forms.Button();
            this.clearFwBeforeDecodeChkBox = new System.Windows.Forms.CheckBox();
            this.groupBox_IF_Options = new System.Windows.Forms.GroupBox();
            this.checkBox_IF_Tag = new System.Windows.Forms.CheckBox();
            this.checkBox_IF_FramePath = new System.Windows.Forms.CheckBox();
            this.textBox_IF_Tag = new System.Windows.Forms.TextBox();
            this.button_IF_InstallFramework = new System.Windows.Forms.Button();
            this.button_IF_BrowseFrameDir = new System.Windows.Forms.Button();
            this.button_IF_BrowseInputFramePath = new System.Windows.Forms.Button();
            this.textBox_IF_InputFramePath = new System.Windows.Forms.TextBox();
            this.textBox_IF_FrameDir = new System.Windows.Forms.TextBox();
            this.tabPageBaksmali = new System.Windows.Forms.TabPage();
            this.smaliGroupBox = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.smaliUseOutputChkBox = new System.Windows.Forms.CheckBox();
            this.comSmaliBtn = new System.Windows.Forms.Button();
            this.smaliBrowseOutputBtn = new System.Windows.Forms.Button();
            this.smaliBrowseInputDirTxtBox = new System.Windows.Forms.TextBox();
            this.smaliBrowseOutputTxtBox = new System.Windows.Forms.TextBox();
            this.smaliBrowseInputDirBtn = new System.Windows.Forms.Button();
            this.bakSmaliGroupBox = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.baksmaliUseOutputChkBox = new System.Windows.Forms.CheckBox();
            this.baksmaliBrowseOutputBtn = new System.Windows.Forms.Button();
            this.baksmaliBrowseOutputTxtBox = new System.Windows.Forms.TextBox();
            this.decSmaliBtn = new System.Windows.Forms.Button();
            this.baksmaliBrowseInputDexBtn = new System.Windows.Forms.Button();
            this.baksmaliBrowseInputDexTxtBox = new System.Windows.Forms.TextBox();
            this.tabPageAdb = new System.Windows.Forms.TabPage();
            this.selAdbDeviceLbl = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.killAdbBtn = new System.Windows.Forms.Button();
            this.installApkBtn = new System.Windows.Forms.Button();
            this.refreshDevicesBtn = new System.Windows.Forms.Button();
            this.setVendorChkBox = new System.Windows.Forms.CheckBox();
            this.selApkAdbBtn = new System.Windows.Forms.Button();
            this.apkPathAdbTxtBox = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.devicesListBox = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStateImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStateText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logTxtBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTempFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportAnIsuueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apktoolIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baksmaliIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.signPanel.SuspendLayout();
            this.zipalignPanel.SuspendLayout();
            this.comPanel.SuspendLayout();
            this.decPanel.SuspendLayout();
            this.tabPageApkInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.basicInfoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apkIconPicBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPageDecode.SuspendLayout();
            this.groupBox_DECODE_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decApiLvlUpDown)).BeginInit();
            this.tabPageBuild.SuspendLayout();
            this.groupBox_BUILD_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buildApiLvlUpDown)).BeginInit();
            this.tabPageSign.SuspendLayout();
            this.groupBox_SIGN_Options.SuspendLayout();
            this.tabPageZipAlign.SuspendLayout();
            this.groupBox_ZIPALIGN_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZIPALIGN_AlignmentBytes)).BeginInit();
            this.tabPageInstallFramework.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_IF_Options.SuspendLayout();
            this.tabPageBaksmali.SuspendLayout();
            this.smaliGroupBox.SuspendLayout();
            this.bakSmaliGroupBox.SuspendLayout();
            this.tabPageAdb.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripLog.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.AllowDrop = true;
            this.tabControlMain.Controls.Add(this.tabPageMain);
            this.tabControlMain.Controls.Add(this.tabPageApkInfo);
            this.tabControlMain.Controls.Add(this.tabPageDecode);
            this.tabControlMain.Controls.Add(this.tabPageBuild);
            this.tabControlMain.Controls.Add(this.tabPageSign);
            this.tabControlMain.Controls.Add(this.tabPageZipAlign);
            this.tabControlMain.Controls.Add(this.tabPageInstallFramework);
            this.tabControlMain.Controls.Add(this.tabPageBaksmali);
            this.tabControlMain.Controls.Add(this.tabPageAdb);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.toolTip1.SetToolTip(this.tabControlMain, resources.GetString("tabControlMain.ToolTip"));
            // 
            // tabPageMain
            // 
            resources.ApplyResources(this.tabPageMain, "tabPageMain");
            this.tabPageMain.BackColor = System.Drawing.Color.White;
            this.tabPageMain.Controls.Add(this.comApkOpenDir);
            this.tabPageMain.Controls.Add(this.decOutOpenDirBtn);
            this.tabPageMain.Controls.Add(this.signApkOpenDirBtn);
            this.tabPageMain.Controls.Add(this.alignApkOpenDirBtn);
            this.tabPageMain.Controls.Add(this.decApkOpenDirBtn);
            this.tabPageMain.Controls.Add(this.compileOutputOpenDirBtn);
            this.tabPageMain.Controls.Add(this.button_OpenMainActivity);
            this.tabPageMain.Controls.Add(this.openApktoolYmlBtn);
            this.tabPageMain.Controls.Add(this.openAndroidMainfestBtn);
            this.tabPageMain.Controls.Add(this.signPanel);
            this.tabPageMain.Controls.Add(this.zipalignPanel);
            this.tabPageMain.Controls.Add(this.comPanel);
            this.tabPageMain.Controls.Add(this.decPanel);
            this.tabPageMain.Name = "tabPageMain";
            this.toolTip1.SetToolTip(this.tabPageMain, resources.GetString("tabPageMain.ToolTip"));
            // 
            // comApkOpenDir
            // 
            resources.ApplyResources(this.comApkOpenDir, "comApkOpenDir");
            this.comApkOpenDir.Name = "comApkOpenDir";
            this.toolTip1.SetToolTip(this.comApkOpenDir, resources.GetString("comApkOpenDir.ToolTip"));
            this.comApkOpenDir.UseVisualStyleBackColor = true;
            // 
            // decOutOpenDirBtn
            // 
            resources.ApplyResources(this.decOutOpenDirBtn, "decOutOpenDirBtn");
            this.decOutOpenDirBtn.Name = "decOutOpenDirBtn";
            this.toolTip1.SetToolTip(this.decOutOpenDirBtn, resources.GetString("decOutOpenDirBtn.ToolTip"));
            this.decOutOpenDirBtn.UseVisualStyleBackColor = true;
            // 
            // signApkOpenDirBtn
            // 
            resources.ApplyResources(this.signApkOpenDirBtn, "signApkOpenDirBtn");
            this.signApkOpenDirBtn.Name = "signApkOpenDirBtn";
            this.toolTip1.SetToolTip(this.signApkOpenDirBtn, resources.GetString("signApkOpenDirBtn.ToolTip"));
            this.signApkOpenDirBtn.UseVisualStyleBackColor = true;
            // 
            // alignApkOpenDirBtn
            // 
            resources.ApplyResources(this.alignApkOpenDirBtn, "alignApkOpenDirBtn");
            this.alignApkOpenDirBtn.Name = "alignApkOpenDirBtn";
            this.toolTip1.SetToolTip(this.alignApkOpenDirBtn, resources.GetString("alignApkOpenDirBtn.ToolTip"));
            this.alignApkOpenDirBtn.UseVisualStyleBackColor = true;
            // 
            // decApkOpenDirBtn
            // 
            resources.ApplyResources(this.decApkOpenDirBtn, "decApkOpenDirBtn");
            this.decApkOpenDirBtn.Name = "decApkOpenDirBtn";
            this.toolTip1.SetToolTip(this.decApkOpenDirBtn, resources.GetString("decApkOpenDirBtn.ToolTip"));
            this.decApkOpenDirBtn.UseVisualStyleBackColor = true;
            // 
            // compileOutputOpenDirBtn
            // 
            resources.ApplyResources(this.compileOutputOpenDirBtn, "compileOutputOpenDirBtn");
            this.compileOutputOpenDirBtn.Name = "compileOutputOpenDirBtn";
            this.toolTip1.SetToolTip(this.compileOutputOpenDirBtn, resources.GetString("compileOutputOpenDirBtn.ToolTip"));
            this.compileOutputOpenDirBtn.UseVisualStyleBackColor = true;
            // 
            // button_OpenMainActivity
            // 
            resources.ApplyResources(this.button_OpenMainActivity, "button_OpenMainActivity");
            this.button_OpenMainActivity.Name = "button_OpenMainActivity";
            this.toolTip1.SetToolTip(this.button_OpenMainActivity, resources.GetString("button_OpenMainActivity.ToolTip"));
            this.button_OpenMainActivity.UseVisualStyleBackColor = true;
            // 
            // openApktoolYmlBtn
            // 
            resources.ApplyResources(this.openApktoolYmlBtn, "openApktoolYmlBtn");
            this.openApktoolYmlBtn.Name = "openApktoolYmlBtn";
            this.toolTip1.SetToolTip(this.openApktoolYmlBtn, resources.GetString("openApktoolYmlBtn.ToolTip"));
            this.openApktoolYmlBtn.UseVisualStyleBackColor = true;
            // 
            // openAndroidMainfestBtn
            // 
            resources.ApplyResources(this.openAndroidMainfestBtn, "openAndroidMainfestBtn");
            this.openAndroidMainfestBtn.Name = "openAndroidMainfestBtn";
            this.toolTip1.SetToolTip(this.openAndroidMainfestBtn, resources.GetString("openAndroidMainfestBtn.ToolTip"));
            this.openAndroidMainfestBtn.UseVisualStyleBackColor = true;
            // 
            // signPanel
            // 
            resources.ApplyResources(this.signPanel, "signPanel");
            this.signPanel.AllowDrop = true;
            this.signPanel.Controls.Add(this.label4);
            this.signPanel.Controls.Add(this.textBox_SIGN_InputFile);
            this.signPanel.Controls.Add(this.button_SIGN_BrowseInputFile);
            this.signPanel.Controls.Add(this.button_SIGN_Sign);
            this.signPanel.Name = "signPanel";
            this.toolTip1.SetToolTip(this.signPanel, resources.GetString("signPanel.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // textBox_SIGN_InputFile
            // 
            resources.ApplyResources(this.textBox_SIGN_InputFile, "textBox_SIGN_InputFile");
            this.textBox_SIGN_InputFile.AllowDrop = true;
            this.textBox_SIGN_InputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_InputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_SIGN_InputFile.Name = "textBox_SIGN_InputFile";
            this.textBox_SIGN_InputFile.Text = global::APKToolGUI.Properties.Settings.Default.Sign_InputFile;
            this.toolTip1.SetToolTip(this.textBox_SIGN_InputFile, resources.GetString("textBox_SIGN_InputFile.ToolTip"));
            // 
            // button_SIGN_BrowseInputFile
            // 
            resources.ApplyResources(this.button_SIGN_BrowseInputFile, "button_SIGN_BrowseInputFile");
            this.button_SIGN_BrowseInputFile.Name = "button_SIGN_BrowseInputFile";
            this.toolTip1.SetToolTip(this.button_SIGN_BrowseInputFile, resources.GetString("button_SIGN_BrowseInputFile.ToolTip"));
            this.button_SIGN_BrowseInputFile.UseVisualStyleBackColor = true;
            // 
            // button_SIGN_Sign
            // 
            resources.ApplyResources(this.button_SIGN_Sign, "button_SIGN_Sign");
            this.button_SIGN_Sign.AllowDrop = true;
            this.button_SIGN_Sign.Name = "button_SIGN_Sign";
            this.toolTip1.SetToolTip(this.button_SIGN_Sign, resources.GetString("button_SIGN_Sign.ToolTip"));
            this.button_SIGN_Sign.UseVisualStyleBackColor = true;
            // 
            // zipalignPanel
            // 
            resources.ApplyResources(this.zipalignPanel, "zipalignPanel");
            this.zipalignPanel.AllowDrop = true;
            this.zipalignPanel.Controls.Add(this.label3);
            this.zipalignPanel.Controls.Add(this.button_ZIPALIGN_Align);
            this.zipalignPanel.Controls.Add(this.button_ZIPALIGN_BrowseInputFile);
            this.zipalignPanel.Controls.Add(this.textBox_ZIPALIGN_InputFile);
            this.zipalignPanel.Name = "zipalignPanel";
            this.toolTip1.SetToolTip(this.zipalignPanel, resources.GetString("zipalignPanel.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // button_ZIPALIGN_Align
            // 
            resources.ApplyResources(this.button_ZIPALIGN_Align, "button_ZIPALIGN_Align");
            this.button_ZIPALIGN_Align.AllowDrop = true;
            this.button_ZIPALIGN_Align.Name = "button_ZIPALIGN_Align";
            this.toolTip1.SetToolTip(this.button_ZIPALIGN_Align, resources.GetString("button_ZIPALIGN_Align.ToolTip"));
            this.button_ZIPALIGN_Align.UseVisualStyleBackColor = true;
            // 
            // button_ZIPALIGN_BrowseInputFile
            // 
            resources.ApplyResources(this.button_ZIPALIGN_BrowseInputFile, "button_ZIPALIGN_BrowseInputFile");
            this.button_ZIPALIGN_BrowseInputFile.Name = "button_ZIPALIGN_BrowseInputFile";
            this.toolTip1.SetToolTip(this.button_ZIPALIGN_BrowseInputFile, resources.GetString("button_ZIPALIGN_BrowseInputFile.ToolTip"));
            this.button_ZIPALIGN_BrowseInputFile.UseVisualStyleBackColor = true;
            // 
            // textBox_ZIPALIGN_InputFile
            // 
            resources.ApplyResources(this.textBox_ZIPALIGN_InputFile, "textBox_ZIPALIGN_InputFile");
            this.textBox_ZIPALIGN_InputFile.AllowDrop = true;
            this.textBox_ZIPALIGN_InputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Zipalign_InputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_ZIPALIGN_InputFile.Name = "textBox_ZIPALIGN_InputFile";
            this.textBox_ZIPALIGN_InputFile.Text = global::APKToolGUI.Properties.Settings.Default.Zipalign_InputFile;
            this.toolTip1.SetToolTip(this.textBox_ZIPALIGN_InputFile, resources.GetString("textBox_ZIPALIGN_InputFile.ToolTip"));
            // 
            // comPanel
            // 
            resources.ApplyResources(this.comPanel, "comPanel");
            this.comPanel.AllowDrop = true;
            this.comPanel.Controls.Add(this.label2);
            this.comPanel.Controls.Add(this.button_BUILD_BrowseInputProjectDir);
            this.comPanel.Controls.Add(this.button_BUILD_Build);
            this.comPanel.Controls.Add(this.textBox_BUILD_InputProjectDir);
            this.comPanel.Name = "comPanel";
            this.toolTip1.SetToolTip(this.comPanel, resources.GetString("comPanel.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // button_BUILD_BrowseInputProjectDir
            // 
            resources.ApplyResources(this.button_BUILD_BrowseInputProjectDir, "button_BUILD_BrowseInputProjectDir");
            this.button_BUILD_BrowseInputProjectDir.Name = "button_BUILD_BrowseInputProjectDir";
            this.toolTip1.SetToolTip(this.button_BUILD_BrowseInputProjectDir, resources.GetString("button_BUILD_BrowseInputProjectDir.ToolTip"));
            this.button_BUILD_BrowseInputProjectDir.UseVisualStyleBackColor = true;
            // 
            // button_BUILD_Build
            // 
            resources.ApplyResources(this.button_BUILD_Build, "button_BUILD_Build");
            this.button_BUILD_Build.AllowDrop = true;
            this.button_BUILD_Build.Name = "button_BUILD_Build";
            this.toolTip1.SetToolTip(this.button_BUILD_Build, resources.GetString("button_BUILD_Build.ToolTip"));
            this.button_BUILD_Build.UseVisualStyleBackColor = true;
            // 
            // textBox_BUILD_InputProjectDir
            // 
            resources.ApplyResources(this.textBox_BUILD_InputProjectDir, "textBox_BUILD_InputProjectDir");
            this.textBox_BUILD_InputProjectDir.AllowDrop = true;
            this.textBox_BUILD_InputProjectDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Build_InputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_InputProjectDir.Name = "textBox_BUILD_InputProjectDir";
            this.textBox_BUILD_InputProjectDir.Text = global::APKToolGUI.Properties.Settings.Default.Build_InputDir;
            this.toolTip1.SetToolTip(this.textBox_BUILD_InputProjectDir, resources.GetString("textBox_BUILD_InputProjectDir.ToolTip"));
            // 
            // decPanel
            // 
            resources.ApplyResources(this.decPanel, "decPanel");
            this.decPanel.AllowDrop = true;
            this.decPanel.BackColor = System.Drawing.Color.White;
            this.decPanel.Controls.Add(this.label1);
            this.decPanel.Controls.Add(this.textBox_DECODE_InputAppPath);
            this.decPanel.Controls.Add(this.button_DECODE_Decode);
            this.decPanel.Controls.Add(this.button_DECODE_BrowseInputAppPath);
            this.decPanel.Name = "decPanel";
            this.toolTip1.SetToolTip(this.decPanel, resources.GetString("decPanel.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // textBox_DECODE_InputAppPath
            // 
            resources.ApplyResources(this.textBox_DECODE_InputAppPath, "textBox_DECODE_InputAppPath");
            this.textBox_DECODE_InputAppPath.AllowDrop = true;
            this.textBox_DECODE_InputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Decode_InputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_InputAppPath.Name = "textBox_DECODE_InputAppPath";
            this.textBox_DECODE_InputAppPath.Text = global::APKToolGUI.Properties.Settings.Default.Decode_InputAppPath;
            this.toolTip1.SetToolTip(this.textBox_DECODE_InputAppPath, resources.GetString("textBox_DECODE_InputAppPath.ToolTip"));
            // 
            // button_DECODE_Decode
            // 
            resources.ApplyResources(this.button_DECODE_Decode, "button_DECODE_Decode");
            this.button_DECODE_Decode.AllowDrop = true;
            this.button_DECODE_Decode.Name = "button_DECODE_Decode";
            this.toolTip1.SetToolTip(this.button_DECODE_Decode, resources.GetString("button_DECODE_Decode.ToolTip"));
            this.button_DECODE_Decode.UseVisualStyleBackColor = true;
            // 
            // button_DECODE_BrowseInputAppPath
            // 
            resources.ApplyResources(this.button_DECODE_BrowseInputAppPath, "button_DECODE_BrowseInputAppPath");
            this.button_DECODE_BrowseInputAppPath.Name = "button_DECODE_BrowseInputAppPath";
            this.toolTip1.SetToolTip(this.button_DECODE_BrowseInputAppPath, resources.GetString("button_DECODE_BrowseInputAppPath.ToolTip"));
            this.button_DECODE_BrowseInputAppPath.UseVisualStyleBackColor = true;
            // 
            // tabPageApkInfo
            // 
            resources.ApplyResources(this.tabPageApkInfo, "tabPageApkInfo");
            this.tabPageApkInfo.AllowDrop = true;
            this.tabPageApkInfo.BackColor = System.Drawing.Color.White;
            this.tabPageApkInfo.Controls.Add(this.tabControl1);
            this.tabPageApkInfo.Name = "tabPageApkInfo";
            this.toolTip1.SetToolTip(this.tabPageApkInfo, resources.GetString("tabPageApkInfo.ToolTip"));
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.basicInfoTabPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.toolTip1.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // basicInfoTabPage
            // 
            resources.ApplyResources(this.basicInfoTabPage, "basicInfoTabPage");
            this.basicInfoTabPage.AllowDrop = true;
            this.basicInfoTabPage.Controls.Add(this.launchActivityTxtBox);
            this.basicInfoTabPage.Controls.Add(this.label31);
            this.basicInfoTabPage.Controls.Add(this.archSdkTxtBox);
            this.basicInfoTabPage.Controls.Add(this.label30);
            this.basicInfoTabPage.Controls.Add(this.apkDlLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.apkSosLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.apkMirrorLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.apkSupportLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.apkGkLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.label17);
            this.basicInfoTabPage.Controls.Add(this.localsTxtBox);
            this.basicInfoTabPage.Controls.Add(this.selApkFileInfoBtn);
            this.basicInfoTabPage.Controls.Add(this.label18);
            this.basicInfoTabPage.Controls.Add(this.appTxtBox);
            this.basicInfoTabPage.Controls.Add(this.permTxtBox);
            this.basicInfoTabPage.Controls.Add(this.apkComboLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.label15);
            this.basicInfoTabPage.Controls.Add(this.fileTxtBox);
            this.basicInfoTabPage.Controls.Add(this.label14);
            this.basicInfoTabPage.Controls.Add(this.densityTxtBox);
            this.basicInfoTabPage.Controls.Add(this.apkAioLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.packNameTxtBox);
            this.basicInfoTabPage.Controls.Add(this.apkPureLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.verTxtBox);
            this.basicInfoTabPage.Controls.Add(this.psLinkBtn);
            this.basicInfoTabPage.Controls.Add(this.minSdkTxtBox);
            this.basicInfoTabPage.Controls.Add(this.label19);
            this.basicInfoTabPage.Controls.Add(this.targetSdkTxtBox);
            this.basicInfoTabPage.Controls.Add(this.screenTxtBox);
            this.basicInfoTabPage.Controls.Add(this.label7);
            this.basicInfoTabPage.Controls.Add(this.label9);
            this.basicInfoTabPage.Controls.Add(this.buildTxtBox);
            this.basicInfoTabPage.Controls.Add(this.label8);
            this.basicInfoTabPage.Controls.Add(this.apkIconPicBox);
            this.basicInfoTabPage.Controls.Add(this.label11);
            this.basicInfoTabPage.Controls.Add(this.label10);
            this.basicInfoTabPage.Controls.Add(this.label13);
            this.basicInfoTabPage.Controls.Add(this.label12);
            this.basicInfoTabPage.Name = "basicInfoTabPage";
            this.toolTip1.SetToolTip(this.basicInfoTabPage, resources.GetString("basicInfoTabPage.ToolTip"));
            this.basicInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // launchActivityTxtBox
            // 
            resources.ApplyResources(this.launchActivityTxtBox, "launchActivityTxtBox");
            this.launchActivityTxtBox.Name = "launchActivityTxtBox";
            this.launchActivityTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.launchActivityTxtBox, resources.GetString("launchActivityTxtBox.ToolTip"));
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            this.toolTip1.SetToolTip(this.label31, resources.GetString("label31.ToolTip"));
            // 
            // archSdkTxtBox
            // 
            resources.ApplyResources(this.archSdkTxtBox, "archSdkTxtBox");
            this.archSdkTxtBox.Name = "archSdkTxtBox";
            this.archSdkTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.archSdkTxtBox, resources.GetString("archSdkTxtBox.ToolTip"));
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            this.toolTip1.SetToolTip(this.label30, resources.GetString("label30.ToolTip"));
            // 
            // apkDlLinkBtn
            // 
            resources.ApplyResources(this.apkDlLinkBtn, "apkDlLinkBtn");
            this.apkDlLinkBtn.Name = "apkDlLinkBtn";
            this.toolTip1.SetToolTip(this.apkDlLinkBtn, resources.GetString("apkDlLinkBtn.ToolTip"));
            this.apkDlLinkBtn.UseVisualStyleBackColor = true;
            // 
            // apkSosLinkBtn
            // 
            resources.ApplyResources(this.apkSosLinkBtn, "apkSosLinkBtn");
            this.apkSosLinkBtn.Name = "apkSosLinkBtn";
            this.toolTip1.SetToolTip(this.apkSosLinkBtn, resources.GetString("apkSosLinkBtn.ToolTip"));
            this.apkSosLinkBtn.UseVisualStyleBackColor = true;
            // 
            // apkMirrorLinkBtn
            // 
            resources.ApplyResources(this.apkMirrorLinkBtn, "apkMirrorLinkBtn");
            this.apkMirrorLinkBtn.Name = "apkMirrorLinkBtn";
            this.toolTip1.SetToolTip(this.apkMirrorLinkBtn, resources.GetString("apkMirrorLinkBtn.ToolTip"));
            this.apkMirrorLinkBtn.UseVisualStyleBackColor = true;
            // 
            // apkSupportLinkBtn
            // 
            resources.ApplyResources(this.apkSupportLinkBtn, "apkSupportLinkBtn");
            this.apkSupportLinkBtn.Name = "apkSupportLinkBtn";
            this.toolTip1.SetToolTip(this.apkSupportLinkBtn, resources.GetString("apkSupportLinkBtn.ToolTip"));
            this.apkSupportLinkBtn.UseVisualStyleBackColor = true;
            // 
            // apkGkLinkBtn
            // 
            resources.ApplyResources(this.apkGkLinkBtn, "apkGkLinkBtn");
            this.apkGkLinkBtn.Name = "apkGkLinkBtn";
            this.toolTip1.SetToolTip(this.apkGkLinkBtn, resources.GetString("apkGkLinkBtn.ToolTip"));
            this.apkGkLinkBtn.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            this.toolTip1.SetToolTip(this.label17, resources.GetString("label17.ToolTip"));
            // 
            // localsTxtBox
            // 
            resources.ApplyResources(this.localsTxtBox, "localsTxtBox");
            this.localsTxtBox.Name = "localsTxtBox";
            this.localsTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.localsTxtBox, resources.GetString("localsTxtBox.ToolTip"));
            // 
            // selApkFileInfoBtn
            // 
            resources.ApplyResources(this.selApkFileInfoBtn, "selApkFileInfoBtn");
            this.selApkFileInfoBtn.Name = "selApkFileInfoBtn";
            this.toolTip1.SetToolTip(this.selApkFileInfoBtn, resources.GetString("selApkFileInfoBtn.ToolTip"));
            this.selApkFileInfoBtn.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            this.toolTip1.SetToolTip(this.label18, resources.GetString("label18.ToolTip"));
            // 
            // appTxtBox
            // 
            resources.ApplyResources(this.appTxtBox, "appTxtBox");
            this.appTxtBox.Name = "appTxtBox";
            this.appTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.appTxtBox, resources.GetString("appTxtBox.ToolTip"));
            // 
            // permTxtBox
            // 
            resources.ApplyResources(this.permTxtBox, "permTxtBox");
            this.permTxtBox.Name = "permTxtBox";
            this.permTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.permTxtBox, resources.GetString("permTxtBox.ToolTip"));
            // 
            // apkComboLinkBtn
            // 
            resources.ApplyResources(this.apkComboLinkBtn, "apkComboLinkBtn");
            this.apkComboLinkBtn.Name = "apkComboLinkBtn";
            this.toolTip1.SetToolTip(this.apkComboLinkBtn, resources.GetString("apkComboLinkBtn.ToolTip"));
            this.apkComboLinkBtn.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            this.toolTip1.SetToolTip(this.label15, resources.GetString("label15.ToolTip"));
            // 
            // fileTxtBox
            // 
            resources.ApplyResources(this.fileTxtBox, "fileTxtBox");
            this.fileTxtBox.Name = "fileTxtBox";
            this.fileTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.fileTxtBox, resources.GetString("fileTxtBox.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            this.toolTip1.SetToolTip(this.label14, resources.GetString("label14.ToolTip"));
            // 
            // densityTxtBox
            // 
            resources.ApplyResources(this.densityTxtBox, "densityTxtBox");
            this.densityTxtBox.Name = "densityTxtBox";
            this.densityTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.densityTxtBox, resources.GetString("densityTxtBox.ToolTip"));
            // 
            // apkAioLinkBtn
            // 
            resources.ApplyResources(this.apkAioLinkBtn, "apkAioLinkBtn");
            this.apkAioLinkBtn.Name = "apkAioLinkBtn";
            this.toolTip1.SetToolTip(this.apkAioLinkBtn, resources.GetString("apkAioLinkBtn.ToolTip"));
            this.apkAioLinkBtn.UseVisualStyleBackColor = true;
            // 
            // packNameTxtBox
            // 
            resources.ApplyResources(this.packNameTxtBox, "packNameTxtBox");
            this.packNameTxtBox.Name = "packNameTxtBox";
            this.packNameTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.packNameTxtBox, resources.GetString("packNameTxtBox.ToolTip"));
            // 
            // apkPureLinkBtn
            // 
            resources.ApplyResources(this.apkPureLinkBtn, "apkPureLinkBtn");
            this.apkPureLinkBtn.Name = "apkPureLinkBtn";
            this.toolTip1.SetToolTip(this.apkPureLinkBtn, resources.GetString("apkPureLinkBtn.ToolTip"));
            this.apkPureLinkBtn.UseVisualStyleBackColor = true;
            // 
            // verTxtBox
            // 
            resources.ApplyResources(this.verTxtBox, "verTxtBox");
            this.verTxtBox.Name = "verTxtBox";
            this.verTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.verTxtBox, resources.GetString("verTxtBox.ToolTip"));
            // 
            // psLinkBtn
            // 
            resources.ApplyResources(this.psLinkBtn, "psLinkBtn");
            this.psLinkBtn.Name = "psLinkBtn";
            this.toolTip1.SetToolTip(this.psLinkBtn, resources.GetString("psLinkBtn.ToolTip"));
            this.psLinkBtn.UseVisualStyleBackColor = true;
            // 
            // minSdkTxtBox
            // 
            resources.ApplyResources(this.minSdkTxtBox, "minSdkTxtBox");
            this.minSdkTxtBox.Name = "minSdkTxtBox";
            this.minSdkTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.minSdkTxtBox, resources.GetString("minSdkTxtBox.ToolTip"));
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            this.toolTip1.SetToolTip(this.label19, resources.GetString("label19.ToolTip"));
            // 
            // targetSdkTxtBox
            // 
            resources.ApplyResources(this.targetSdkTxtBox, "targetSdkTxtBox");
            this.targetSdkTxtBox.Name = "targetSdkTxtBox";
            this.targetSdkTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.targetSdkTxtBox, resources.GetString("targetSdkTxtBox.ToolTip"));
            // 
            // screenTxtBox
            // 
            resources.ApplyResources(this.screenTxtBox, "screenTxtBox");
            this.screenTxtBox.Name = "screenTxtBox";
            this.screenTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.screenTxtBox, resources.GetString("screenTxtBox.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.toolTip1.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            this.toolTip1.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // buildTxtBox
            // 
            resources.ApplyResources(this.buildTxtBox, "buildTxtBox");
            this.buildTxtBox.Name = "buildTxtBox";
            this.buildTxtBox.ReadOnly = true;
            this.toolTip1.SetToolTip(this.buildTxtBox, resources.GetString("buildTxtBox.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            this.toolTip1.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // apkIconPicBox
            // 
            resources.ApplyResources(this.apkIconPicBox, "apkIconPicBox");
            this.apkIconPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apkIconPicBox.Name = "apkIconPicBox";
            this.apkIconPicBox.TabStop = false;
            this.toolTip1.SetToolTip(this.apkIconPicBox, resources.GetString("apkIconPicBox.ToolTip"));
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            this.toolTip1.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            this.toolTip1.SetToolTip(this.label10, resources.GetString("label10.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.toolTip1.SetToolTip(this.label13, resources.GetString("label13.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.toolTip1.SetToolTip(this.label12, resources.GetString("label12.ToolTip"));
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.fullInfoTextBox);
            this.tabPage3.Name = "tabPage3";
            this.toolTip1.SetToolTip(this.tabPage3, resources.GetString("tabPage3.ToolTip"));
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fullInfoTextBox
            // 
            resources.ApplyResources(this.fullInfoTextBox, "fullInfoTextBox");
            this.fullInfoTextBox.Name = "fullInfoTextBox";
            this.toolTip1.SetToolTip(this.fullInfoTextBox, resources.GetString("fullInfoTextBox.ToolTip"));
            // 
            // tabPageDecode
            // 
            resources.ApplyResources(this.tabPageDecode, "tabPageDecode");
            this.tabPageDecode.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageDecode.Controls.Add(this.groupBox_DECODE_Options);
            this.tabPageDecode.Name = "tabPageDecode";
            this.toolTip1.SetToolTip(this.tabPageDecode, resources.GetString("tabPageDecode.ToolTip"));
            // 
            // groupBox_DECODE_Options
            // 
            resources.ApplyResources(this.groupBox_DECODE_Options, "groupBox_DECODE_Options");
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_UseApkEditorMerge);
            this.groupBox_DECODE_Options.Controls.Add(this.decApiLvlUpDown);
            this.groupBox_DECODE_Options.Controls.Add(this.decSetApiLvlChkBox);
            this.groupBox_DECODE_Options.Controls.Add(this.label6);
            this.groupBox_DECODE_Options.Controls.Add(this.label5);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_FixError);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_OnlyMainClasses);
            this.groupBox_DECODE_Options.Controls.Add(this.textBox_DECODE_FrameDir);
            this.groupBox_DECODE_Options.Controls.Add(this.button_DECODE_BrowseOutputDirectory);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_UseFramework);
            this.groupBox_DECODE_Options.Controls.Add(this.button_DECODE_BrowseFrameDir);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_MatchOriginal);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_OutputDirectory);
            this.groupBox_DECODE_Options.Controls.Add(this.textBox_DECODE_OutputDirectory);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_KeepBrokenRes);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_NoSrc);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_Force);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_NoRes);
            this.groupBox_DECODE_Options.Controls.Add(this.checkBox_DECODE_NoDebugInfo);
            this.groupBox_DECODE_Options.Name = "groupBox_DECODE_Options";
            this.groupBox_DECODE_Options.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox_DECODE_Options, resources.GetString("groupBox_DECODE_Options.ToolTip"));
            // 
            // checkBox_DECODE_UseApkEditorMerge
            // 
            resources.ApplyResources(this.checkBox_DECODE_UseApkEditorMerge, "checkBox_DECODE_UseApkEditorMerge");
            this.checkBox_DECODE_UseApkEditorMerge.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_UseApkEditorMergeApk;
            this.checkBox_DECODE_UseApkEditorMerge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DECODE_UseApkEditorMerge.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_UseApkEditorMergeApk", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_UseApkEditorMerge.Name = "checkBox_DECODE_UseApkEditorMerge";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_UseApkEditorMerge, resources.GetString("checkBox_DECODE_UseApkEditorMerge.ToolTip"));
            this.checkBox_DECODE_UseApkEditorMerge.UseVisualStyleBackColor = true;
            // 
            // decApiLvlUpDown
            // 
            resources.ApplyResources(this.decApiLvlUpDown, "decApiLvlUpDown");
            this.decApiLvlUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::APKToolGUI.Properties.Settings.Default, "Decode_ApiLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.decApiLvlUpDown.Name = "decApiLvlUpDown";
            this.toolTip1.SetToolTip(this.decApiLvlUpDown, resources.GetString("decApiLvlUpDown.ToolTip"));
            this.decApiLvlUpDown.Value = global::APKToolGUI.Properties.Settings.Default.Decode_ApiLevel;
            // 
            // decSetApiLvlChkBox
            // 
            resources.ApplyResources(this.decSetApiLvlChkBox, "decSetApiLvlChkBox");
            this.decSetApiLvlChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_SetApiLevel;
            this.decSetApiLvlChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_SetApiLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.decSetApiLvlChkBox.Name = "decSetApiLvlChkBox";
            this.toolTip1.SetToolTip(this.decSetApiLvlChkBox, resources.GetString("decSetApiLvlChkBox.ToolTip"));
            this.decSetApiLvlChkBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Name = "label6";
            this.toolTip1.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Name = "label5";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // checkBox_DECODE_FixError
            // 
            resources.ApplyResources(this.checkBox_DECODE_FixError, "checkBox_DECODE_FixError");
            this.checkBox_DECODE_FixError.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_FixError;
            this.checkBox_DECODE_FixError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DECODE_FixError.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_FixError", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_FixError.Name = "checkBox_DECODE_FixError";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_FixError, resources.GetString("checkBox_DECODE_FixError.ToolTip"));
            this.checkBox_DECODE_FixError.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_OnlyMainClasses
            // 
            resources.ApplyResources(this.checkBox_DECODE_OnlyMainClasses, "checkBox_DECODE_OnlyMainClasses");
            this.checkBox_DECODE_OnlyMainClasses.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_OnlyMainClasses;
            this.checkBox_DECODE_OnlyMainClasses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DECODE_OnlyMainClasses.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_OnlyMainClasses", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_OnlyMainClasses.Name = "checkBox_DECODE_OnlyMainClasses";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_OnlyMainClasses, resources.GetString("checkBox_DECODE_OnlyMainClasses.ToolTip"));
            this.checkBox_DECODE_OnlyMainClasses.UseVisualStyleBackColor = true;
            // 
            // textBox_DECODE_FrameDir
            // 
            resources.ApplyResources(this.textBox_DECODE_FrameDir, "textBox_DECODE_FrameDir");
            this.textBox_DECODE_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Decode_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Framework_FrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_FrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.Decode_UseFramework;
            this.textBox_DECODE_FrameDir.Name = "textBox_DECODE_FrameDir";
            this.textBox_DECODE_FrameDir.Text = global::APKToolGUI.Properties.Settings.Default.Framework_FrameDir;
            this.toolTip1.SetToolTip(this.textBox_DECODE_FrameDir, resources.GetString("textBox_DECODE_FrameDir.ToolTip"));
            // 
            // button_DECODE_BrowseOutputDirectory
            // 
            resources.ApplyResources(this.button_DECODE_BrowseOutputDirectory, "button_DECODE_BrowseOutputDirectory");
            this.button_DECODE_BrowseOutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Decode_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_DECODE_BrowseOutputDirectory.Enabled = global::APKToolGUI.Properties.Settings.Default.Decode_UseOutputDir;
            this.button_DECODE_BrowseOutputDirectory.Name = "button_DECODE_BrowseOutputDirectory";
            this.toolTip1.SetToolTip(this.button_DECODE_BrowseOutputDirectory, resources.GetString("button_DECODE_BrowseOutputDirectory.ToolTip"));
            this.button_DECODE_BrowseOutputDirectory.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_UseFramework
            // 
            resources.ApplyResources(this.checkBox_DECODE_UseFramework, "checkBox_DECODE_UseFramework");
            this.checkBox_DECODE_UseFramework.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_UseFramework;
            this.checkBox_DECODE_UseFramework.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_UseFramework.Name = "checkBox_DECODE_UseFramework";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_UseFramework, resources.GetString("checkBox_DECODE_UseFramework.ToolTip"));
            this.checkBox_DECODE_UseFramework.UseVisualStyleBackColor = true;
            // 
            // button_DECODE_BrowseFrameDir
            // 
            resources.ApplyResources(this.button_DECODE_BrowseFrameDir, "button_DECODE_BrowseFrameDir");
            this.button_DECODE_BrowseFrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Decode_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_DECODE_BrowseFrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.Decode_UseFramework;
            this.button_DECODE_BrowseFrameDir.Name = "button_DECODE_BrowseFrameDir";
            this.toolTip1.SetToolTip(this.button_DECODE_BrowseFrameDir, resources.GetString("button_DECODE_BrowseFrameDir.ToolTip"));
            this.button_DECODE_BrowseFrameDir.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_MatchOriginal
            // 
            resources.ApplyResources(this.checkBox_DECODE_MatchOriginal, "checkBox_DECODE_MatchOriginal");
            this.checkBox_DECODE_MatchOriginal.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_MatchOriginal;
            this.checkBox_DECODE_MatchOriginal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_MatchOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_MatchOriginal.Name = "checkBox_DECODE_MatchOriginal";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_MatchOriginal, resources.GetString("checkBox_DECODE_MatchOriginal.ToolTip"));
            this.checkBox_DECODE_MatchOriginal.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_OutputDirectory
            // 
            resources.ApplyResources(this.checkBox_DECODE_OutputDirectory, "checkBox_DECODE_OutputDirectory");
            this.checkBox_DECODE_OutputDirectory.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_UseOutputDir;
            this.checkBox_DECODE_OutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_OutputDirectory.Name = "checkBox_DECODE_OutputDirectory";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_OutputDirectory, resources.GetString("checkBox_DECODE_OutputDirectory.ToolTip"));
            this.checkBox_DECODE_OutputDirectory.UseVisualStyleBackColor = true;
            // 
            // textBox_DECODE_OutputDirectory
            // 
            resources.ApplyResources(this.textBox_DECODE_OutputDirectory, "textBox_DECODE_OutputDirectory");
            this.textBox_DECODE_OutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Decode_OutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_OutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Decode_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_OutputDirectory.Enabled = global::APKToolGUI.Properties.Settings.Default.Decode_UseOutputDir;
            this.textBox_DECODE_OutputDirectory.Name = "textBox_DECODE_OutputDirectory";
            this.textBox_DECODE_OutputDirectory.Text = global::APKToolGUI.Properties.Settings.Default.Decode_OutputDir;
            this.toolTip1.SetToolTip(this.textBox_DECODE_OutputDirectory, resources.GetString("textBox_DECODE_OutputDirectory.ToolTip"));
            // 
            // checkBox_DECODE_KeepBrokenRes
            // 
            resources.ApplyResources(this.checkBox_DECODE_KeepBrokenRes, "checkBox_DECODE_KeepBrokenRes");
            this.checkBox_DECODE_KeepBrokenRes.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_KeepBrokenRes;
            this.checkBox_DECODE_KeepBrokenRes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_KeepBrokenRes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_KeepBrokenRes.Name = "checkBox_DECODE_KeepBrokenRes";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_KeepBrokenRes, resources.GetString("checkBox_DECODE_KeepBrokenRes.ToolTip"));
            this.checkBox_DECODE_KeepBrokenRes.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_NoSrc
            // 
            resources.ApplyResources(this.checkBox_DECODE_NoSrc, "checkBox_DECODE_NoSrc");
            this.checkBox_DECODE_NoSrc.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_NoSrc;
            this.checkBox_DECODE_NoSrc.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_NoSrc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_NoSrc.Name = "checkBox_DECODE_NoSrc";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_NoSrc, resources.GetString("checkBox_DECODE_NoSrc.ToolTip"));
            this.checkBox_DECODE_NoSrc.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_Force
            // 
            resources.ApplyResources(this.checkBox_DECODE_Force, "checkBox_DECODE_Force");
            this.checkBox_DECODE_Force.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_Force;
            this.checkBox_DECODE_Force.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DECODE_Force.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_Force", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_Force.Name = "checkBox_DECODE_Force";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_Force, resources.GetString("checkBox_DECODE_Force.ToolTip"));
            this.checkBox_DECODE_Force.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_NoRes
            // 
            resources.ApplyResources(this.checkBox_DECODE_NoRes, "checkBox_DECODE_NoRes");
            this.checkBox_DECODE_NoRes.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_NoRes;
            this.checkBox_DECODE_NoRes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_NoRes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_NoRes.Name = "checkBox_DECODE_NoRes";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_NoRes, resources.GetString("checkBox_DECODE_NoRes.ToolTip"));
            this.checkBox_DECODE_NoRes.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_NoDebugInfo
            // 
            resources.ApplyResources(this.checkBox_DECODE_NoDebugInfo, "checkBox_DECODE_NoDebugInfo");
            this.checkBox_DECODE_NoDebugInfo.Checked = global::APKToolGUI.Properties.Settings.Default.Decode_NoDebugInfo;
            this.checkBox_DECODE_NoDebugInfo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Decode_NoDebugInfo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_DECODE_NoDebugInfo.Name = "checkBox_DECODE_NoDebugInfo";
            this.toolTip1.SetToolTip(this.checkBox_DECODE_NoDebugInfo, resources.GetString("checkBox_DECODE_NoDebugInfo.ToolTip"));
            this.checkBox_DECODE_NoDebugInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageBuild
            // 
            resources.ApplyResources(this.tabPageBuild, "tabPageBuild");
            this.tabPageBuild.BackColor = System.Drawing.Color.White;
            this.tabPageBuild.Controls.Add(this.groupBox_BUILD_Options);
            this.tabPageBuild.Name = "tabPageBuild";
            this.toolTip1.SetToolTip(this.tabPageBuild, resources.GetString("tabPageBuild.ToolTip"));
            // 
            // groupBox_BUILD_Options
            // 
            resources.ApplyResources(this.groupBox_BUILD_Options, "groupBox_BUILD_Options");
            this.groupBox_BUILD_Options.Controls.Add(this.useAapt2ChkBox);
            this.groupBox_BUILD_Options.Controls.Add(this.buildApiLvlUpDown);
            this.groupBox_BUILD_Options.Controls.Add(this.buildSetApiLvlChkBox);
            this.groupBox_BUILD_Options.Controls.Add(this.label23);
            this.groupBox_BUILD_Options.Controls.Add(this.createUnsignApkChkBox);
            this.groupBox_BUILD_Options.Controls.Add(this.label16);
            this.groupBox_BUILD_Options.Controls.Add(this.signAfterBuildChkBox);
            this.groupBox_BUILD_Options.Controls.Add(this.zipalignAfterBuildChkBox);
            this.groupBox_BUILD_Options.Controls.Add(this.checkBox_BUILD_NoCrunch);
            this.groupBox_BUILD_Options.Controls.Add(this.button_BUILD_BrowseOutputAppPath);
            this.groupBox_BUILD_Options.Controls.Add(this.checkBox_BUILD_ForceAll);
            this.groupBox_BUILD_Options.Controls.Add(this.button_BUILD_BrowseFrameDir);
            this.groupBox_BUILD_Options.Controls.Add(this.button_BUILD_BrowseAaptPath);
            this.groupBox_BUILD_Options.Controls.Add(this.checkBox_BUILD_OutputAppPath);
            this.groupBox_BUILD_Options.Controls.Add(this.checkBox_BUILD_CopyOriginal);
            this.groupBox_BUILD_Options.Controls.Add(this.textBox_BUILD_OutputAppPath);
            this.groupBox_BUILD_Options.Controls.Add(this.checkBox_BUILD_UseAapt);
            this.groupBox_BUILD_Options.Controls.Add(this.textBox_BUILD_AaptPath);
            this.groupBox_BUILD_Options.Controls.Add(this.textBox_BUILD_FrameDir);
            this.groupBox_BUILD_Options.Controls.Add(this.checkBox_BUILD_UseFramework);
            this.groupBox_BUILD_Options.Name = "groupBox_BUILD_Options";
            this.groupBox_BUILD_Options.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox_BUILD_Options, resources.GetString("groupBox_BUILD_Options.ToolTip"));
            // 
            // useAapt2ChkBox
            // 
            resources.ApplyResources(this.useAapt2ChkBox, "useAapt2ChkBox");
            this.useAapt2ChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Build_UseAapt2;
            this.useAapt2ChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useAapt2ChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_UseAapt2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useAapt2ChkBox.Name = "useAapt2ChkBox";
            this.toolTip1.SetToolTip(this.useAapt2ChkBox, resources.GetString("useAapt2ChkBox.ToolTip"));
            this.useAapt2ChkBox.UseVisualStyleBackColor = true;
            // 
            // buildApiLvlUpDown
            // 
            resources.ApplyResources(this.buildApiLvlUpDown, "buildApiLvlUpDown");
            this.buildApiLvlUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::APKToolGUI.Properties.Settings.Default, "Build_ApiLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buildApiLvlUpDown.Name = "buildApiLvlUpDown";
            this.toolTip1.SetToolTip(this.buildApiLvlUpDown, resources.GetString("buildApiLvlUpDown.ToolTip"));
            this.buildApiLvlUpDown.Value = global::APKToolGUI.Properties.Settings.Default.Build_ApiLevel;
            // 
            // buildSetApiLvlChkBox
            // 
            resources.ApplyResources(this.buildSetApiLvlChkBox, "buildSetApiLvlChkBox");
            this.buildSetApiLvlChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Build_SetApiLevel;
            this.buildSetApiLvlChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_SetApiLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buildSetApiLvlChkBox.Name = "buildSetApiLvlChkBox";
            this.toolTip1.SetToolTip(this.buildSetApiLvlChkBox, resources.GetString("buildSetApiLvlChkBox.ToolTip"));
            this.buildSetApiLvlChkBox.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.ForeColor = System.Drawing.Color.DimGray;
            this.label23.Name = "label23";
            this.toolTip1.SetToolTip(this.label23, resources.GetString("label23.ToolTip"));
            // 
            // createUnsignApkChkBox
            // 
            resources.ApplyResources(this.createUnsignApkChkBox, "createUnsignApkChkBox");
            this.createUnsignApkChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Build_CreateUnsignedApk;
            this.createUnsignApkChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_CreateUnsignedApk", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.createUnsignApkChkBox.Name = "createUnsignApkChkBox";
            this.toolTip1.SetToolTip(this.createUnsignApkChkBox, resources.GetString("createUnsignApkChkBox.ToolTip"));
            this.createUnsignApkChkBox.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Name = "label16";
            this.toolTip1.SetToolTip(this.label16, resources.GetString("label16.ToolTip"));
            // 
            // signAfterBuildChkBox
            // 
            resources.ApplyResources(this.signAfterBuildChkBox, "signAfterBuildChkBox");
            this.signAfterBuildChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Build_SignAfterBuild;
            this.signAfterBuildChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.signAfterBuildChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_SignAfterBuild", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.signAfterBuildChkBox.Name = "signAfterBuildChkBox";
            this.toolTip1.SetToolTip(this.signAfterBuildChkBox, resources.GetString("signAfterBuildChkBox.ToolTip"));
            this.signAfterBuildChkBox.UseVisualStyleBackColor = true;
            // 
            // zipalignAfterBuildChkBox
            // 
            resources.ApplyResources(this.zipalignAfterBuildChkBox, "zipalignAfterBuildChkBox");
            this.zipalignAfterBuildChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Build_ZipalignAfterBuild;
            this.zipalignAfterBuildChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zipalignAfterBuildChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_ZipalignAfterBuild", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.zipalignAfterBuildChkBox.Name = "zipalignAfterBuildChkBox";
            this.toolTip1.SetToolTip(this.zipalignAfterBuildChkBox, resources.GetString("zipalignAfterBuildChkBox.ToolTip"));
            this.zipalignAfterBuildChkBox.UseVisualStyleBackColor = true;
            // 
            // checkBox_BUILD_NoCrunch
            // 
            resources.ApplyResources(this.checkBox_BUILD_NoCrunch, "checkBox_BUILD_NoCrunch");
            this.checkBox_BUILD_NoCrunch.Checked = global::APKToolGUI.Properties.Settings.Default.Build_NoCrunch;
            this.checkBox_BUILD_NoCrunch.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_NoCrunch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_BUILD_NoCrunch.Name = "checkBox_BUILD_NoCrunch";
            this.toolTip1.SetToolTip(this.checkBox_BUILD_NoCrunch, resources.GetString("checkBox_BUILD_NoCrunch.ToolTip"));
            this.checkBox_BUILD_NoCrunch.UseVisualStyleBackColor = true;
            // 
            // button_BUILD_BrowseOutputAppPath
            // 
            resources.ApplyResources(this.button_BUILD_BrowseOutputAppPath, "button_BUILD_BrowseOutputAppPath");
            this.button_BUILD_BrowseOutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Build_UseOutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_BUILD_BrowseOutputAppPath.Enabled = global::APKToolGUI.Properties.Settings.Default.Build_UseOutputAppPath;
            this.button_BUILD_BrowseOutputAppPath.Name = "button_BUILD_BrowseOutputAppPath";
            this.toolTip1.SetToolTip(this.button_BUILD_BrowseOutputAppPath, resources.GetString("button_BUILD_BrowseOutputAppPath.ToolTip"));
            this.button_BUILD_BrowseOutputAppPath.UseVisualStyleBackColor = true;
            // 
            // checkBox_BUILD_ForceAll
            // 
            resources.ApplyResources(this.checkBox_BUILD_ForceAll, "checkBox_BUILD_ForceAll");
            this.checkBox_BUILD_ForceAll.Checked = global::APKToolGUI.Properties.Settings.Default.Build_ForceAll;
            this.checkBox_BUILD_ForceAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_BUILD_ForceAll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_ForceAll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_BUILD_ForceAll.Name = "checkBox_BUILD_ForceAll";
            this.toolTip1.SetToolTip(this.checkBox_BUILD_ForceAll, resources.GetString("checkBox_BUILD_ForceAll.ToolTip"));
            this.checkBox_BUILD_ForceAll.UseVisualStyleBackColor = true;
            // 
            // button_BUILD_BrowseFrameDir
            // 
            resources.ApplyResources(this.button_BUILD_BrowseFrameDir, "button_BUILD_BrowseFrameDir");
            this.button_BUILD_BrowseFrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Build_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_BUILD_BrowseFrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.Build_UseFramework;
            this.button_BUILD_BrowseFrameDir.Name = "button_BUILD_BrowseFrameDir";
            this.toolTip1.SetToolTip(this.button_BUILD_BrowseFrameDir, resources.GetString("button_BUILD_BrowseFrameDir.ToolTip"));
            this.button_BUILD_BrowseFrameDir.UseVisualStyleBackColor = true;
            // 
            // button_BUILD_BrowseAaptPath
            // 
            resources.ApplyResources(this.button_BUILD_BrowseAaptPath, "button_BUILD_BrowseAaptPath");
            this.button_BUILD_BrowseAaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Build_UseAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_BUILD_BrowseAaptPath.Enabled = global::APKToolGUI.Properties.Settings.Default.Build_UseAapt;
            this.button_BUILD_BrowseAaptPath.Name = "button_BUILD_BrowseAaptPath";
            this.toolTip1.SetToolTip(this.button_BUILD_BrowseAaptPath, resources.GetString("button_BUILD_BrowseAaptPath.ToolTip"));
            this.button_BUILD_BrowseAaptPath.UseVisualStyleBackColor = true;
            // 
            // checkBox_BUILD_OutputAppPath
            // 
            resources.ApplyResources(this.checkBox_BUILD_OutputAppPath, "checkBox_BUILD_OutputAppPath");
            this.checkBox_BUILD_OutputAppPath.Checked = global::APKToolGUI.Properties.Settings.Default.Build_UseOutputAppPath;
            this.checkBox_BUILD_OutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_UseOutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_BUILD_OutputAppPath.Name = "checkBox_BUILD_OutputAppPath";
            this.toolTip1.SetToolTip(this.checkBox_BUILD_OutputAppPath, resources.GetString("checkBox_BUILD_OutputAppPath.ToolTip"));
            this.checkBox_BUILD_OutputAppPath.UseVisualStyleBackColor = true;
            // 
            // checkBox_BUILD_CopyOriginal
            // 
            resources.ApplyResources(this.checkBox_BUILD_CopyOriginal, "checkBox_BUILD_CopyOriginal");
            this.checkBox_BUILD_CopyOriginal.Checked = global::APKToolGUI.Properties.Settings.Default.Build_CopyOriginal;
            this.checkBox_BUILD_CopyOriginal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_CopyOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_BUILD_CopyOriginal.Name = "checkBox_BUILD_CopyOriginal";
            this.toolTip1.SetToolTip(this.checkBox_BUILD_CopyOriginal, resources.GetString("checkBox_BUILD_CopyOriginal.ToolTip"));
            this.checkBox_BUILD_CopyOriginal.UseVisualStyleBackColor = true;
            // 
            // textBox_BUILD_OutputAppPath
            // 
            resources.ApplyResources(this.textBox_BUILD_OutputAppPath, "textBox_BUILD_OutputAppPath");
            this.textBox_BUILD_OutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Build_UseOutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_OutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Build_OutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_OutputAppPath.Enabled = global::APKToolGUI.Properties.Settings.Default.Build_UseOutputAppPath;
            this.textBox_BUILD_OutputAppPath.Name = "textBox_BUILD_OutputAppPath";
            this.textBox_BUILD_OutputAppPath.Text = global::APKToolGUI.Properties.Settings.Default.Build_OutputAppPath;
            this.toolTip1.SetToolTip(this.textBox_BUILD_OutputAppPath, resources.GetString("textBox_BUILD_OutputAppPath.ToolTip"));
            // 
            // checkBox_BUILD_UseAapt
            // 
            resources.ApplyResources(this.checkBox_BUILD_UseAapt, "checkBox_BUILD_UseAapt");
            this.checkBox_BUILD_UseAapt.Checked = global::APKToolGUI.Properties.Settings.Default.Build_UseAapt;
            this.checkBox_BUILD_UseAapt.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_UseAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_BUILD_UseAapt.Name = "checkBox_BUILD_UseAapt";
            this.toolTip1.SetToolTip(this.checkBox_BUILD_UseAapt, resources.GetString("checkBox_BUILD_UseAapt.ToolTip"));
            this.checkBox_BUILD_UseAapt.UseVisualStyleBackColor = true;
            // 
            // textBox_BUILD_AaptPath
            // 
            resources.ApplyResources(this.textBox_BUILD_AaptPath, "textBox_BUILD_AaptPath");
            this.textBox_BUILD_AaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Build_UseAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_AaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Build_AaptPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_AaptPath.Enabled = global::APKToolGUI.Properties.Settings.Default.Build_UseAapt;
            this.textBox_BUILD_AaptPath.Name = "textBox_BUILD_AaptPath";
            this.textBox_BUILD_AaptPath.Text = global::APKToolGUI.Properties.Settings.Default.Build_AaptPath;
            this.toolTip1.SetToolTip(this.textBox_BUILD_AaptPath, resources.GetString("textBox_BUILD_AaptPath.ToolTip"));
            // 
            // textBox_BUILD_FrameDir
            // 
            resources.ApplyResources(this.textBox_BUILD_FrameDir, "textBox_BUILD_FrameDir");
            this.textBox_BUILD_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Build_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Framework_FrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_FrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.Build_UseFramework;
            this.textBox_BUILD_FrameDir.Name = "textBox_BUILD_FrameDir";
            this.textBox_BUILD_FrameDir.Text = global::APKToolGUI.Properties.Settings.Default.Framework_FrameDir;
            this.toolTip1.SetToolTip(this.textBox_BUILD_FrameDir, resources.GetString("textBox_BUILD_FrameDir.ToolTip"));
            // 
            // checkBox_BUILD_UseFramework
            // 
            resources.ApplyResources(this.checkBox_BUILD_UseFramework, "checkBox_BUILD_UseFramework");
            this.checkBox_BUILD_UseFramework.Checked = global::APKToolGUI.Properties.Settings.Default.Build_UseFramework;
            this.checkBox_BUILD_UseFramework.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Build_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_BUILD_UseFramework.Name = "checkBox_BUILD_UseFramework";
            this.toolTip1.SetToolTip(this.checkBox_BUILD_UseFramework, resources.GetString("checkBox_BUILD_UseFramework.ToolTip"));
            this.checkBox_BUILD_UseFramework.UseVisualStyleBackColor = true;
            // 
            // tabPageSign
            // 
            resources.ApplyResources(this.tabPageSign, "tabPageSign");
            this.tabPageSign.BackColor = System.Drawing.Color.White;
            this.tabPageSign.Controls.Add(this.groupBox_SIGN_Options);
            this.tabPageSign.Name = "tabPageSign";
            this.toolTip1.SetToolTip(this.tabPageSign, resources.GetString("tabPageSign.ToolTip"));
            // 
            // groupBox_SIGN_Options
            // 
            resources.ApplyResources(this.groupBox_SIGN_Options, "groupBox_SIGN_Options");
            this.groupBox_SIGN_Options.Controls.Add(this.checkBox2);
            this.groupBox_SIGN_Options.Controls.Add(this.checkBox1);
            this.groupBox_SIGN_Options.Controls.Add(this.autoDelIdsigChkBox);
            this.groupBox_SIGN_Options.Controls.Add(this.schemev4ComboBox);
            this.groupBox_SIGN_Options.Controls.Add(this.label27);
            this.groupBox_SIGN_Options.Controls.Add(this.schemev3ComboBox);
            this.groupBox_SIGN_Options.Controls.Add(this.label26);
            this.groupBox_SIGN_Options.Controls.Add(this.schemev2ComboBox);
            this.groupBox_SIGN_Options.Controls.Add(this.label25);
            this.groupBox_SIGN_Options.Controls.Add(this.schemev1ComboBox);
            this.groupBox_SIGN_Options.Controls.Add(this.label24);
            this.groupBox_SIGN_Options.Controls.Add(this.textBox3);
            this.groupBox_SIGN_Options.Controls.Add(this.selectKeyStoreFileBtn);
            this.groupBox_SIGN_Options.Controls.Add(this.aliasTxtBox);
            this.groupBox_SIGN_Options.Controls.Add(this.useAliasChkBox);
            this.groupBox_SIGN_Options.Controls.Add(this.label22);
            this.groupBox_SIGN_Options.Controls.Add(this.keyStoreFileTxtBox);
            this.groupBox_SIGN_Options.Controls.Add(this.label21);
            this.groupBox_SIGN_Options.Controls.Add(this.label20);
            this.groupBox_SIGN_Options.Controls.Add(this.useKeyStoreChkBox);
            this.groupBox_SIGN_Options.Controls.Add(this.useSigningOutputDir);
            this.groupBox_SIGN_Options.Controls.Add(this.label_SIGN_PrivateKey);
            this.groupBox_SIGN_Options.Controls.Add(this.label_SIGN_PublicKey);
            this.groupBox_SIGN_Options.Controls.Add(this.button_SIGN_BrowseOutputFile);
            this.groupBox_SIGN_Options.Controls.Add(this.textBox_SIGN_OutputFile);
            this.groupBox_SIGN_Options.Controls.Add(this.button_SIGN_BrowsePublicKey);
            this.groupBox_SIGN_Options.Controls.Add(this.button_SIGN_BrowsePrivateKey);
            this.groupBox_SIGN_Options.Controls.Add(this.textBox_SIGN_PublicKey);
            this.groupBox_SIGN_Options.Controls.Add(this.textBox_SIGN_PrivateKey);
            this.groupBox_SIGN_Options.Name = "groupBox_SIGN_Options";
            this.groupBox_SIGN_Options.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox_SIGN_Options, resources.GetString("groupBox_SIGN_Options.ToolTip"));
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Checked = global::APKToolGUI.Properties.Settings.Default.Sign_InstallApkAfterSign;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Sign_InstallApkAfterSign", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Name = "checkBox2";
            this.toolTip1.SetToolTip(this.checkBox2, resources.GetString("checkBox2.ToolTip"));
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = global::APKToolGUI.Properties.Settings.Default.Sign_OverwriteInputFile;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Sign_OverwriteInputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Name = "checkBox1";
            this.toolTip1.SetToolTip(this.checkBox1, resources.GetString("checkBox1.ToolTip"));
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // autoDelIdsigChkBox
            // 
            resources.ApplyResources(this.autoDelIdsigChkBox, "autoDelIdsigChkBox");
            this.autoDelIdsigChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.AutoDeleteIdsigFile;
            this.autoDelIdsigChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoDelIdsigChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "AutoDeleteIdsigFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.autoDelIdsigChkBox.Name = "autoDelIdsigChkBox";
            this.toolTip1.SetToolTip(this.autoDelIdsigChkBox, resources.GetString("autoDelIdsigChkBox.ToolTip"));
            this.autoDelIdsigChkBox.UseVisualStyleBackColor = true;
            // 
            // schemev4ComboBox
            // 
            resources.ApplyResources(this.schemev4ComboBox, "schemev4ComboBox");
            this.schemev4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemev4ComboBox.FormattingEnabled = true;
            this.schemev4ComboBox.Items.AddRange(new object[] {
            resources.GetString("schemev4ComboBox.Items"),
            resources.GetString("schemev4ComboBox.Items1"),
            resources.GetString("schemev4ComboBox.Items2")});
            this.schemev4ComboBox.Name = "schemev4ComboBox";
            this.toolTip1.SetToolTip(this.schemev4ComboBox, resources.GetString("schemev4ComboBox.ToolTip"));
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            this.toolTip1.SetToolTip(this.label27, resources.GetString("label27.ToolTip"));
            // 
            // schemev3ComboBox
            // 
            resources.ApplyResources(this.schemev3ComboBox, "schemev3ComboBox");
            this.schemev3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemev3ComboBox.FormattingEnabled = true;
            this.schemev3ComboBox.Items.AddRange(new object[] {
            resources.GetString("schemev3ComboBox.Items"),
            resources.GetString("schemev3ComboBox.Items1"),
            resources.GetString("schemev3ComboBox.Items2")});
            this.schemev3ComboBox.Name = "schemev3ComboBox";
            this.toolTip1.SetToolTip(this.schemev3ComboBox, resources.GetString("schemev3ComboBox.ToolTip"));
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            this.toolTip1.SetToolTip(this.label26, resources.GetString("label26.ToolTip"));
            // 
            // schemev2ComboBox
            // 
            resources.ApplyResources(this.schemev2ComboBox, "schemev2ComboBox");
            this.schemev2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemev2ComboBox.FormattingEnabled = true;
            this.schemev2ComboBox.Items.AddRange(new object[] {
            resources.GetString("schemev2ComboBox.Items"),
            resources.GetString("schemev2ComboBox.Items1"),
            resources.GetString("schemev2ComboBox.Items2")});
            this.schemev2ComboBox.Name = "schemev2ComboBox";
            this.toolTip1.SetToolTip(this.schemev2ComboBox, resources.GetString("schemev2ComboBox.ToolTip"));
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            this.toolTip1.SetToolTip(this.label25, resources.GetString("label25.ToolTip"));
            // 
            // schemev1ComboBox
            // 
            resources.ApplyResources(this.schemev1ComboBox, "schemev1ComboBox");
            this.schemev1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemev1ComboBox.FormattingEnabled = true;
            this.schemev1ComboBox.Items.AddRange(new object[] {
            resources.GetString("schemev1ComboBox.Items"),
            resources.GetString("schemev1ComboBox.Items1"),
            resources.GetString("schemev1ComboBox.Items2")});
            this.schemev1ComboBox.Name = "schemev1ComboBox";
            this.toolTip1.SetToolTip(this.schemev1ComboBox, resources.GetString("schemev1ComboBox.ToolTip"));
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            this.toolTip1.SetToolTip(this.label24, resources.GetString("label24.ToolTip"));
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_KeystorePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Name = "textBox3";
            this.textBox3.Text = global::APKToolGUI.Properties.Settings.Default.Sign_KeystorePassword;
            this.toolTip1.SetToolTip(this.textBox3, resources.GetString("textBox3.ToolTip"));
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // selectKeyStoreFileBtn
            // 
            resources.ApplyResources(this.selectKeyStoreFileBtn, "selectKeyStoreFileBtn");
            this.selectKeyStoreFileBtn.Name = "selectKeyStoreFileBtn";
            this.toolTip1.SetToolTip(this.selectKeyStoreFileBtn, resources.GetString("selectKeyStoreFileBtn.ToolTip"));
            this.selectKeyStoreFileBtn.UseVisualStyleBackColor = true;
            // 
            // aliasTxtBox
            // 
            resources.ApplyResources(this.aliasTxtBox, "aliasTxtBox");
            this.aliasTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_Alias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aliasTxtBox.Name = "aliasTxtBox";
            this.aliasTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Sign_Alias;
            this.toolTip1.SetToolTip(this.aliasTxtBox, resources.GetString("aliasTxtBox.ToolTip"));
            // 
            // useAliasChkBox
            // 
            resources.ApplyResources(this.useAliasChkBox, "useAliasChkBox");
            this.useAliasChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Sign_SetAlias;
            this.useAliasChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useAliasChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Sign_SetAlias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useAliasChkBox.Name = "useAliasChkBox";
            this.toolTip1.SetToolTip(this.useAliasChkBox, resources.GetString("useAliasChkBox.ToolTip"));
            this.useAliasChkBox.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.Color.Maroon;
            this.label22.Name = "label22";
            this.toolTip1.SetToolTip(this.label22, resources.GetString("label22.ToolTip"));
            // 
            // keyStoreFileTxtBox
            // 
            resources.ApplyResources(this.keyStoreFileTxtBox, "keyStoreFileTxtBox");
            this.keyStoreFileTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_KeystoreFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.keyStoreFileTxtBox.Name = "keyStoreFileTxtBox";
            this.keyStoreFileTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Sign_KeystoreFilePath;
            this.toolTip1.SetToolTip(this.keyStoreFileTxtBox, resources.GetString("keyStoreFileTxtBox.ToolTip"));
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            this.toolTip1.SetToolTip(this.label21, resources.GetString("label21.ToolTip"));
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            this.toolTip1.SetToolTip(this.label20, resources.GetString("label20.ToolTip"));
            // 
            // useKeyStoreChkBox
            // 
            resources.ApplyResources(this.useKeyStoreChkBox, "useKeyStoreChkBox");
            this.useKeyStoreChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Sign_UseKeystoreFile;
            this.useKeyStoreChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Sign_UseKeystoreFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useKeyStoreChkBox.Name = "useKeyStoreChkBox";
            this.toolTip1.SetToolTip(this.useKeyStoreChkBox, resources.GetString("useKeyStoreChkBox.ToolTip"));
            this.useKeyStoreChkBox.UseVisualStyleBackColor = true;
            // 
            // useSigningOutputDir
            // 
            resources.ApplyResources(this.useSigningOutputDir, "useSigningOutputDir");
            this.useSigningOutputDir.Checked = global::APKToolGUI.Properties.Settings.Default.Sign_UseOutputDir;
            this.useSigningOutputDir.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Sign_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useSigningOutputDir.Name = "useSigningOutputDir";
            this.toolTip1.SetToolTip(this.useSigningOutputDir, resources.GetString("useSigningOutputDir.ToolTip"));
            this.useSigningOutputDir.UseVisualStyleBackColor = true;
            // 
            // label_SIGN_PrivateKey
            // 
            resources.ApplyResources(this.label_SIGN_PrivateKey, "label_SIGN_PrivateKey");
            this.label_SIGN_PrivateKey.Name = "label_SIGN_PrivateKey";
            this.toolTip1.SetToolTip(this.label_SIGN_PrivateKey, resources.GetString("label_SIGN_PrivateKey.ToolTip"));
            // 
            // label_SIGN_PublicKey
            // 
            resources.ApplyResources(this.label_SIGN_PublicKey, "label_SIGN_PublicKey");
            this.label_SIGN_PublicKey.Name = "label_SIGN_PublicKey";
            this.toolTip1.SetToolTip(this.label_SIGN_PublicKey, resources.GetString("label_SIGN_PublicKey.ToolTip"));
            // 
            // button_SIGN_BrowseOutputFile
            // 
            resources.ApplyResources(this.button_SIGN_BrowseOutputFile, "button_SIGN_BrowseOutputFile");
            this.button_SIGN_BrowseOutputFile.Name = "button_SIGN_BrowseOutputFile";
            this.toolTip1.SetToolTip(this.button_SIGN_BrowseOutputFile, resources.GetString("button_SIGN_BrowseOutputFile.ToolTip"));
            this.button_SIGN_BrowseOutputFile.UseVisualStyleBackColor = true;
            // 
            // textBox_SIGN_OutputFile
            // 
            resources.ApplyResources(this.textBox_SIGN_OutputFile, "textBox_SIGN_OutputFile");
            this.textBox_SIGN_OutputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_OutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_SIGN_OutputFile.Name = "textBox_SIGN_OutputFile";
            this.textBox_SIGN_OutputFile.Text = global::APKToolGUI.Properties.Settings.Default.Sign_OutputDir;
            this.toolTip1.SetToolTip(this.textBox_SIGN_OutputFile, resources.GetString("textBox_SIGN_OutputFile.ToolTip"));
            // 
            // button_SIGN_BrowsePublicKey
            // 
            resources.ApplyResources(this.button_SIGN_BrowsePublicKey, "button_SIGN_BrowsePublicKey");
            this.button_SIGN_BrowsePublicKey.Name = "button_SIGN_BrowsePublicKey";
            this.toolTip1.SetToolTip(this.button_SIGN_BrowsePublicKey, resources.GetString("button_SIGN_BrowsePublicKey.ToolTip"));
            this.button_SIGN_BrowsePublicKey.UseVisualStyleBackColor = true;
            // 
            // button_SIGN_BrowsePrivateKey
            // 
            resources.ApplyResources(this.button_SIGN_BrowsePrivateKey, "button_SIGN_BrowsePrivateKey");
            this.button_SIGN_BrowsePrivateKey.Name = "button_SIGN_BrowsePrivateKey";
            this.toolTip1.SetToolTip(this.button_SIGN_BrowsePrivateKey, resources.GetString("button_SIGN_BrowsePrivateKey.ToolTip"));
            this.button_SIGN_BrowsePrivateKey.UseVisualStyleBackColor = true;
            // 
            // textBox_SIGN_PublicKey
            // 
            resources.ApplyResources(this.textBox_SIGN_PublicKey, "textBox_SIGN_PublicKey");
            this.textBox_SIGN_PublicKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_PublicKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_SIGN_PublicKey.Name = "textBox_SIGN_PublicKey";
            this.textBox_SIGN_PublicKey.Text = global::APKToolGUI.Properties.Settings.Default.Sign_PublicKey;
            this.toolTip1.SetToolTip(this.textBox_SIGN_PublicKey, resources.GetString("textBox_SIGN_PublicKey.ToolTip"));
            // 
            // textBox_SIGN_PrivateKey
            // 
            resources.ApplyResources(this.textBox_SIGN_PrivateKey, "textBox_SIGN_PrivateKey");
            this.textBox_SIGN_PrivateKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Sign_PrivateKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_SIGN_PrivateKey.Name = "textBox_SIGN_PrivateKey";
            this.textBox_SIGN_PrivateKey.Text = global::APKToolGUI.Properties.Settings.Default.Sign_PrivateKey;
            this.toolTip1.SetToolTip(this.textBox_SIGN_PrivateKey, resources.GetString("textBox_SIGN_PrivateKey.ToolTip"));
            // 
            // tabPageZipAlign
            // 
            resources.ApplyResources(this.tabPageZipAlign, "tabPageZipAlign");
            this.tabPageZipAlign.BackColor = System.Drawing.Color.White;
            this.tabPageZipAlign.Controls.Add(this.groupBox_ZIPALIGN_Options);
            this.tabPageZipAlign.Name = "tabPageZipAlign";
            this.toolTip1.SetToolTip(this.tabPageZipAlign, resources.GetString("tabPageZipAlign.ToolTip"));
            // 
            // groupBox_ZIPALIGN_Options
            // 
            resources.ApplyResources(this.groupBox_ZIPALIGN_Options, "groupBox_ZIPALIGN_Options");
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.zipalignOutputDirChkBox);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.signAfterZipalignChkBox);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_Recompress);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.label_ZIPALIGN_AlignmentBytes);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.button_ZIPALIGN_BrowseOutputFile);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_CheckAlignment);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.textBox_ZIPALIGN_OutputFile);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_VerboseOutput);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.numericUpDown_ZIPALIGN_AlignmentBytes);
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_OverwriteOutputFile);
            this.groupBox_ZIPALIGN_Options.Name = "groupBox_ZIPALIGN_Options";
            this.groupBox_ZIPALIGN_Options.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox_ZIPALIGN_Options, resources.GetString("groupBox_ZIPALIGN_Options.ToolTip"));
            // 
            // zipalignOutputDirChkBox
            // 
            resources.ApplyResources(this.zipalignOutputDirChkBox, "zipalignOutputDirChkBox");
            this.zipalignOutputDirChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Zipalign_UseOutputDir;
            this.zipalignOutputDirChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Zipalign_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.zipalignOutputDirChkBox.Name = "zipalignOutputDirChkBox";
            this.toolTip1.SetToolTip(this.zipalignOutputDirChkBox, resources.GetString("zipalignOutputDirChkBox.ToolTip"));
            this.zipalignOutputDirChkBox.UseVisualStyleBackColor = true;
            // 
            // signAfterZipalignChkBox
            // 
            resources.ApplyResources(this.signAfterZipalignChkBox, "signAfterZipalignChkBox");
            this.signAfterZipalignChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Zipalign_SignAfterZipAlign;
            this.signAfterZipalignChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.signAfterZipalignChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Zipalign_SignAfterZipAlign", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.signAfterZipalignChkBox.Name = "signAfterZipalignChkBox";
            this.toolTip1.SetToolTip(this.signAfterZipalignChkBox, resources.GetString("signAfterZipalignChkBox.ToolTip"));
            this.signAfterZipalignChkBox.UseVisualStyleBackColor = true;
            // 
            // checkBox_ZIPALIGN_Recompress
            // 
            resources.ApplyResources(this.checkBox_ZIPALIGN_Recompress, "checkBox_ZIPALIGN_Recompress");
            this.checkBox_ZIPALIGN_Recompress.Checked = global::APKToolGUI.Properties.Settings.Default.Zipalign_Recompress;
            this.checkBox_ZIPALIGN_Recompress.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Zipalign_Recompress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ZIPALIGN_Recompress.Name = "checkBox_ZIPALIGN_Recompress";
            this.toolTip1.SetToolTip(this.checkBox_ZIPALIGN_Recompress, resources.GetString("checkBox_ZIPALIGN_Recompress.ToolTip"));
            this.checkBox_ZIPALIGN_Recompress.UseVisualStyleBackColor = true;
            // 
            // label_ZIPALIGN_AlignmentBytes
            // 
            resources.ApplyResources(this.label_ZIPALIGN_AlignmentBytes, "label_ZIPALIGN_AlignmentBytes");
            this.label_ZIPALIGN_AlignmentBytes.Name = "label_ZIPALIGN_AlignmentBytes";
            this.toolTip1.SetToolTip(this.label_ZIPALIGN_AlignmentBytes, resources.GetString("label_ZIPALIGN_AlignmentBytes.ToolTip"));
            // 
            // button_ZIPALIGN_BrowseOutputFile
            // 
            resources.ApplyResources(this.button_ZIPALIGN_BrowseOutputFile, "button_ZIPALIGN_BrowseOutputFile");
            this.button_ZIPALIGN_BrowseOutputFile.Name = "button_ZIPALIGN_BrowseOutputFile";
            this.toolTip1.SetToolTip(this.button_ZIPALIGN_BrowseOutputFile, resources.GetString("button_ZIPALIGN_BrowseOutputFile.ToolTip"));
            this.button_ZIPALIGN_BrowseOutputFile.UseVisualStyleBackColor = true;
            // 
            // checkBox_ZIPALIGN_CheckAlignment
            // 
            resources.ApplyResources(this.checkBox_ZIPALIGN_CheckAlignment, "checkBox_ZIPALIGN_CheckAlignment");
            this.checkBox_ZIPALIGN_CheckAlignment.Checked = global::APKToolGUI.Properties.Settings.Default.Zipalign_CheckOnly;
            this.checkBox_ZIPALIGN_CheckAlignment.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Zipalign_CheckOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ZIPALIGN_CheckAlignment.Name = "checkBox_ZIPALIGN_CheckAlignment";
            this.toolTip1.SetToolTip(this.checkBox_ZIPALIGN_CheckAlignment, resources.GetString("checkBox_ZIPALIGN_CheckAlignment.ToolTip"));
            this.checkBox_ZIPALIGN_CheckAlignment.UseVisualStyleBackColor = true;
            // 
            // textBox_ZIPALIGN_OutputFile
            // 
            resources.ApplyResources(this.textBox_ZIPALIGN_OutputFile, "textBox_ZIPALIGN_OutputFile");
            this.textBox_ZIPALIGN_OutputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Zipalign_OutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_ZIPALIGN_OutputFile.Name = "textBox_ZIPALIGN_OutputFile";
            this.textBox_ZIPALIGN_OutputFile.Text = global::APKToolGUI.Properties.Settings.Default.Zipalign_OutputDir;
            this.toolTip1.SetToolTip(this.textBox_ZIPALIGN_OutputFile, resources.GetString("textBox_ZIPALIGN_OutputFile.ToolTip"));
            // 
            // checkBox_ZIPALIGN_VerboseOutput
            // 
            resources.ApplyResources(this.checkBox_ZIPALIGN_VerboseOutput, "checkBox_ZIPALIGN_VerboseOutput");
            this.checkBox_ZIPALIGN_VerboseOutput.Checked = global::APKToolGUI.Properties.Settings.Default.Zipalign_Verbose;
            this.checkBox_ZIPALIGN_VerboseOutput.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Zipalign_Verbose", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ZIPALIGN_VerboseOutput.Name = "checkBox_ZIPALIGN_VerboseOutput";
            this.toolTip1.SetToolTip(this.checkBox_ZIPALIGN_VerboseOutput, resources.GetString("checkBox_ZIPALIGN_VerboseOutput.ToolTip"));
            this.checkBox_ZIPALIGN_VerboseOutput.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_ZIPALIGN_AlignmentBytes
            // 
            resources.ApplyResources(this.numericUpDown_ZIPALIGN_AlignmentBytes, "numericUpDown_ZIPALIGN_AlignmentBytes");
            this.numericUpDown_ZIPALIGN_AlignmentBytes.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::APKToolGUI.Properties.Settings.Default, "Zipalign_AlignmentInBytes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_ZIPALIGN_AlignmentBytes.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_ZIPALIGN_AlignmentBytes.Name = "numericUpDown_ZIPALIGN_AlignmentBytes";
            this.toolTip1.SetToolTip(this.numericUpDown_ZIPALIGN_AlignmentBytes, resources.GetString("numericUpDown_ZIPALIGN_AlignmentBytes.ToolTip"));
            this.numericUpDown_ZIPALIGN_AlignmentBytes.Value = global::APKToolGUI.Properties.Settings.Default.Zipalign_AlignmentInBytes;
            // 
            // checkBox_ZIPALIGN_OverwriteOutputFile
            // 
            resources.ApplyResources(this.checkBox_ZIPALIGN_OverwriteOutputFile, "checkBox_ZIPALIGN_OverwriteOutputFile");
            this.checkBox_ZIPALIGN_OverwriteOutputFile.Checked = global::APKToolGUI.Properties.Settings.Default.Zipalign_OverwriteOutputFile;
            this.checkBox_ZIPALIGN_OverwriteOutputFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Zipalign_OverwriteOutputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ZIPALIGN_OverwriteOutputFile.Name = "checkBox_ZIPALIGN_OverwriteOutputFile";
            this.toolTip1.SetToolTip(this.checkBox_ZIPALIGN_OverwriteOutputFile, resources.GetString("checkBox_ZIPALIGN_OverwriteOutputFile.ToolTip"));
            this.checkBox_ZIPALIGN_OverwriteOutputFile.UseVisualStyleBackColor = true;
            // 
            // tabPageInstallFramework
            // 
            resources.ApplyResources(this.tabPageInstallFramework, "tabPageInstallFramework");
            this.tabPageInstallFramework.BackColor = System.Drawing.Color.White;
            this.tabPageInstallFramework.Controls.Add(this.groupBox1);
            this.tabPageInstallFramework.Controls.Add(this.groupBox_IF_Options);
            this.tabPageInstallFramework.Name = "tabPageInstallFramework";
            this.toolTip1.SetToolTip(this.tabPageInstallFramework, resources.GetString("tabPageInstallFramework.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.openFwFolderBtn);
            this.groupBox1.Controls.Add(this.clearFwBtn);
            this.groupBox1.Controls.Add(this.clearFwBeforeDecodeChkBox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // openFwFolderBtn
            // 
            resources.ApplyResources(this.openFwFolderBtn, "openFwFolderBtn");
            this.openFwFolderBtn.Name = "openFwFolderBtn";
            this.toolTip1.SetToolTip(this.openFwFolderBtn, resources.GetString("openFwFolderBtn.ToolTip"));
            this.openFwFolderBtn.UseVisualStyleBackColor = true;
            // 
            // clearFwBtn
            // 
            resources.ApplyResources(this.clearFwBtn, "clearFwBtn");
            this.clearFwBtn.Name = "clearFwBtn";
            this.toolTip1.SetToolTip(this.clearFwBtn, resources.GetString("clearFwBtn.ToolTip"));
            this.clearFwBtn.UseVisualStyleBackColor = true;
            // 
            // clearFwBeforeDecodeChkBox
            // 
            resources.ApplyResources(this.clearFwBeforeDecodeChkBox, "clearFwBeforeDecodeChkBox");
            this.clearFwBeforeDecodeChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Framework_ClearBeforeDecode;
            this.clearFwBeforeDecodeChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearFwBeforeDecodeChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Framework_ClearBeforeDecode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.clearFwBeforeDecodeChkBox.Name = "clearFwBeforeDecodeChkBox";
            this.toolTip1.SetToolTip(this.clearFwBeforeDecodeChkBox, resources.GetString("clearFwBeforeDecodeChkBox.ToolTip"));
            this.clearFwBeforeDecodeChkBox.UseVisualStyleBackColor = true;
            // 
            // groupBox_IF_Options
            // 
            resources.ApplyResources(this.groupBox_IF_Options, "groupBox_IF_Options");
            this.groupBox_IF_Options.Controls.Add(this.checkBox_IF_Tag);
            this.groupBox_IF_Options.Controls.Add(this.checkBox_IF_FramePath);
            this.groupBox_IF_Options.Controls.Add(this.textBox_IF_Tag);
            this.groupBox_IF_Options.Controls.Add(this.button_IF_InstallFramework);
            this.groupBox_IF_Options.Controls.Add(this.button_IF_BrowseFrameDir);
            this.groupBox_IF_Options.Controls.Add(this.button_IF_BrowseInputFramePath);
            this.groupBox_IF_Options.Controls.Add(this.textBox_IF_InputFramePath);
            this.groupBox_IF_Options.Controls.Add(this.textBox_IF_FrameDir);
            this.groupBox_IF_Options.Name = "groupBox_IF_Options";
            this.groupBox_IF_Options.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox_IF_Options, resources.GetString("groupBox_IF_Options.ToolTip"));
            // 
            // checkBox_IF_Tag
            // 
            resources.ApplyResources(this.checkBox_IF_Tag, "checkBox_IF_Tag");
            this.checkBox_IF_Tag.Checked = global::APKToolGUI.Properties.Settings.Default.InstallFramework_UseTag;
            this.checkBox_IF_Tag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "InstallFramework_UseTag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_IF_Tag.Name = "checkBox_IF_Tag";
            this.toolTip1.SetToolTip(this.checkBox_IF_Tag, resources.GetString("checkBox_IF_Tag.ToolTip"));
            this.checkBox_IF_Tag.UseVisualStyleBackColor = true;
            // 
            // checkBox_IF_FramePath
            // 
            resources.ApplyResources(this.checkBox_IF_FramePath, "checkBox_IF_FramePath");
            this.checkBox_IF_FramePath.Checked = global::APKToolGUI.Properties.Settings.Default.Framework_UseFrameDir;
            this.checkBox_IF_FramePath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Framework_UseFrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_IF_FramePath.Name = "checkBox_IF_FramePath";
            this.toolTip1.SetToolTip(this.checkBox_IF_FramePath, resources.GetString("checkBox_IF_FramePath.ToolTip"));
            this.checkBox_IF_FramePath.UseVisualStyleBackColor = true;
            // 
            // textBox_IF_Tag
            // 
            resources.ApplyResources(this.textBox_IF_Tag, "textBox_IF_Tag");
            this.textBox_IF_Tag.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "InstallFramework_Tag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_Tag.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "InstallFramework_UseTag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_Tag.Enabled = global::APKToolGUI.Properties.Settings.Default.InstallFramework_UseTag;
            this.textBox_IF_Tag.Name = "textBox_IF_Tag";
            this.textBox_IF_Tag.Text = global::APKToolGUI.Properties.Settings.Default.InstallFramework_Tag;
            this.toolTip1.SetToolTip(this.textBox_IF_Tag, resources.GetString("textBox_IF_Tag.ToolTip"));
            // 
            // button_IF_InstallFramework
            // 
            resources.ApplyResources(this.button_IF_InstallFramework, "button_IF_InstallFramework");
            this.button_IF_InstallFramework.Name = "button_IF_InstallFramework";
            this.toolTip1.SetToolTip(this.button_IF_InstallFramework, resources.GetString("button_IF_InstallFramework.ToolTip"));
            this.button_IF_InstallFramework.UseVisualStyleBackColor = true;
            // 
            // button_IF_BrowseFrameDir
            // 
            resources.ApplyResources(this.button_IF_BrowseFrameDir, "button_IF_BrowseFrameDir");
            this.button_IF_BrowseFrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Framework_UseFrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_IF_BrowseFrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.Framework_UseFrameDir;
            this.button_IF_BrowseFrameDir.Name = "button_IF_BrowseFrameDir";
            this.toolTip1.SetToolTip(this.button_IF_BrowseFrameDir, resources.GetString("button_IF_BrowseFrameDir.ToolTip"));
            this.button_IF_BrowseFrameDir.UseVisualStyleBackColor = true;
            // 
            // button_IF_BrowseInputFramePath
            // 
            resources.ApplyResources(this.button_IF_BrowseInputFramePath, "button_IF_BrowseInputFramePath");
            this.button_IF_BrowseInputFramePath.Name = "button_IF_BrowseInputFramePath";
            this.toolTip1.SetToolTip(this.button_IF_BrowseInputFramePath, resources.GetString("button_IF_BrowseInputFramePath.ToolTip"));
            this.button_IF_BrowseInputFramePath.UseVisualStyleBackColor = true;
            // 
            // textBox_IF_InputFramePath
            // 
            resources.ApplyResources(this.textBox_IF_InputFramePath, "textBox_IF_InputFramePath");
            this.textBox_IF_InputFramePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "InstallFramework_InputFramePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_InputFramePath.Name = "textBox_IF_InputFramePath";
            this.textBox_IF_InputFramePath.Text = global::APKToolGUI.Properties.Settings.Default.InstallFramework_InputFramePath;
            this.toolTip1.SetToolTip(this.textBox_IF_InputFramePath, resources.GetString("textBox_IF_InputFramePath.ToolTip"));
            // 
            // textBox_IF_FrameDir
            // 
            resources.ApplyResources(this.textBox_IF_FrameDir, "textBox_IF_FrameDir");
            this.textBox_IF_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "Framework_UseFrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Framework_FrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_FrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.Framework_UseFrameDir;
            this.textBox_IF_FrameDir.Name = "textBox_IF_FrameDir";
            this.textBox_IF_FrameDir.Text = global::APKToolGUI.Properties.Settings.Default.Framework_FrameDir;
            this.toolTip1.SetToolTip(this.textBox_IF_FrameDir, resources.GetString("textBox_IF_FrameDir.ToolTip"));
            // 
            // tabPageBaksmali
            // 
            resources.ApplyResources(this.tabPageBaksmali, "tabPageBaksmali");
            this.tabPageBaksmali.AllowDrop = true;
            this.tabPageBaksmali.BackColor = System.Drawing.Color.White;
            this.tabPageBaksmali.Controls.Add(this.smaliGroupBox);
            this.tabPageBaksmali.Controls.Add(this.bakSmaliGroupBox);
            this.tabPageBaksmali.Name = "tabPageBaksmali";
            this.toolTip1.SetToolTip(this.tabPageBaksmali, resources.GetString("tabPageBaksmali.ToolTip"));
            // 
            // smaliGroupBox
            // 
            resources.ApplyResources(this.smaliGroupBox, "smaliGroupBox");
            this.smaliGroupBox.Controls.Add(this.label29);
            this.smaliGroupBox.Controls.Add(this.smaliUseOutputChkBox);
            this.smaliGroupBox.Controls.Add(this.comSmaliBtn);
            this.smaliGroupBox.Controls.Add(this.smaliBrowseOutputBtn);
            this.smaliGroupBox.Controls.Add(this.smaliBrowseInputDirTxtBox);
            this.smaliGroupBox.Controls.Add(this.smaliBrowseOutputTxtBox);
            this.smaliGroupBox.Controls.Add(this.smaliBrowseInputDirBtn);
            this.smaliGroupBox.Name = "smaliGroupBox";
            this.smaliGroupBox.TabStop = false;
            this.toolTip1.SetToolTip(this.smaliGroupBox, resources.GetString("smaliGroupBox.ToolTip"));
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            this.toolTip1.SetToolTip(this.label29, resources.GetString("label29.ToolTip"));
            // 
            // smaliUseOutputChkBox
            // 
            resources.ApplyResources(this.smaliUseOutputChkBox, "smaliUseOutputChkBox");
            this.smaliUseOutputChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Smali_UseOutputDir;
            this.smaliUseOutputChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Smali_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smaliUseOutputChkBox.Name = "smaliUseOutputChkBox";
            this.toolTip1.SetToolTip(this.smaliUseOutputChkBox, resources.GetString("smaliUseOutputChkBox.ToolTip"));
            this.smaliUseOutputChkBox.UseVisualStyleBackColor = true;
            // 
            // comSmaliBtn
            // 
            resources.ApplyResources(this.comSmaliBtn, "comSmaliBtn");
            this.comSmaliBtn.Name = "comSmaliBtn";
            this.toolTip1.SetToolTip(this.comSmaliBtn, resources.GetString("comSmaliBtn.ToolTip"));
            this.comSmaliBtn.UseVisualStyleBackColor = true;
            // 
            // smaliBrowseOutputBtn
            // 
            resources.ApplyResources(this.smaliBrowseOutputBtn, "smaliBrowseOutputBtn");
            this.smaliBrowseOutputBtn.Name = "smaliBrowseOutputBtn";
            this.toolTip1.SetToolTip(this.smaliBrowseOutputBtn, resources.GetString("smaliBrowseOutputBtn.ToolTip"));
            this.smaliBrowseOutputBtn.UseVisualStyleBackColor = true;
            // 
            // smaliBrowseInputDirTxtBox
            // 
            resources.ApplyResources(this.smaliBrowseInputDirTxtBox, "smaliBrowseInputDirTxtBox");
            this.smaliBrowseInputDirTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Smali_InputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smaliBrowseInputDirTxtBox.Name = "smaliBrowseInputDirTxtBox";
            this.smaliBrowseInputDirTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Smali_InputDir;
            this.toolTip1.SetToolTip(this.smaliBrowseInputDirTxtBox, resources.GetString("smaliBrowseInputDirTxtBox.ToolTip"));
            // 
            // smaliBrowseOutputTxtBox
            // 
            resources.ApplyResources(this.smaliBrowseOutputTxtBox, "smaliBrowseOutputTxtBox");
            this.smaliBrowseOutputTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Smali_OutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.smaliBrowseOutputTxtBox.Name = "smaliBrowseOutputTxtBox";
            this.smaliBrowseOutputTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Smali_OutputDir;
            this.toolTip1.SetToolTip(this.smaliBrowseOutputTxtBox, resources.GetString("smaliBrowseOutputTxtBox.ToolTip"));
            // 
            // smaliBrowseInputDirBtn
            // 
            resources.ApplyResources(this.smaliBrowseInputDirBtn, "smaliBrowseInputDirBtn");
            this.smaliBrowseInputDirBtn.Name = "smaliBrowseInputDirBtn";
            this.toolTip1.SetToolTip(this.smaliBrowseInputDirBtn, resources.GetString("smaliBrowseInputDirBtn.ToolTip"));
            this.smaliBrowseInputDirBtn.UseVisualStyleBackColor = true;
            // 
            // bakSmaliGroupBox
            // 
            resources.ApplyResources(this.bakSmaliGroupBox, "bakSmaliGroupBox");
            this.bakSmaliGroupBox.Controls.Add(this.label28);
            this.bakSmaliGroupBox.Controls.Add(this.baksmaliUseOutputChkBox);
            this.bakSmaliGroupBox.Controls.Add(this.baksmaliBrowseOutputBtn);
            this.bakSmaliGroupBox.Controls.Add(this.baksmaliBrowseOutputTxtBox);
            this.bakSmaliGroupBox.Controls.Add(this.decSmaliBtn);
            this.bakSmaliGroupBox.Controls.Add(this.baksmaliBrowseInputDexBtn);
            this.bakSmaliGroupBox.Controls.Add(this.baksmaliBrowseInputDexTxtBox);
            this.bakSmaliGroupBox.Name = "bakSmaliGroupBox";
            this.bakSmaliGroupBox.TabStop = false;
            this.toolTip1.SetToolTip(this.bakSmaliGroupBox, resources.GetString("bakSmaliGroupBox.ToolTip"));
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            this.toolTip1.SetToolTip(this.label28, resources.GetString("label28.ToolTip"));
            // 
            // baksmaliUseOutputChkBox
            // 
            resources.ApplyResources(this.baksmaliUseOutputChkBox, "baksmaliUseOutputChkBox");
            this.baksmaliUseOutputChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Baksmali_UseOutputDir;
            this.baksmaliUseOutputChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Baksmali_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.baksmaliUseOutputChkBox.Name = "baksmaliUseOutputChkBox";
            this.toolTip1.SetToolTip(this.baksmaliUseOutputChkBox, resources.GetString("baksmaliUseOutputChkBox.ToolTip"));
            this.baksmaliUseOutputChkBox.UseVisualStyleBackColor = true;
            // 
            // baksmaliBrowseOutputBtn
            // 
            resources.ApplyResources(this.baksmaliBrowseOutputBtn, "baksmaliBrowseOutputBtn");
            this.baksmaliBrowseOutputBtn.Name = "baksmaliBrowseOutputBtn";
            this.toolTip1.SetToolTip(this.baksmaliBrowseOutputBtn, resources.GetString("baksmaliBrowseOutputBtn.ToolTip"));
            this.baksmaliBrowseOutputBtn.UseVisualStyleBackColor = true;
            // 
            // baksmaliBrowseOutputTxtBox
            // 
            resources.ApplyResources(this.baksmaliBrowseOutputTxtBox, "baksmaliBrowseOutputTxtBox");
            this.baksmaliBrowseOutputTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Baksmali_OutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.baksmaliBrowseOutputTxtBox.Name = "baksmaliBrowseOutputTxtBox";
            this.baksmaliBrowseOutputTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Baksmali_OutputDir;
            this.toolTip1.SetToolTip(this.baksmaliBrowseOutputTxtBox, resources.GetString("baksmaliBrowseOutputTxtBox.ToolTip"));
            // 
            // decSmaliBtn
            // 
            resources.ApplyResources(this.decSmaliBtn, "decSmaliBtn");
            this.decSmaliBtn.Name = "decSmaliBtn";
            this.toolTip1.SetToolTip(this.decSmaliBtn, resources.GetString("decSmaliBtn.ToolTip"));
            this.decSmaliBtn.UseVisualStyleBackColor = true;
            // 
            // baksmaliBrowseInputDexBtn
            // 
            resources.ApplyResources(this.baksmaliBrowseInputDexBtn, "baksmaliBrowseInputDexBtn");
            this.baksmaliBrowseInputDexBtn.Name = "baksmaliBrowseInputDexBtn";
            this.toolTip1.SetToolTip(this.baksmaliBrowseInputDexBtn, resources.GetString("baksmaliBrowseInputDexBtn.ToolTip"));
            this.baksmaliBrowseInputDexBtn.UseVisualStyleBackColor = true;
            // 
            // baksmaliBrowseInputDexTxtBox
            // 
            resources.ApplyResources(this.baksmaliBrowseInputDexTxtBox, "baksmaliBrowseInputDexTxtBox");
            this.baksmaliBrowseInputDexTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Baksmali_InputDexFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.baksmaliBrowseInputDexTxtBox.Name = "baksmaliBrowseInputDexTxtBox";
            this.baksmaliBrowseInputDexTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Baksmali_InputDexFile;
            this.toolTip1.SetToolTip(this.baksmaliBrowseInputDexTxtBox, resources.GetString("baksmaliBrowseInputDexTxtBox.ToolTip"));
            // 
            // tabPageAdb
            // 
            resources.ApplyResources(this.tabPageAdb, "tabPageAdb");
            this.tabPageAdb.AllowDrop = true;
            this.tabPageAdb.Controls.Add(this.selAdbDeviceLbl);
            this.tabPageAdb.Controls.Add(this.label33);
            this.tabPageAdb.Controls.Add(this.killAdbBtn);
            this.tabPageAdb.Controls.Add(this.installApkBtn);
            this.tabPageAdb.Controls.Add(this.refreshDevicesBtn);
            this.tabPageAdb.Controls.Add(this.setVendorChkBox);
            this.tabPageAdb.Controls.Add(this.selApkAdbBtn);
            this.tabPageAdb.Controls.Add(this.apkPathAdbTxtBox);
            this.tabPageAdb.Controls.Add(this.label32);
            this.tabPageAdb.Controls.Add(this.devicesListBox);
            this.tabPageAdb.Name = "tabPageAdb";
            this.toolTip1.SetToolTip(this.tabPageAdb, resources.GetString("tabPageAdb.ToolTip"));
            this.tabPageAdb.UseVisualStyleBackColor = true;
            // 
            // selAdbDeviceLbl
            // 
            resources.ApplyResources(this.selAdbDeviceLbl, "selAdbDeviceLbl");
            this.selAdbDeviceLbl.ForeColor = System.Drawing.Color.ForestGreen;
            this.selAdbDeviceLbl.Name = "selAdbDeviceLbl";
            this.toolTip1.SetToolTip(this.selAdbDeviceLbl, resources.GetString("selAdbDeviceLbl.ToolTip"));
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            this.toolTip1.SetToolTip(this.label33, resources.GetString("label33.ToolTip"));
            // 
            // killAdbBtn
            // 
            resources.ApplyResources(this.killAdbBtn, "killAdbBtn");
            this.killAdbBtn.Name = "killAdbBtn";
            this.toolTip1.SetToolTip(this.killAdbBtn, resources.GetString("killAdbBtn.ToolTip"));
            this.killAdbBtn.UseVisualStyleBackColor = true;
            // 
            // installApkBtn
            // 
            resources.ApplyResources(this.installApkBtn, "installApkBtn");
            this.installApkBtn.Name = "installApkBtn";
            this.toolTip1.SetToolTip(this.installApkBtn, resources.GetString("installApkBtn.ToolTip"));
            this.installApkBtn.UseVisualStyleBackColor = true;
            // 
            // refreshDevicesBtn
            // 
            resources.ApplyResources(this.refreshDevicesBtn, "refreshDevicesBtn");
            this.refreshDevicesBtn.Name = "refreshDevicesBtn";
            this.toolTip1.SetToolTip(this.refreshDevicesBtn, resources.GetString("refreshDevicesBtn.ToolTip"));
            this.refreshDevicesBtn.UseVisualStyleBackColor = true;
            // 
            // setVendorChkBox
            // 
            resources.ApplyResources(this.setVendorChkBox, "setVendorChkBox");
            this.setVendorChkBox.Checked = global::APKToolGUI.Properties.Settings.Default.Adb_SetVendor;
            this.setVendorChkBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Adb_SetVendor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.setVendorChkBox.Name = "setVendorChkBox";
            this.toolTip1.SetToolTip(this.setVendorChkBox, resources.GetString("setVendorChkBox.ToolTip"));
            this.setVendorChkBox.UseVisualStyleBackColor = true;
            // 
            // selApkAdbBtn
            // 
            resources.ApplyResources(this.selApkAdbBtn, "selApkAdbBtn");
            this.selApkAdbBtn.Name = "selApkAdbBtn";
            this.toolTip1.SetToolTip(this.selApkAdbBtn, resources.GetString("selApkAdbBtn.ToolTip"));
            this.selApkAdbBtn.UseVisualStyleBackColor = true;
            // 
            // apkPathAdbTxtBox
            // 
            resources.ApplyResources(this.apkPathAdbTxtBox, "apkPathAdbTxtBox");
            this.apkPathAdbTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "Adb_SelectedApkPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.apkPathAdbTxtBox.Name = "apkPathAdbTxtBox";
            this.apkPathAdbTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.Adb_SelectedApkPath;
            this.toolTip1.SetToolTip(this.apkPathAdbTxtBox, resources.GetString("apkPathAdbTxtBox.ToolTip"));
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            this.toolTip1.SetToolTip(this.label32, resources.GetString("label32.ToolTip"));
            // 
            // devicesListBox
            // 
            resources.ApplyResources(this.devicesListBox, "devicesListBox");
            this.devicesListBox.FormattingEnabled = true;
            this.devicesListBox.Name = "devicesListBox";
            this.toolTip1.SetToolTip(this.devicesListBox, resources.GetString("devicesListBox.ToolTip"));
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStateImage,
            this.toolStripStatusLabelStateText,
            this.toolStripProgressBar1});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            this.toolTip1.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // toolStripStatusLabelStateImage
            // 
            resources.ApplyResources(this.toolStripStatusLabelStateImage, "toolStripStatusLabelStateImage");
            this.toolStripStatusLabelStateImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabelStateImage.Name = "toolStripStatusLabelStateImage";
            // 
            // toolStripStatusLabelStateText
            // 
            resources.ApplyResources(this.toolStripStatusLabelStateText, "toolStripStatusLabelStateText");
            this.toolStripStatusLabelStateText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelStateText.Name = "toolStripStatusLabelStateText";
            this.toolStripStatusLabelStateText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelStateText.Spring = true;
            this.toolStripStatusLabelStateText.Click += new System.EventHandler(this.toolStripStatusLabelStateText_Click);
            // 
            // toolStripProgressBar1
            // 
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar1.Click += new System.EventHandler(this.toolStripProgressBar1_Click);
            // 
            // contextMenuStripLog
            // 
            resources.ApplyResources(this.contextMenuStripLog, "contextMenuStripLog");
            this.contextMenuStripLog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.clearLogToolStripMenuItem});
            this.contextMenuStripLog.Name = "contextMenuStripLog";
            this.toolTip1.SetToolTip(this.contextMenuStripLog, resources.GetString("contextMenuStripLog.ToolTip"));
            // 
            // copyToolStripMenuItem
            // 
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            // 
            // clearLogToolStripMenuItem
            // 
            resources.ApplyResources(this.clearLogToolStripMenuItem, "clearLogToolStripMenuItem");
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            // 
            // logTxtBox
            // 
            resources.ApplyResources(this.logTxtBox, "logTxtBox");
            this.logTxtBox.ContextMenuStrip = this.contextMenuStripLog;
            this.logTxtBox.HideSelection = false;
            this.logTxtBox.Name = "logTxtBox";
            this.logTxtBox.TabStop = false;
            this.toolTip1.SetToolTip(this.logTxtBox, resources.GetString("logTxtBox.ToolTip"));
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.toolTip1.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToFileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.openTempFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // saveLogToFileToolStripMenuItem
            // 
            resources.ApplyResources(this.saveLogToFileToolStripMenuItem, "saveLogToFileToolStripMenuItem");
            this.saveLogToFileToolStripMenuItem.Name = "saveLogToFileToolStripMenuItem";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // openTempFolderToolStripMenuItem
            // 
            resources.ApplyResources(this.openTempFolderToolStripMenuItem, "openTempFolderToolStripMenuItem");
            this.openTempFolderToolStripMenuItem.Name = "openTempFolderToolStripMenuItem";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.reportAnIsuueToolStripMenuItem,
            this.apktoolIssuesToolStripMenuItem,
            this.baksmaliIssuesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            resources.ApplyResources(this.checkForUpdateToolStripMenuItem, "checkForUpdateToolStripMenuItem");
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            // 
            // reportAnIsuueToolStripMenuItem
            // 
            resources.ApplyResources(this.reportAnIsuueToolStripMenuItem, "reportAnIsuueToolStripMenuItem");
            this.reportAnIsuueToolStripMenuItem.Name = "reportAnIsuueToolStripMenuItem";
            // 
            // apktoolIssuesToolStripMenuItem
            // 
            resources.ApplyResources(this.apktoolIssuesToolStripMenuItem, "apktoolIssuesToolStripMenuItem");
            this.apktoolIssuesToolStripMenuItem.Name = "apktoolIssuesToolStripMenuItem";
            // 
            // baksmaliIssuesToolStripMenuItem
            // 
            resources.ApplyResources(this.baksmaliIssuesToolStripMenuItem, "baksmaliIssuesToolStripMenuItem");
            this.baksmaliIssuesToolStripMenuItem.Name = "baksmaliIssuesToolStripMenuItem";
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.logTxtBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControlMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.signPanel.ResumeLayout(false);
            this.signPanel.PerformLayout();
            this.zipalignPanel.ResumeLayout(false);
            this.zipalignPanel.PerformLayout();
            this.comPanel.ResumeLayout(false);
            this.comPanel.PerformLayout();
            this.decPanel.ResumeLayout(false);
            this.decPanel.PerformLayout();
            this.tabPageApkInfo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.basicInfoTabPage.ResumeLayout(false);
            this.basicInfoTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apkIconPicBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPageDecode.ResumeLayout(false);
            this.groupBox_DECODE_Options.ResumeLayout(false);
            this.groupBox_DECODE_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.decApiLvlUpDown)).EndInit();
            this.tabPageBuild.ResumeLayout(false);
            this.groupBox_BUILD_Options.ResumeLayout(false);
            this.groupBox_BUILD_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buildApiLvlUpDown)).EndInit();
            this.tabPageSign.ResumeLayout(false);
            this.groupBox_SIGN_Options.ResumeLayout(false);
            this.groupBox_SIGN_Options.PerformLayout();
            this.tabPageZipAlign.ResumeLayout(false);
            this.groupBox_ZIPALIGN_Options.ResumeLayout(false);
            this.groupBox_ZIPALIGN_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZIPALIGN_AlignmentBytes)).EndInit();
            this.tabPageInstallFramework.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_IF_Options.ResumeLayout(false);
            this.groupBox_IF_Options.PerformLayout();
            this.tabPageBaksmali.ResumeLayout(false);
            this.smaliGroupBox.ResumeLayout(false);
            this.smaliGroupBox.PerformLayout();
            this.bakSmaliGroupBox.ResumeLayout(false);
            this.bakSmaliGroupBox.PerformLayout();
            this.tabPageAdb.ResumeLayout(false);
            this.tabPageAdb.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripLog.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabControl tabControlMain;
        internal System.Windows.Forms.TabPage tabPageDecode;
        internal System.Windows.Forms.TabPage tabPageSign;
        internal System.Windows.Forms.TabPage tabPageZipAlign;
        internal System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateText;
        internal System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateImage;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStripLog;
        internal System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        internal System.Windows.Forms.TabPage tabPageBuild;
        internal System.Windows.Forms.TabPage tabPageInstallFramework;
        internal System.Windows.Forms.TextBox textBox_IF_InputFramePath;
        internal System.Windows.Forms.Button button_IF_BrowseInputFramePath;
        internal System.Windows.Forms.Button button_IF_InstallFramework;
        internal System.Windows.Forms.GroupBox groupBox_BUILD_Options;
        internal System.Windows.Forms.Button button_BUILD_BrowseOutputAppPath;
        internal System.Windows.Forms.CheckBox checkBox_BUILD_OutputAppPath;
        internal System.Windows.Forms.TextBox textBox_BUILD_OutputAppPath;
        internal System.Windows.Forms.CheckBox checkBox_BUILD_CopyOriginal;
        internal System.Windows.Forms.Button button_BUILD_BrowseFrameDir;
        internal System.Windows.Forms.CheckBox checkBox_BUILD_UseFramework;
        internal System.Windows.Forms.TextBox textBox_BUILD_FrameDir;
        internal System.Windows.Forms.TextBox textBox_BUILD_AaptPath;
        internal System.Windows.Forms.CheckBox checkBox_BUILD_UseAapt;
        internal System.Windows.Forms.Button button_BUILD_BrowseAaptPath;
        internal System.Windows.Forms.CheckBox checkBox_BUILD_ForceAll;
        internal System.Windows.Forms.GroupBox groupBox_IF_Options;
        internal System.Windows.Forms.CheckBox checkBox_IF_Tag;
        internal System.Windows.Forms.TextBox textBox_IF_Tag;
        internal System.Windows.Forms.TextBox textBox_IF_FrameDir;
        internal System.Windows.Forms.CheckBox checkBox_IF_FramePath;
        internal System.Windows.Forms.Button button_IF_BrowseFrameDir;
        internal System.Windows.Forms.GroupBox groupBox_ZIPALIGN_Options;
        internal System.Windows.Forms.Label label_ZIPALIGN_AlignmentBytes;
        internal System.Windows.Forms.NumericUpDown numericUpDown_ZIPALIGN_AlignmentBytes;
        internal System.Windows.Forms.CheckBox checkBox_ZIPALIGN_VerboseOutput;
        internal System.Windows.Forms.CheckBox checkBox_ZIPALIGN_CheckAlignment;
        internal System.Windows.Forms.Button button_ZIPALIGN_BrowseOutputFile;
        internal System.Windows.Forms.TextBox textBox_ZIPALIGN_OutputFile;
        internal System.Windows.Forms.CheckBox checkBox_ZIPALIGN_OverwriteOutputFile;
        internal System.Windows.Forms.CheckBox checkBox_ZIPALIGN_Recompress;
        internal System.Windows.Forms.GroupBox groupBox_SIGN_Options;
        internal System.Windows.Forms.Label label_SIGN_PrivateKey;
        internal System.Windows.Forms.Button button_SIGN_BrowsePrivateKey;
        internal System.Windows.Forms.TextBox textBox_SIGN_PrivateKey;
        internal System.Windows.Forms.Label label_SIGN_PublicKey;
        internal System.Windows.Forms.Button button_SIGN_BrowsePublicKey;
        internal System.Windows.Forms.TextBox textBox_SIGN_PublicKey;
        internal System.Windows.Forms.Button button_SIGN_BrowseOutputFile;
        internal System.Windows.Forms.TextBox textBox_SIGN_OutputFile;
        internal System.Windows.Forms.TabPage tabPageMain;
        internal System.Windows.Forms.GroupBox groupBox_DECODE_Options;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_MatchOriginal;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_KeepBrokenRes;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_Force;
        internal System.Windows.Forms.Panel signPanel;
        internal System.Windows.Forms.TextBox textBox_SIGN_InputFile;
        internal System.Windows.Forms.Button button_SIGN_BrowseInputFile;
        internal System.Windows.Forms.Button button_SIGN_Sign;
        internal System.Windows.Forms.Panel zipalignPanel;
        internal System.Windows.Forms.Button button_ZIPALIGN_Align;
        internal System.Windows.Forms.Button button_ZIPALIGN_BrowseInputFile;
        internal System.Windows.Forms.TextBox textBox_ZIPALIGN_InputFile;
        internal System.Windows.Forms.Panel comPanel;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button button_BUILD_BrowseInputProjectDir;
        internal System.Windows.Forms.Button button_BUILD_Build;
        internal System.Windows.Forms.TextBox textBox_BUILD_InputProjectDir;
        internal System.Windows.Forms.Panel decPanel;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBox_DECODE_InputAppPath;
        internal System.Windows.Forms.Button button_DECODE_Decode;
        internal System.Windows.Forms.Button button_DECODE_BrowseInputAppPath;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox textBox_DECODE_FrameDir;
        internal System.Windows.Forms.Button button_DECODE_BrowseOutputDirectory;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_UseFramework;
        internal System.Windows.Forms.Button button_DECODE_BrowseFrameDir;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_OutputDirectory;
        internal System.Windows.Forms.TextBox textBox_DECODE_OutputDirectory;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_NoSrc;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_NoRes;
        internal System.Windows.Forms.Button button_OpenMainActivity;
        internal System.Windows.Forms.Button openAndroidMainfestBtn;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_OnlyMainClasses;
        internal System.Windows.Forms.CheckBox checkBox_BUILD_NoCrunch;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_FixError;
        internal System.Windows.Forms.TabPage tabPageApkInfo;
        internal System.Windows.Forms.RichTextBox permTxtBox;
        internal System.Windows.Forms.TextBox buildTxtBox;
        internal System.Windows.Forms.PictureBox apkIconPicBox;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox densityTxtBox;
        internal System.Windows.Forms.TextBox screenTxtBox;
        internal System.Windows.Forms.TextBox minSdkTxtBox;
        internal System.Windows.Forms.TextBox verTxtBox;
        internal System.Windows.Forms.TextBox packNameTxtBox;
        internal System.Windows.Forms.TextBox appTxtBox;
        internal System.Windows.Forms.CheckBox checkBox_DECODE_NoDebugInfo;
        internal System.Windows.Forms.RichTextBox localsTxtBox;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox targetSdkTxtBox;
        internal System.Windows.Forms.TextBox fileTxtBox;
        internal System.Windows.Forms.Button comApkOpenDir;
        internal System.Windows.Forms.Button decApkOpenDirBtn;
        internal System.Windows.Forms.Button compileOutputOpenDirBtn;
        internal System.Windows.Forms.Button apkComboLinkBtn;
        internal System.Windows.Forms.Button apkPureLinkBtn;
        internal System.Windows.Forms.Button psLinkBtn;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.CheckBox zipalignAfterBuildChkBox;
        internal System.Windows.Forms.CheckBox clearFwBeforeDecodeChkBox;
        internal System.Windows.Forms.Button clearFwBtn;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.CheckBox signAfterBuildChkBox;
        internal System.Windows.Forms.CheckBox signAfterZipalignChkBox;
        internal System.Windows.Forms.CheckBox zipalignOutputDirChkBox;
        internal System.Windows.Forms.CheckBox useSigningOutputDir;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox keyStoreFileTxtBox;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.CheckBox useKeyStoreChkBox;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.Button selectKeyStoreFileBtn;
        internal System.Windows.Forms.TextBox aliasTxtBox;
        internal System.Windows.Forms.CheckBox useAliasChkBox;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.CheckBox createUnsignApkChkBox;
        internal System.Windows.Forms.ComboBox schemev4ComboBox;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox schemev3ComboBox;
        internal System.Windows.Forms.Label label26;
        internal System.Windows.Forms.ComboBox schemev2ComboBox;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.ComboBox schemev1ComboBox;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.NumericUpDown decApiLvlUpDown;
        internal System.Windows.Forms.CheckBox decSetApiLvlChkBox;
        internal System.Windows.Forms.NumericUpDown buildApiLvlUpDown;
        internal System.Windows.Forms.CheckBox buildSetApiLvlChkBox;
        internal System.Windows.Forms.TabPage tabPageBaksmali;
        internal System.Windows.Forms.Button openFwFolderBtn;
        internal System.Windows.Forms.Button selApkFileInfoBtn;
        internal System.Windows.Forms.GroupBox smaliGroupBox;
        internal System.Windows.Forms.GroupBox bakSmaliGroupBox;
        internal System.Windows.Forms.Button comSmaliBtn;
        internal System.Windows.Forms.TextBox smaliBrowseInputDirTxtBox;
        internal System.Windows.Forms.Button smaliBrowseInputDirBtn;
        internal System.Windows.Forms.Button decSmaliBtn;
        internal System.Windows.Forms.Button baksmaliBrowseInputDexBtn;
        internal System.Windows.Forms.TextBox baksmaliBrowseInputDexTxtBox;
        internal System.Windows.Forms.CheckBox smaliUseOutputChkBox;
        internal System.Windows.Forms.Button smaliBrowseOutputBtn;
        internal System.Windows.Forms.TextBox smaliBrowseOutputTxtBox;
        internal System.Windows.Forms.CheckBox baksmaliUseOutputChkBox;
        internal System.Windows.Forms.Button baksmaliBrowseOutputBtn;
        internal System.Windows.Forms.TextBox baksmaliBrowseOutputTxtBox;
        internal System.Windows.Forms.Button openApktoolYmlBtn;
        internal System.Windows.Forms.Button apkAioLinkBtn;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        internal System.Windows.Forms.Button signApkOpenDirBtn;
        internal System.Windows.Forms.Button alignApkOpenDirBtn;
        internal System.Windows.Forms.Button decOutOpenDirBtn;
        private System.Windows.Forms.CheckBox useAapt2ChkBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox fullInfoTextBox;
        internal System.Windows.Forms.TabPage basicInfoTabPage;
        internal System.Windows.Forms.Button apkMirrorLinkBtn;
        internal System.Windows.Forms.Button apkDlLinkBtn;
        internal System.Windows.Forms.Button apkSosLinkBtn;
        internal System.Windows.Forms.Button apkSupportLinkBtn;
        internal System.Windows.Forms.Button apkGkLinkBtn;
        internal System.Windows.Forms.TextBox archSdkTxtBox;
        internal System.Windows.Forms.Label label30;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoDelIdsigChkBox;
        private System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.TextBox launchActivityTxtBox;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.RichTextBox logTxtBox;
        internal System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_DECODE_UseApkEditorMerge;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Button selApkAdbBtn;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        internal System.Windows.Forms.TabPage tabPageAdb;
        internal System.Windows.Forms.Button installApkBtn;
        internal System.Windows.Forms.TextBox apkPathAdbTxtBox;
        internal System.Windows.Forms.ListBox devicesListBox;
        internal System.Windows.Forms.CheckBox setVendorChkBox;
        internal System.Windows.Forms.Button killAdbBtn;
        internal System.Windows.Forms.Button refreshDevicesBtn;
        internal System.Windows.Forms.Label selAdbDeviceLbl;
        private System.Windows.Forms.CheckBox checkBox2;
        internal System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem apktoolIssuesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem baksmaliIssuesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem openTempFolderToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem reportAnIsuueToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveLogToFileToolStripMenuItem;
    }
}

