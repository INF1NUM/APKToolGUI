namespace APKToolGUI
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customApkToolTxtBox = new System.Windows.Forms.TextBox();
            this.customApktoolBtn = new System.Windows.Forms.Button();
            this.useCustomApktoolChk = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.customTempLocationTxtBox = new System.Windows.Forms.TextBox();
            this.textBoxCustomJavaLocation = new System.Windows.Forms.TextBox();
            this.buttonCustomTempLocation = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.buttonCustomJavaLocation = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckUpdateStartup = new System.Windows.Forms.CheckBox();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxContextMenu = new System.Windows.Forms.GroupBox();
            this.ignoreOutputContextMenuBox = new System.Windows.Forms.CheckBox();
            this.labelAdminRights = new System.Windows.Forms.Label();
            this.buttonAddContextMenu = new System.Windows.Forms.Button();
            this.buttonRemoveContextMenu = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonОК = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.groupBoxContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBoxLanguage);
            this.tabPage1.Controls.Add(this.groupBoxContextMenu);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.themeComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.customApkToolTxtBox);
            this.groupBox1.Controls.Add(this.customApktoolBtn);
            this.groupBox1.Controls.Add(this.useCustomApktoolChk);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.customTempLocationTxtBox);
            this.groupBox1.Controls.Add(this.textBoxCustomJavaLocation);
            this.groupBox1.Controls.Add(this.buttonCustomTempLocation);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.buttonCustomJavaLocation);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBoxCheckUpdateStartup);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "CustomJVMArgs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Name = "textBox1";
            this.textBox1.Text = global::APKToolGUI.Properties.Settings.Default.CustomJVMArgs;
            // 
            // checkBox7
            // 
            resources.ApplyResources(this.checkBox7, "checkBox7");
            this.checkBox7.Checked = global::APKToolGUI.Properties.Settings.Default.UseCustomJVMArgs;
            this.checkBox7.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "UseCustomJVMArgs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            resources.ApplyResources(this.checkBox6, "checkBox6");
            this.checkBox6.Checked = global::APKToolGUI.Properties.Settings.Default.DebugMode;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DebugMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // themeComboBox
            // 
            resources.ApplyResources(this.themeComboBox, "themeComboBox");
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Items.AddRange(new object[] {
            resources.GetString("themeComboBox.Items"),
            resources.GetString("themeComboBox.Items1"),
            resources.GetString("themeComboBox.Items2")});
            this.themeComboBox.Name = "themeComboBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // customApkToolTxtBox
            // 
            resources.ApplyResources(this.customApkToolTxtBox, "customApkToolTxtBox");
            this.customApkToolTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.customApkToolTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "ApktoolPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customApkToolTxtBox.Name = "customApkToolTxtBox";
            this.customApkToolTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.ApktoolPath;
            // 
            // customApktoolBtn
            // 
            resources.ApplyResources(this.customApktoolBtn, "customApktoolBtn");
            this.customApktoolBtn.Name = "customApktoolBtn";
            this.customApktoolBtn.UseVisualStyleBackColor = true;
            this.customApktoolBtn.Click += new System.EventHandler(this.customApktoolBtn_Click);
            // 
            // useCustomApktoolChk
            // 
            resources.ApplyResources(this.useCustomApktoolChk, "useCustomApktoolChk");
            this.useCustomApktoolChk.Checked = global::APKToolGUI.Properties.Settings.Default.UseCustomApktool;
            this.useCustomApktoolChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "UseCustomApktool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useCustomApktoolChk.Name = "useCustomApktoolChk";
            this.useCustomApktoolChk.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Name = "label6";
            // 
            // checkBox5
            // 
            resources.ApplyResources(this.checkBox5, "checkBox5");
            this.checkBox5.Checked = global::APKToolGUI.Properties.Settings.Default.Utf8FilenameSupport;
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "Utf8FilenameSupport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.Checked = global::APKToolGUI.Properties.Settings.Default.UseCustomJavaExe;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "UseCustomJavaExe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // customTempLocationTxtBox
            // 
            resources.ApplyResources(this.customTempLocationTxtBox, "customTempLocationTxtBox");
            this.customTempLocationTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.customTempLocationTxtBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "TempDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customTempLocationTxtBox.Name = "customTempLocationTxtBox";
            this.customTempLocationTxtBox.Text = global::APKToolGUI.Properties.Settings.Default.TempDir;
            // 
            // textBoxCustomJavaLocation
            // 
            resources.ApplyResources(this.textBoxCustomJavaLocation, "textBoxCustomJavaLocation");
            this.textBoxCustomJavaLocation.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustomJavaLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "JavaExe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxCustomJavaLocation.Name = "textBoxCustomJavaLocation";
            this.textBoxCustomJavaLocation.Text = global::APKToolGUI.Properties.Settings.Default.JavaExe;
            // 
            // buttonCustomTempLocation
            // 
            resources.ApplyResources(this.buttonCustomTempLocation, "buttonCustomTempLocation");
            this.buttonCustomTempLocation.Name = "buttonCustomTempLocation";
            this.buttonCustomTempLocation.UseVisualStyleBackColor = true;
            this.buttonCustomTempLocation.Click += new System.EventHandler(this.buttonCustomTempLocation_Click);
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Checked = global::APKToolGUI.Properties.Settings.Default.UseCustomTempDir;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "UseCustomTempDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // buttonCustomJavaLocation
            // 
            resources.ApplyResources(this.buttonCustomJavaLocation, "buttonCustomJavaLocation");
            this.buttonCustomJavaLocation.Name = "buttonCustomJavaLocation";
            this.buttonCustomJavaLocation.UseVisualStyleBackColor = true;
            this.buttonCustomJavaLocation.Click += new System.EventHandler(this.buttonCustomJavaLocation_Click);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Checked = global::APKToolGUI.Properties.Settings.Default.PlaySoundWhenDone;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "PlaySoundWhenDone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = global::APKToolGUI.Properties.Settings.Default.ClearLogBeforeAction;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "ClearLogBeforeAction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheckUpdateStartup
            // 
            resources.ApplyResources(this.checkBoxCheckUpdateStartup, "checkBoxCheckUpdateStartup");
            this.checkBoxCheckUpdateStartup.Checked = global::APKToolGUI.Properties.Settings.Default.CheckForUpdateAtStartup;
            this.checkBoxCheckUpdateStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCheckUpdateStartup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "CheckForUpdateAtStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxCheckUpdateStartup.Name = "checkBoxCheckUpdateStartup";
            this.checkBoxCheckUpdateStartup.UseVisualStyleBackColor = true;
            // 
            // groupBoxLanguage
            // 
            resources.ApplyResources(this.groupBoxLanguage, "groupBoxLanguage");
            this.groupBoxLanguage.Controls.Add(this.comboBox1);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.TabStop = false;
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            // 
            // groupBoxContextMenu
            // 
            resources.ApplyResources(this.groupBoxContextMenu, "groupBoxContextMenu");
            this.groupBoxContextMenu.Controls.Add(this.ignoreOutputContextMenuBox);
            this.groupBoxContextMenu.Controls.Add(this.labelAdminRights);
            this.groupBoxContextMenu.Controls.Add(this.buttonAddContextMenu);
            this.groupBoxContextMenu.Controls.Add(this.buttonRemoveContextMenu);
            this.groupBoxContextMenu.Name = "groupBoxContextMenu";
            this.groupBoxContextMenu.TabStop = false;
            // 
            // ignoreOutputContextMenuBox
            // 
            resources.ApplyResources(this.ignoreOutputContextMenuBox, "ignoreOutputContextMenuBox");
            this.ignoreOutputContextMenuBox.Checked = global::APKToolGUI.Properties.Settings.Default.IgnoreOutputDirContextMenu;
            this.ignoreOutputContextMenuBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "IgnoreOutputDirContextMenu", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ignoreOutputContextMenuBox.Name = "ignoreOutputContextMenuBox";
            this.ignoreOutputContextMenuBox.UseVisualStyleBackColor = true;
            // 
            // labelAdminRights
            // 
            resources.ApplyResources(this.labelAdminRights, "labelAdminRights");
            this.labelAdminRights.Name = "labelAdminRights";
            // 
            // buttonAddContextMenu
            // 
            resources.ApplyResources(this.buttonAddContextMenu, "buttonAddContextMenu");
            this.buttonAddContextMenu.Name = "buttonAddContextMenu";
            this.buttonAddContextMenu.UseVisualStyleBackColor = true;
            this.buttonAddContextMenu.Click += new System.EventHandler(this.buttonAddContextMenu_Click);
            // 
            // buttonRemoveContextMenu
            // 
            resources.ApplyResources(this.buttonRemoveContextMenu, "buttonRemoveContextMenu");
            this.buttonRemoveContextMenu.Name = "buttonRemoveContextMenu";
            this.buttonRemoveContextMenu.UseVisualStyleBackColor = true;
            this.buttonRemoveContextMenu.Click += new System.EventHandler(this.buttonRemoveContextMenu_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonОК
            // 
            resources.ApplyResources(this.buttonОК, "buttonОК");
            this.buttonОК.Name = "buttonОК";
            this.buttonОК.UseVisualStyleBackColor = true;
            this.buttonОК.Click += new System.EventHandler(this.buttonОК_Click);
            // 
            // FormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonОК);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxContextMenu.ResumeLayout(false);
            this.groupBoxContextMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBoxContextMenu;
        private System.Windows.Forms.Label labelAdminRights;
        private System.Windows.Forms.Button buttonAddContextMenu;
        private System.Windows.Forms.Button buttonRemoveContextMenu;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonОК;
        private System.Windows.Forms.TextBox textBoxCustomJavaLocation;
        private System.Windows.Forms.Button buttonCustomJavaLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCheckUpdateStartup;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox ignoreOutputContextMenuBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox customTempLocationTxtBox;
        private System.Windows.Forms.Button buttonCustomTempLocation;
        private System.Windows.Forms.CheckBox checkBox3;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox customApkToolTxtBox;
        private System.Windows.Forms.Button customApktoolBtn;
        private System.Windows.Forms.CheckBox useCustomApktoolChk;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox textBox1;
    }
}