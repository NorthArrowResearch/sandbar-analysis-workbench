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
            this.exportToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucAreaVolumeAnalyses1 = new SandbarWorkbench.Sandbars.ucAreaVolumeAnalyses();
            this.tabPhoto = new System.Windows.Forms.TabPage();
            this.picBestPhoto = new System.Windows.Forms.PictureBox();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.webMap = new System.Windows.Forms.WebBrowser();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtRiverMile = new System.Windows.Forms.TextBox();
            this.txtSiteCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdGDAWS = new System.Windows.Forms.Button();
            this.cmdPhotos = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.tabCampsiteResults = new System.Windows.Forms.TabPage();
            this.ucCampsiteAnalysis1 = new SandbarWorkbench.Sandbars.ucCampsiteAnalysis();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabSurveys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSurveys)).BeginInit();
            this.cmsSurveys.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBestPhoto)).BeginInit();
            this.tabMap.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabCampsiteResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(507, 637);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 13);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(312, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
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
            this.tabControl1.Controls.Add(this.tabPhoto);
            this.tabControl1.Controls.Add(this.tabCampsiteResults);
            this.tabControl1.Controls.Add(this.tabMap);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 562);
            this.tabControl1.TabIndex = 9;
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
            this.grdSurveys.SelectionChanged += new System.EventHandler(this.grdSurveys_SelectionChanged);
            // 
            // cmsSurveys
            // 
            this.cmsSurveys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSurveyPropertiesToolStripMenuItem,
            this.exportToCSVToolStripMenuItem,
            this.toolStripSeparator1,
            this.addSurveyToolStripMenuItem,
            this.editSurveyToolStripMenuItem,
            this.deleteSurveyToolStripMenuItem});
            this.cmsSurveys.Name = "cmsSurveys";
            this.cmsSurveys.Size = new System.Drawing.Size(194, 120);
            // 
            // viewSurveyPropertiesToolStripMenuItem
            // 
            this.viewSurveyPropertiesToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Settings;
            this.viewSurveyPropertiesToolStripMenuItem.Name = "viewSurveyPropertiesToolStripMenuItem";
            this.viewSurveyPropertiesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.viewSurveyPropertiesToolStripMenuItem.Text = "View Survey Properties";
            this.viewSurveyPropertiesToolStripMenuItem.Click += new System.EventHandler(this.viewSurveyPropertiesToolStripMenuItem_Click);
            // 
            // exportToCSVToolStripMenuItem
            // 
            this.exportToCSVToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.export;
            this.exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            this.exportToCSVToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exportToCSVToolStripMenuItem.Text = "Export To CSV...";
            this.exportToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportToCSVToolStripMenuItem_Click);
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
            // tabPhoto
            // 
            this.tabPhoto.Controls.Add(this.picBestPhoto);
            this.tabPhoto.Location = new System.Drawing.Point(4, 22);
            this.tabPhoto.Name = "tabPhoto";
            this.tabPhoto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhoto.Size = new System.Drawing.Size(562, 536);
            this.tabPhoto.TabIndex = 4;
            this.tabPhoto.Text = "Photo";
            this.tabPhoto.UseVisualStyleBackColor = true;
            // 
            // picBestPhoto
            // 
            this.picBestPhoto.Location = new System.Drawing.Point(256, 104);
            this.picBestPhoto.Name = "picBestPhoto";
            this.picBestPhoto.Size = new System.Drawing.Size(100, 50);
            this.picBestPhoto.TabIndex = 0;
            this.picBestPhoto.TabStop = false;
            this.picBestPhoto.Paint += new System.Windows.Forms.PaintEventHandler(this.picBestPhoto_Paint);
            this.picBestPhoto.DoubleClick += new System.EventHandler(this.picBestPhoto_DoubleClick);
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.webMap);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(562, 536);
            this.tabMap.TabIndex = 5;
            this.tabMap.Text = "Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // webMap
            // 
            this.webMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webMap.Location = new System.Drawing.Point(3, 3);
            this.webMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMap.Name = "webMap";
            this.webMap.Size = new System.Drawing.Size(556, 530);
            this.webMap.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtRemarks);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(562, 536);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Text = "Remarks";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(3, 3);
            this.txtRemarks.MaxLength = 1000;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(556, 530);
            this.txtRemarks.TabIndex = 0;
            // 
            // txtRiverMile
            // 
            this.txtRiverMile.Location = new System.Drawing.Point(83, 43);
            this.txtRiverMile.Name = "txtRiverMile";
            this.txtRiverMile.ReadOnly = true;
            this.txtRiverMile.Size = new System.Drawing.Size(123, 20);
            this.txtRiverMile.TabIndex = 6;
            // 
            // txtSiteCode
            // 
            this.txtSiteCode.Location = new System.Drawing.Point(272, 43);
            this.txtSiteCode.Name = "txtSiteCode";
            this.txtSiteCode.ReadOnly = true;
            this.txtSiteCode.Size = new System.Drawing.Size(123, 20);
            this.txtSiteCode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Site code";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowse.Location = new System.Drawing.Point(401, 12);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdGDAWS
            // 
            this.cmdGDAWS.Image = global::SandbarWorkbench.Properties.Resources.USGS_logo_icon;
            this.cmdGDAWS.Location = new System.Drawing.Point(430, 12);
            this.cmdGDAWS.Name = "cmdGDAWS";
            this.cmdGDAWS.Size = new System.Drawing.Size(23, 23);
            this.cmdGDAWS.TabIndex = 3;
            this.cmdGDAWS.UseVisualStyleBackColor = true;
            this.cmdGDAWS.Click += new System.EventHandler(this.cmdGDAWS_Click);
            // 
            // cmdPhotos
            // 
            this.cmdPhotos.Image = global::SandbarWorkbench.Properties.Resources.pictures2;
            this.cmdPhotos.Location = new System.Drawing.Point(459, 12);
            this.cmdPhotos.Name = "cmdPhotos";
            this.cmdPhotos.Size = new System.Drawing.Size(23, 23);
            this.cmdPhotos.TabIndex = 4;
            this.cmdPhotos.UseVisualStyleBackColor = true;
            this.cmdPhotos.Visible = false;
            this.cmdPhotos.Click += new System.EventHandler(this.cmdPhotos_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 637);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 11;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // tabCampsiteResults
            // 
            this.tabCampsiteResults.Controls.Add(this.ucCampsiteAnalysis1);
            this.tabCampsiteResults.Location = new System.Drawing.Point(4, 22);
            this.tabCampsiteResults.Name = "tabCampsiteResults";
            this.tabCampsiteResults.Size = new System.Drawing.Size(562, 536);
            this.tabCampsiteResults.TabIndex = 7;
            this.tabCampsiteResults.Text = "Campsite Analysis";
            this.tabCampsiteResults.UseVisualStyleBackColor = true;
            // 
            // ucCampsiteAnalysis1
            // 
            this.ucCampsiteAnalysis1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCampsiteAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.ucCampsiteAnalysis1.Name = "ucCampsiteAnalysis1";
            this.ucCampsiteAnalysis1.SandbarSite = null;
            this.ucCampsiteAnalysis1.Size = new System.Drawing.Size(562, 536);
            this.ucCampsiteAnalysis1.TabIndex = 0;
            // 
            // frmSandbarProperties
            // 
            this.AcceptButton = this.cmdCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(594, 672);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdPhotos);
            this.Controls.Add(this.cmdGDAWS);
            this.Controls.Add(this.cmdBrowse);
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
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmSandbarProperties_HelpRequested);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabSurveys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSurveys)).EndInit();
            this.cmsSurveys.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBestPhoto)).EndInit();
            this.tabMap.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabCampsiteResults.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPhoto;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.WebBrowser webMap;
        private System.Windows.Forms.PictureBox picBestPhoto;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Button cmdGDAWS;
        private System.Windows.Forms.Button cmdPhotos;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVToolStripMenuItem;
        private System.Windows.Forms.TabPage tabCampsiteResults;
        private ucCampsiteAnalysis ucCampsiteAnalysis1;
    }
}