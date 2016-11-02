namespace SandbarWorkbench.DataGridViews
{
    partial class frmDataGridView
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
            this.grdData = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editReachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteReachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addReachToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editReachToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteReachToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.cmsDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.ContextMenuStrip = this.cmsDataGrid;
            this.grdData.Location = new System.Drawing.Point(106, 142);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(240, 150);
            this.grdData.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReachToolStripMenuItem,
            this.editReachToolStripMenuItem,
            this.deleteReachToolStripMenuItem});
            this.editToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.editToolStripMenuItem.MergeIndex = 1;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addReachToolStripMenuItem
            // 
            this.addReachToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Add;
            this.addReachToolStripMenuItem.Name = "addReachToolStripMenuItem";
            this.addReachToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.addReachToolStripMenuItem.Text = "Add...";
            this.addReachToolStripMenuItem.Click += new System.EventHandler(this.AddEdit_Click);
            // 
            // editReachToolStripMenuItem
            // 
            this.editReachToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.editReachToolStripMenuItem.Name = "editReachToolStripMenuItem";
            this.editReachToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.editReachToolStripMenuItem.Text = "Edit...";
            this.editReachToolStripMenuItem.Click += new System.EventHandler(this.AddEdit_Click);
            // 
            // deleteReachToolStripMenuItem
            // 
            this.deleteReachToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Delete;
            this.deleteReachToolStripMenuItem.Name = "deleteReachToolStripMenuItem";
            this.deleteReachToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.deleteReachToolStripMenuItem.Text = "Delete...";
            this.deleteReachToolStripMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // cmsDataGrid
            // 
            this.cmsDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReachToolStripMenuItem1,
            this.editReachToolStripMenuItem1,
            this.deleteReachToolStripMenuItem1});
            this.cmsDataGrid.Name = "cmsDataGrid";
            this.cmsDataGrid.Size = new System.Drawing.Size(117, 70);
            // 
            // addReachToolStripMenuItem1
            // 
            this.addReachToolStripMenuItem1.Image = global::SandbarWorkbench.Properties.Resources.Add;
            this.addReachToolStripMenuItem1.Name = "addReachToolStripMenuItem1";
            this.addReachToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.addReachToolStripMenuItem1.Text = "Add...";
            this.addReachToolStripMenuItem1.Click += new System.EventHandler(this.AddEdit_Click);
            // 
            // editReachToolStripMenuItem1
            // 
            this.editReachToolStripMenuItem1.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.editReachToolStripMenuItem1.Name = "editReachToolStripMenuItem1";
            this.editReachToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.editReachToolStripMenuItem1.Text = "Edit...";
            this.editReachToolStripMenuItem1.Click += new System.EventHandler(this.AddEdit_Click);
            // 
            // deleteReachToolStripMenuItem1
            // 
            this.deleteReachToolStripMenuItem1.Image = global::SandbarWorkbench.Properties.Resources.Delete;
            this.deleteReachToolStripMenuItem1.Name = "deleteReachToolStripMenuItem1";
            this.deleteReachToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.deleteReachToolStripMenuItem1.Text = "Delete...";
            this.deleteReachToolStripMenuItem1.Click += new System.EventHandler(this.Delete_Click);
            // 
            // frmDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grdData);
            this.Name = "frmDataGridView";
            this.Text = "frmDataGridView";
            this.Load += new System.EventHandler(this.frmDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addReachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editReachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteReachToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsDataGrid;
        private System.Windows.Forms.ToolStripMenuItem addReachToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editReachToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteReachToolStripMenuItem1;
    }
}