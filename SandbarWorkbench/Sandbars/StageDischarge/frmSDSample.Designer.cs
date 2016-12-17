namespace SandbarWorkbench.Sandbars.StageDischarge
{
    partial class frmSDSample
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
            this.cboSite = new System.Windows.Forms.ComboBox();
            this.dtSampleDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSampleTime = new System.Windows.Forms.TextBox();
            this.valLocalElevation = new System.Windows.Forms.NumericUpDown();
            this.valSPElevation = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSampleCount = new System.Windows.Forms.CheckBox();
            this.valSampleCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.valFlow = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.valFlowMS = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.chkLocalElevation = new System.Windows.Forms.CheckBox();
            this.chkSampleDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.valLocalElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valSPElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valSampleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valFlowMS)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(297, 356);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(216, 356);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 18;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 356);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 20;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site";
            // 
            // cboSite
            // 
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.FormattingEnabled = true;
            this.cboSite.Location = new System.Drawing.Point(116, 12);
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(255, 21);
            this.cboSite.TabIndex = 1;
            // 
            // dtSampleDate
            // 
            this.dtSampleDate.Location = new System.Drawing.Point(116, 42);
            this.dtSampleDate.Name = "dtSampleDate";
            this.dtSampleDate.Size = new System.Drawing.Size(255, 20);
            this.dtSampleDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time";
            // 
            // txtSampleTime
            // 
            this.txtSampleTime.Location = new System.Drawing.Point(116, 71);
            this.txtSampleTime.MaxLength = 50;
            this.txtSampleTime.Name = "txtSampleTime";
            this.txtSampleTime.Size = new System.Drawing.Size(255, 20);
            this.txtSampleTime.TabIndex = 5;
            // 
            // valLocalElevation
            // 
            this.valLocalElevation.DecimalPlaces = 3;
            this.valLocalElevation.Location = new System.Drawing.Point(116, 100);
            this.valLocalElevation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valLocalElevation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valLocalElevation.Name = "valLocalElevation";
            this.valLocalElevation.Size = new System.Drawing.Size(120, 20);
            this.valLocalElevation.TabIndex = 7;
            this.valLocalElevation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // valSPElevation
            // 
            this.valSPElevation.DecimalPlaces = 3;
            this.valSPElevation.Location = new System.Drawing.Point(116, 129);
            this.valSPElevation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.valSPElevation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.valSPElevation.Name = "valSPElevation";
            this.valSPElevation.Size = new System.Drawing.Size(120, 20);
            this.valSPElevation.TabIndex = 9;
            this.valSPElevation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "SP elevation (m)";
            // 
            // chkSampleCount
            // 
            this.chkSampleCount.AutoSize = true;
            this.chkSampleCount.Location = new System.Drawing.Point(22, 160);
            this.chkSampleCount.Name = "chkSampleCount";
            this.chkSampleCount.Size = new System.Drawing.Size(91, 17);
            this.chkSampleCount.TabIndex = 10;
            this.chkSampleCount.Text = "Sample count";
            this.chkSampleCount.UseVisualStyleBackColor = true;
            this.chkSampleCount.CheckedChanged += new System.EventHandler(this.UpdateControls);
            // 
            // valSampleCount
            // 
            this.valSampleCount.Location = new System.Drawing.Point(116, 158);
            this.valSampleCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valSampleCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valSampleCount.Name = "valSampleCount";
            this.valSampleCount.Size = new System.Drawing.Size(120, 20);
            this.valSampleCount.TabIndex = 11;
            this.valSampleCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Flow (cfs)";
            // 
            // valFlow
            // 
            this.valFlow.Location = new System.Drawing.Point(116, 187);
            this.valFlow.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.valFlow.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valFlow.Name = "valFlow";
            this.valFlow.Size = new System.Drawing.Size(120, 20);
            this.valFlow.TabIndex = 13;
            this.valFlow.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Flow (ms)";
            // 
            // valFlowMS
            // 
            this.valFlowMS.DecimalPlaces = 3;
            this.valFlowMS.Location = new System.Drawing.Point(116, 216);
            this.valFlowMS.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.valFlowMS.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.valFlowMS.Name = "valFlowMS";
            this.valFlowMS.Size = new System.Drawing.Size(120, 20);
            this.valFlowMS.TabIndex = 15;
            this.valFlowMS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(116, 245);
            this.txtComments.MaxLength = 255;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(255, 99);
            this.txtComments.TabIndex = 17;
            // 
            // chkLocalElevation
            // 
            this.chkLocalElevation.AutoSize = true;
            this.chkLocalElevation.Location = new System.Drawing.Point(15, 102);
            this.chkLocalElevation.Name = "chkLocalElevation";
            this.chkLocalElevation.Size = new System.Drawing.Size(98, 17);
            this.chkLocalElevation.TabIndex = 6;
            this.chkLocalElevation.Text = "Local elevation";
            this.chkLocalElevation.UseVisualStyleBackColor = true;
            this.chkLocalElevation.CheckedChanged += new System.EventHandler(this.UpdateControls);
            // 
            // chkSampleDate
            // 
            this.chkSampleDate.AutoSize = true;
            this.chkSampleDate.Location = new System.Drawing.Point(64, 44);
            this.chkSampleDate.Name = "chkSampleDate";
            this.chkSampleDate.Size = new System.Drawing.Size(49, 17);
            this.chkSampleDate.TabIndex = 2;
            this.chkSampleDate.Text = "Date";
            this.chkSampleDate.UseVisualStyleBackColor = true;
            this.chkSampleDate.CheckedChanged += new System.EventHandler(this.UpdateControls);
            // 
            // frmSDSample
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(384, 391);
            this.Controls.Add(this.chkSampleDate);
            this.Controls.Add(this.chkLocalElevation);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.valFlowMS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.valFlow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.valSampleCount);
            this.Controls.Add(this.chkSampleCount);
            this.Controls.Add(this.valSPElevation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.valLocalElevation);
            this.Controls.Add(this.txtSampleTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtSampleDate);
            this.Controls.Add(this.cboSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSDSample";
            this.Text = "Stage Discharge Sample";
            this.Load += new System.EventHandler(this.frmSDSample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.valLocalElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valSPElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valSampleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valFlowMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.DateTimePicker dtSampleDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSampleTime;
        private System.Windows.Forms.NumericUpDown valLocalElevation;
        private System.Windows.Forms.NumericUpDown valSPElevation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSampleCount;
        private System.Windows.Forms.NumericUpDown valSampleCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown valFlow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown valFlowMS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.CheckBox chkLocalElevation;
        private System.Windows.Forms.CheckBox chkSampleDate;
    }
}