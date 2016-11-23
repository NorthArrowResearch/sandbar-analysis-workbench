﻿namespace SandbarWorkbench.Sandbars
{
    partial class frmSandbars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSandbars));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolEdit = new System.Windows.Forms.ToolStripButton();
            this.ucThumbail = new SandbarWorkbench.Pictures.ucThumbail();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.grpTimeSeries = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkRiverMile = new System.Windows.Forms.CheckBox();
            this.grpSiteName = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.grpRiverMile = new System.Windows.Forms.GroupBox();
            this.valDownstream = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valUpstream = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sandbarAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.cmsSite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseTopoFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewSandbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedSandbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTimeSeries.SuspendLayout();
            this.grpSiteName.SuspendLayout();
            this.grpRiverMile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDownstream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpstream)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.cmsSite.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.ucThumbail);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.grpTimeSeries);
            this.splitContainer1.Panel1.Controls.Add(this.chkRiverMile);
            this.splitContainer1.Panel1.Controls.Add(this.grpSiteName);
            this.splitContainer1.Panel1.Controls.Add(this.grpRiverMile);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdData);
            this.splitContainer1.Size = new System.Drawing.Size(747, 588);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBrowse,
            this.toolProperties,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolAdd,
            this.toolEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(249, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolBrowse
            // 
            this.toolBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBrowse.Image = ((System.Drawing.Image)(resources.GetObject("toolBrowse.Image")));
            this.toolBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBrowse.Name = "toolBrowse";
            this.toolBrowse.Size = new System.Drawing.Size(23, 22);
            this.toolBrowse.ToolTipText = "Browse sandbar site topo data folder";
            this.toolBrowse.Click += new System.EventHandler(this.toolBrowse_Click);
            // 
            // toolProperties
            // 
            this.toolProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolProperties.Image = global::SandbarWorkbench.Properties.Resources.Settings;
            this.toolProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolProperties.Name = "toolProperties";
            this.toolProperties.Size = new System.Drawing.Size(23, 22);
            this.toolProperties.Text = "toolStripButton1";
            this.toolProperties.ToolTipText = "View sandbar site properties";
            this.toolProperties.Click += new System.EventHandler(this.editPropertiesToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolBestPhoto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAdd
            // 
            this.toolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAdd.Image = global::SandbarWorkbench.Properties.Resources.Add;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(23, 22);
            this.toolAdd.Text = "toolStripButton1";
            this.toolAdd.ToolTipText = "Add new sandbar site";
            this.toolAdd.Click += new System.EventHandler(this.addNewSandbarToolStripMenuItem_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEdit.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(23, 22);
            this.toolEdit.Text = "toolStripButton1";
            this.toolEdit.ToolTipText = "Edit the selected sandbar site properties";
            this.toolEdit.Click += new System.EventHandler(this.editPropertiesToolStripMenuItem_Click);
            // 
            // ucThumbail
            // 
            this.ucThumbail.Location = new System.Drawing.Point(12, 330);
            this.ucThumbail.Name = "ucThumbail";
            this.ucThumbail.Size = new System.Drawing.Size(227, 192);
            this.ucThumbail.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trip Types";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(11, 45);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(130, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Channel mapping trips";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.TextChanged += new System.EventHandler(this.FilterItems);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(11, 22);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(88, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "Sandbar trips";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.TextChanged += new System.EventHandler(this.FilterItems);
            // 
            // grpTimeSeries
            // 
            this.grpTimeSeries.Controls.Add(this.checkBox2);
            this.grpTimeSeries.Controls.Add(this.checkBox1);
            this.grpTimeSeries.Location = new System.Drawing.Point(12, 180);
            this.grpTimeSeries.Name = "grpTimeSeries";
            this.grpTimeSeries.Size = new System.Drawing.Size(227, 69);
            this.grpTimeSeries.TabIndex = 2;
            this.grpTimeSeries.TabStop = false;
            this.grpTimeSeries.Text = "Time Series";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(11, 45);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Long time series";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.TextChanged += new System.EventHandler(this.FilterItems);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(11, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Short time series";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.TextChanged += new System.EventHandler(this.FilterItems);
            // 
            // chkRiverMile
            // 
            this.chkRiverMile.AutoSize = true;
            this.chkRiverMile.Location = new System.Drawing.Point(21, 8);
            this.chkRiverMile.Name = "chkRiverMile";
            this.chkRiverMile.Size = new System.Drawing.Size(73, 17);
            this.chkRiverMile.TabIndex = 0;
            this.chkRiverMile.Text = "River Mile";
            this.chkRiverMile.UseVisualStyleBackColor = true;
            this.chkRiverMile.CheckedChanged += new System.EventHandler(this.FilterItems);
            // 
            // grpSiteName
            // 
            this.grpSiteName.Controls.Add(this.txtTitle);
            this.grpSiteName.Location = new System.Drawing.Point(12, 121);
            this.grpSiteName.Name = "grpSiteName";
            this.grpSiteName.Size = new System.Drawing.Size(227, 53);
            this.grpSiteName.TabIndex = 1;
            this.grpSiteName.TabStop = false;
            this.grpSiteName.Text = "Site Name";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(11, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(205, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.FilterItems);
            // 
            // grpRiverMile
            // 
            this.grpRiverMile.Controls.Add(this.valDownstream);
            this.grpRiverMile.Controls.Add(this.label2);
            this.grpRiverMile.Controls.Add(this.valUpstream);
            this.grpRiverMile.Controls.Add(this.label1);
            this.grpRiverMile.Location = new System.Drawing.Point(12, 14);
            this.grpRiverMile.Name = "grpRiverMile";
            this.grpRiverMile.Size = new System.Drawing.Size(227, 100);
            this.grpRiverMile.TabIndex = 0;
            this.grpRiverMile.TabStop = false;
            this.grpRiverMile.Text = "                    ";
            // 
            // valDownstream
            // 
            this.valDownstream.DecimalPlaces = 1;
            this.valDownstream.Location = new System.Drawing.Point(141, 50);
            this.valDownstream.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.valDownstream.Name = "valDownstream";
            this.valDownstream.Size = new System.Drawing.Size(75, 20);
            this.valDownstream.TabIndex = 4;
            this.valDownstream.ValueChanged += new System.EventHandler(this.FilterItemsRiverMileDownstream);
            this.valDownstream.Click += new System.EventHandler(this.EnterNumericUpDown);
            this.valDownstream.Enter += new System.EventHandler(this.EnterNumericUpDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Downstream";
            // 
            // valUpstream
            // 
            this.valUpstream.DecimalPlaces = 1;
            this.valUpstream.Location = new System.Drawing.Point(141, 24);
            this.valUpstream.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.valUpstream.Name = "valUpstream";
            this.valUpstream.Size = new System.Drawing.Size(75, 20);
            this.valUpstream.TabIndex = 2;
            this.valUpstream.ValueChanged += new System.EventHandler(this.FilterItemsRiverMileUpstream);
            this.valUpstream.Click += new System.EventHandler(this.EnterNumericUpDown);
            this.valUpstream.Enter += new System.EventHandler(this.EnterNumericUpDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upstream";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(249, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sandbarAnalysisToolStripMenuItem});
            this.toolsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolsToolStripMenuItem.MergeIndex = 2;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Visible = false;
            // 
            // sandbarAnalysisToolStripMenuItem
            // 
            this.sandbarAnalysisToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.sandbarAnalysisToolStripMenuItem.MergeIndex = 0;
            this.sandbarAnalysisToolStripMenuItem.Name = "sandbarAnalysisToolStripMenuItem";
            this.sandbarAnalysisToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.sandbarAnalysisToolStripMenuItem.Text = "Sandbar Analysis...";
            this.sandbarAnalysisToolStripMenuItem.Click += new System.EventHandler(this.sandbarAnalysisToolStripMenuItem_Click);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.ContextMenuStrip = this.cmsSite;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersVisible = false;
            this.grdData.Size = new System.Drawing.Size(494, 588);
            this.grdData.TabIndex = 0;
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellContentClick);
            this.grdData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellDoubleClick);
            this.grdData.SelectionChanged += new System.EventHandler(this.grdData_SelectionChanged);
            this.grdData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdData_MouseClick);
            // 
            // cmsSite
            // 
            this.cmsSite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPropertiesToolStripMenuItem,
            this.browseTopoFolderToolStripMenuItem,
            this.toolStripSeparator2,
            this.addNewSandbarToolStripMenuItem,
            this.editPropertiesToolStripMenuItem,
            this.deleteSelectedSandbarToolStripMenuItem});
            this.cmsSite.Name = "cmsSite";
            this.cmsSite.Size = new System.Drawing.Size(210, 120);
            // 
            // viewPropertiesToolStripMenuItem
            // 
            this.viewPropertiesToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Settings;
            this.viewPropertiesToolStripMenuItem.Name = "viewPropertiesToolStripMenuItem";
            this.viewPropertiesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.viewPropertiesToolStripMenuItem.Text = "View Properties";
            // 
            // browseTopoFolderToolStripMenuItem
            // 
            this.browseTopoFolderToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.browseTopoFolderToolStripMenuItem.Name = "browseTopoFolderToolStripMenuItem";
            this.browseTopoFolderToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.browseTopoFolderToolStripMenuItem.Text = "Browse Topo Folder...";
            this.browseTopoFolderToolStripMenuItem.Click += new System.EventHandler(this.browseTopoFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // addNewSandbarToolStripMenuItem
            // 
            this.addNewSandbarToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Add;
            this.addNewSandbarToolStripMenuItem.Name = "addNewSandbarToolStripMenuItem";
            this.addNewSandbarToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addNewSandbarToolStripMenuItem.Text = "Add New Sandbar...";
            this.addNewSandbarToolStripMenuItem.Click += new System.EventHandler(this.addNewSandbarToolStripMenuItem_Click);
            // 
            // editPropertiesToolStripMenuItem
            // 
            this.editPropertiesToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.editPropertiesToolStripMenuItem.Name = "editPropertiesToolStripMenuItem";
            this.editPropertiesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.editPropertiesToolStripMenuItem.Text = "Edit Properties";
            this.editPropertiesToolStripMenuItem.Click += new System.EventHandler(this.editPropertiesToolStripMenuItem_Click);
            // 
            // deleteSelectedSandbarToolStripMenuItem
            // 
            this.deleteSelectedSandbarToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Delete;
            this.deleteSelectedSandbarToolStripMenuItem.Name = "deleteSelectedSandbarToolStripMenuItem";
            this.deleteSelectedSandbarToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.deleteSelectedSandbarToolStripMenuItem.Text = "Delete Selected Sandbar...";
            this.deleteSelectedSandbarToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedSandbarToolStripMenuItem_Click);
            // 
            // frmSandbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 588);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSandbars";
            this.Text = "Sandbar Sites";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSandbars_FormClosing);
            this.Load += new System.EventHandler(this.frmSandbars_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTimeSeries.ResumeLayout(false);
            this.grpTimeSeries.PerformLayout();
            this.grpSiteName.ResumeLayout(false);
            this.grpSiteName.PerformLayout();
            this.grpRiverMile.ResumeLayout(false);
            this.grpRiverMile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDownstream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpstream)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.cmsSite.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.GroupBox grpSiteName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox grpRiverMile;
        private System.Windows.Forms.NumericUpDown valDownstream;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valUpstream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRiverMile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox grpTimeSeries;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip cmsSite;
        private System.Windows.Forms.ToolStripMenuItem viewPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSandbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedSandbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseTopoFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandbarAnalysisToolStripMenuItem;
        private Pictures.ucThumbail ucThumbail;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBrowse;
        private System.Windows.Forms.ToolStripButton toolProperties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolEdit;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}