namespace APKToolGUI
{
    partial class FormBuild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStateImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStateText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.textBoxFrameworkPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseFrameworkPath = new System.Windows.Forms.Button();
            this.checkBoxUseFramework = new System.Windows.Forms.CheckBox();
            this.checkBoxCopyOriginal = new System.Windows.Forms.CheckBox();
            this.textBoxAaptPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseAaptPath = new System.Windows.Forms.Button();
            this.checkBoxCustomAapt = new System.Windows.Forms.CheckBox();
            this.checkBoxForceAll = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStart = new System.Windows.Forms.Button();
            this.openFileDialogBrowseAapt = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogApk = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialogFrameworks = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxOutputApkPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseOutputApk = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStateImage,
            this.toolStripStatusLabelStateText,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 360);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStateImage
            // 
            this.toolStripStatusLabelStateImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabelStateImage.Name = "toolStripStatusLabelStateImage";
            this.toolStripStatusLabelStateImage.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabelStateImage.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelStateText
            // 
            this.toolStripStatusLabelStateText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelStateText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelStateText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabelStateText.Name = "toolStripStatusLabelStateText";
            this.toolStripStatusLabelStateText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelStateText.Size = new System.Drawing.Size(453, 17);
            this.toolStripStatusLabelStateText.Spring = true;
            this.toolStripStatusLabelStateText.Text = "Done";
            this.toolStripStatusLabelStateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 50;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.textBoxFrameworkPath);
            this.groupBoxOptions.Controls.Add(this.buttonBrowseFrameworkPath);
            this.groupBoxOptions.Controls.Add(this.checkBoxUseFramework);
            this.groupBoxOptions.Controls.Add(this.checkBoxCopyOriginal);
            this.groupBoxOptions.Controls.Add(this.textBoxAaptPath);
            this.groupBoxOptions.Controls.Add(this.buttonBrowseAaptPath);
            this.groupBoxOptions.Controls.Add(this.checkBoxCustomAapt);
            this.groupBoxOptions.Controls.Add(this.checkBoxForceAll);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 200);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(546, 118);
            this.groupBoxOptions.TabIndex = 28;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // textBoxFrameworkPath
            // 
            this.textBoxFrameworkPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFrameworkPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "BUILD_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFrameworkPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "BUILD_FrameworkPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFrameworkPath.Enabled = global::APKToolGUI.Properties.Settings.Default.BUILD_UseFramework;
            this.textBoxFrameworkPath.Location = new System.Drawing.Point(230, 90);
            this.textBoxFrameworkPath.Name = "textBoxFrameworkPath";
            this.textBoxFrameworkPath.Size = new System.Drawing.Size(280, 22);
            this.textBoxFrameworkPath.TabIndex = 17;
            this.textBoxFrameworkPath.Text = global::APKToolGUI.Properties.Settings.Default.BUILD_FrameworkPath;
            // 
            // buttonBrowseFrameworkPath
            // 
            this.buttonBrowseFrameworkPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFrameworkPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "BUILD_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonBrowseFrameworkPath.Enabled = global::APKToolGUI.Properties.Settings.Default.BUILD_UseFramework;
            this.buttonBrowseFrameworkPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBrowseFrameworkPath.Location = new System.Drawing.Point(512, 89);
            this.buttonBrowseFrameworkPath.Name = "buttonBrowseFrameworkPath";
            this.buttonBrowseFrameworkPath.Size = new System.Drawing.Size(28, 24);
            this.buttonBrowseFrameworkPath.TabIndex = 18;
            this.buttonBrowseFrameworkPath.Text = "...";
            this.buttonBrowseFrameworkPath.UseVisualStyleBackColor = true;
            this.buttonBrowseFrameworkPath.Click += new System.EventHandler(this.buttonBrowseFrameworkPath_Click);
            // 
            // checkBoxUseFramework
            // 
            this.checkBoxUseFramework.Checked = global::APKToolGUI.Properties.Settings.Default.BUILD_UseFramework;
            this.checkBoxUseFramework.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "BUILD_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUseFramework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxUseFramework.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxUseFramework.Location = new System.Drawing.Point(6, 91);
            this.checkBoxUseFramework.Name = "checkBoxUseFramework";
            this.checkBoxUseFramework.Size = new System.Drawing.Size(218, 18);
            this.checkBoxUseFramework.TabIndex = 16;
            this.checkBoxUseFramework.Text = "Uses framework files located in";
            this.checkBoxUseFramework.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopyOriginal
            // 
            this.checkBoxCopyOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCopyOriginal.Checked = global::APKToolGUI.Properties.Settings.Default.BUILD_CopyOriginal;
            this.checkBoxCopyOriginal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "BUILD_CopyOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxCopyOriginal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCopyOriginal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxCopyOriginal.Location = new System.Drawing.Point(6, 43);
            this.checkBoxCopyOriginal.Name = "checkBoxCopyOriginal";
            this.checkBoxCopyOriginal.Size = new System.Drawing.Size(534, 18);
            this.checkBoxCopyOriginal.TabIndex = 15;
            this.checkBoxCopyOriginal.Text = "Copies original AndroidManifest.xml and META-INF folder into built apk.";
            this.checkBoxCopyOriginal.UseVisualStyleBackColor = true;
            // 
            // textBoxAaptPath
            // 
            this.textBoxAaptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "BUILD_CustomAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "BUILD_AaptPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAaptPath.Enabled = global::APKToolGUI.Properties.Settings.Default.BUILD_CustomAapt;
            this.textBoxAaptPath.Location = new System.Drawing.Point(230, 66);
            this.textBoxAaptPath.Name = "textBoxAaptPath";
            this.textBoxAaptPath.Size = new System.Drawing.Size(280, 22);
            this.textBoxAaptPath.TabIndex = 13;
            this.textBoxAaptPath.Text = global::APKToolGUI.Properties.Settings.Default.BUILD_AaptPath;
            // 
            // buttonBrowseAaptPath
            // 
            this.buttonBrowseAaptPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseAaptPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "BUILD_CustomAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonBrowseAaptPath.Enabled = global::APKToolGUI.Properties.Settings.Default.BUILD_CustomAapt;
            this.buttonBrowseAaptPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBrowseAaptPath.Location = new System.Drawing.Point(512, 65);
            this.buttonBrowseAaptPath.Name = "buttonBrowseAaptPath";
            this.buttonBrowseAaptPath.Size = new System.Drawing.Size(28, 24);
            this.buttonBrowseAaptPath.TabIndex = 14;
            this.buttonBrowseAaptPath.Text = "...";
            this.buttonBrowseAaptPath.UseVisualStyleBackColor = true;
            this.buttonBrowseAaptPath.Click += new System.EventHandler(this.buttonBsowseAaptPath_Click);
            // 
            // checkBoxCustomAapt
            // 
            this.checkBoxCustomAapt.Checked = global::APKToolGUI.Properties.Settings.Default.BUILD_CustomAapt;
            this.checkBoxCustomAapt.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "BUILD_CustomAapt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxCustomAapt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCustomAapt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxCustomAapt.Location = new System.Drawing.Point(6, 67);
            this.checkBoxCustomAapt.Name = "checkBoxCustomAapt";
            this.checkBoxCustomAapt.Size = new System.Drawing.Size(218, 18);
            this.checkBoxCustomAapt.TabIndex = 12;
            this.checkBoxCustomAapt.Text = "Uses aapt.exe located in";
            this.checkBoxCustomAapt.UseVisualStyleBackColor = true;
            // 
            // checkBoxForceAll
            // 
            this.checkBoxForceAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxForceAll.Checked = global::APKToolGUI.Properties.Settings.Default.BUILD_ForceAll;
            this.checkBoxForceAll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "BUILD_ForceAll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxForceAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxForceAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxForceAll.Location = new System.Drawing.Point(6, 19);
            this.checkBoxForceAll.Name = "checkBoxForceAll";
            this.checkBoxForceAll.Size = new System.Drawing.Size(534, 18);
            this.checkBoxForceAll.TabIndex = 0;
            this.checkBoxForceAll.Text = "Skip changes detection and build all files";
            this.checkBoxForceAll.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 24;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImage,
            this.ColumnTime,
            this.ColumnMessage});
            this.dataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 19;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(546, 182);
            this.dataGridView1.TabIndex = 26;
            // 
            // ColumnImage
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnImage.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnImage.Frozen = true;
            this.ColumnImage.HeaderText = "";
            this.ColumnImage.Name = "ColumnImage";
            this.ColumnImage.ReadOnly = true;
            this.ColumnImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnImage.Width = 20;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTime.Frozen = true;
            this.ColumnTime.HeaderText = "Time";
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 55;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMessage.HeaderText = "Message";
            this.ColumnMessage.Name = "ColumnMessage";
            this.ColumnMessage.ReadOnly = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonStart.Location = new System.Drawing.Point(438, 325);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 24);
            this.buttonStart.TabIndex = 27;
            this.buttonStart.Text = "Build";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // openFileDialogBrowseAapt
            // 
            this.openFileDialogBrowseAapt.Filter = "*.exe|*.exe";
            // 
            // saveFileDialogApk
            // 
            this.saveFileDialogApk.DefaultExt = "apk";
            this.saveFileDialogApk.Filter = "Android App|*.apk";
            // 
            // folderBrowserDialogFrameworks
            // 
            this.folderBrowserDialogFrameworks.ShowNewFolderButton = false;
            // 
            // textBoxOutputApkPath
            // 
            this.textBoxOutputApkPath.Location = new System.Drawing.Point(12, 326);
            this.textBoxOutputApkPath.Name = "textBoxOutputApkPath";
            this.textBoxOutputApkPath.Size = new System.Drawing.Size(390, 22);
            this.textBoxOutputApkPath.TabIndex = 29;
            // 
            // buttonBrowseOutputApk
            // 
            this.buttonBrowseOutputApk.Location = new System.Drawing.Point(404, 325);
            this.buttonBrowseOutputApk.Name = "buttonBrowseOutputApk";
            this.buttonBrowseOutputApk.Size = new System.Drawing.Size(28, 24);
            this.buttonBrowseOutputApk.TabIndex = 30;
            this.buttonBrowseOutputApk.Text = "...";
            this.buttonBrowseOutputApk.UseVisualStyleBackColor = true;
            this.buttonBrowseOutputApk.Click += new System.EventHandler(this.buttonBrowseOutputApk_Click);
            // 
            // FormBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 382);
            this.Controls.Add(this.buttonBrowseOutputApk);
            this.Controls.Add(this.textBoxOutputApkPath);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormBuild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBuild";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBuild_FormClosed);
            this.Load += new System.EventHandler(this.FormBuild_Load);
            this.Shown += new System.EventHandler(this.FormBuild_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateImage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.TextBox textBoxAaptPath;
        private System.Windows.Forms.Button buttonBrowseAaptPath;
        private System.Windows.Forms.CheckBox checkBoxCustomAapt;
        private System.Windows.Forms.CheckBox checkBoxForceAll;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.OpenFileDialog openFileDialogBrowseAapt;
        private System.Windows.Forms.SaveFileDialog saveFileDialogApk;
        private System.Windows.Forms.CheckBox checkBoxCopyOriginal;
        private System.Windows.Forms.TextBox textBoxFrameworkPath;
        private System.Windows.Forms.Button buttonBrowseFrameworkPath;
        private System.Windows.Forms.CheckBox checkBoxUseFramework;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogFrameworks;
        private System.Windows.Forms.TextBox textBoxOutputApkPath;
        private System.Windows.Forms.Button buttonBrowseOutputApk;
    }
}