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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSandbarProperties));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucStageDischarge1 = new SandbarWorkbench.Sandbars.ucStageDischarge();
            this.tabSurveys = new System.Windows.Forms.TabPage();
            this.grdSurveys = new System.Windows.Forms.DataGridView();
            this.cmsSurveys = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewSurveyPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucAreaVolumeAnalyses1 = new SandbarWorkbench.Sandbars.ucAreaVolumeAnalyses();
            this.txtRiverMile = new System.Windows.Forms.TextBox();
            this.txtSiteCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabSurveys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurveys)).BeginInit();
            this.cmsSurveys.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(507, 637);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
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
            this.label2.Location = new System.Drawing.Point(12, 47);
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
            this.tabControl1.Location = new System.Drawing.Point(12, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 562);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Location = new System.Drawing.Point(218, 133);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(240, 150);
            this.grdData.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucStageDischarge1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stage Discharge";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucStageDischarge1
            // 
            this.ucStageDischarge1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStageDischarge1.Location = new System.Drawing.Point(3, 3);
            this.ucStageDischarge1.Name = "ucStageDischarge1";
            this.ucStageDischarge1.Size = new System.Drawing.Size(556, 530);
            this.ucStageDischarge1.TabIndex = 0;
            // 
            // tabSurveys
            // 
            this.tabSurveys.Controls.Add(this.grdSurveys);
            this.tabSurveys.Location = new System.Drawing.Point(4, 22);
            this.tabSurveys.Name = "tabSurveys";
            this.tabSurveys.Padding = new System.Windows.Forms.Padding(3);
            this.tabSurveys.Size = new System.Drawing.Size(562, 536);
            this.tabSurveys.TabIndex = 2;
            this.tabSurveys.Text = "Surveys";
            this.tabSurveys.UseVisualStyleBackColor = true;
            // 
            // grdSurveys
            // 
            this.grdSurveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSurveys.ContextMenuStrip = this.cmsSurveys;
            this.grdSurveys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSurveys.Location = new System.Drawing.Point(3, 3);
            this.grdSurveys.Name = "grdSurveys";
            this.grdSurveys.Size = new System.Drawing.Size(556, 530);
            this.grdSurveys.TabIndex = 0;
            this.grdSurveys.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSurveys_CellDoubleClick);
            // 
            // cmsSurveys
            // 
            this.cmsSurveys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSurveyPropertiesToolStripMenuItem,
            this.toolStripSeparator1,
            this.addSurveyToolStripMenuItem,
            this.editSurveyToolStripMenuItem,
            this.deleteSurveyToolStripMenuItem});
            this.cmsSurveys.Name = "cmsSurveys";
            this.cmsSurveys.Size = new System.Drawing.Size(194, 98);
            // 
            // viewSurveyPropertiesToolStripMenuItem
            // 
            this.viewSurveyPropertiesToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Settings;
            this.viewSurveyPropertiesToolStripMenuItem.Name = "viewSurveyPropertiesToolStripMenuItem";
            this.viewSurveyPropertiesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.viewSurveyPropertiesToolStripMenuItem.Text = "View Survey Properties";
            this.viewSurveyPropertiesToolStripMenuItem.Click += new System.EventHandler(this.viewSurveyPropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // addSurveyToolStripMenuItem
            // 
            this.addSurveyToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Add;
            this.addSurveyToolStripMenuItem.Name = "addSurveyToolStripMenuItem";
            this.addSurveyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addSurveyToolStripMenuItem.Text = "Add Survey";
            this.addSurveyToolStripMenuItem.Click += new System.EventHandler(this.addSurveyToolStripMenuItem_Click);
            // 
            // editSurveyToolStripMenuItem
            // 
            this.editSurveyToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.editSurveyToolStripMenuItem.Name = "editSurveyToolStripMenuItem";
            this.editSurveyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.editSurveyToolStripMenuItem.Text = "Edit Survey";
            this.editSurveyToolStripMenuItem.Click += new System.EventHandler(this.editSurveyToolStripMenuItem_Click);
            // 
            // deleteSurveyToolStripMenuItem
            // 
            this.deleteSurveyToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Delete;
            this.deleteSurveyToolStripMenuItem.Name = "deleteSurveyToolStripMenuItem";
            this.deleteSurveyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.deleteSurveyToolStripMenuItem.Text = "Delete Survey...";
            this.deleteSurveyToolStripMenuItem.Click += new System.EventHandler(this.deleteSurveyToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucAreaVolumeAnalyses1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(562, 536);
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
            this.ucAreaVolumeAnalyses1.Size = new System.Drawing.Size(556, 530);
            this.ucAreaVolumeAnalyses1.TabIndex = 0;
            // 
            // txtRiverMile
            // 
            this.txtRiverMile.Location = new System.Drawing.Point(83, 43);
            this.txtRiverMile.Name = "txtRiverMile";
            this.txtRiverMile.ReadOnly = true;
            this.txtRiverMile.Size = new System.Drawing.Size(123, 20);
            this.txtRiverMile.TabIndex = 7;
            // 
            // txtSiteCode
            // 
            this.txtSiteCode.Location = new System.Drawing.Point(272, 43);
            this.txtSiteCode.Name = "txtSiteCode";
            this.txtSiteCode.ReadOnly = true;
            this.txtSiteCode.Size = new System.Drawing.Size(123, 20);
            this.txtSiteCode.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Site code";
            // 
            // frmSandbarProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 672);
            this.Controls.Add(this.txtSiteCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRiverMile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(425, 300);
            this.Name = "frmSandbarProperties";
            this.Text = "Sandbar Properties";
            this.Load += new System.EventHandler(this.frmSandbarProperties_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabSurveys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSurveys)).EndInit();
            this.cmsSurveys.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
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
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.ContextMenuStrip cmsSurveys;
        private System.Windows.Forms.ToolStripMenuItem viewSurveyPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addSurveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSurveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSurveyToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSiteCode;
        private System.Windows.Forms.Label label3;
    }
}