namespace SandbarWorkbench
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo5Digits = new System.Windows.Forms.RadioButton();
            this.rdo4Digits = new System.Windows.Forms.RadioButton();
            this.cboStartupView = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLoadLastDatabase = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtMasterDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMasterPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMasterUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMasterServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdFolderPaths = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.valDefaultInputCellSize = new System.Windows.Forms.NumericUpDown();
            this.valDefaultOutputCellSize = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cboInterpolation = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolderPaths)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultInputCellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultOutputCellSize)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(491, 373);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "Close";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 355);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.cboStartupView);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkLoadLastDatabase);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start Up";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo5Digits);
            this.groupBox1.Controls.Add(this.rdo4Digits);
            this.groupBox1.Location = new System.Drawing.Point(29, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 79);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sandbar Folder Identification";
            // 
            // rdo5Digits
            // 
            this.rdo5Digits.AutoSize = true;
            this.rdo5Digits.Location = new System.Drawing.Point(27, 49);
            this.rdo5Digits.Name = "rdo5Digits";
            this.rdo5Digits.Size = new System.Drawing.Size(145, 17);
            this.rdo5Digits.TabIndex = 1;
            this.rdo5Digits.Text = "5 digit codes (e.g. 0003L)";
            this.rdo5Digits.UseVisualStyleBackColor = true;
            // 
            // rdo4Digits
            // 
            this.rdo4Digits.AutoSize = true;
            this.rdo4Digits.Checked = true;
            this.rdo4Digits.Location = new System.Drawing.Point(27, 25);
            this.rdo4Digits.Name = "rdo4Digits";
            this.rdo4Digits.Size = new System.Drawing.Size(139, 17);
            this.rdo4Digits.TabIndex = 0;
            this.rdo4Digits.TabStop = true;
            this.rdo4Digits.Text = "4 digit codes (e.g. 003L)";
            this.rdo4Digits.UseVisualStyleBackColor = true;
            // 
            // cboStartupView
            // 
            this.cboStartupView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartupView.FormattingEnabled = true;
            this.cboStartupView.Location = new System.Drawing.Point(149, 44);
            this.cboStartupView.Name = "cboStartupView";
            this.cboStartupView.Size = new System.Drawing.Size(265, 21);
            this.cboStartupView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Open view at start up";
            // 
            // chkLoadLastDatabase
            // 
            this.chkLoadLastDatabase.AutoSize = true;
            this.chkLoadLastDatabase.Location = new System.Drawing.Point(25, 16);
            this.chkLoadLastDatabase.Name = "chkLoadLastDatabase";
            this.chkLoadLastDatabase.Size = new System.Drawing.Size(116, 17);
            this.chkLoadLastDatabase.TabIndex = 0;
            this.chkLoadLastDatabase.Text = "Load last database";
            this.chkLoadLastDatabase.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtMasterDatabase);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtMasterPassword);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtMasterUserName);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtMasterServer);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Master Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtMasterDatabase
            // 
            this.txtMasterDatabase.Location = new System.Drawing.Point(98, 50);
            this.txtMasterDatabase.Name = "txtMasterDatabase";
            this.txtMasterDatabase.Size = new System.Drawing.Size(433, 20);
            this.txtMasterDatabase.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Database";
            // 
            // txtMasterPassword
            // 
            this.txtMasterPassword.Location = new System.Drawing.Point(98, 114);
            this.txtMasterPassword.Name = "txtMasterPassword";
            this.txtMasterPassword.PasswordChar = '*';
            this.txtMasterPassword.Size = new System.Drawing.Size(433, 20);
            this.txtMasterPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // txtMasterUserName
            // 
            this.txtMasterUserName.Location = new System.Drawing.Point(98, 82);
            this.txtMasterUserName.Name = "txtMasterUserName";
            this.txtMasterUserName.Size = new System.Drawing.Size(433, 20);
            this.txtMasterUserName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User name";
            // 
            // txtMasterServer
            // 
            this.txtMasterServer.Location = new System.Drawing.Point(98, 18);
            this.txtMasterServer.Name = "txtMasterServer";
            this.txtMasterServer.Size = new System.Drawing.Size(433, 20);
            this.txtMasterServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdFolderPaths);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(546, 329);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Folders";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdFolderPaths
            // 
            this.grdFolderPaths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFolderPaths.Location = new System.Drawing.Point(125, 112);
            this.grdFolderPaths.Name = "grdFolderPaths";
            this.grdFolderPaths.Size = new System.Drawing.Size(240, 150);
            this.grdFolderPaths.TabIndex = 0;
            this.grdFolderPaths.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFolderPaths_CellClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cboInterpolation);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.valDefaultOutputCellSize);
            this.tabPage4.Controls.Add(this.valDefaultInputCellSize);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(546, 329);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sandbar Analysis";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Default input text file cell size (m)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Default raster output cell size (m)";
            // 
            // valDefaultInputCellSize
            // 
            this.valDefaultInputCellSize.DecimalPlaces = 2;
            this.valDefaultInputCellSize.Location = new System.Drawing.Point(209, 18);
            this.valDefaultInputCellSize.Name = "valDefaultInputCellSize";
            this.valDefaultInputCellSize.Size = new System.Drawing.Size(120, 20);
            this.valDefaultInputCellSize.TabIndex = 2;
            // 
            // valDefaultOutputCellSize
            // 
            this.valDefaultOutputCellSize.DecimalPlaces = 2;
            this.valDefaultOutputCellSize.Location = new System.Drawing.Point(209, 47);
            this.valDefaultOutputCellSize.Name = "valDefaultOutputCellSize";
            this.valDefaultOutputCellSize.Size = new System.Drawing.Size(120, 20);
            this.valDefaultOutputCellSize.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Default interpolation method";
            // 
            // cboInterpolation
            // 
            this.cboInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterpolation.FormattingEnabled = true;
            this.cboInterpolation.Location = new System.Drawing.Point(209, 82);
            this.cboInterpolation.Name = "cboInterpolation";
            this.cboInterpolation.Size = new System.Drawing.Size(121, 21);
            this.cboInterpolation.TabIndex = 5;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 408);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOptions";
            this.Text = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFolderPaths)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultInputCellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultOutputCellSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboStartupView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLoadLastDatabase;
        private System.Windows.Forms.TextBox txtMasterDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMasterPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMasterUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMasterServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grdFolderPaths;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo5Digits;
        private System.Windows.Forms.RadioButton rdo4Digits;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown valDefaultOutputCellSize;
        private System.Windows.Forms.NumericUpDown valDefaultInputCellSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboInterpolation;
        private System.Windows.Forms.Label label8;
    }
}