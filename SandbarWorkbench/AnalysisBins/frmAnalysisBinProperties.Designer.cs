namespace SandbarWorkbench.AnalysisBins
{
    partial class frmAnalysisBinProperties
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkLower = new System.Windows.Forms.CheckBox();
            this.valLower = new System.Windows.Forms.NumericUpDown();
            this.chkUpper = new System.Windows.Forms.CheckBox();
            this.valUpper = new System.Windows.Forms.NumericUpDown();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frmColourPicker = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.valLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(395, 171);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(314, 171);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 171);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 10;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(89, 13);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(380, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // chkLower
            // 
            this.chkLower.AutoSize = true;
            this.chkLower.Checked = true;
            this.chkLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLower.Location = new System.Drawing.Point(89, 74);
            this.chkLower.Name = "chkLower";
            this.chkLower.Size = new System.Drawing.Size(127, 17);
            this.chkLower.TabIndex = 4;
            this.chkLower.Text = "Lower discharge (cfs)";
            this.chkLower.UseVisualStyleBackColor = true;
            this.chkLower.Click += new System.EventHandler(this.UpdateControls);
            // 
            // valLower
            // 
            this.valLower.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valLower.Location = new System.Drawing.Point(223, 72);
            this.valLower.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.valLower.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valLower.Name = "valLower";
            this.valLower.Size = new System.Drawing.Size(120, 20);
            this.valLower.TabIndex = 5;
            this.valLower.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // chkUpper
            // 
            this.chkUpper.AutoSize = true;
            this.chkUpper.Checked = true;
            this.chkUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpper.Location = new System.Drawing.Point(89, 45);
            this.chkUpper.Name = "chkUpper";
            this.chkUpper.Size = new System.Drawing.Size(133, 17);
            this.chkUpper.TabIndex = 2;
            this.chkUpper.Text = "Uppper discharge (cfs)";
            this.chkUpper.UseVisualStyleBackColor = true;
            this.chkUpper.Click += new System.EventHandler(this.UpdateControls);
            // 
            // valUpper
            // 
            this.valUpper.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valUpper.Location = new System.Drawing.Point(223, 43);
            this.valUpper.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.valUpper.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valUpper.Name = "valUpper";
            this.valUpper.Size = new System.Drawing.Size(120, 20);
            this.valUpper.TabIndex = 3;
            this.valUpper.Value = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(89, 135);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(219, 17);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "Analysis bin is active for sandbar analysis";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Display color";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(89, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 20);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmAnalysisBinProperties
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(482, 206);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.valUpper);
            this.Controls.Add(this.chkUpper);
            this.Controls.Add(this.valLower);
            this.Controls.Add(this.chkLower);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnalysisBinProperties";
            this.Text = "Analysis Bin Properties";
            this.Load += new System.EventHandler(this.frmAnalysisBinProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.valLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkLower;
        private System.Windows.Forms.NumericUpDown valLower;
        private System.Windows.Forms.CheckBox chkUpper;
        private System.Windows.Forms.NumericUpDown valUpper;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog frmColourPicker;
    }
}