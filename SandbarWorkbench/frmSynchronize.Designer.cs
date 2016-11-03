﻿namespace SandbarWorkbench
{
    partial class frmSynchronize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSynchronize));
            this.chkLookup = new System.Windows.Forms.CheckBox();
            this.chkResults = new System.Windows.Forms.CheckBox();
            this.grpProgress = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.grpProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLookup
            // 
            this.chkLookup.AutoSize = true;
            this.chkLookup.Checked = true;
            this.chkLookup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLookup.Location = new System.Drawing.Point(13, 13);
            this.chkLookup.Name = "chkLookup";
            this.chkLookup.Size = new System.Drawing.Size(154, 17);
            this.chkLookup.TabIndex = 0;
            this.chkLookup.Text = "Synchronize Lookup tables";
            this.chkLookup.UseVisualStyleBackColor = true;
            // 
            // chkResults
            // 
            this.chkResults.AutoSize = true;
            this.chkResults.Checked = true;
            this.chkResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResults.Location = new System.Drawing.Point(13, 37);
            this.chkResults.Name = "chkResults";
            this.chkResults.Size = new System.Drawing.Size(97, 17);
            this.chkResults.TabIndex = 1;
            this.chkResults.Text = "Analysis results";
            this.chkResults.UseVisualStyleBackColor = true;
            // 
            // grpProgress
            // 
            this.grpProgress.Controls.Add(this.txtProgress);
            this.grpProgress.Controls.Add(this.progressBar2);
            this.grpProgress.Controls.Add(this.label2);
            this.grpProgress.Controls.Add(this.progressBar1);
            this.grpProgress.Controls.Add(this.label1);
            this.grpProgress.Location = new System.Drawing.Point(12, 60);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new System.Drawing.Size(561, 140);
            this.grpProgress.TabIndex = 2;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "Progress";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(498, 206);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Location = new System.Drawing.Point(417, 206);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 206);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 5;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overall progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(113, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(442, 13);
            this.progressBar1.TabIndex = 1;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(113, 48);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(442, 13);
            this.progressBar2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current task";
            // 
            // txtProgress
            // 
            this.txtProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgress.Location = new System.Drawing.Point(6, 67);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(549, 67);
            this.txtProgress.TabIndex = 4;
            // 
            // frmSynchronize
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(585, 241);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.grpProgress);
            this.Controls.Add(this.chkResults);
            this.Controls.Add(this.chkLookup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSynchronize";
            this.Text = "Synchronize Local Database With Master Database";
            this.Load += new System.EventHandler(this.frmSynchronize_Load);
            this.grpProgress.ResumeLayout(false);
            this.grpProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLookup;
        private System.Windows.Forms.CheckBox chkResults;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}