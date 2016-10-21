namespace SandbarWorkbench.RemoteCameras
{
    partial class frmRemoteCameras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoteCameras));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoTRight = new System.Windows.Forms.RadioButton();
            this.rdoTLeft = new System.Windows.Forms.RadioButton();
            this.rdoTBoth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCRight = new System.Windows.Forms.RadioButton();
            this.rdoCLeft = new System.Windows.Forms.RadioButton();
            this.rdoCBoth = new System.Windows.Forms.RadioButton();
            this.grpSiteName = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.grpRiverMile = new System.Windows.Forms.GroupBox();
            this.valDownstream = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valUpstream = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRiverMile = new System.Windows.Forms.CheckBox();
            this.grdData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSiteName.SuspendLayout();
            this.grpRiverMile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDownstream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpstream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.grpSiteName);
            this.splitContainer1.Panel1.Controls.Add(this.grpRiverMile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdData);
            this.splitContainer1.Size = new System.Drawing.Size(745, 555);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoTRight);
            this.groupBox2.Controls.Add(this.rdoTLeft);
            this.groupBox2.Controls.Add(this.rdoTBoth);
            this.groupBox2.Location = new System.Drawing.Point(124, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 91);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Bank";
            // 
            // rdoTRight
            // 
            this.rdoTRight.AutoSize = true;
            this.rdoTRight.Location = new System.Drawing.Point(11, 66);
            this.rdoTRight.Name = "rdoTRight";
            this.rdoTRight.Size = new System.Drawing.Size(50, 17);
            this.rdoTRight.TabIndex = 2;
            this.rdoTRight.Text = "Right";
            this.rdoTRight.UseVisualStyleBackColor = true;
            this.rdoTRight.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoTLeft
            // 
            this.rdoTLeft.AutoSize = true;
            this.rdoTLeft.Location = new System.Drawing.Point(11, 43);
            this.rdoTLeft.Name = "rdoTLeft";
            this.rdoTLeft.Size = new System.Drawing.Size(43, 17);
            this.rdoTLeft.TabIndex = 1;
            this.rdoTLeft.Text = "Left";
            this.rdoTLeft.UseVisualStyleBackColor = true;
            this.rdoTLeft.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoTBoth
            // 
            this.rdoTBoth.AutoSize = true;
            this.rdoTBoth.Checked = true;
            this.rdoTBoth.Location = new System.Drawing.Point(11, 20);
            this.rdoTBoth.Name = "rdoTBoth";
            this.rdoTBoth.Size = new System.Drawing.Size(47, 17);
            this.rdoTBoth.TabIndex = 0;
            this.rdoTBoth.TabStop = true;
            this.rdoTBoth.Text = "Both";
            this.rdoTBoth.UseVisualStyleBackColor = true;
            this.rdoTBoth.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCRight);
            this.groupBox1.Controls.Add(this.rdoCLeft);
            this.groupBox1.Controls.Add(this.rdoCBoth);
            this.groupBox1.Location = new System.Drawing.Point(8, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Bank";
            // 
            // rdoCRight
            // 
            this.rdoCRight.AutoSize = true;
            this.rdoCRight.Location = new System.Drawing.Point(11, 66);
            this.rdoCRight.Name = "rdoCRight";
            this.rdoCRight.Size = new System.Drawing.Size(50, 17);
            this.rdoCRight.TabIndex = 2;
            this.rdoCRight.Text = "Right";
            this.rdoCRight.UseVisualStyleBackColor = true;
            this.rdoCRight.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoCLeft
            // 
            this.rdoCLeft.AutoSize = true;
            this.rdoCLeft.Location = new System.Drawing.Point(11, 43);
            this.rdoCLeft.Name = "rdoCLeft";
            this.rdoCLeft.Size = new System.Drawing.Size(43, 17);
            this.rdoCLeft.TabIndex = 1;
            this.rdoCLeft.Text = "Left";
            this.rdoCLeft.UseVisualStyleBackColor = true;
            this.rdoCLeft.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoCBoth
            // 
            this.rdoCBoth.AutoSize = true;
            this.rdoCBoth.Checked = true;
            this.rdoCBoth.Location = new System.Drawing.Point(11, 20);
            this.rdoCBoth.Name = "rdoCBoth";
            this.rdoCBoth.Size = new System.Drawing.Size(47, 17);
            this.rdoCBoth.TabIndex = 0;
            this.rdoCBoth.TabStop = true;
            this.rdoCBoth.Text = "Both";
            this.rdoCBoth.UseVisualStyleBackColor = true;
            this.rdoCBoth.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // grpSiteName
            // 
            this.grpSiteName.Controls.Add(this.txtTitle);
            this.grpSiteName.Location = new System.Drawing.Point(8, 111);
            this.grpSiteName.Name = "grpSiteName";
            this.grpSiteName.Size = new System.Drawing.Size(227, 53);
            this.grpSiteName.TabIndex = 2;
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
            this.grpRiverMile.Controls.Add(this.chkRiverMile);
            this.grpRiverMile.Location = new System.Drawing.Point(8, 5);
            this.grpRiverMile.Name = "grpRiverMile";
            this.grpRiverMile.Size = new System.Drawing.Size(227, 100);
            this.grpRiverMile.TabIndex = 1;
            this.grpRiverMile.TabStop = false;
            this.grpRiverMile.Text = "                    ";
            // 
            // valDownstream
            // 
            this.valDownstream.DecimalPlaces = 1;
            this.valDownstream.Location = new System.Drawing.Point(141, 50);
            this.valDownstream.Name = "valDownstream";
            this.valDownstream.Size = new System.Drawing.Size(75, 20);
            this.valDownstream.TabIndex = 4;
            this.valDownstream.ValueChanged += new System.EventHandler(this.FilterItemsRiverMileDownstream);
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
            this.valUpstream.Name = "valUpstream";
            this.valUpstream.Size = new System.Drawing.Size(75, 20);
            this.valUpstream.TabIndex = 2;
            this.valUpstream.ValueChanged += new System.EventHandler(this.FilterItemsRiverMileUpstream);
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
            // chkRiverMile
            // 
            this.chkRiverMile.AutoSize = true;
            this.chkRiverMile.Location = new System.Drawing.Point(16, 2);
            this.chkRiverMile.Name = "chkRiverMile";
            this.chkRiverMile.Size = new System.Drawing.Size(73, 17);
            this.chkRiverMile.TabIndex = 0;
            this.chkRiverMile.Text = "River Mile";
            this.chkRiverMile.UseVisualStyleBackColor = true;
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(492, 555);
            this.grdData.TabIndex = 0;
            // 
            // frmRemoteCameras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 555);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRemoteCameras";
            this.Text = "Remote Camera Locations";
            this.Load += new System.EventHandler(this.frmRemoteCameras_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSiteName.ResumeLayout(false);
            this.grpSiteName.PerformLayout();
            this.grpRiverMile.ResumeLayout(false);
            this.grpRiverMile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDownstream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpstream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.GroupBox grpRiverMile;
        private System.Windows.Forms.NumericUpDown valDownstream;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valUpstream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRiverMile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoCRight;
        private System.Windows.Forms.RadioButton rdoCLeft;
        private System.Windows.Forms.RadioButton rdoCBoth;
        private System.Windows.Forms.GroupBox grpSiteName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoTRight;
        private System.Windows.Forms.RadioButton rdoTLeft;
        private System.Windows.Forms.RadioButton rdoTBoth;
    }
}