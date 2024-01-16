namespace SandbarWorkbench.ModelRuns
{
    partial class frmModelRuns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModelRuns));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.cmsGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseLocalModelRunResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportIncrementalResultsToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBinnedResultsToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editModelRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteModelRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.exportCampsiteResultsToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.cmsGridView.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdData);
            this.splitContainer1.Size = new System.Drawing.Size(731, 381);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtTo);
            this.groupBox2.Controls.Add(this.dtFrom);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Run Date";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(53, 49);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(160, 20);
            this.dtTo.TabIndex = 3;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(53, 20);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(160, 20);
            this.dtFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Location = new System.Drawing.Point(152, 138);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(240, 150);
            this.grdData.TabIndex = 0;
            this.grdData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdData_CellPainting);
            this.grdData.SelectionChanged += new System.EventHandler(this.grdData_SelectionChanged);
            this.grdData.DoubleClick += new System.EventHandler(this.editModelRunToolStripMenuItem_Click);
            // 
            // cmsGridView
            // 
            this.cmsGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseLocalModelRunResultsToolStripMenuItem,
            this.exportIncrementalResultsToCSVToolStripMenuItem,
            this.exportBinnedResultsToCSVToolStripMenuItem,
            this.exportCampsiteResultsToCSVToolStripMenuItem,
            this.toolStripSeparator1,
            this.editModelRunToolStripMenuItem,
            this.deleteModelRunToolStripMenuItem});
            this.cmsGridView.Name = "cmsGridView";
            this.cmsGridView.Size = new System.Drawing.Size(262, 164);
            // 
            // browseLocalModelRunResultsToolStripMenuItem
            // 
            this.browseLocalModelRunResultsToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.browseLocalModelRunResultsToolStripMenuItem.Name = "browseLocalModelRunResultsToolStripMenuItem";
            this.browseLocalModelRunResultsToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.browseLocalModelRunResultsToolStripMenuItem.Text = "Browse Local Model Run Results...";
            this.browseLocalModelRunResultsToolStripMenuItem.Click += new System.EventHandler(this.browseLocalModelRunResultsToolStripMenuItem_Click);
            // 
            // exportIncrementalResultsToCSVToolStripMenuItem
            // 
            this.exportIncrementalResultsToCSVToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.export;
            this.exportIncrementalResultsToCSVToolStripMenuItem.Name = "exportIncrementalResultsToCSVToolStripMenuItem";
            this.exportIncrementalResultsToCSVToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.exportIncrementalResultsToCSVToolStripMenuItem.Text = "Export Incremental Results to CSV...";
            this.exportIncrementalResultsToCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportResultsCSV);
            // 
            // exportBinnedResultsToCSVToolStripMenuItem
            // 
            this.exportBinnedResultsToCSVToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.export;
            this.exportBinnedResultsToCSVToolStripMenuItem.Name = "exportBinnedResultsToCSVToolStripMenuItem";
            this.exportBinnedResultsToCSVToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.exportBinnedResultsToCSVToolStripMenuItem.Text = "Export Binned Results to CSV...";
            this.exportBinnedResultsToCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportResultsCSV);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // editModelRunToolStripMenuItem
            // 
            this.editModelRunToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.editModelRunToolStripMenuItem.Name = "editModelRunToolStripMenuItem";
            this.editModelRunToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.editModelRunToolStripMenuItem.Text = "Edit Model Run...";
            this.editModelRunToolStripMenuItem.Click += new System.EventHandler(this.editModelRunToolStripMenuItem_Click);
            // 
            // deleteModelRunToolStripMenuItem
            // 
            this.deleteModelRunToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Delete;
            this.deleteModelRunToolStripMenuItem.Name = "deleteModelRunToolStripMenuItem";
            this.deleteModelRunToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.deleteModelRunToolStripMenuItem.Text = "Delete Model Run...";
            this.deleteModelRunToolStripMenuItem.Click += new System.EventHandler(this.deleteModelRunToolStripMenuItem_Click);
            // 
            // exportCampsiteResultsToCSVToolStripMenuItem
            // 
            this.exportCampsiteResultsToCSVToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.export;
            this.exportCampsiteResultsToCSVToolStripMenuItem.Name = "exportCampsiteResultsToCSVToolStripMenuItem";
            this.exportCampsiteResultsToCSVToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.exportCampsiteResultsToCSVToolStripMenuItem.Text = "Export Campsite Results to CSV...";
            this.exportCampsiteResultsToCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportResultsCSV);
            // 
            // frmModelRuns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 381);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModelRuns";
            this.Text = "frmModelRuns";
            this.Load += new System.EventHandler(this.frmModelRuns_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmModelRuns_HelpRequested);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.cmsGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.ContextMenuStrip cmsGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem editModelRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteModelRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseLocalModelRunResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportIncrementalResultsToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportBinnedResultsToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.ToolStripMenuItem exportCampsiteResultsToCSVToolStripMenuItem;
    }
}