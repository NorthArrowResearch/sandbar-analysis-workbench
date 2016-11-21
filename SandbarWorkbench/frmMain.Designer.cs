namespace SandbarWorkbench
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.createNewDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteCamerasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteCameraPictureViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sandbarSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDuplicateSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheWorkbenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssDatabasePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.experimentalToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1295, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseToolStripMenuItem,
            this.closeDatabaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.createNewDatabaseToolStripMenuItem,
            this.databaseInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.database;
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // closeDatabaseToolStripMenuItem
            // 
            this.closeDatabaseToolStripMenuItem.Name = "closeDatabaseToolStripMenuItem";
            this.closeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeDatabaseToolStripMenuItem.Text = "Close Database";
            this.closeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.closeDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // createNewDatabaseToolStripMenuItem
            // 
            this.createNewDatabaseToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.NewDatabase;
            this.createNewDatabaseToolStripMenuItem.Name = "createNewDatabaseToolStripMenuItem";
            this.createNewDatabaseToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createNewDatabaseToolStripMenuItem.Text = "Create New Database...";
            this.createNewDatabaseToolStripMenuItem.Click += new System.EventHandler(this.createNewDatabaseToolStripMenuItem_Click);
            // 
            // databaseInformationToolStripMenuItem
            // 
            this.databaseInformationToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Help;
            this.databaseInformationToolStripMenuItem.Name = "databaseInformationToolStripMenuItem";
            this.databaseInformationToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.databaseInformationToolStripMenuItem.Text = "Database Information";
            this.databaseInformationToolStripMenuItem.Click += new System.EventHandler(this.databaseInformationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteCamerasToolStripMenuItem,
            this.remoteCameraPictureViewerToolStripMenuItem,
            this.sandbarSitesToolStripMenuItem,
            this.toolStripSeparator3});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viewsToolStripMenuItem.Text = "Views";
            // 
            // remoteCamerasToolStripMenuItem
            // 
            this.remoteCamerasToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.camera_lens;
            this.remoteCamerasToolStripMenuItem.Name = "remoteCamerasToolStripMenuItem";
            this.remoteCamerasToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.remoteCamerasToolStripMenuItem.Text = "Remote Cameras";
            this.remoteCamerasToolStripMenuItem.Click += new System.EventHandler(this.LoadView);
            // 
            // remoteCameraPictureViewerToolStripMenuItem
            // 
            this.remoteCameraPictureViewerToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.camera_lens;
            this.remoteCameraPictureViewerToolStripMenuItem.Name = "remoteCameraPictureViewerToolStripMenuItem";
            this.remoteCameraPictureViewerToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.remoteCameraPictureViewerToolStripMenuItem.Text = "Remote Camera Picture Viewer";
            this.remoteCameraPictureViewerToolStripMenuItem.Click += new System.EventHandler(this.LoadView);
            // 
            // sandbarSitesToolStripMenuItem
            // 
            this.sandbarSitesToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.sandbar;
            this.sandbarSitesToolStripMenuItem.Name = "sandbarSitesToolStripMenuItem";
            this.sandbarSitesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.sandbarSitesToolStripMenuItem.Text = "Sandbar Sites";
            this.sandbarSitesToolStripMenuItem.Click += new System.EventHandler(this.LoadView);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.optionsToolStripMenuItem,
            this.syncToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Settings;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.update;
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.syncToolStripMenuItem.Text = "Synchronize Data...";
            this.syncToolStripMenuItem.Click += new System.EventHandler(this.syncToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileVerticaToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // tileVerticaToolStripMenuItem
            // 
            this.tileVerticaToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.tile;
            this.tileVerticaToolStripMenuItem.Name = "tileVerticaToolStripMenuItem";
            this.tileVerticaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticaToolStripMenuItem.Text = "Tile Vertical";
            this.tileVerticaToolStripMenuItem.Click += new System.EventHandler(this.tileVerticaToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.tile_horizontal;
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.cascade;
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // experimentalToolStripMenuItem
            // 
            this.experimentalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeDuplicateSectionsToolStripMenuItem});
            this.experimentalToolStripMenuItem.Name = "experimentalToolStripMenuItem";
            this.experimentalToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.experimentalToolStripMenuItem.Text = "Experimental";
            // 
            // removeDuplicateSectionsToolStripMenuItem
            // 
            this.removeDuplicateSectionsToolStripMenuItem.Name = "removeDuplicateSectionsToolStripMenuItem";
            this.removeDuplicateSectionsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.removeDuplicateSectionsToolStripMenuItem.Text = "Remove Duplicate Sections";
            this.removeDuplicateSectionsToolStripMenuItem.Click += new System.EventHandler(this.removeDuplicateSectionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem,
            this.aboutTheWorkbenchToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // sandbarWorkbenchOnlineHelpToolStripMenuItem
            // 
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.Help;
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem.Name = "sandbarWorkbenchOnlineHelpToolStripMenuItem";
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem.Text = "Workbench Online Help";
            this.sandbarWorkbenchOnlineHelpToolStripMenuItem.Click += new System.EventHandler(this.sandbarWorkbenchOnlineHelpToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Image = global::SandbarWorkbench.Properties.Resources.update;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            // 
            // aboutTheWorkbenchToolStripMenuItem
            // 
            this.aboutTheWorkbenchToolStripMenuItem.Name = "aboutTheWorkbenchToolStripMenuItem";
            this.aboutTheWorkbenchToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutTheWorkbenchToolStripMenuItem.Text = "About the Workbench";
            this.aboutTheWorkbenchToolStripMenuItem.Click += new System.EventHandler(this.aboutTheWorkbenchToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssDatabasePath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1295, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssDatabasePath
            // 
            this.tssDatabasePath.Name = "tssDatabasePath";
            this.tssDatabasePath.Size = new System.Drawing.Size(93, 17);
            this.tssDatabasePath.Text = "tssDatabasePath";
            this.tssDatabasePath.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 736);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandbarSitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteCamerasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandbarWorkbenchOnlineHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheWorkbenchToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssDatabasePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem experimentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDuplicateSectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteCameraPictureViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem createNewDatabaseToolStripMenuItem;
    }
}

