namespace SandbarWorkbench.Sandbars
{
    partial class ucCampsiteAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCampsiteAnalysis));
            this.splitHoriztonal = new System.Windows.Forms.SplitContainer();
            this.splitVertical = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBins = new System.Windows.Forms.CheckedListBox();
            this.chtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grdAnalyses = new System.Windows.Forms.DataGridView();
            this.cmsResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseAnalysisFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportIncrementalResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitHoriztonal)).BeginInit();
            this.splitHoriztonal.Panel1.SuspendLayout();
            this.splitHoriztonal.Panel2.SuspendLayout();
            this.splitHoriztonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).BeginInit();
            this.splitVertical.Panel1.SuspendLayout();
            this.splitVertical.Panel2.SuspendLayout();
            this.splitVertical.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyses)).BeginInit();
            this.cmsResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitHoriztonal
            // 
            this.splitHoriztonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHoriztonal.Location = new System.Drawing.Point(0, 0);
            this.splitHoriztonal.Name = "splitHoriztonal";
            this.splitHoriztonal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHoriztonal.Panel1
            // 
            this.splitHoriztonal.Panel1.Controls.Add(this.splitVertical);
            // 
            // splitHoriztonal.Panel2
            // 
            this.splitHoriztonal.Panel2.Controls.Add(this.grdAnalyses);
            this.splitHoriztonal.Size = new System.Drawing.Size(885, 679);
            this.splitHoriztonal.SplitterDistance = 499;
            this.splitHoriztonal.TabIndex = 0;
            // 
            // splitVertical
            // 
            this.splitVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitVertical.Location = new System.Drawing.Point(0, 0);
            this.splitVertical.Name = "splitVertical";
            // 
            // splitVertical.Panel1
            // 
            this.splitVertical.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitVertical.Panel2
            // 
            this.splitVertical.Panel2.Controls.Add(this.chtData);
            this.splitVertical.Size = new System.Drawing.Size(885, 499);
            this.splitVertical.SplitterDistance = 210;
            this.splitVertical.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBins);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 499);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campsite Analysis Bins";
            // 
            // chkBins
            // 
            this.chkBins.CheckOnClick = true;
            this.chkBins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBins.FormattingEnabled = true;
            this.chkBins.Location = new System.Drawing.Point(3, 16);
            this.chkBins.Name = "chkBins";
            this.chkBins.Size = new System.Drawing.Size(204, 480);
            this.chkBins.TabIndex = 0;
            this.chkBins.SelectedIndexChanged += new System.EventHandler(this.UpdateCharts);
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
            // cmsResults
            // 
            this.cmsResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseAnalysisFolderToolStripMenuItem,
            this.exportIncrementalResultsToolStripMenuItem});
            this.cmsResults.Name = "cmsResults";
            this.cmsResults.Size = new System.Drawing.Size(238, 48);
            // 
            // browseAnalysisFolderToolStripMenuItem
            // 
            this.browseAnalysisFolderToolStripMenuItem.Name = "browseAnalysisFolderToolStripMenuItem";
            this.browseAnalysisFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.browseAnalysisFolderToolStripMenuItem.Text = "Browse Analysis Folder...";
            this.browseAnalysisFolderToolStripMenuItem.Click += new System.EventHandler(this.browseAnalysisFolderToolStripMenuItem_Click);
            // 
            // exportIncrementalResultsToolStripMenuItem
            // 
            this.exportIncrementalResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportIncrementalResultsToolStripMenuItem.Image")));
            this.exportIncrementalResultsToolStripMenuItem.Name = "exportIncrementalResultsToolStripMenuItem";
            this.exportIncrementalResultsToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.exportIncrementalResultsToolStripMenuItem.Text = "Export Campsite Area Results...";
            this.exportIncrementalResultsToolStripMenuItem.Click += new System.EventHandler(this.ExportResults);
            // 
            // ucCampsiteAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitHoriztonal);
            this.Name = "ucCampsiteAnalysis";
            this.Size = new System.Drawing.Size(885, 679);
            this.Load += new System.EventHandler(this.ucCampsiteAnalysis_Load);
            this.splitHoriztonal.Panel1.ResumeLayout(false);
            this.splitHoriztonal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHoriztonal)).EndInit();
            this.splitHoriztonal.ResumeLayout(false);
            this.splitVertical.Panel1.ResumeLayout(false);
            this.splitVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitVertical)).EndInit();
            this.splitVertical.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyses)).EndInit();
            this.cmsResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitHoriztonal;
        private System.Windows.Forms.SplitContainer splitVertical;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtData;
        private System.Windows.Forms.DataGridView grdAnalyses;
        private System.Windows.Forms.ContextMenuStrip cmsResults;
        private System.Windows.Forms.ToolStripMenuItem browseAnalysisFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportIncrementalResultsToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox chkBins;
    }
}
