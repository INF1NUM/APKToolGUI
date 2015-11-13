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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckUpdateStartup = new System.Windows.Forms.CheckBox();
            this.groupBoxJava = new System.Windows.Forms.GroupBox();
            this.labelCustomJavaLocation = new System.Windows.Forms.Label();
            this.textBoxCustomJavaLocation = new System.Windows.Forms.TextBox();
            this.buttonCustomJavaLocation = new System.Windows.Forms.Button();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxContextMenu = new System.Windows.Forms.GroupBox();
            this.labelAdminRights = new System.Windows.Forms.Label();
            this.buttonAddContextMenu = new System.Windows.Forms.Button();
            this.buttonRemoveContextMenu = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonОК = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxJava.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.groupBoxJava);
            this.tabPage1.Controls.Add(this.groupBoxLanguage);
            this.tabPage1.Controls.Add(this.groupBoxContextMenu);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBoxCheckUpdateStartup);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = global::APKToolGUI.Properties.Settings.Default.ClearLogBeforeAction;
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
            // groupBoxJava
            // 
            resources.ApplyResources(this.groupBoxJava, "groupBoxJava");
            this.groupBoxJava.Controls.Add(this.labelCustomJavaLocation);
            this.groupBoxJava.Controls.Add(this.textBoxCustomJavaLocation);
            this.groupBoxJava.Controls.Add(this.buttonCustomJavaLocation);
            this.groupBoxJava.Name = "groupBoxJava";
            this.groupBoxJava.TabStop = false;
            // 
            // labelCustomJavaLocation
            // 
            resources.ApplyResources(this.labelCustomJavaLocation, "labelCustomJavaLocation");
            this.labelCustomJavaLocation.Name = "labelCustomJavaLocation";
            // 
            // textBoxCustomJavaLocation
            // 
            resources.ApplyResources(this.textBoxCustomJavaLocation, "textBoxCustomJavaLocation");
            this.textBoxCustomJavaLocation.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustomJavaLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "JavaExe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxCustomJavaLocation.Name = "textBoxCustomJavaLocation";
            this.textBoxCustomJavaLocation.Text = global::APKToolGUI.Properties.Settings.Default.JavaExe;
            // 
            // buttonCustomJavaLocation
            // 
            resources.ApplyResources(this.buttonCustomJavaLocation, "buttonCustomJavaLocation");
            this.buttonCustomJavaLocation.Name = "buttonCustomJavaLocation";
            this.buttonCustomJavaLocation.UseVisualStyleBackColor = true;
            this.buttonCustomJavaLocation.Click += new System.EventHandler(this.buttonCustomJavaLocation_Click);
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
            this.groupBoxContextMenu.Controls.Add(this.labelAdminRights);
            this.groupBoxContextMenu.Controls.Add(this.buttonAddContextMenu);
            this.groupBoxContextMenu.Controls.Add(this.buttonRemoveContextMenu);
            this.groupBoxContextMenu.Name = "groupBoxContextMenu";
            this.groupBoxContextMenu.TabStop = false;
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
            this.groupBoxJava.ResumeLayout(false);
            this.groupBoxJava.PerformLayout();
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxJava;
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
        private System.Windows.Forms.Label labelCustomJavaLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCheckUpdateStartup;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}