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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.grpRiverMile = new System.Windows.Forms.GroupBox();
            this.valDownstream = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valUpstream = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRiverMile = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.grpSiteName = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBoth = new System.Windows.Forms.RadioButton();
            this.Left = new System.Windows.Forms.RadioButton();
            this.rdoRight = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.grpRiverMile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDownstream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpstream)).BeginInit();
            this.grpSiteName.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.grpSiteName);
            this.splitContainer1.Panel1.Controls.Add(this.grpRiverMile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdData);
            this.splitContainer1.Size = new System.Drawing.Size(745, 555);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(493, 555);
            this.grdData.TabIndex = 0;
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
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(11, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(205, 20);
            this.txtTitle.TabIndex = 0;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoRight);
            this.groupBox1.Controls.Add(this.Left);
            this.groupBox1.Controls.Add(this.rdoBoth);
            this.groupBox1.Location = new System.Drawing.Point(8, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "River Bank";
            // 
            // rdoBoth
            // 
            this.rdoBoth.AutoSize = true;
            this.rdoBoth.Checked = true;
            this.rdoBoth.Location = new System.Drawing.Point(11, 20);
            this.rdoBoth.Name = "rdoBoth";
            this.rdoBoth.Size = new System.Drawing.Size(47, 17);
            this.rdoBoth.TabIndex = 0;
            this.rdoBoth.TabStop = true;
            this.rdoBoth.Text = "Both";
            this.rdoBoth.UseVisualStyleBackColor = true;
            // 
            // Left
            // 
            this.Left.AutoSize = true;
            this.Left.Location = new System.Drawing.Point(11, 43);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(43, 17);
            this.Left.TabIndex = 1;
            this.Left.Text = "Left";
            this.Left.UseVisualStyleBackColor = true;
            // 
            // rdoRight
            // 
            this.rdoRight.AutoSize = true;
            this.rdoRight.Location = new System.Drawing.Point(11, 66);
            this.rdoRight.Name = "rdoRight";
            this.rdoRight.Size = new System.Drawing.Size(50, 17);
            this.rdoRight.TabIndex = 2;
            this.rdoRight.Text = "Right";
            this.rdoRight.UseVisualStyleBackColor = true;
            // 
            // frmRemoteCameras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 555);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRemoteCameras";
            this.Text = "frmRemoteCameras";
            this.Load += new System.EventHandler(this.frmRemoteCameras_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.grpRiverMile.ResumeLayout(false);
            this.grpRiverMile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDownstream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valUpstream)).EndInit();
            this.grpSiteName.ResumeLayout(false);
            this.grpSiteName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.RadioButton rdoRight;
        private System.Windows.Forms.RadioButton Left;
        private System.Windows.Forms.RadioButton rdoBoth;
        private System.Windows.Forms.GroupBox grpSiteName;
        private System.Windows.Forms.TextBox txtTitle;
    }
}