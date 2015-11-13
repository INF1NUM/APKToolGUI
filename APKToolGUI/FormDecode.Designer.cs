namespace APKToolGUI
{
    partial class FormDecode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDecode));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStateImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStateText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxMatchOriginal = new System.Windows.Forms.CheckBox();
            this.checkBoxKeepBrokenResource = new System.Windows.Forms.CheckBox();
            this.textBoxFrameworkPath = new System.Windows.Forms.TextBox();
            this.buttonFramePath = new System.Windows.Forms.Button();
            this.checkBoxFrameworkPath = new System.Windows.Forms.CheckBox();
            this.checkBoxForce = new System.Windows.Forms.CheckBox();
            this.checkBoxNoRes = new System.Windows.Forms.CheckBox();
            this.checkBoxNoSrc = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialogFrameworks = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogProjectDir = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxOutputProjectDir = new System.Windows.Forms.TextBox();
            this.buttonBrowseOutputProjectDir = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStateImage,
            this.toolStripStatusLabelStateText,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 22;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridView1.TabIndex = 25;
            // 
            // ColumnImage
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            this.ColumnImage.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.buttonStart.Location = new System.Drawing.Point(438, 371);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 24);
            this.buttonStart.TabIndex = 27;
            this.buttonStart.Text = "Decompile";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOptions.Controls.Add(this.checkBoxMatchOriginal);
            this.groupBoxOptions.Controls.Add(this.checkBoxKeepBrokenResource);
            this.groupBoxOptions.Controls.Add(this.textBoxFrameworkPath);
            this.groupBoxOptions.Controls.Add(this.buttonFramePath);
            this.groupBoxOptions.Controls.Add(this.checkBoxFrameworkPath);
            this.groupBoxOptions.Controls.Add(this.checkBoxForce);
            this.groupBoxOptions.Controls.Add(this.checkBoxNoRes);
            this.groupBoxOptions.Controls.Add(this.checkBoxNoSrc);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 200);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(546, 166);
            this.groupBoxOptions.TabIndex = 26;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxMatchOriginal
            // 
            this.checkBoxMatchOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMatchOriginal.Checked = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_MatchOriginal;
            this.checkBoxMatchOriginal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_MatchOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxMatchOriginal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxMatchOriginal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMatchOriginal.Location = new System.Drawing.Point(6, 115);
            this.checkBoxMatchOriginal.Name = "checkBoxMatchOriginal";
            this.checkBoxMatchOriginal.Size = new System.Drawing.Size(534, 18);
            this.checkBoxMatchOriginal.TabIndex = 13;
            this.checkBoxMatchOriginal.Text = "Keeps files to closest to original as possible. Prevents rebuild.";
            this.checkBoxMatchOriginal.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeepBrokenResource
            // 
            this.checkBoxKeepBrokenResource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxKeepBrokenResource.Checked = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_KeepBrokenResource;
            this.checkBoxKeepBrokenResource.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_KeepBrokenResource", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxKeepBrokenResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxKeepBrokenResource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxKeepBrokenResource.Location = new System.Drawing.Point(6, 91);
            this.checkBoxKeepBrokenResource.Name = "checkBoxKeepBrokenResource";
            this.checkBoxKeepBrokenResource.Size = new System.Drawing.Size(534, 18);
            this.checkBoxKeepBrokenResource.TabIndex = 12;
            this.checkBoxKeepBrokenResource.Text = "Keep broken resource";
            this.checkBoxKeepBrokenResource.UseVisualStyleBackColor = true;
            // 
            // textBoxFrameworkPath
            // 
            this.textBoxFrameworkPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFrameworkPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFrameworkPath.Enabled = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_UseFramework;
            this.textBoxFrameworkPath.Location = new System.Drawing.Point(230, 138);
            this.textBoxFrameworkPath.Name = "textBoxFrameworkPath";
            this.textBoxFrameworkPath.Size = new System.Drawing.Size(280, 22);
            this.textBoxFrameworkPath.TabIndex = 10;
            // 
            // buttonFramePath
            // 
            this.buttonFramePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFramePath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonFramePath.Enabled = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_UseFramework;
            this.buttonFramePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonFramePath.Location = new System.Drawing.Point(512, 137);
            this.buttonFramePath.Name = "buttonFramePath";
            this.buttonFramePath.Size = new System.Drawing.Size(28, 24);
            this.buttonFramePath.TabIndex = 11;
            this.buttonFramePath.Text = "...";
            this.buttonFramePath.UseVisualStyleBackColor = true;
            this.buttonFramePath.Click += new System.EventHandler(this.buttonFramePath_Click);
            // 
            // checkBoxFrameworkPath
            // 
            this.checkBoxFrameworkPath.Checked = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_UseFramework;
            this.checkBoxFrameworkPath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_UseFramework", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxFrameworkPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxFrameworkPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxFrameworkPath.Location = new System.Drawing.Point(6, 139);
            this.checkBoxFrameworkPath.Name = "checkBoxFrameworkPath";
            this.checkBoxFrameworkPath.Size = new System.Drawing.Size(218, 18);
            this.checkBoxFrameworkPath.TabIndex = 9;
            this.checkBoxFrameworkPath.Text = "Uses framework files located in";
            this.checkBoxFrameworkPath.UseVisualStyleBackColor = true;
            // 
            // checkBoxForce
            // 
            this.checkBoxForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxForce.Checked = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_Force;
            this.checkBoxForce.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_Force", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxForce.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxForce.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxForce.Location = new System.Drawing.Point(6, 67);
            this.checkBoxForce.Name = "checkBoxForce";
            this.checkBoxForce.Size = new System.Drawing.Size(534, 18);
            this.checkBoxForce.TabIndex = 8;
            this.checkBoxForce.Text = "Force delete destination directory";
            this.checkBoxForce.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoRes
            // 
            this.checkBoxNoRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNoRes.Checked = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_NoRes;
            this.checkBoxNoRes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_NoRes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxNoRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxNoRes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxNoRes.Location = new System.Drawing.Point(6, 43);
            this.checkBoxNoRes.Name = "checkBoxNoRes";
            this.checkBoxNoRes.Size = new System.Drawing.Size(534, 18);
            this.checkBoxNoRes.TabIndex = 7;
            this.checkBoxNoRes.Text = "Do not decode resources";
            this.checkBoxNoRes.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoSrc
            // 
            this.checkBoxNoSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNoSrc.Checked = global::APKToolGUI.Properties.Settings.Default.DECOMPILE_NoSrc;
            this.checkBoxNoSrc.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "DECOMPILE_NoSrc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxNoSrc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxNoSrc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxNoSrc.Location = new System.Drawing.Point(6, 19);
            this.checkBoxNoSrc.Name = "checkBoxNoSrc";
            this.checkBoxNoSrc.Size = new System.Drawing.Size(534, 18);
            this.checkBoxNoSrc.TabIndex = 6;
            this.checkBoxNoSrc.Text = "Do not decode sources";
            this.checkBoxNoSrc.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialogFrameworks
            // 
            this.folderBrowserDialogFrameworks.ShowNewFolderButton = false;
            // 
            // textBoxOutputProjectDir
            // 
            this.textBoxOutputProjectDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputProjectDir.Location = new System.Drawing.Point(12, 372);
            this.textBoxOutputProjectDir.Name = "textBoxOutputProjectDir";
            this.textBoxOutputProjectDir.Size = new System.Drawing.Size(390, 22);
            this.textBoxOutputProjectDir.TabIndex = 28;
            // 
            // buttonBrowseOutputProjectDir
            // 
            this.buttonBrowseOutputProjectDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseOutputProjectDir.Location = new System.Drawing.Point(404, 371);
            this.buttonBrowseOutputProjectDir.Name = "buttonBrowseOutputProjectDir";
            this.buttonBrowseOutputProjectDir.Size = new System.Drawing.Size(28, 24);
            this.buttonBrowseOutputProjectDir.TabIndex = 29;
            this.buttonBrowseOutputProjectDir.Text = "...";
            this.buttonBrowseOutputProjectDir.UseVisualStyleBackColor = true;
            this.buttonBrowseOutputProjectDir.Click += new System.EventHandler(this.buttonBrowseOutputProjectDir_Click);
            // 
            // FormDecode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 430);
            this.Controls.Add(this.buttonBrowseOutputProjectDir);
            this.Controls.Add(this.textBoxOutputProjectDir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "FormDecode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDecode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDecompile_FormClosed);
            this.Load += new System.EventHandler(this.FormDecompile_Load);
            this.Shown += new System.EventHandler(this.FormDecompile_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateImage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.TextBox textBoxFrameworkPath;
        private System.Windows.Forms.Button buttonFramePath;
        private System.Windows.Forms.CheckBox checkBoxFrameworkPath;
        private System.Windows.Forms.CheckBox checkBoxForce;
        private System.Windows.Forms.CheckBox checkBoxNoRes;
        private System.Windows.Forms.CheckBox checkBoxNoSrc;
        private System.Windows.Forms.CheckBox checkBoxMatchOriginal;
        private System.Windows.Forms.CheckBox checkBoxKeepBrokenResource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogFrameworks;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogProjectDir;
        private System.Windows.Forms.TextBox textBoxOutputProjectDir;
        private System.Windows.Forms.Button buttonBrowseOutputProjectDir;
    }
}