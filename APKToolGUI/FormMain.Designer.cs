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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_DECODE_BrowseInputAppPath = new System.Windows.Forms.Button();
            this.button_DECODE_Decode = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDecode = new System.Windows.Forms.TabPage();
            this.groupBox_DECODE_Options = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_DECODE_Options = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_DECODE_MatchOriginal = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_KeepBrokenRes = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_Force = new System.Windows.Forms.CheckBox();
            this.checkBox_DECODE_NoRes = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelDecodeOutputDir = new System.Windows.Forms.TableLayoutPanel();
            this.button_DECODE_BrowseOutputDirectory = new System.Windows.Forms.Button();
            this.checkBox_DECODE_OutputDirectory = new System.Windows.Forms.CheckBox();
            this.textBox_DECODE_OutputDirectory = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelDecodeUseFramework = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_DECODE_FrameDir = new System.Windows.Forms.TextBox();
            this.checkBox_DECODE_UseFramework = new System.Windows.Forms.CheckBox();
            this.button_DECODE_BrowseFrameDir = new System.Windows.Forms.Button();
            this.checkBox_DECODE_NoSrc = new System.Windows.Forms.CheckBox();
            this.textBox_DECODE_InputAppPath = new System.Windows.Forms.TextBox();
            this.tabPageBuild = new System.Windows.Forms.TabPage();
            this.groupBox_BUILD_Options = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_BUILD_Options = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBuildOutputApk = new System.Windows.Forms.TableLayoutPanel();
            this.button_BUILD_BrowseOutputAppPath = new System.Windows.Forms.Button();
            this.checkBox_BUILD_OutputAppPath = new System.Windows.Forms.CheckBox();
            this.textBox_BUILD_OutputAppPath = new System.Windows.Forms.TextBox();
            this.checkBox_BUILD_CopyOriginal = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelBuildUseFramework = new System.Windows.Forms.TableLayoutPanel();
            this.button_BUILD_BrowseFrameDir = new System.Windows.Forms.Button();
            this.checkBox_BUILD_UseFramework = new System.Windows.Forms.CheckBox();
            this.textBox_BUILD_FrameDir = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelBuildUseAapt = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_BUILD_AaptPath = new System.Windows.Forms.TextBox();
            this.checkBox_BUILD_UseAapt = new System.Windows.Forms.CheckBox();
            this.button_BUILD_BrowseAaptPath = new System.Windows.Forms.Button();
            this.checkBox_BUILD_ForceAll = new System.Windows.Forms.CheckBox();
            this.button_BUILD_BrowseInputProjectDir = new System.Windows.Forms.Button();
            this.button_BUILD_Build = new System.Windows.Forms.Button();
            this.textBox_BUILD_InputProjectDir = new System.Windows.Forms.TextBox();
            this.tabPageInstallFramework = new System.Windows.Forms.TabPage();
            this.groupBox_IF_Options = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_IF_Options = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_IF_Tag = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_IF_Tag = new System.Windows.Forms.CheckBox();
            this.textBox_IF_Tag = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_IF_FramePath = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_IF_FrameDir = new System.Windows.Forms.TextBox();
            this.checkBox_IF_FramePath = new System.Windows.Forms.CheckBox();
            this.button_IF_BrowseFrameDir = new System.Windows.Forms.Button();
            this.button_IF_InstallFramework = new System.Windows.Forms.Button();
            this.button_IF_BrowseInputFramePath = new System.Windows.Forms.Button();
            this.textBox_IF_InputFramePath = new System.Windows.Forms.TextBox();
            this.tabPageSign = new System.Windows.Forms.TabPage();
            this.groupBox_SIGN_Options = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_SIGN_Options = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_SIGN_PrivateKey = new System.Windows.Forms.TableLayoutPanel();
            this.label_SIGN_PrivateKey = new System.Windows.Forms.Label();
            this.button_SIGN_BrowsePrivateKey = new System.Windows.Forms.Button();
            this.textBox_SIGN_PrivateKey = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_SIGN_PublicKey = new System.Windows.Forms.TableLayoutPanel();
            this.label_SIGN_PublicKey = new System.Windows.Forms.Label();
            this.button_SIGN_BrowsePublicKey = new System.Windows.Forms.Button();
            this.textBox_SIGN_PublicKey = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_SIGN_OutputFile = new System.Windows.Forms.TableLayoutPanel();
            this.label_SIGN_OutputFile = new System.Windows.Forms.Label();
            this.button_SIGN_BrowseOutputFile = new System.Windows.Forms.Button();
            this.textBox_SIGN_OutputFile = new System.Windows.Forms.TextBox();
            this.textBox_SIGN_InputFile = new System.Windows.Forms.TextBox();
            this.button_SIGN_BrowseInputFile = new System.Windows.Forms.Button();
            this.button_SIGN_Sign = new System.Windows.Forms.Button();
            this.tabPageZipAlign = new System.Windows.Forms.TabPage();
            this.groupBox_ZIPALIGN_Options = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_ZIPALIGN_Options = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_ZIPALIGN_Recompress = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes = new System.Windows.Forms.TableLayoutPanel();
            this.label_ZIPALIGN_AlignmentBytes = new System.Windows.Forms.Label();
            this.numericUpDown_ZIPALIGN_AlignmentBytes = new System.Windows.Forms.NumericUpDown();
            this.checkBox_ZIPALIGN_VerboseOutput = new System.Windows.Forms.CheckBox();
            this.checkBox_ZIPALIGN_CheckAlignment = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_ZIPALIGN_OutputFile = new System.Windows.Forms.TableLayoutPanel();
            this.label_ZIPALIGN_OutputFile = new System.Windows.Forms.Label();
            this.button_ZIPALIGN_BrowseOutputFile = new System.Windows.Forms.Button();
            this.textBox_ZIPALIGN_OutputFile = new System.Windows.Forms.TextBox();
            this.checkBox_ZIPALIGN_OverwriteOutputFile = new System.Windows.Forms.CheckBox();
            this.button_ZIPALIGN_Align = new System.Windows.Forms.Button();
            this.button_ZIPALIGN_BrowseInputFile = new System.Windows.Forms.Button();
            this.textBox_ZIPALIGN_InputFile = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStateImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStateText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemSettings = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemCheckUpdate = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.openFileDialogApk = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogBuild = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlMain.SuspendLayout();
            this.tabPageDecode.SuspendLayout();
            this.groupBox_DECODE_Options.SuspendLayout();
            this.tableLayoutPanel_DECODE_Options.SuspendLayout();
            this.tableLayoutPanelDecodeOutputDir.SuspendLayout();
            this.tableLayoutPanelDecodeUseFramework.SuspendLayout();
            this.tabPageBuild.SuspendLayout();
            this.groupBox_BUILD_Options.SuspendLayout();
            this.tableLayoutPanel_BUILD_Options.SuspendLayout();
            this.tableLayoutPanelBuildOutputApk.SuspendLayout();
            this.tableLayoutPanelBuildUseFramework.SuspendLayout();
            this.tableLayoutPanelBuildUseAapt.SuspendLayout();
            this.tabPageInstallFramework.SuspendLayout();
            this.groupBox_IF_Options.SuspendLayout();
            this.tableLayoutPanel_IF_Options.SuspendLayout();
            this.tableLayoutPanel_IF_Tag.SuspendLayout();
            this.tableLayoutPanel_IF_FramePath.SuspendLayout();
            this.tabPageSign.SuspendLayout();
            this.groupBox_SIGN_Options.SuspendLayout();
            this.tableLayoutPanel_SIGN_Options.SuspendLayout();
            this.tableLayoutPanel_SIGN_PrivateKey.SuspendLayout();
            this.tableLayoutPanel_SIGN_PublicKey.SuspendLayout();
            this.tableLayoutPanel_SIGN_OutputFile.SuspendLayout();
            this.tabPageZipAlign.SuspendLayout();
            this.groupBox_ZIPALIGN_Options.SuspendLayout();
            this.tableLayoutPanel_ZIPALIGN_Options.SuspendLayout();
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZIPALIGN_AlignmentBytes)).BeginInit();
            this.tableLayoutPanel_ZIPALIGN_OutputFile.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_DECODE_BrowseInputAppPath
            // 
            resources.ApplyResources(this.button_DECODE_BrowseInputAppPath, "button_DECODE_BrowseInputAppPath");
            this.button_DECODE_BrowseInputAppPath.Name = "button_DECODE_BrowseInputAppPath";
            this.button_DECODE_BrowseInputAppPath.UseVisualStyleBackColor = true;
            this.button_DECODE_BrowseInputAppPath.Click += new System.EventHandler(this.button_DECODE_BrowseInputAppPath_Click);
            // 
            // button_DECODE_Decode
            // 
            resources.ApplyResources(this.button_DECODE_Decode, "button_DECODE_Decode");
            this.button_DECODE_Decode.Name = "button_DECODE_Decode";
            this.button_DECODE_Decode.UseVisualStyleBackColor = true;
            this.button_DECODE_Decode.Click += new System.EventHandler(this.button_DECODE_Decode_Click);
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Controls.Add(this.tabPageDecode);
            this.tabControlMain.Controls.Add(this.tabPageBuild);
            this.tabControlMain.Controls.Add(this.tabPageInstallFramework);
            this.tabControlMain.Controls.Add(this.tabPageSign);
            this.tabControlMain.Controls.Add(this.tabPageZipAlign);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            // 
            // tabPageDecode
            // 
            this.tabPageDecode.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageDecode.Controls.Add(this.groupBox_DECODE_Options);
            this.tabPageDecode.Controls.Add(this.textBox_DECODE_InputAppPath);
            this.tabPageDecode.Controls.Add(this.button_DECODE_Decode);
            this.tabPageDecode.Controls.Add(this.button_DECODE_BrowseInputAppPath);
            resources.ApplyResources(this.tabPageDecode, "tabPageDecode");
            this.tabPageDecode.Name = "tabPageDecode";
            // 
            // groupBox_DECODE_Options
            // 
            resources.ApplyResources(this.groupBox_DECODE_Options, "groupBox_DECODE_Options");
            this.groupBox_DECODE_Options.Controls.Add(this.tableLayoutPanel_DECODE_Options);
            this.groupBox_DECODE_Options.Name = "groupBox_DECODE_Options";
            this.groupBox_DECODE_Options.TabStop = false;
            // 
            // tableLayoutPanel_DECODE_Options
            // 
            resources.ApplyResources(this.tableLayoutPanel_DECODE_Options, "tableLayoutPanel_DECODE_Options");
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.checkBox_DECODE_MatchOriginal, 0, 4);
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.checkBox_DECODE_KeepBrokenRes, 0, 3);
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.checkBox_DECODE_Force, 0, 2);
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.checkBox_DECODE_NoRes, 0, 1);
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.tableLayoutPanelDecodeOutputDir, 0, 6);
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.tableLayoutPanelDecodeUseFramework, 0, 5);
            this.tableLayoutPanel_DECODE_Options.Controls.Add(this.checkBox_DECODE_NoSrc, 0, 0);
            this.tableLayoutPanel_DECODE_Options.Name = "tableLayoutPanel_DECODE_Options";
            // 
            // checkBox_DECODE_MatchOriginal
            // 
            this.checkBox_DECODE_MatchOriginal.AutoEllipsis = true;
            this.checkBox_DECODE_MatchOriginal.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_MatchOriginal;
            this.checkBox_DECODE_MatchOriginal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_MatchOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_MatchOriginal, "checkBox_DECODE_MatchOriginal");
            this.checkBox_DECODE_MatchOriginal.Name = "checkBox_DECODE_MatchOriginal";
            this.checkBox_DECODE_MatchOriginal.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_KeepBrokenRes
            // 
            this.checkBox_DECODE_KeepBrokenRes.AutoEllipsis = true;
            this.checkBox_DECODE_KeepBrokenRes.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_KeepBrokenRes;
            this.checkBox_DECODE_KeepBrokenRes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_KeepBrokenRes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_KeepBrokenRes, "checkBox_DECODE_KeepBrokenRes");
            this.checkBox_DECODE_KeepBrokenRes.Name = "checkBox_DECODE_KeepBrokenRes";
            this.checkBox_DECODE_KeepBrokenRes.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_Force
            // 
            this.checkBox_DECODE_Force.AutoEllipsis = true;
            this.checkBox_DECODE_Force.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_Force;
            this.checkBox_DECODE_Force.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_Force", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_Force, "checkBox_DECODE_Force");
            this.checkBox_DECODE_Force.Name = "checkBox_DECODE_Force";
            this.checkBox_DECODE_Force.UseVisualStyleBackColor = true;
            // 
            // checkBox_DECODE_NoRes
            // 
            this.checkBox_DECODE_NoRes.AutoEllipsis = true;
            this.checkBox_DECODE_NoRes.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_NoRes;
            this.checkBox_DECODE_NoRes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_NoRes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_NoRes, "checkBox_DECODE_NoRes");
            this.checkBox_DECODE_NoRes.Name = "checkBox_DECODE_NoRes";
            this.checkBox_DECODE_NoRes.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDecodeOutputDir
            // 
            resources.ApplyResources(this.tableLayoutPanelDecodeOutputDir, "tableLayoutPanelDecodeOutputDir");
            this.tableLayoutPanelDecodeOutputDir.Controls.Add(this.button_DECODE_BrowseOutputDirectory, 2, 0);
            this.tableLayoutPanelDecodeOutputDir.Controls.Add(this.checkBox_DECODE_OutputDirectory, 0, 0);
            this.tableLayoutPanelDecodeOutputDir.Controls.Add(this.textBox_DECODE_OutputDirectory, 1, 0);
            this.tableLayoutPanelDecodeOutputDir.Name = "tableLayoutPanelDecodeOutputDir";
            // 
            // button_DECODE_BrowseOutputDirectory
            // 
            this.button_DECODE_BrowseOutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_DECODE_BrowseOutputDirectory.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_UseOutputDir;
            resources.ApplyResources(this.button_DECODE_BrowseOutputDirectory, "button_DECODE_BrowseOutputDirectory");
            this.button_DECODE_BrowseOutputDirectory.Name = "button_DECODE_BrowseOutputDirectory";
            this.button_DECODE_BrowseOutputDirectory.UseVisualStyleBackColor = true;
            this.button_DECODE_BrowseOutputDirectory.Click += new System.EventHandler(this.button_DECODE_BrowseOutputDirectory_Click);
            // 
            // checkBox_DECODE_OutputDirectory
            // 
            this.checkBox_DECODE_OutputDirectory.AutoEllipsis = true;
            this.checkBox_DECODE_OutputDirectory.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_UseOutputDir;
            this.checkBox_DECODE_OutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_OutputDirectory, "checkBox_DECODE_OutputDirectory");
            this.checkBox_DECODE_OutputDirectory.Name = "checkBox_DECODE_OutputDirectory";
            this.checkBox_DECODE_OutputDirectory.UseVisualStyleBackColor = true;
            // 
            // textBox_DECODE_OutputDirectory
            // 
            this.textBox_DECODE_OutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_UseOutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_OutputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_OutputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_DECODE_OutputDirectory, "textBox_DECODE_OutputDirectory");
            this.textBox_DECODE_OutputDirectory.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_UseOutputDir;
            this.textBox_DECODE_OutputDirectory.Name = "textBox_DECODE_OutputDirectory";
            this.textBox_DECODE_OutputDirectory.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_OutputDir;
            // 
            // tableLayoutPanelDecodeUseFramework
            // 
            resources.ApplyResources(this.tableLayoutPanelDecodeUseFramework, "tableLayoutPanelDecodeUseFramework");
            this.tableLayoutPanelDecodeUseFramework.Controls.Add(this.textBox_DECODE_FrameDir, 0, 0);
            this.tableLayoutPanelDecodeUseFramework.Controls.Add(this.checkBox_DECODE_UseFramework, 0, 0);
            this.tableLayoutPanelDecodeUseFramework.Controls.Add(this.button_DECODE_BrowseFrameDir, 2, 0);
            this.tableLayoutPanelDecodeUseFramework.Name = "tableLayoutPanelDecodeUseFramework";
            // 
            // textBox_DECODE_FrameDir
            // 
            this.textBox_DECODE_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_FrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_DECODE_FrameDir, "textBox_DECODE_FrameDir");
            this.textBox_DECODE_FrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_UseFramework;
            this.textBox_DECODE_FrameDir.Name = "textBox_DECODE_FrameDir";
            this.textBox_DECODE_FrameDir.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_FrameDir;
            // 
            // checkBox_DECODE_UseFramework
            // 
            this.checkBox_DECODE_UseFramework.AutoEllipsis = true;
            this.checkBox_DECODE_UseFramework.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_UseFramework;
            this.checkBox_DECODE_UseFramework.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_UseFramework, "checkBox_DECODE_UseFramework");
            this.checkBox_DECODE_UseFramework.Name = "checkBox_DECODE_UseFramework";
            this.checkBox_DECODE_UseFramework.UseVisualStyleBackColor = true;
            // 
            // button_DECODE_BrowseFrameDir
            // 
            this.button_DECODE_BrowseFrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_DECODE_BrowseFrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_UseFramework;
            resources.ApplyResources(this.button_DECODE_BrowseFrameDir, "button_DECODE_BrowseFrameDir");
            this.button_DECODE_BrowseFrameDir.Name = "button_DECODE_BrowseFrameDir";
            this.button_DECODE_BrowseFrameDir.UseVisualStyleBackColor = true;
            this.button_DECODE_BrowseFrameDir.Click += new System.EventHandler(this.button_DECODE_BrowseFrameDir_Click);
            // 
            // checkBox_DECODE_NoSrc
            // 
            this.checkBox_DECODE_NoSrc.AutoEllipsis = true;
            this.checkBox_DECODE_NoSrc.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_NoSrc;
            this.checkBox_DECODE_NoSrc.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_NoSrc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_DECODE_NoSrc, "checkBox_DECODE_NoSrc");
            this.checkBox_DECODE_NoSrc.Name = "checkBox_DECODE_NoSrc";
            this.checkBox_DECODE_NoSrc.UseVisualStyleBackColor = true;
            // 
            // textBox_DECODE_InputAppPath
            // 
            resources.ApplyResources(this.textBox_DECODE_InputAppPath, "textBox_DECODE_InputAppPath");
            this.textBox_DECODE_InputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Decode_InputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_DECODE_InputAppPath.Name = "textBox_DECODE_InputAppPath";
            this.textBox_DECODE_InputAppPath.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Decode_InputAppPath;
            // 
            // tabPageBuild
            // 
            this.tabPageBuild.Controls.Add(this.groupBox_BUILD_Options);
            this.tabPageBuild.Controls.Add(this.button_BUILD_BrowseInputProjectDir);
            this.tabPageBuild.Controls.Add(this.button_BUILD_Build);
            this.tabPageBuild.Controls.Add(this.textBox_BUILD_InputProjectDir);
            resources.ApplyResources(this.tabPageBuild, "tabPageBuild");
            this.tabPageBuild.Name = "tabPageBuild";
            this.tabPageBuild.UseVisualStyleBackColor = true;
            // 
            // groupBox_BUILD_Options
            // 
            resources.ApplyResources(this.groupBox_BUILD_Options, "groupBox_BUILD_Options");
            this.groupBox_BUILD_Options.Controls.Add(this.tableLayoutPanel_BUILD_Options);
            this.groupBox_BUILD_Options.Name = "groupBox_BUILD_Options";
            this.groupBox_BUILD_Options.TabStop = false;
            // 
            // tableLayoutPanel_BUILD_Options
            // 
            resources.ApplyResources(this.tableLayoutPanel_BUILD_Options, "tableLayoutPanel_BUILD_Options");
            this.tableLayoutPanel_BUILD_Options.Controls.Add(this.tableLayoutPanelBuildOutputApk, 0, 4);
            this.tableLayoutPanel_BUILD_Options.Controls.Add(this.checkBox_BUILD_CopyOriginal, 0, 1);
            this.tableLayoutPanel_BUILD_Options.Controls.Add(this.tableLayoutPanelBuildUseFramework, 0, 3);
            this.tableLayoutPanel_BUILD_Options.Controls.Add(this.tableLayoutPanelBuildUseAapt, 0, 2);
            this.tableLayoutPanel_BUILD_Options.Controls.Add(this.checkBox_BUILD_ForceAll, 0, 0);
            this.tableLayoutPanel_BUILD_Options.Name = "tableLayoutPanel_BUILD_Options";
            // 
            // tableLayoutPanelBuildOutputApk
            // 
            resources.ApplyResources(this.tableLayoutPanelBuildOutputApk, "tableLayoutPanelBuildOutputApk");
            this.tableLayoutPanelBuildOutputApk.Controls.Add(this.button_BUILD_BrowseOutputAppPath, 2, 0);
            this.tableLayoutPanelBuildOutputApk.Controls.Add(this.checkBox_BUILD_OutputAppPath, 0, 0);
            this.tableLayoutPanelBuildOutputApk.Controls.Add(this.textBox_BUILD_OutputAppPath, 1, 0);
            this.tableLayoutPanelBuildOutputApk.Name = "tableLayoutPanelBuildOutputApk";
            // 
            // button_BUILD_BrowseOutputAppPath
            // 
            this.button_BUILD_BrowseOutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseOutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_BUILD_BrowseOutputAppPath.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseOutputAppPath;
            resources.ApplyResources(this.button_BUILD_BrowseOutputAppPath, "button_BUILD_BrowseOutputAppPath");
            this.button_BUILD_BrowseOutputAppPath.Name = "button_BUILD_BrowseOutputAppPath";
            this.button_BUILD_BrowseOutputAppPath.UseVisualStyleBackColor = true;
            this.button_BUILD_BrowseOutputAppPath.Click += new System.EventHandler(this.button_BUILD_BrowseOutputAppPath_Click);
            // 
            // checkBox_BUILD_OutputAppPath
            // 
            this.checkBox_BUILD_OutputAppPath.AutoEllipsis = true;
            this.checkBox_BUILD_OutputAppPath.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseOutputAppPath;
            this.checkBox_BUILD_OutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseOutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_BUILD_OutputAppPath, "checkBox_BUILD_OutputAppPath");
            this.checkBox_BUILD_OutputAppPath.Name = "checkBox_BUILD_OutputAppPath";
            this.checkBox_BUILD_OutputAppPath.UseVisualStyleBackColor = true;
            // 
            // textBox_BUILD_OutputAppPath
            // 
            this.textBox_BUILD_OutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_OutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_OutputAppPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseOutputAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_BUILD_OutputAppPath, "textBox_BUILD_OutputAppPath");
            this.textBox_BUILD_OutputAppPath.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseOutputAppPath;
            this.textBox_BUILD_OutputAppPath.Name = "textBox_BUILD_OutputAppPath";
            this.textBox_BUILD_OutputAppPath.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_OutputAppPath;
            // 
            // checkBox_BUILD_CopyOriginal
            // 
            this.checkBox_BUILD_CopyOriginal.AutoEllipsis = true;
            this.checkBox_BUILD_CopyOriginal.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_CopyOriginal;
            this.checkBox_BUILD_CopyOriginal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_CopyOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_BUILD_CopyOriginal, "checkBox_BUILD_CopyOriginal");
            this.checkBox_BUILD_CopyOriginal.Name = "checkBox_BUILD_CopyOriginal";
            this.checkBox_BUILD_CopyOriginal.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelBuildUseFramework
            // 
            resources.ApplyResources(this.tableLayoutPanelBuildUseFramework, "tableLayoutPanelBuildUseFramework");
            this.tableLayoutPanelBuildUseFramework.Controls.Add(this.button_BUILD_BrowseFrameDir, 2, 0);
            this.tableLayoutPanelBuildUseFramework.Controls.Add(this.checkBox_BUILD_UseFramework, 0, 0);
            this.tableLayoutPanelBuildUseFramework.Controls.Add(this.textBox_BUILD_FrameDir, 1, 0);
            this.tableLayoutPanelBuildUseFramework.Name = "tableLayoutPanelBuildUseFramework";
            // 
            // button_BUILD_BrowseFrameDir
            // 
            this.button_BUILD_BrowseFrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_BUILD_BrowseFrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseFramework;
            resources.ApplyResources(this.button_BUILD_BrowseFrameDir, "button_BUILD_BrowseFrameDir");
            this.button_BUILD_BrowseFrameDir.Name = "button_BUILD_BrowseFrameDir";
            this.button_BUILD_BrowseFrameDir.UseVisualStyleBackColor = true;
            this.button_BUILD_BrowseFrameDir.Click += new System.EventHandler(this.button_BUILD_BrowseFrameDir_Click);
            // 
            // checkBox_BUILD_UseFramework
            // 
            this.checkBox_BUILD_UseFramework.AutoEllipsis = true;
            this.checkBox_BUILD_UseFramework.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseFramework;
            this.checkBox_BUILD_UseFramework.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_BUILD_UseFramework, "checkBox_BUILD_UseFramework");
            this.checkBox_BUILD_UseFramework.Name = "checkBox_BUILD_UseFramework";
            this.checkBox_BUILD_UseFramework.UseVisualStyleBackColor = true;
            // 
            // textBox_BUILD_FrameDir
            // 
            this.textBox_BUILD_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_FrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_BUILD_FrameDir, "textBox_BUILD_FrameDir");
            this.textBox_BUILD_FrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseFramework;
            this.textBox_BUILD_FrameDir.Name = "textBox_BUILD_FrameDir";
            this.textBox_BUILD_FrameDir.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_FrameDir;
            // 
            // tableLayoutPanelBuildUseAapt
            // 
            resources.ApplyResources(this.tableLayoutPanelBuildUseAapt, "tableLayoutPanelBuildUseAapt");
            this.tableLayoutPanelBuildUseAapt.Controls.Add(this.textBox_BUILD_AaptPath, 0, 0);
            this.tableLayoutPanelBuildUseAapt.Controls.Add(this.checkBox_BUILD_UseAapt, 0, 0);
            this.tableLayoutPanelBuildUseAapt.Controls.Add(this.button_BUILD_BrowseAaptPath, 2, 0);
            this.tableLayoutPanelBuildUseAapt.Name = "tableLayoutPanelBuildUseAapt";
            // 
            // textBox_BUILD_AaptPath
            // 
            this.textBox_BUILD_AaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_AaptPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_AaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_BUILD_AaptPath, "textBox_BUILD_AaptPath");
            this.textBox_BUILD_AaptPath.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseAapt;
            this.textBox_BUILD_AaptPath.Name = "textBox_BUILD_AaptPath";
            this.textBox_BUILD_AaptPath.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_AaptPath;
            // 
            // checkBox_BUILD_UseAapt
            // 
            this.checkBox_BUILD_UseAapt.AutoEllipsis = true;
            this.checkBox_BUILD_UseAapt.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseAapt;
            this.checkBox_BUILD_UseAapt.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_BUILD_UseAapt, "checkBox_BUILD_UseAapt");
            this.checkBox_BUILD_UseAapt.Name = "checkBox_BUILD_UseAapt";
            this.checkBox_BUILD_UseAapt.UseVisualStyleBackColor = true;
            // 
            // button_BUILD_BrowseAaptPath
            // 
            this.button_BUILD_BrowseAaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_UseAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_BUILD_BrowseAaptPath.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_UseAapt;
            resources.ApplyResources(this.button_BUILD_BrowseAaptPath, "button_BUILD_BrowseAaptPath");
            this.button_BUILD_BrowseAaptPath.Name = "button_BUILD_BrowseAaptPath";
            this.button_BUILD_BrowseAaptPath.UseVisualStyleBackColor = true;
            this.button_BUILD_BrowseAaptPath.Click += new System.EventHandler(this.button_BUILD_BrowseAaptPath_Click);
            // 
            // checkBox_BUILD_ForceAll
            // 
            this.checkBox_BUILD_ForceAll.AutoEllipsis = true;
            this.checkBox_BUILD_ForceAll.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_ForceAll;
            this.checkBox_BUILD_ForceAll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_ForceAll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_BUILD_ForceAll, "checkBox_BUILD_ForceAll");
            this.checkBox_BUILD_ForceAll.Name = "checkBox_BUILD_ForceAll";
            this.checkBox_BUILD_ForceAll.UseVisualStyleBackColor = true;
            // 
            // button_BUILD_BrowseInputProjectDir
            // 
            resources.ApplyResources(this.button_BUILD_BrowseInputProjectDir, "button_BUILD_BrowseInputProjectDir");
            this.button_BUILD_BrowseInputProjectDir.Name = "button_BUILD_BrowseInputProjectDir";
            this.button_BUILD_BrowseInputProjectDir.UseVisualStyleBackColor = true;
            this.button_BUILD_BrowseInputProjectDir.Click += new System.EventHandler(this.button_BUILD_BrowseInputProjectDir_Click);
            // 
            // button_BUILD_Build
            // 
            resources.ApplyResources(this.button_BUILD_Build, "button_BUILD_Build");
            this.button_BUILD_Build.Name = "button_BUILD_Build";
            this.button_BUILD_Build.UseVisualStyleBackColor = true;
            this.button_BUILD_Build.Click += new System.EventHandler(this.button_BUILD_Build_Click);
            // 
            // textBox_BUILD_InputProjectDir
            // 
            resources.ApplyResources(this.textBox_BUILD_InputProjectDir, "textBox_BUILD_InputProjectDir");
            this.textBox_BUILD_InputProjectDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Build_InputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_BUILD_InputProjectDir.Name = "textBox_BUILD_InputProjectDir";
            this.textBox_BUILD_InputProjectDir.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Build_InputDir;
            // 
            // tabPageInstallFramework
            // 
            this.tabPageInstallFramework.Controls.Add(this.groupBox_IF_Options);
            this.tabPageInstallFramework.Controls.Add(this.button_IF_InstallFramework);
            this.tabPageInstallFramework.Controls.Add(this.button_IF_BrowseInputFramePath);
            this.tabPageInstallFramework.Controls.Add(this.textBox_IF_InputFramePath);
            resources.ApplyResources(this.tabPageInstallFramework, "tabPageInstallFramework");
            this.tabPageInstallFramework.Name = "tabPageInstallFramework";
            this.tabPageInstallFramework.UseVisualStyleBackColor = true;
            // 
            // groupBox_IF_Options
            // 
            resources.ApplyResources(this.groupBox_IF_Options, "groupBox_IF_Options");
            this.groupBox_IF_Options.Controls.Add(this.tableLayoutPanel_IF_Options);
            this.groupBox_IF_Options.Name = "groupBox_IF_Options";
            this.groupBox_IF_Options.TabStop = false;
            // 
            // tableLayoutPanel_IF_Options
            // 
            resources.ApplyResources(this.tableLayoutPanel_IF_Options, "tableLayoutPanel_IF_Options");
            this.tableLayoutPanel_IF_Options.Controls.Add(this.tableLayoutPanel_IF_Tag, 0, 1);
            this.tableLayoutPanel_IF_Options.Controls.Add(this.tableLayoutPanel_IF_FramePath, 0, 0);
            this.tableLayoutPanel_IF_Options.Name = "tableLayoutPanel_IF_Options";
            // 
            // tableLayoutPanel_IF_Tag
            // 
            resources.ApplyResources(this.tableLayoutPanel_IF_Tag, "tableLayoutPanel_IF_Tag");
            this.tableLayoutPanel_IF_Tag.Controls.Add(this.checkBox_IF_Tag, 0, 0);
            this.tableLayoutPanel_IF_Tag.Controls.Add(this.textBox_IF_Tag, 1, 0);
            this.tableLayoutPanel_IF_Tag.Name = "tableLayoutPanel_IF_Tag";
            // 
            // checkBox_IF_Tag
            // 
            this.checkBox_IF_Tag.AutoEllipsis = true;
            this.checkBox_IF_Tag.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_UseTag;
            this.checkBox_IF_Tag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_UseTag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_IF_Tag, "checkBox_IF_Tag");
            this.checkBox_IF_Tag.Name = "checkBox_IF_Tag";
            this.checkBox_IF_Tag.UseVisualStyleBackColor = true;
            // 
            // textBox_IF_Tag
            // 
            this.textBox_IF_Tag.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_Tag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_Tag.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_UseTag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_IF_Tag, "textBox_IF_Tag");
            this.textBox_IF_Tag.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_UseTag;
            this.textBox_IF_Tag.Name = "textBox_IF_Tag";
            this.textBox_IF_Tag.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_Tag;
            // 
            // tableLayoutPanel_IF_FramePath
            // 
            resources.ApplyResources(this.tableLayoutPanel_IF_FramePath, "tableLayoutPanel_IF_FramePath");
            this.tableLayoutPanel_IF_FramePath.Controls.Add(this.textBox_IF_FrameDir, 0, 0);
            this.tableLayoutPanel_IF_FramePath.Controls.Add(this.checkBox_IF_FramePath, 0, 0);
            this.tableLayoutPanel_IF_FramePath.Controls.Add(this.button_IF_BrowseFrameDir, 2, 0);
            this.tableLayoutPanel_IF_FramePath.Name = "tableLayoutPanel_IF_FramePath";
            // 
            // textBox_IF_FrameDir
            // 
            this.textBox_IF_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_UseFrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_FrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_FrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_IF_FrameDir, "textBox_IF_FrameDir");
            this.textBox_IF_FrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_UseFrameDir;
            this.textBox_IF_FrameDir.Name = "textBox_IF_FrameDir";
            this.textBox_IF_FrameDir.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_FrameDir;
            // 
            // checkBox_IF_FramePath
            // 
            this.checkBox_IF_FramePath.AutoEllipsis = true;
            this.checkBox_IF_FramePath.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_UseFrameDir;
            this.checkBox_IF_FramePath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_UseFrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_IF_FramePath, "checkBox_IF_FramePath");
            this.checkBox_IF_FramePath.Name = "checkBox_IF_FramePath";
            this.checkBox_IF_FramePath.UseVisualStyleBackColor = true;
            // 
            // button_IF_BrowseFrameDir
            // 
            this.button_IF_BrowseFrameDir.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_UseFrameDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button_IF_BrowseFrameDir.Enabled = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_UseFrameDir;
            resources.ApplyResources(this.button_IF_BrowseFrameDir, "button_IF_BrowseFrameDir");
            this.button_IF_BrowseFrameDir.Name = "button_IF_BrowseFrameDir";
            this.button_IF_BrowseFrameDir.UseVisualStyleBackColor = true;
            this.button_IF_BrowseFrameDir.Click += new System.EventHandler(this.button_IF_BrowseFrameDir_Click);
            // 
            // button_IF_InstallFramework
            // 
            resources.ApplyResources(this.button_IF_InstallFramework, "button_IF_InstallFramework");
            this.button_IF_InstallFramework.Name = "button_IF_InstallFramework";
            this.button_IF_InstallFramework.UseVisualStyleBackColor = true;
            this.button_IF_InstallFramework.Click += new System.EventHandler(this.button_IF_InstallFramework_Click);
            // 
            // button_IF_BrowseInputFramePath
            // 
            resources.ApplyResources(this.button_IF_BrowseInputFramePath, "button_IF_BrowseInputFramePath");
            this.button_IF_BrowseInputFramePath.Name = "button_IF_BrowseInputFramePath";
            this.button_IF_BrowseInputFramePath.UseVisualStyleBackColor = true;
            this.button_IF_BrowseInputFramePath.Click += new System.EventHandler(this.button_IF_BrowseInputFramePath_Click);
            // 
            // textBox_IF_InputFramePath
            // 
            resources.ApplyResources(this.textBox_IF_InputFramePath, "textBox_IF_InputFramePath");
            this.textBox_IF_InputFramePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_InstallFramework_InputFramePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_IF_InputFramePath.Name = "textBox_IF_InputFramePath";
            this.textBox_IF_InputFramePath.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_InstallFramework_InputFramePath;
            // 
            // tabPageSign
            // 
            this.tabPageSign.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageSign.Controls.Add(this.groupBox_SIGN_Options);
            this.tabPageSign.Controls.Add(this.textBox_SIGN_InputFile);
            this.tabPageSign.Controls.Add(this.button_SIGN_BrowseInputFile);
            this.tabPageSign.Controls.Add(this.button_SIGN_Sign);
            resources.ApplyResources(this.tabPageSign, "tabPageSign");
            this.tabPageSign.Name = "tabPageSign";
            // 
            // groupBox_SIGN_Options
            // 
            resources.ApplyResources(this.groupBox_SIGN_Options, "groupBox_SIGN_Options");
            this.groupBox_SIGN_Options.Controls.Add(this.tableLayoutPanel_SIGN_Options);
            this.groupBox_SIGN_Options.Name = "groupBox_SIGN_Options";
            this.groupBox_SIGN_Options.TabStop = false;
            // 
            // tableLayoutPanel_SIGN_Options
            // 
            resources.ApplyResources(this.tableLayoutPanel_SIGN_Options, "tableLayoutPanel_SIGN_Options");
            this.tableLayoutPanel_SIGN_Options.Controls.Add(this.tableLayoutPanel_SIGN_PrivateKey, 0, 1);
            this.tableLayoutPanel_SIGN_Options.Controls.Add(this.tableLayoutPanel_SIGN_PublicKey, 0, 0);
            this.tableLayoutPanel_SIGN_Options.Controls.Add(this.tableLayoutPanel_SIGN_OutputFile, 0, 2);
            this.tableLayoutPanel_SIGN_Options.Name = "tableLayoutPanel_SIGN_Options";
            // 
            // tableLayoutPanel_SIGN_PrivateKey
            // 
            resources.ApplyResources(this.tableLayoutPanel_SIGN_PrivateKey, "tableLayoutPanel_SIGN_PrivateKey");
            this.tableLayoutPanel_SIGN_PrivateKey.Controls.Add(this.label_SIGN_PrivateKey, 0, 0);
            this.tableLayoutPanel_SIGN_PrivateKey.Controls.Add(this.button_SIGN_BrowsePrivateKey, 2, 0);
            this.tableLayoutPanel_SIGN_PrivateKey.Controls.Add(this.textBox_SIGN_PrivateKey, 1, 0);
            this.tableLayoutPanel_SIGN_PrivateKey.Name = "tableLayoutPanel_SIGN_PrivateKey";
            // 
            // label_SIGN_PrivateKey
            // 
            resources.ApplyResources(this.label_SIGN_PrivateKey, "label_SIGN_PrivateKey");
            this.label_SIGN_PrivateKey.Name = "label_SIGN_PrivateKey";
            // 
            // button_SIGN_BrowsePrivateKey
            // 
            resources.ApplyResources(this.button_SIGN_BrowsePrivateKey, "button_SIGN_BrowsePrivateKey");
            this.button_SIGN_BrowsePrivateKey.Name = "button_SIGN_BrowsePrivateKey";
            this.button_SIGN_BrowsePrivateKey.UseVisualStyleBackColor = true;
            this.button_SIGN_BrowsePrivateKey.Click += new System.EventHandler(this.button_SIGN_BrowsePrivateKey_Click);
            // 
            // textBox_SIGN_PrivateKey
            // 
            this.textBox_SIGN_PrivateKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_SIGN_PrivateKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_SIGN_PrivateKey, "textBox_SIGN_PrivateKey");
            this.textBox_SIGN_PrivateKey.Name = "textBox_SIGN_PrivateKey";
            this.textBox_SIGN_PrivateKey.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_SIGN_PrivateKey;
            // 
            // tableLayoutPanel_SIGN_PublicKey
            // 
            resources.ApplyResources(this.tableLayoutPanel_SIGN_PublicKey, "tableLayoutPanel_SIGN_PublicKey");
            this.tableLayoutPanel_SIGN_PublicKey.Controls.Add(this.label_SIGN_PublicKey, 0, 0);
            this.tableLayoutPanel_SIGN_PublicKey.Controls.Add(this.button_SIGN_BrowsePublicKey, 2, 0);
            this.tableLayoutPanel_SIGN_PublicKey.Controls.Add(this.textBox_SIGN_PublicKey, 1, 0);
            this.tableLayoutPanel_SIGN_PublicKey.Name = "tableLayoutPanel_SIGN_PublicKey";
            // 
            // label_SIGN_PublicKey
            // 
            resources.ApplyResources(this.label_SIGN_PublicKey, "label_SIGN_PublicKey");
            this.label_SIGN_PublicKey.Name = "label_SIGN_PublicKey";
            // 
            // button_SIGN_BrowsePublicKey
            // 
            resources.ApplyResources(this.button_SIGN_BrowsePublicKey, "button_SIGN_BrowsePublicKey");
            this.button_SIGN_BrowsePublicKey.Name = "button_SIGN_BrowsePublicKey";
            this.button_SIGN_BrowsePublicKey.UseVisualStyleBackColor = true;
            this.button_SIGN_BrowsePublicKey.Click += new System.EventHandler(this.button_SIGN_BrowsePublicKey_Click);
            // 
            // textBox_SIGN_PublicKey
            // 
            this.textBox_SIGN_PublicKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_SIGN_PublicKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_SIGN_PublicKey, "textBox_SIGN_PublicKey");
            this.textBox_SIGN_PublicKey.Name = "textBox_SIGN_PublicKey";
            this.textBox_SIGN_PublicKey.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_SIGN_PublicKey;
            // 
            // tableLayoutPanel_SIGN_OutputFile
            // 
            resources.ApplyResources(this.tableLayoutPanel_SIGN_OutputFile, "tableLayoutPanel_SIGN_OutputFile");
            this.tableLayoutPanel_SIGN_OutputFile.Controls.Add(this.label_SIGN_OutputFile, 0, 0);
            this.tableLayoutPanel_SIGN_OutputFile.Controls.Add(this.button_SIGN_BrowseOutputFile, 2, 0);
            this.tableLayoutPanel_SIGN_OutputFile.Controls.Add(this.textBox_SIGN_OutputFile, 1, 0);
            this.tableLayoutPanel_SIGN_OutputFile.Name = "tableLayoutPanel_SIGN_OutputFile";
            // 
            // label_SIGN_OutputFile
            // 
            resources.ApplyResources(this.label_SIGN_OutputFile, "label_SIGN_OutputFile");
            this.label_SIGN_OutputFile.Name = "label_SIGN_OutputFile";
            // 
            // button_SIGN_BrowseOutputFile
            // 
            resources.ApplyResources(this.button_SIGN_BrowseOutputFile, "button_SIGN_BrowseOutputFile");
            this.button_SIGN_BrowseOutputFile.Name = "button_SIGN_BrowseOutputFile";
            this.button_SIGN_BrowseOutputFile.UseVisualStyleBackColor = true;
            this.button_SIGN_BrowseOutputFile.Click += new System.EventHandler(this.button_SIGN_BrowseOutputFile_Click);
            // 
            // textBox_SIGN_OutputFile
            // 
            this.textBox_SIGN_OutputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_SIGN_OutputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_SIGN_OutputFile, "textBox_SIGN_OutputFile");
            this.textBox_SIGN_OutputFile.Name = "textBox_SIGN_OutputFile";
            this.textBox_SIGN_OutputFile.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_SIGN_OutputFile;
            // 
            // textBox_SIGN_InputFile
            // 
            resources.ApplyResources(this.textBox_SIGN_InputFile, "textBox_SIGN_InputFile");
            this.textBox_SIGN_InputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_SIGN_InputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_SIGN_InputFile.Name = "textBox_SIGN_InputFile";
            this.textBox_SIGN_InputFile.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_SIGN_InputFile;
            // 
            // button_SIGN_BrowseInputFile
            // 
            resources.ApplyResources(this.button_SIGN_BrowseInputFile, "button_SIGN_BrowseInputFile");
            this.button_SIGN_BrowseInputFile.Name = "button_SIGN_BrowseInputFile";
            this.button_SIGN_BrowseInputFile.UseVisualStyleBackColor = true;
            this.button_SIGN_BrowseInputFile.Click += new System.EventHandler(this.button_SIGN_BrowseInputFile_Click);
            // 
            // button_SIGN_Sign
            // 
            resources.ApplyResources(this.button_SIGN_Sign, "button_SIGN_Sign");
            this.button_SIGN_Sign.Name = "button_SIGN_Sign";
            this.button_SIGN_Sign.UseVisualStyleBackColor = true;
            this.button_SIGN_Sign.Click += new System.EventHandler(this.button_SIGN_Sign_Click);
            // 
            // tabPageZipAlign
            // 
            this.tabPageZipAlign.Controls.Add(this.groupBox_ZIPALIGN_Options);
            this.tabPageZipAlign.Controls.Add(this.button_ZIPALIGN_Align);
            this.tabPageZipAlign.Controls.Add(this.button_ZIPALIGN_BrowseInputFile);
            this.tabPageZipAlign.Controls.Add(this.textBox_ZIPALIGN_InputFile);
            resources.ApplyResources(this.tabPageZipAlign, "tabPageZipAlign");
            this.tabPageZipAlign.Name = "tabPageZipAlign";
            this.tabPageZipAlign.UseVisualStyleBackColor = true;
            // 
            // groupBox_ZIPALIGN_Options
            // 
            resources.ApplyResources(this.groupBox_ZIPALIGN_Options, "groupBox_ZIPALIGN_Options");
            this.groupBox_ZIPALIGN_Options.Controls.Add(this.tableLayoutPanel_ZIPALIGN_Options);
            this.groupBox_ZIPALIGN_Options.Name = "groupBox_ZIPALIGN_Options";
            this.groupBox_ZIPALIGN_Options.TabStop = false;
            // 
            // tableLayoutPanel_ZIPALIGN_Options
            // 
            resources.ApplyResources(this.tableLayoutPanel_ZIPALIGN_Options, "tableLayoutPanel_ZIPALIGN_Options");
            this.tableLayoutPanel_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_Recompress, 0, 3);
            this.tableLayoutPanel_ZIPALIGN_Options.Controls.Add(this.tableLayoutPanel_ZIPALIGN_AlignmentBytes, 0, 0);
            this.tableLayoutPanel_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_VerboseOutput, 0, 2);
            this.tableLayoutPanel_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_CheckAlignment, 0, 1);
            this.tableLayoutPanel_ZIPALIGN_Options.Controls.Add(this.tableLayoutPanel_ZIPALIGN_OutputFile, 0, 5);
            this.tableLayoutPanel_ZIPALIGN_Options.Controls.Add(this.checkBox_ZIPALIGN_OverwriteOutputFile, 0, 4);
            this.tableLayoutPanel_ZIPALIGN_Options.Name = "tableLayoutPanel_ZIPALIGN_Options";
            // 
            // checkBox_ZIPALIGN_Recompress
            // 
            this.checkBox_ZIPALIGN_Recompress.AutoEllipsis = true;
            this.checkBox_ZIPALIGN_Recompress.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_Recompress;
            this.checkBox_ZIPALIGN_Recompress.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_Recompress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_ZIPALIGN_Recompress, "checkBox_ZIPALIGN_Recompress");
            this.checkBox_ZIPALIGN_Recompress.Name = "checkBox_ZIPALIGN_Recompress";
            this.checkBox_ZIPALIGN_Recompress.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_ZIPALIGN_AlignmentBytes
            // 
            resources.ApplyResources(this.tableLayoutPanel_ZIPALIGN_AlignmentBytes, "tableLayoutPanel_ZIPALIGN_AlignmentBytes");
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes.Controls.Add(this.label_ZIPALIGN_AlignmentBytes, 0, 0);
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes.Controls.Add(this.numericUpDown_ZIPALIGN_AlignmentBytes, 1, 0);
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes.Name = "tableLayoutPanel_ZIPALIGN_AlignmentBytes";
            // 
            // label_ZIPALIGN_AlignmentBytes
            // 
            resources.ApplyResources(this.label_ZIPALIGN_AlignmentBytes, "label_ZIPALIGN_AlignmentBytes");
            this.label_ZIPALIGN_AlignmentBytes.Name = "label_ZIPALIGN_AlignmentBytes";
            // 
            // numericUpDown_ZIPALIGN_AlignmentBytes
            // 
            this.numericUpDown_ZIPALIGN_AlignmentBytes.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_AlignmentInBytes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.numericUpDown_ZIPALIGN_AlignmentBytes, "numericUpDown_ZIPALIGN_AlignmentBytes");
            this.numericUpDown_ZIPALIGN_AlignmentBytes.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_ZIPALIGN_AlignmentBytes.Name = "numericUpDown_ZIPALIGN_AlignmentBytes";
            this.numericUpDown_ZIPALIGN_AlignmentBytes.Value = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_AlignmentInBytes;
            // 
            // checkBox_ZIPALIGN_VerboseOutput
            // 
            this.checkBox_ZIPALIGN_VerboseOutput.AutoEllipsis = true;
            this.checkBox_ZIPALIGN_VerboseOutput.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_Verbose;
            this.checkBox_ZIPALIGN_VerboseOutput.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_Verbose", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_ZIPALIGN_VerboseOutput, "checkBox_ZIPALIGN_VerboseOutput");
            this.checkBox_ZIPALIGN_VerboseOutput.Name = "checkBox_ZIPALIGN_VerboseOutput";
            this.checkBox_ZIPALIGN_VerboseOutput.UseVisualStyleBackColor = true;
            // 
            // checkBox_ZIPALIGN_CheckAlignment
            // 
            this.checkBox_ZIPALIGN_CheckAlignment.AutoEllipsis = true;
            this.checkBox_ZIPALIGN_CheckAlignment.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_CheckOnly;
            this.checkBox_ZIPALIGN_CheckAlignment.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_CheckOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_ZIPALIGN_CheckAlignment, "checkBox_ZIPALIGN_CheckAlignment");
            this.checkBox_ZIPALIGN_CheckAlignment.Name = "checkBox_ZIPALIGN_CheckAlignment";
            this.checkBox_ZIPALIGN_CheckAlignment.UseVisualStyleBackColor = true;
            this.checkBox_ZIPALIGN_CheckAlignment.CheckedChanged += new System.EventHandler(this.checkBox_ZIPALIGN_CheckAlignment_CheckedChanged);
            // 
            // tableLayoutPanel_ZIPALIGN_OutputFile
            // 
            resources.ApplyResources(this.tableLayoutPanel_ZIPALIGN_OutputFile, "tableLayoutPanel_ZIPALIGN_OutputFile");
            this.tableLayoutPanel_ZIPALIGN_OutputFile.Controls.Add(this.label_ZIPALIGN_OutputFile, 0, 0);
            this.tableLayoutPanel_ZIPALIGN_OutputFile.Controls.Add(this.button_ZIPALIGN_BrowseOutputFile, 2, 0);
            this.tableLayoutPanel_ZIPALIGN_OutputFile.Controls.Add(this.textBox_ZIPALIGN_OutputFile, 1, 0);
            this.tableLayoutPanel_ZIPALIGN_OutputFile.Name = "tableLayoutPanel_ZIPALIGN_OutputFile";
            // 
            // label_ZIPALIGN_OutputFile
            // 
            resources.ApplyResources(this.label_ZIPALIGN_OutputFile, "label_ZIPALIGN_OutputFile");
            this.label_ZIPALIGN_OutputFile.Name = "label_ZIPALIGN_OutputFile";
            // 
            // button_ZIPALIGN_BrowseOutputFile
            // 
            resources.ApplyResources(this.button_ZIPALIGN_BrowseOutputFile, "button_ZIPALIGN_BrowseOutputFile");
            this.button_ZIPALIGN_BrowseOutputFile.Name = "button_ZIPALIGN_BrowseOutputFile";
            this.button_ZIPALIGN_BrowseOutputFile.UseVisualStyleBackColor = true;
            this.button_ZIPALIGN_BrowseOutputFile.Click += new System.EventHandler(this.button_ZIPALIGN_BrowseOutputFile_Click);
            // 
            // textBox_ZIPALIGN_OutputFile
            // 
            this.textBox_ZIPALIGN_OutputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_OutputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.textBox_ZIPALIGN_OutputFile, "textBox_ZIPALIGN_OutputFile");
            this.textBox_ZIPALIGN_OutputFile.Name = "textBox_ZIPALIGN_OutputFile";
            this.textBox_ZIPALIGN_OutputFile.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_OutputFile;
            // 
            // checkBox_ZIPALIGN_OverwriteOutputFile
            // 
            this.checkBox_ZIPALIGN_OverwriteOutputFile.AutoEllipsis = true;
            this.checkBox_ZIPALIGN_OverwriteOutputFile.Checked = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_OverwriteOutputFile;
            this.checkBox_ZIPALIGN_OverwriteOutputFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_OverwriteOutputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBox_ZIPALIGN_OverwriteOutputFile, "checkBox_ZIPALIGN_OverwriteOutputFile");
            this.checkBox_ZIPALIGN_OverwriteOutputFile.Name = "checkBox_ZIPALIGN_OverwriteOutputFile";
            this.checkBox_ZIPALIGN_OverwriteOutputFile.UseVisualStyleBackColor = true;
            // 
            // button_ZIPALIGN_Align
            // 
            resources.ApplyResources(this.button_ZIPALIGN_Align, "button_ZIPALIGN_Align");
            this.button_ZIPALIGN_Align.Name = "button_ZIPALIGN_Align";
            this.button_ZIPALIGN_Align.UseVisualStyleBackColor = true;
            this.button_ZIPALIGN_Align.Click += new System.EventHandler(this.button_ZIPALIGN_Align_Click);
            // 
            // button_ZIPALIGN_BrowseInputFile
            // 
            resources.ApplyResources(this.button_ZIPALIGN_BrowseInputFile, "button_ZIPALIGN_BrowseInputFile");
            this.button_ZIPALIGN_BrowseInputFile.Name = "button_ZIPALIGN_BrowseInputFile";
            this.button_ZIPALIGN_BrowseInputFile.UseVisualStyleBackColor = true;
            this.button_ZIPALIGN_BrowseInputFile.Click += new System.EventHandler(this.button_ZIPALIGN_BrowseInputFile_Click);
            // 
            // textBox_ZIPALIGN_InputFile
            // 
            resources.ApplyResources(this.textBox_ZIPALIGN_InputFile, "textBox_ZIPALIGN_InputFile");
            this.textBox_ZIPALIGN_InputFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "MAIN_Zipalign_InputFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_ZIPALIGN_InputFile.Name = "textBox_ZIPALIGN_InputFile";
            this.textBox_ZIPALIGN_InputFile.Text = global::APKToolGUI.Properties.Settings.Default.MAIN_Zipalign_InputFile;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStateImage,
            this.toolStripStatusLabelStateText,
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelStateImage
            // 
            this.toolStripStatusLabelStateImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabelStateImage.Name = "toolStripStatusLabelStateImage";
            resources.ApplyResources(this.toolStripStatusLabelStateImage, "toolStripStatusLabelStateImage");
            // 
            // toolStripStatusLabelStateText
            // 
            this.toolStripStatusLabelStateText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelStateText.Image = global::APKToolGUI.Properties.Resources.waiting;
            resources.ApplyResources(this.toolStripStatusLabelStateText, "toolStripStatusLabelStateText");
            this.toolStripStatusLabelStateText.Name = "toolStripStatusLabelStateText";
            this.toolStripStatusLabelStateText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelStateText.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImage,
            this.ColumnTime,
            this.ColumnMessage});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripLog;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 19;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            // 
            // ColumnImage
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnImage.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnImage.Frozen = true;
            resources.ApplyResources(this.ColumnImage, "ColumnImage");
            this.ColumnImage.Name = "ColumnImage";
            this.ColumnImage.ReadOnly = true;
            this.ColumnImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTime.Frozen = true;
            resources.ApplyResources(this.ColumnTime, "ColumnTime");
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnMessage, "ColumnMessage");
            this.ColumnMessage.Name = "ColumnMessage";
            this.ColumnMessage.ReadOnly = true;
            // 
            // contextMenuStripLog
            // 
            this.contextMenuStripLog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem});
            this.contextMenuStripLog.Name = "contextMenuStripLog";
            resources.ApplyResources(this.contextMenuStripLog, "contextMenuStripLog");
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            resources.ApplyResources(this.clearLogToolStripMenuItem, "clearLogToolStripMenuItem");
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSettings,
            this.menuItemExit});
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Index = 0;
            resources.ApplyResources(this.menuItemSettings, "menuItemSettings");
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 1;
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 1;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCheckUpdate,
            this.menuItemAbout});
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            // 
            // menuItemCheckUpdate
            // 
            this.menuItemCheckUpdate.Index = 0;
            resources.ApplyResources(this.menuItemCheckUpdate, "menuItemCheckUpdate");
            this.menuItemCheckUpdate.Click += new System.EventHandler(this.menuItemCheckUpdate_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 1;
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // openFileDialogApk
            // 
            resources.ApplyResources(this.openFileDialogApk, "openFileDialogApk");
            // 
            // folderBrowserDialogBuild
            // 
            this.folderBrowserDialogBuild.ShowNewFolderButton = false;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.DoubleBuffered = true;
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDecode.ResumeLayout(false);
            this.tabPageDecode.PerformLayout();
            this.groupBox_DECODE_Options.ResumeLayout(false);
            this.tableLayoutPanel_DECODE_Options.ResumeLayout(false);
            this.tableLayoutPanelDecodeOutputDir.ResumeLayout(false);
            this.tableLayoutPanelDecodeOutputDir.PerformLayout();
            this.tableLayoutPanelDecodeUseFramework.ResumeLayout(false);
            this.tableLayoutPanelDecodeUseFramework.PerformLayout();
            this.tabPageBuild.ResumeLayout(false);
            this.tabPageBuild.PerformLayout();
            this.groupBox_BUILD_Options.ResumeLayout(false);
            this.tableLayoutPanel_BUILD_Options.ResumeLayout(false);
            this.tableLayoutPanelBuildOutputApk.ResumeLayout(false);
            this.tableLayoutPanelBuildOutputApk.PerformLayout();
            this.tableLayoutPanelBuildUseFramework.ResumeLayout(false);
            this.tableLayoutPanelBuildUseFramework.PerformLayout();
            this.tableLayoutPanelBuildUseAapt.ResumeLayout(false);
            this.tableLayoutPanelBuildUseAapt.PerformLayout();
            this.tabPageInstallFramework.ResumeLayout(false);
            this.tabPageInstallFramework.PerformLayout();
            this.groupBox_IF_Options.ResumeLayout(false);
            this.tableLayoutPanel_IF_Options.ResumeLayout(false);
            this.tableLayoutPanel_IF_Tag.ResumeLayout(false);
            this.tableLayoutPanel_IF_Tag.PerformLayout();
            this.tableLayoutPanel_IF_FramePath.ResumeLayout(false);
            this.tableLayoutPanel_IF_FramePath.PerformLayout();
            this.tabPageSign.ResumeLayout(false);
            this.tabPageSign.PerformLayout();
            this.groupBox_SIGN_Options.ResumeLayout(false);
            this.tableLayoutPanel_SIGN_Options.ResumeLayout(false);
            this.tableLayoutPanel_SIGN_PrivateKey.ResumeLayout(false);
            this.tableLayoutPanel_SIGN_PrivateKey.PerformLayout();
            this.tableLayoutPanel_SIGN_PublicKey.ResumeLayout(false);
            this.tableLayoutPanel_SIGN_PublicKey.PerformLayout();
            this.tableLayoutPanel_SIGN_OutputFile.ResumeLayout(false);
            this.tableLayoutPanel_SIGN_OutputFile.PerformLayout();
            this.tabPageZipAlign.ResumeLayout(false);
            this.tabPageZipAlign.PerformLayout();
            this.groupBox_ZIPALIGN_Options.ResumeLayout(false);
            this.tableLayoutPanel_ZIPALIGN_Options.ResumeLayout(false);
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes.ResumeLayout(false);
            this.tableLayoutPanel_ZIPALIGN_AlignmentBytes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ZIPALIGN_AlignmentBytes)).EndInit();
            this.tableLayoutPanel_ZIPALIGN_OutputFile.ResumeLayout(false);
            this.tableLayoutPanel_ZIPALIGN_OutputFile.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_DECODE_Decode;
        private System.Windows.Forms.TextBox textBox_DECODE_InputAppPath;
        private System.Windows.Forms.Button button_DECODE_BrowseInputAppPath;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDecode;
        private System.Windows.Forms.TabPage tabPageSign;
        private System.Windows.Forms.TextBox textBox_SIGN_InputFile;
        private System.Windows.Forms.Button button_SIGN_BrowseInputFile;
        private System.Windows.Forms.Button button_SIGN_Sign;
        private System.Windows.Forms.TabPage tabPageZipAlign;
        private System.Windows.Forms.TextBox textBox_ZIPALIGN_InputFile;
        private System.Windows.Forms.Button button_ZIPALIGN_BrowseInputFile;
        private System.Windows.Forms.Button button_ZIPALIGN_Align;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLog;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageBuild;
        private System.Windows.Forms.TextBox textBox_BUILD_InputProjectDir;
        private System.Windows.Forms.Button button_BUILD_Build;
        private System.Windows.Forms.Button button_BUILD_BrowseInputProjectDir;
        private System.Windows.Forms.TabPage tabPageInstallFramework;
        private System.Windows.Forms.TextBox textBox_IF_InputFramePath;
        private System.Windows.Forms.Button button_IF_BrowseInputFramePath;
        private System.Windows.Forms.Button button_IF_InstallFramework;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemSettings;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemCheckUpdate;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.GroupBox groupBox_DECODE_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_DECODE_Options;
        private System.Windows.Forms.CheckBox checkBox_DECODE_MatchOriginal;
        private System.Windows.Forms.CheckBox checkBox_DECODE_KeepBrokenRes;
        private System.Windows.Forms.CheckBox checkBox_DECODE_Force;
        private System.Windows.Forms.CheckBox checkBox_DECODE_NoRes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDecodeOutputDir;
        private System.Windows.Forms.Button button_DECODE_BrowseOutputDirectory;
        private System.Windows.Forms.CheckBox checkBox_DECODE_OutputDirectory;
        private System.Windows.Forms.TextBox textBox_DECODE_OutputDirectory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDecodeUseFramework;
        private System.Windows.Forms.TextBox textBox_DECODE_FrameDir;
        private System.Windows.Forms.CheckBox checkBox_DECODE_UseFramework;
        private System.Windows.Forms.Button button_DECODE_BrowseFrameDir;
        private System.Windows.Forms.CheckBox checkBox_DECODE_NoSrc;
        private System.Windows.Forms.GroupBox groupBox_BUILD_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_BUILD_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBuildOutputApk;
        private System.Windows.Forms.Button button_BUILD_BrowseOutputAppPath;
        private System.Windows.Forms.CheckBox checkBox_BUILD_OutputAppPath;
        private System.Windows.Forms.TextBox textBox_BUILD_OutputAppPath;
        private System.Windows.Forms.CheckBox checkBox_BUILD_CopyOriginal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBuildUseFramework;
        private System.Windows.Forms.Button button_BUILD_BrowseFrameDir;
        private System.Windows.Forms.CheckBox checkBox_BUILD_UseFramework;
        private System.Windows.Forms.TextBox textBox_BUILD_FrameDir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBuildUseAapt;
        private System.Windows.Forms.TextBox textBox_BUILD_AaptPath;
        private System.Windows.Forms.CheckBox checkBox_BUILD_UseAapt;
        private System.Windows.Forms.Button button_BUILD_BrowseAaptPath;
        private System.Windows.Forms.CheckBox checkBox_BUILD_ForceAll;
        private System.Windows.Forms.GroupBox groupBox_IF_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_IF_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_IF_Tag;
        private System.Windows.Forms.CheckBox checkBox_IF_Tag;
        private System.Windows.Forms.TextBox textBox_IF_Tag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_IF_FramePath;
        private System.Windows.Forms.TextBox textBox_IF_FrameDir;
        private System.Windows.Forms.CheckBox checkBox_IF_FramePath;
        private System.Windows.Forms.Button button_IF_BrowseFrameDir;
        private System.Windows.Forms.GroupBox groupBox_ZIPALIGN_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ZIPALIGN_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ZIPALIGN_AlignmentBytes;
        private System.Windows.Forms.Label label_ZIPALIGN_AlignmentBytes;
        private System.Windows.Forms.NumericUpDown numericUpDown_ZIPALIGN_AlignmentBytes;
        private System.Windows.Forms.CheckBox checkBox_ZIPALIGN_VerboseOutput;
        private System.Windows.Forms.CheckBox checkBox_ZIPALIGN_CheckAlignment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ZIPALIGN_OutputFile;
        private System.Windows.Forms.Label label_ZIPALIGN_OutputFile;
        private System.Windows.Forms.Button button_ZIPALIGN_BrowseOutputFile;
        private System.Windows.Forms.TextBox textBox_ZIPALIGN_OutputFile;
        private System.Windows.Forms.CheckBox checkBox_ZIPALIGN_OverwriteOutputFile;
        private System.Windows.Forms.CheckBox checkBox_ZIPALIGN_Recompress;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.GroupBox groupBox_SIGN_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SIGN_Options;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SIGN_PrivateKey;
        private System.Windows.Forms.Label label_SIGN_PrivateKey;
        private System.Windows.Forms.Button button_SIGN_BrowsePrivateKey;
        private System.Windows.Forms.TextBox textBox_SIGN_PrivateKey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SIGN_PublicKey;
        private System.Windows.Forms.Label label_SIGN_PublicKey;
        private System.Windows.Forms.Button button_SIGN_BrowsePublicKey;
        private System.Windows.Forms.TextBox textBox_SIGN_PublicKey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SIGN_OutputFile;
        private System.Windows.Forms.Label label_SIGN_OutputFile;
        private System.Windows.Forms.Button button_SIGN_BrowseOutputFile;
        private System.Windows.Forms.TextBox textBox_SIGN_OutputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogApk;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogBuild;
    }
}

