namespace SandbarWorkbench.Sandbars
{
    partial class ucAreaVolumeAnalyses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAreaVolumeAnalyses));
            this.splitContainer_Vert = new System.Windows.Forms.SplitContainer();
            this.grpAnalysisType = new System.Windows.Forms.GroupBox();
            this.valDisUpper = new System.Windows.Forms.NumericUpDown();
            this.lblUpperDischarge = new System.Windows.Forms.Label();
            this.chkBins = new System.Windows.Forms.CheckedListBox();
            this.rdoBinned = new System.Windows.Forms.RadioButton();
            this.valDisLower = new System.Windows.Forms.NumericUpDown();
            this.lblLowerdischarge = new System.Windows.Forms.Label();
            this.rdoIncremental = new System.Windows.Forms.RadioButton();
            this.grpVolume = new System.Windows.Forms.GroupBox();
            this.chkVolSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.chkAreaSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.chtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grdAnalyses = new System.Windows.Forms.DataGridView();
            this.splitContainer_Horiz = new System.Windows.Forms.SplitContainer();
            this.cmsResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportIncrementalResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBinnedResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseAnalysisFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Vert)).BeginInit();
            this.splitContainer_Vert.Panel1.SuspendLayout();
            this.splitContainer_Vert.Panel2.SuspendLayout();
            this.splitContainer_Vert.SuspendLayout();
            this.grpAnalysisType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDisUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDisLower)).BeginInit();
            this.grpVolume.SuspendLayout();
            this.grpArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Horiz)).BeginInit();
            this.splitContainer_Horiz.Panel1.SuspendLayout();
            this.splitContainer_Horiz.Panel2.SuspendLayout();
            this.splitContainer_Horiz.SuspendLayout();
            this.cmsResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Vert
            // 
            this.splitContainer_Vert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Vert.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Vert.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Vert.Name = "splitContainer_Vert";
            // 
            // splitContainer_Vert.Panel1
            // 
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpAnalysisType);
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpVolume);
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpArea);
            // 
            // splitContainer_Vert.Panel2
            // 
            this.splitContainer_Vert.Panel2.Controls.Add(this.chtData);
            this.splitContainer_Vert.Size = new System.Drawing.Size(885, 499);
            this.splitContainer_Vert.SplitterDistance = 210;
            this.splitContainer_Vert.TabIndex = 0;
            // 
            // grpAnalysisType
            // 
            this.grpAnalysisType.Controls.Add(this.valDisUpper);
            this.grpAnalysisType.Controls.Add(this.lblUpperDischarge);
            this.grpAnalysisType.Controls.Add(this.chkBins);
            this.grpAnalysisType.Controls.Add(this.rdoBinned);
            this.grpAnalysisType.Controls.Add(this.valDisLower);
            this.grpAnalysisType.Controls.Add(this.lblLowerdischarge);
            this.grpAnalysisType.Controls.Add(this.rdoIncremental);
            this.grpAnalysisType.Location = new System.Drawing.Point(5, 6);
            this.grpAnalysisType.Name = "grpAnalysisType";
            this.grpAnalysisType.Size = new System.Drawing.Size(200, 200);
            this.grpAnalysisType.TabIndex = 3;
            this.grpAnalysisType.TabStop = false;
            this.grpAnalysisType.Text = "Analysis Type";
            // 
            // valDisUpper
            // 
            this.valDisUpper.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valDisUpper.Location = new System.Drawing.Point(116, 69);
            this.valDisUpper.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.valDisUpper.Name = "valDisUpper";
            this.valDisUpper.Size = new System.Drawing.Size(78, 20);
            this.valDisUpper.TabIndex = 4;
            this.valDisUpper.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.valDisUpper.ValueChanged += new System.EventHandler(this.Discharge_ValueChanged);
            // 
            // lblUpperDischarge
            // 
            this.lblUpperDischarge.AutoSize = true;
            this.lblUpperDischarge.Location = new System.Drawing.Point(27, 73);
            this.lblUpperDischarge.Name = "lblUpperDischarge";
            this.lblUpperDischarge.Size = new System.Drawing.Size(85, 13);
            this.lblUpperDischarge.TabIndex = 3;
            this.lblUpperDischarge.Text = "Upper discharge";
            // 
            // chkBins
            // 
            this.chkBins.CheckOnClick = true;
            this.chkBins.FormattingEnabled = true;
            this.chkBins.Location = new System.Drawing.Point(25, 126);
            this.chkBins.Name = "chkBins";
            this.chkBins.Size = new System.Drawing.Size(169, 64);
            this.chkBins.TabIndex = 6;
            this.chkBins.SelectedIndexChanged += new System.EventHandler(this.UpdateCharts);
            // 
            // rdoBinned
            // 
            this.rdoBinned.AutoSize = true;
            this.rdoBinned.Location = new System.Drawing.Point(11, 102);
            this.rdoBinned.Name = "rdoBinned";
            this.rdoBinned.Size = new System.Drawing.Size(58, 17);
            this.rdoBinned.TabIndex = 5;
            this.rdoBinned.Text = "Binned";
            this.rdoBinned.UseVisualStyleBackColor = true;
            // 
            // valDisLower
            // 
            this.valDisLower.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valDisLower.Location = new System.Drawing.Point(116, 43);
            this.valDisLower.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.valDisLower.Name = "valDisLower";
            this.valDisLower.Size = new System.Drawing.Size(78, 20);
            this.valDisLower.TabIndex = 2;
            this.valDisLower.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.valDisLower.ValueChanged += new System.EventHandler(this.Discharge_ValueChanged);
            // 
            // lblLowerdischarge
            // 
            this.lblLowerdischarge.AutoSize = true;
            this.lblLowerdischarge.Location = new System.Drawing.Point(27, 47);
            this.lblLowerdischarge.Name = "lblLowerdischarge";
            this.lblLowerdischarge.Size = new System.Drawing.Size(85, 13);
            this.lblLowerdischarge.TabIndex = 1;
            this.lblLowerdischarge.Text = "Lower discharge";
            // 
            // rdoIncremental
            // 
            this.rdoIncremental.AutoSize = true;
            this.rdoIncremental.Checked = true;
            this.rdoIncremental.Location = new System.Drawing.Point(11, 20);
            this.rdoIncremental.Name = "rdoIncremental";
            this.rdoIncremental.Size = new System.Drawing.Size(80, 17);
            this.rdoIncremental.TabIndex = 0;
            this.rdoIncremental.TabStop = true;
            this.rdoIncremental.Text = "Incremental";
            this.rdoIncremental.UseVisualStyleBackColor = true;
            this.rdoIncremental.CheckedChanged += new System.EventHandler(this.ChartTypeChanging);
            // 
            // grpVolume
            // 
            this.grpVolume.Controls.Add(this.chkVolSectionTypes);
            this.grpVolume.Location = new System.Drawing.Point(5, 328);
            this.grpVolume.Name = "grpVolume";
            this.grpVolume.Size = new System.Drawing.Size(200, 110);
            this.grpVolume.TabIndex = 1;
            this.grpVolume.TabStop = false;
            this.grpVolume.Text = "Volume";
            // 
            // chkVolSectionTypes
            // 
            this.chkVolSectionTypes.CheckOnClick = true;
            this.chkVolSectionTypes.FormattingEnabled = true;
            this.chkVolSectionTypes.Location = new System.Drawing.Point(25, 22);
            this.chkVolSectionTypes.Name = "chkVolSectionTypes";
            this.chkVolSectionTypes.Size = new System.Drawing.Size(169, 79);
            this.chkVolSectionTypes.TabIndex = 2;
            this.chkVolSectionTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SectionTypes_ItemCheck);
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.chkAreaSectionTypes);
            this.grpArea.Location = new System.Drawing.Point(5, 212);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(200, 110);
            this.grpArea.TabIndex = 0;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "Area";
            // 
            // chkAreaSectionTypes
            // 
            this.chkAreaSectionTypes.CheckOnClick = true;
            this.chkAreaSectionTypes.FormattingEnabled = true;
            this.chkAreaSectionTypes.Location = new System.Drawing.Point(25, 22);
            this.chkAreaSectionTypes.Name = "chkAreaSectionTypes";
            this.chkAreaSectionTypes.Size = new System.Drawing.Size(169, 79);
            this.chkAreaSectionTypes.TabIndex = 1;
            this.chkAreaSectionTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SectionTypes_ItemCheck);
            // 
            // chtData
            // 
            chartArea1.Name = "ChartArea1";
            this.chtData.ChartAreas.Add(chartArea1);
            this.chtData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtData.Legends.Add(legend1);
            this.chtData.Location = new System.Drawing.Point(0, 0);
            this.chtData.Name = "chtData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtData.Series.Add(series1);
            this.chtData.Size = new System.Drawing.Size(671, 499);
            this.chtData.TabIndex = 0;
            this.chtData.Text = "chart1";
            // 
            // grdAnalyses
            // 
            this.grdAnalyses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAnalyses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnalyses.Location = new System.Drawing.Point(0, 0);
            this.grdAnalyses.Name = "grdAnalyses";
            this.grdAnalyses.Size = new System.Drawing.Size(885, 176);
            this.grdAnalyses.TabIndex = 0;
            this.grdAnalyses.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdAnalyses_CellMouseUp);
            this.grdAnalyses.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAnalyses_CellValueChanged);
            // 
            // splitContainer_Horiz
            // 
            this.splitContainer_Horiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Horiz.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Horiz.Name = "splitContainer_Horiz";
            this.splitContainer_Horiz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Horiz.Panel1
            // 
            this.splitContainer_Horiz.Panel1.Controls.Add(this.splitContainer_Vert);
            // 
            // splitContainer_Horiz.Panel2
            // 
            this.splitContainer_Horiz.Panel2.Controls.Add(this.grdAnalyses);
            this.splitContainer_Horiz.Size = new System.Drawing.Size(885, 679);
            this.splitContainer_Horiz.SplitterDistance = 499;
            this.splitContainer_Horiz.TabIndex = 1;
            // 
            // cmsResults
            // 
            this.cmsResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseAnalysisFolderToolStripMenuItem,
            this.exportIncrementalResultsToolStripMenuItem,
            this.exportBinnedResultsToolStripMenuItem});
            this.cmsResults.Name = "cmsResults";
            this.cmsResults.Size = new System.Drawing.Size(223, 92);
            // 
            // exportIncrementalResultsToolStripMenuItem
            // 
            this.exportIncrementalResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportIncrementalResultsToolStripMenuItem.Image")));
            this.exportIncrementalResultsToolStripMenuItem.Name = "exportIncrementalResultsToolStripMenuItem";
            this.exportIncrementalResultsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exportIncrementalResultsToolStripMenuItem.Text = "Export Incremental Results...";
            this.exportIncrementalResultsToolStripMenuItem.Click += new System.EventHandler(this.ExportResults);
            // 
            // exportBinnedResultsToolStripMenuItem
            // 
            this.exportBinnedResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportBinnedResultsToolStripMenuItem.Image")));
            this.exportBinnedResultsToolStripMenuItem.Name = "exportBinnedResultsToolStripMenuItem";
            this.exportBinnedResultsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exportBinnedResultsToolStripMenuItem.Text = "Export Binned Results...";
            this.exportBinnedResultsToolStripMenuItem.Click += new System.EventHandler(this.ExportResults);
            // 
            // browseAnalysisFolderToolStripMenuItem
            // 
            this.browseAnalysisFolderToolStripMenuItem.Name = "browseAnalysisFolderToolStripMenuItem";
            this.browseAnalysisFolderToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.browseAnalysisFolderToolStripMenuItem.Text = "Browse Analysis Folder...";
            // 
            // ucAreaVolumeAnalyses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_Horiz);
            this.Name = "ucAreaVolumeAnalyses";
            this.Size = new System.Drawing.Size(885, 679);
            this.Load += new System.EventHandler(this.ucAreaVolumeAnalyses_Load);
            this.splitContainer_Vert.Panel1.ResumeLayout(false);
            this.splitContainer_Vert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Vert)).EndInit();
            this.splitContainer_Vert.ResumeLayout(false);
            this.grpAnalysisType.ResumeLayout(false);
            this.grpAnalysisType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDisUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDisLower)).EndInit();
            this.grpVolume.ResumeLayout(false);
            this.grpArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyses)).EndInit();
            this.splitContainer_Horiz.Panel1.ResumeLayout(false);
            this.splitContainer_Horiz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Horiz)).EndInit();
            this.splitContainer_Horiz.ResumeLayout(false);
            this.cmsResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Vert;
        private System.Windows.Forms.GroupBox grpVolume;
        private System.Windows.Forms.GroupBox grpArea;
        private System.Windows.Forms.NumericUpDown valDisUpper;
        private System.Windows.Forms.Label lblUpperDischarge;
        private System.Windows.Forms.NumericUpDown valDisLower;
        private System.Windows.Forms.Label lblLowerdischarge;
        private System.Windows.Forms.DataGridView grdAnalyses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtData;
        private System.Windows.Forms.SplitContainer splitContainer_Horiz;
        private System.Windows.Forms.CheckedListBox chkVolSectionTypes;
        private System.Windows.Forms.CheckedListBox chkAreaSectionTypes;
        private System.Windows.Forms.GroupBox grpAnalysisType;
        private System.Windows.Forms.RadioButton rdoBinned;
        private System.Windows.Forms.RadioButton rdoIncremental;
        private System.Windows.Forms.ContextMenuStrip cmsResults;
        private System.Windows.Forms.ToolStripMenuItem exportIncrementalResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportBinnedResultsToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox chkBins;
        private System.Windows.Forms.ToolStripMenuItem browseAnalysisFolderToolStripMenuItem;
    }
}
