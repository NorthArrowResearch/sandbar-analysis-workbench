namespace SandbarWorkbench.Pictures
{
    partial class frmPictureViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPictureViewer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoFull = new System.Windows.Forms.RadioButton();
            this.rdoWeb = new System.Windows.Forms.RadioButton();
            this.rdoThumb = new System.Windows.Forms.RadioButton();
            this.valSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRCSetup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucPictureViewer = new SandbarWorkbench.Pictures.ucPictureViewer();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valSize)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.valSize);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cboRCSetup);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucPictureViewer);
            this.splitContainer1.Size = new System.Drawing.Size(576, 535);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(138, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "    Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoFull);
            this.groupBox1.Controls.Add(this.rdoWeb);
            this.groupBox1.Controls.Add(this.rdoThumb);
            this.groupBox1.Location = new System.Drawing.Point(16, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picture Type";
            // 
            // rdoFull
            // 
            this.rdoFull.AutoSize = true;
            this.rdoFull.Location = new System.Drawing.Point(14, 71);
            this.rdoFull.Name = "rdoFull";
            this.rdoFull.Size = new System.Drawing.Size(94, 17);
            this.rdoFull.TabIndex = 2;
            this.rdoFull.TabStop = true;
            this.rdoFull.Text = "Full Resolution";
            this.rdoFull.UseVisualStyleBackColor = true;
            this.rdoFull.CheckedChanged += new System.EventHandler(this.LoadPictures);
            // 
            // rdoWeb
            // 
            this.rdoWeb.AutoSize = true;
            this.rdoWeb.Location = new System.Drawing.Point(14, 47);
            this.rdoWeb.Name = "rdoWeb";
            this.rdoWeb.Size = new System.Drawing.Size(101, 17);
            this.rdoWeb.TabIndex = 1;
            this.rdoWeb.TabStop = true;
            this.rdoWeb.Text = "Web Resolution";
            this.rdoWeb.UseVisualStyleBackColor = true;
            this.rdoWeb.CheckedChanged += new System.EventHandler(this.LoadPictures);
            // 
            // rdoThumb
            // 
            this.rdoThumb.AutoSize = true;
            this.rdoThumb.Checked = true;
            this.rdoThumb.Location = new System.Drawing.Point(14, 23);
            this.rdoThumb.Name = "rdoThumb";
            this.rdoThumb.Size = new System.Drawing.Size(68, 17);
            this.rdoThumb.TabIndex = 0;
            this.rdoThumb.TabStop = true;
            this.rdoThumb.Text = "Thumbail";
            this.rdoThumb.UseVisualStyleBackColor = true;
            this.rdoThumb.CheckedChanged += new System.EventHandler(this.LoadPictures);
            // 
            // valSize
            // 
            this.valSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.valSize.Location = new System.Drawing.Point(73, 44);
            this.valSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.valSize.Name = "valSize";
            this.valSize.Size = new System.Drawing.Size(59, 20);
            this.valSize.TabIndex = 3;
            this.valSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.valSize.ValueChanged += new System.EventHandler(this.LoadPictures);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size";
            // 
            // cboRCSetup
            // 
            this.cboRCSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRCSetup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRCSetup.FormattingEnabled = true;
            this.cboRCSetup.Location = new System.Drawing.Point(73, 13);
            this.cboRCSetup.Name = "cboRCSetup";
            this.cboRCSetup.Size = new System.Drawing.Size(164, 21);
            this.cboRCSetup.TabIndex = 1;
            this.cboRCSetup.SelectedIndexChanged += new System.EventHandler(this.LoadPictures);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RC Setup";
            // 
            // ucPictureViewer
            // 
            this.ucPictureViewer.Location = new System.Drawing.Point(110, 83);
            this.ucPictureViewer.Name = "ucPictureViewer";
            this.ucPictureViewer.Size = new System.Drawing.Size(187, 112);
            this.ucPictureViewer.TabIndex = 2;
            // 
            // frmPictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 535);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPictureViewer";
            this.Text = "Remote Camera Pictures";
            this.Load += new System.EventHandler(this.frmPictureViewer_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmPictureViewer_HelpRequested);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cboRCSetup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown valSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoFull;
        private System.Windows.Forms.RadioButton rdoWeb;
        private System.Windows.Forms.RadioButton rdoThumb;
        private ucPictureViewer ucPictureViewer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip tt;
    }
}