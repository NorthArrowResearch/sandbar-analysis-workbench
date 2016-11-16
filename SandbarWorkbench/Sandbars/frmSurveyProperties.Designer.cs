namespace SandbarWorkbench.Sandbars
{
    partial class frmSurveyProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurveyProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTrips = new System.Windows.Forms.ComboBox();
            this.dtSurveyDate = new System.Windows.Forms.DateTimePicker();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colSectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSectionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInstrumentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colUncertainty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Survey date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trip";
            // 
            // cboTrips
            // 
            this.cboTrips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrips.FormattingEnabled = true;
            this.cboTrips.Location = new System.Drawing.Point(82, 13);
            this.cboTrips.Name = "cboTrips";
            this.cboTrips.Size = new System.Drawing.Size(182, 21);
            this.cboTrips.TabIndex = 1;
            this.cboTrips.SelectedIndexChanged += new System.EventHandler(this.cboTrips_SelectedIndexChanged);
            // 
            // dtSurveyDate
            // 
            this.dtSurveyDate.Location = new System.Drawing.Point(82, 43);
            this.dtSurveyDate.Name = "dtSurveyDate";
            this.dtSurveyDate.Size = new System.Drawing.Size(182, 20);
            this.dtSurveyDate.TabIndex = 3;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSectionID,
            this.colSectionType,
            this.colInstrumentType,
            this.colUncertainty});
            this.grdData.Location = new System.Drawing.Point(16, 19);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(419, 133);
            this.grdData.TabIndex = 0;
            this.grdData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdData_CellValidating);
            this.grdData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdData_DataError);
            this.grdData.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdData_RowValidating);
            // 
            // colSectionID
            // 
            this.colSectionID.DataPropertyName = "SectionID";
            this.colSectionID.HeaderText = "SectionID";
            this.colSectionID.Name = "colSectionID";
            this.colSectionID.ReadOnly = true;
            this.colSectionID.Visible = false;
            // 
            // colSectionType
            // 
            this.colSectionType.DataPropertyName = "SectionTypeID";
            this.colSectionType.HeaderText = "Section Type";
            this.colSectionType.Name = "colSectionType";
            this.colSectionType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSectionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSectionType.Width = 150;
            // 
            // colInstrumentType
            // 
            this.colInstrumentType.DataPropertyName = "InstrumentID";
            this.colInstrumentType.HeaderText = "Instrument";
            this.colInstrumentType.Name = "colInstrumentType";
            this.colInstrumentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInstrumentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInstrumentType.Width = 150;
            // 
            // colUncertainty
            // 
            this.colUncertainty.DataPropertyName = "Uncertainty";
            this.colUncertainty.HeaderText = "Uncertainty";
            this.colUncertainty.Name = "colUncertainty";
            this.colUncertainty.Width = 75;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(297, 246);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(378, 246);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 246);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 7;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grdData);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sandbars Surveyed";
            // 
            // frmSurveyProperties
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(465, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.dtSurveyDate);
            this.Controls.Add(this.cboTrips);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(481, 250);
            this.Name = "frmSurveyProperties";
            this.Text = "frmSurveyProperties";
            this.Load += new System.EventHandler(this.frmSurveyProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTrips;
        private System.Windows.Forms.DateTimePicker dtSurveyDate;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSectionID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSectionType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInstrumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUncertainty;
    }
}