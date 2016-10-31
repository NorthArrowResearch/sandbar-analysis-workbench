namespace SandbarWorkbench.Sandbars
{
    partial class frmSandbarProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucStageDischarge1 = new SandbarWorkbench.Sandbars.ucStageDischarge();
            this.tabSurveys = new System.Windows.Forms.TabPage();
            this.grdSurveys = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucAreaVolumeAnalyses1 = new SandbarWorkbench.Sandbars.ucAreaVolumeAnalyses();
            this.txtRiverMile = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabSurveys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurveys)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(581, 575);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Location = new System.Drawing.Point(478, 575);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(97, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "Save and Close";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 13);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(312, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "River mile";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabSurveys);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 504);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucStageDischarge1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(636, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stage Discharge";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucStageDischarge1
            // 
            this.ucStageDischarge1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStageDischarge1.Location = new System.Drawing.Point(3, 3);
            this.ucStageDischarge1.Name = "ucStageDischarge1";
            this.ucStageDischarge1.Size = new System.Drawing.Size(630, 446);
            this.ucStageDischarge1.TabIndex = 0;
            // 
            // tabSurveys
            // 
            this.tabSurveys.Controls.Add(this.grdSurveys);
            this.tabSurveys.Location = new System.Drawing.Point(4, 22);
            this.tabSurveys.Name = "tabSurveys";
            this.tabSurveys.Padding = new System.Windows.Forms.Padding(3);
            this.tabSurveys.Size = new System.Drawing.Size(636, 478);
            this.tabSurveys.TabIndex = 2;
            this.tabSurveys.Text = "Surveys";
            this.tabSurveys.UseVisualStyleBackColor = true;
            // 
            // grdSurveys
            // 
            this.grdSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSurveys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSurveys.Location = new System.Drawing.Point(3, 3);
            this.grdSurveys.Name = "grdSurveys";
            this.grdSurveys.Size = new System.Drawing.Size(630, 472);
            this.grdSurveys.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucAreaVolumeAnalyses1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(636, 478);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Area & Volume Analyses";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucAreaVolumeAnalyses1
            // 
            this.ucAreaVolumeAnalyses1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAreaVolumeAnalyses1.Location = new System.Drawing.Point(3, 3);
            this.ucAreaVolumeAnalyses1.Name = "ucAreaVolumeAnalyses1";
            this.ucAreaVolumeAnalyses1.SandbarSite = null;
            this.ucAreaVolumeAnalyses1.Size = new System.Drawing.Size(630, 472);
            this.ucAreaVolumeAnalyses1.TabIndex = 0;
            // 
            // txtRiverMile
            // 
            this.txtRiverMile.Location = new System.Drawing.Point(83, 43);
            this.txtRiverMile.Name = "txtRiverMile";
            this.txtRiverMile.ReadOnly = true;
            this.txtRiverMile.Size = new System.Drawing.Size(100, 20);
            this.txtRiverMile.TabIndex = 7;
            // 
            // frmSandbarProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 610);
            this.Controls.Add(this.txtRiverMile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Name = "frmSandbarProperties";
            this.Text = "Sandbar Properties";
            this.Load += new System.EventHandler(this.frmSandbarProperties_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabSurveys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSurveys)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucStageDischarge ucStageDischarge1;
        private System.Windows.Forms.TabPage tabSurveys;
        private System.Windows.Forms.DataGridView grdSurveys;
        private System.Windows.Forms.TabPage tabPage3;
        private ucAreaVolumeAnalyses ucAreaVolumeAnalyses1;
        private System.Windows.Forms.TextBox txtRiverMile;
    }
}