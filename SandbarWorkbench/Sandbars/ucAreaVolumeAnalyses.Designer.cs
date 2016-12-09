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
            this.rdoBinned = new System.Windows.Forms.RadioButton();
            this.rdoIncremental = new System.Windows.Forms.RadioButton();
            this.chkVolume = new System.Windows.Forms.CheckBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.grpVolume = new System.Windows.Forms.GroupBox();
            this.chkVolSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.chkAreaSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.valDisUpper = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valDisLower = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grdAnalyses = new System.Windows.Forms.DataGridView();
            this.splitContainer_Horiz = new System.Windows.Forms.SplitContainer();
            this.cmsResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportIncrementalResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBinnedResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Vert)).BeginInit();
            this.splitContainer_Vert.Panel1.SuspendLayout();
            this.splitContainer_Vert.Panel2.SuspendLayout();
            this.splitContainer_Vert.SuspendLayout();
            this.grpAnalysisType.SuspendLayout();
            this.grpVolume.SuspendLayout();
            this.grpArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDisUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDisLower)).BeginInit();
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
            this.splitContainer_Vert.Panel1.Controls.Add(this.chkVolume);
            this.splitContainer_Vert.Panel1.Controls.Add(this.chkArea);
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpVolume);
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpArea);
            this.splitContainer_Vert.Panel1.Controls.Add(this.groupBox1);
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
            this.grpAnalysisType.Controls.Add(this.rdoBinned);
            this.grpAnalysisType.Controls.Add(this.rdoIncremental);
            this.grpAnalysisType.Location = new System.Drawing.Point(5, 6);
            this.grpAnalysisType.Name = "grpAnalysisType";
            this.grpAnalysisType.Size = new System.Drawing.Size(200, 69);
            this.grpAnalysisType.TabIndex = 3;
            this.grpAnalysisType.TabStop = false;
            this.grpAnalysisType.Text = "Analysis Type";
            // 
            // rdoBinned
            // 
            this.rdoBinned.AutoSize = true;
            this.rdoBinned.Location = new System.Drawing.Point(11, 44);
            this.rdoBinned.Name = "rdoBinned";
            this.rdoBinned.Size = new System.Drawing.Size(58, 17);
            this.rdoBinned.TabIndex = 1;
            this.rdoBinned.Text = "Binned";
            this.rdoBinned.UseVisualStyleBackColor = true;
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
            // 
            // chkVolume
            // 
            this.chkVolume.AutoSize = true;
            this.chkVolume.Location = new System.Drawing.Point(17, 268);
            this.chkVolume.Name = "chkVolume";
            this.chkVolume.Size = new System.Drawing.Size(61, 17);
            this.chkVolume.TabIndex = 0;
            this.chkVolume.Text = "Volume";
            this.chkVolume.UseVisualStyleBackColor = true;
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(17, 170);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(48, 17);
            this.chkArea.TabIndex = 0;
            this.chkArea.Text = "Area";
            this.chkArea.UseVisualStyleBackColor = true;
            // 
            // grpVolume
            // 
            this.grpVolume.Controls.Add(this.chkVolSectionTypes);
            this.grpVolume.Location = new System.Drawing.Point(5, 272);
            this.grpVolume.Name = "grpVolume";
            this.grpVolume.Size = new System.Drawing.Size(200, 85);
            this.grpVolume.TabIndex = 2;
            this.grpVolume.TabStop = false;
            this.grpVolume.Text = "                      ";
            // 
            // chkVolSectionTypes
            // 
            this.chkVolSectionTypes.CheckOnClick = true;
            this.chkVolSectionTypes.FormattingEnabled = true;
            this.chkVolSectionTypes.Location = new System.Drawing.Point(25, 22);
            this.chkVolSectionTypes.Name = "chkVolSectionTypes";
            this.chkVolSectionTypes.Size = new System.Drawing.Size(169, 49);
            this.chkVolSectionTypes.TabIndex = 2;
            this.chkVolSectionTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SectionTypes_ItemCheck);
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.chkAreaSectionTypes);
            this.grpArea.Location = new System.Drawing.Point(5, 175);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(200, 85);
            this.grpArea.TabIndex = 1;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "               ";
            // 
            // chkAreaSectionTypes
            // 
            this.chkAreaSectionTypes.CheckOnClick = true;
            this.chkAreaSectionTypes.FormattingEnabled = true;
            this.chkAreaSectionTypes.Location = new System.Drawing.Point(25, 22);
            this.chkAreaSectionTypes.Name = "chkAreaSectionTypes";
            this.chkAreaSectionTypes.Size = new System.Drawing.Size(169, 49);
            this.chkAreaSectionTypes.TabIndex = 1;
            this.chkAreaSectionTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SectionTypes_ItemCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.valDisUpper);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.valDisLower);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Discharge";
            // 
            // valDisUpper
            // 
            this.valDisUpper.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valDisUpper.Location = new System.Drawing.Point(74, 47);
            this.valDisUpper.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.valDisUpper.Name = "valDisUpper";
            this.valDisUpper.Size = new System.Drawing.Size(120, 20);
            this.valDisUpper.TabIndex = 3;
            this.valDisUpper.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.valDisUpper.ValueChanged += new System.EventHandler(this.Discharge_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Upper";
            // 
            // valDisLower
            // 
            this.valDisLower.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valDisLower.Location = new System.Drawing.Point(74, 19);
            this.valDisLower.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.valDisLower.Name = "valDisLower";
            this.valDisLower.Size = new System.Drawing.Size(120, 20);
            this.valDisLower.TabIndex = 1;
            this.valDisLower.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.valDisLower.ValueChanged += new System.EventHandler(this.Discharge_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lower";
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
            this.exportIncrementalResultsToolStripMenuItem,
            this.exportBinnedResultsToolStripMenuItem});
            this.cmsResults.Name = "cmsResults";
            this.cmsResults.Size = new System.Drawing.Size(223, 70);
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
            // ucAreaVolumeAnalyses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_Horiz);
            this.Name = "ucAreaVolumeAnalyses";
            this.Size = new System.Drawing.Size(885, 679);
            this.Load += new System.EventHandler(this.ucAreaVolumeAnalyses_Load);
            this.splitContainer_Vert.Panel1.ResumeLayout(false);
            this.splitContainer_Vert.Panel1.PerformLayout();
            this.splitContainer_Vert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Vert)).EndInit();
            this.splitContainer_Vert.ResumeLayout(false);
            this.grpAnalysisType.ResumeLayout(false);
            this.grpAnalysisType.PerformLayout();
            this.grpVolume.ResumeLayout(false);
            this.grpArea.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDisUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDisLower)).EndInit();
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
        private System.Windows.Forms.CheckBox chkVolume;
        private System.Windows.Forms.GroupBox grpArea;
        private System.Windows.Forms.CheckBox chkArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown valDisUpper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valDisLower;
        private System.Windows.Forms.Label label1;
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
    }
}
