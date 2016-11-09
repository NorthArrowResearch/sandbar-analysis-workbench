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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTrips = new System.Windows.Forms.ComboBox();
            this.dtSurveyDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.cmdOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.colSectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSectionTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colUncertainty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Survey date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trip";
            // 
            // cboTrips
            // 
            this.cboTrips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrips.FormattingEnabled = true;
            this.cboTrips.Location = new System.Drawing.Point(82, 43);
            this.cboTrips.Name = "cboTrips";
            this.cboTrips.Size = new System.Drawing.Size(215, 21);
            this.cboTrips.TabIndex = 2;
            // 
            // dtSurveyDate
            // 
            this.dtSurveyDate.Location = new System.Drawing.Point(82, 13);
            this.dtSurveyDate.Name = "dtSurveyDate";
            this.dtSurveyDate.Size = new System.Drawing.Size(215, 20);
            this.dtSurveyDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sections Surveyed";
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSectionID,
            this.colSectionTypeID,
            this.colUncertainty});
            this.grdData.Location = new System.Drawing.Point(12, 96);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(285, 133);
            this.grdData.TabIndex = 5;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(141, 235);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(222, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(12, 235);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 8;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            // 
            // colSectionID
            // 
            this.colSectionID.HeaderText = "SectionID";
            this.colSectionID.Name = "colSectionID";
            this.colSectionID.ReadOnly = true;
            this.colSectionID.Visible = false;
            // 
            // colSectionTypeID
            // 
            this.colSectionTypeID.HeaderText = "Section Type";
            this.colSectionTypeID.Name = "colSectionTypeID";
            this.colSectionTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSectionTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colUncertainty
            // 
            this.colUncertainty.HeaderText = "Uncertainty";
            this.colUncertainty.Name = "colUncertainty";
            // 
            // frmSurveyProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 270);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtSurveyDate);
            this.Controls.Add(this.cboTrips);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSurveyProperties";
            this.Text = "frmSurveyProperties";
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTrips;
        private System.Windows.Forms.DateTimePicker dtSurveyDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSectionID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSectionTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUncertainty;
    }
}