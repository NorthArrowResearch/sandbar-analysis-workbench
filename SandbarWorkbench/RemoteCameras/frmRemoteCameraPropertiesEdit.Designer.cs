namespace SandbarWorkbench.RemoteCameras
{
    partial class frmRemoteCameraPropertiesEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoteCameraPropertiesEdit));
            this.chkCurrentNSPPermit = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSandbarSite = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNAUName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSiteCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTargetRiverBank = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCameraRiverBank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valRiverMile = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHavePhotos = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtView = new System.Windows.Forms.TextBox();
            this.lblView = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBestPhotoTime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEndFilm = new System.Windows.Forms.TextBox();
            this.txtBeginFilm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEndDigital = new System.Windows.Forms.TextBox();
            this.txtBeginDigital = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboCardType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valRiverMile)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCurrentNSPPermit
            // 
            this.chkCurrentNSPPermit.AutoSize = true;
            this.chkCurrentNSPPermit.Location = new System.Drawing.Point(89, 144);
            this.chkCurrentNSPPermit.Name = "chkCurrentNSPPermit";
            this.chkCurrentNSPPermit.Size = new System.Drawing.Size(116, 17);
            this.chkCurrentNSPPermit.TabIndex = 8;
            this.chkCurrentNSPPermit.Text = "Current NPS permit";
            this.chkCurrentNSPPermit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSandbarSite);
            this.groupBox1.Controls.Add(this.chkCurrentNSPPermit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNAUName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSiteName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSiteCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 169);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site";
            // 
            // cboSandbarSite
            // 
            this.cboSandbarSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSandbarSite.FormattingEnabled = true;
            this.cboSandbarSite.Location = new System.Drawing.Point(89, 19);
            this.cboSandbarSite.Name = "cboSandbarSite";
            this.cboSandbarSite.Size = new System.Drawing.Size(398, 21);
            this.cboSandbarSite.TabIndex = 1;
            this.cboSandbarSite.SelectedIndexChanged += new System.EventHandler(this.cboSandbarSite_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sandbar site";
            // 
            // txtNAUName
            // 
            this.txtNAUName.Location = new System.Drawing.Point(89, 81);
            this.txtNAUName.MaxLength = 10;
            this.txtNAUName.Name = "txtNAUName";
            this.txtNAUName.Size = new System.Drawing.Size(398, 20);
            this.txtNAUName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "NAU name";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(89, 50);
            this.txtSiteName.MaxLength = 50;
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(398, 20);
            this.txtSiteName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Site name";
            // 
            // txtSiteCode
            // 
            this.txtSiteCode.Location = new System.Drawing.Point(89, 112);
            this.txtSiteCode.Name = "txtSiteCode";
            this.txtSiteCode.Size = new System.Drawing.Size(131, 20);
            this.txtSiteCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Site code";
            // 
            // cboTargetRiverBank
            // 
            this.cboTargetRiverBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetRiverBank.FormattingEnabled = true;
            this.cboTargetRiverBank.Location = new System.Drawing.Point(436, 21);
            this.cboTargetRiverBank.Name = "cboTargetRiverBank";
            this.cboTargetRiverBank.Size = new System.Drawing.Size(76, 21);
            this.cboTargetRiverBank.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Target river bank";
            // 
            // cboCameraRiverBank
            // 
            this.cboCameraRiverBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCameraRiverBank.FormattingEnabled = true;
            this.cboCameraRiverBank.Location = new System.Drawing.Point(259, 21);
            this.cboCameraRiverBank.Name = "cboCameraRiverBank";
            this.cboCameraRiverBank.Size = new System.Drawing.Size(76, 21);
            this.cboCameraRiverBank.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Camera river bank";
            // 
            // valRiverMile
            // 
            this.valRiverMile.DecimalPlaces = 2;
            this.valRiverMile.Location = new System.Drawing.Point(67, 21);
            this.valRiverMile.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.valRiverMile.Name = "valRiverMile";
            this.valRiverMile.Size = new System.Drawing.Size(76, 20);
            this.valRiverMile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "River mile";
            // 
            // chkHavePhotos
            // 
            this.chkHavePhotos.AutoSize = true;
            this.chkHavePhotos.Location = new System.Drawing.Point(89, 140);
            this.chkHavePhotos.Name = "chkHavePhotos";
            this.chkHavePhotos.Size = new System.Drawing.Size(93, 17);
            this.chkHavePhotos.TabIndex = 7;
            this.chkHavePhotos.Text = "Have photos?";
            this.chkHavePhotos.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(89, 23);
            this.txtSubject.MaxLength = 50;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(398, 20);
            this.txtSubject.TabIndex = 1;
            // 
            // txtView
            // 
            this.txtView.Location = new System.Drawing.Point(89, 52);
            this.txtView.MaxLength = 50;
            this.txtView.Name = "txtView";
            this.txtView.Size = new System.Drawing.Size(398, 20);
            this.txtView.TabIndex = 3;
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(54, 56);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(30, 13);
            this.lblView.TabIndex = 2;
            this.lblView.Text = "View";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Best photo time";
            // 
            // txtBestPhotoTime
            // 
            this.txtBestPhotoTime.Location = new System.Drawing.Point(89, 111);
            this.txtBestPhotoTime.MaxLength = 10;
            this.txtBestPhotoTime.Name = "txtBestPhotoTime";
            this.txtBestPhotoTime.Size = new System.Drawing.Size(100, 20);
            this.txtBestPhotoTime.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEndFilm);
            this.groupBox2.Controls.Add(this.txtBeginFilm);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(89, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 90);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Film Record";
            // 
            // txtEndFilm
            // 
            this.txtEndFilm.Location = new System.Drawing.Point(51, 58);
            this.txtEndFilm.MaxLength = 10;
            this.txtEndFilm.Name = "txtEndFilm";
            this.txtEndFilm.Size = new System.Drawing.Size(100, 20);
            this.txtEndFilm.TabIndex = 3;
            // 
            // txtBeginFilm
            // 
            this.txtBeginFilm.Location = new System.Drawing.Point(51, 27);
            this.txtBeginFilm.MaxLength = 10;
            this.txtBeginFilm.Name = "txtBeginFilm";
            this.txtBeginFilm.Size = new System.Drawing.Size(100, 20);
            this.txtBeginFilm.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "End";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Begin";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtEndDigital);
            this.groupBox3.Controls.Add(this.txtBeginDigital);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(263, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 90);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Digital Film Record";
            // 
            // txtEndDigital
            // 
            this.txtEndDigital.Location = new System.Drawing.Point(51, 58);
            this.txtEndDigital.MaxLength = 10;
            this.txtEndDigital.Name = "txtEndDigital";
            this.txtEndDigital.Size = new System.Drawing.Size(100, 20);
            this.txtEndDigital.TabIndex = 3;
            // 
            // txtBeginDigital
            // 
            this.txtBeginDigital.Location = new System.Drawing.Point(51, 27);
            this.txtBeginDigital.MaxLength = 10;
            this.txtBeginDigital.Name = "txtBeginDigital";
            this.txtBeginDigital.Size = new System.Drawing.Size(100, 20);
            this.txtBeginDigital.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "End";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Begin";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Card type";
            // 
            // cboCardType
            // 
            this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardType.FormattingEnabled = true;
            this.cboCardType.Location = new System.Drawing.Point(89, 81);
            this.cboCardType.Name = "cboCardType";
            this.cboCardType.Size = new System.Drawing.Size(398, 21);
            this.cboCardType.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkHavePhotos);
            this.groupBox4.Controls.Add(this.cboCardType);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtSubject);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.lblView);
            this.groupBox4.Controls.Add(this.txtView);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtBestPhotoTime);
            this.groupBox4.Location = new System.Drawing.Point(12, 223);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(500, 266);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Photos";
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 501);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 10;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(436, 501);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(358, 501);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmRemoteCameraPropertiesEdit
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(524, 536);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTargetRiverBank);
            this.Controls.Add(this.valRiverMile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCameraRiverBank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemoteCameraPropertiesEdit";
            this.Text = "frmRemoteCameraPropertiesEdit";
            this.Load += new System.EventHandler(this.frmRemoteCameraPropertiesEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valRiverMile)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown valRiverMile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCurrentNSPPermit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNAUName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSiteCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTargetRiverBank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCameraRiverBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkHavePhotos;
        private System.Windows.Forms.ComboBox cboSandbarSite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtView;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBestPhotoTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEndFilm;
        private System.Windows.Forms.TextBox txtBeginFilm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEndDigital;
        private System.Windows.Forms.TextBox txtBeginDigital;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCardType;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}