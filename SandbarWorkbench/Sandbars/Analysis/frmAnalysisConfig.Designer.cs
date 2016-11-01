namespace SandbarWorkbench.Sandbars.Analysis
{
    partial class frmAnalysisConfig
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
            this.lstSites = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.valInputCellSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.valOutputCellSize = new System.Windows.Forms.NumericUpDown();
            this.lblInterpolationMethod = new System.Windows.Forms.Label();
            this.cboInterpolationMethod = new System.Windows.Forms.ComboBox();
            this.ucMinimumTo = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.ucMinimumFrom = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.ucAnalysisTo = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.ucAnalysisFrom = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valInputCellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valOutputCellSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected sandbar sites";
            // 
            // lstSites
            // 
            this.lstSites.FormattingEnabled = true;
            this.lstSites.Location = new System.Drawing.Point(16, 30);
            this.lstSites.Name = "lstSites";
            this.lstSites.Size = new System.Drawing.Size(545, 225);
            this.lstSites.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ucAnalysisTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ucAnalysisFrom);
            this.groupBox1.Location = new System.Drawing.Point(16, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anaylsis Date Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "To:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ucMinimumTo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ucMinimumFrom);
            this.groupBox2.Location = new System.Drawing.Point(16, 353);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 83);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Minimum Surface Date Range";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "From:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboInterpolationMethod);
            this.groupBox3.Controls.Add(this.lblInterpolationMethod);
            this.groupBox3.Controls.Add(this.valOutputCellSize);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.valInputCellSize);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(16, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(545, 90);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Raster Properties";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Input text file cell size";
            // 
            // valInputCellSize
            // 
            this.valInputCellSize.DecimalPlaces = 2;
            this.valInputCellSize.Location = new System.Drawing.Point(146, 27);
            this.valInputCellSize.Name = "valInputCellSize";
            this.valInputCellSize.Size = new System.Drawing.Size(79, 20);
            this.valInputCellSize.TabIndex = 1;
            this.valInputCellSize.ValueChanged += new System.EventHandler(this.CellSizeChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Output raster cell size";
            // 
            // valOutputCellSize
            // 
            this.valOutputCellSize.DecimalPlaces = 2;
            this.valOutputCellSize.Location = new System.Drawing.Point(146, 56);
            this.valOutputCellSize.Name = "valOutputCellSize";
            this.valOutputCellSize.Size = new System.Drawing.Size(79, 20);
            this.valOutputCellSize.TabIndex = 3;
            this.valOutputCellSize.ValueChanged += new System.EventHandler(this.CellSizeChanged);
            // 
            // lblInterpolationMethod
            // 
            this.lblInterpolationMethod.AutoSize = true;
            this.lblInterpolationMethod.Location = new System.Drawing.Point(245, 58);
            this.lblInterpolationMethod.Name = "lblInterpolationMethod";
            this.lblInterpolationMethod.Size = new System.Drawing.Size(103, 13);
            this.lblInterpolationMethod.TabIndex = 4;
            this.lblInterpolationMethod.Text = "Interpolation method";
            // 
            // cboInterpolationMethod
            // 
            this.cboInterpolationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterpolationMethod.FormattingEnabled = true;
            this.cboInterpolationMethod.Location = new System.Drawing.Point(354, 55);
            this.cboInterpolationMethod.Name = "cboInterpolationMethod";
            this.cboInterpolationMethod.Size = new System.Drawing.Size(185, 21);
            this.cboInterpolationMethod.TabIndex = 5;
            // 
            // ucMinimumTo
            // 
            this.ucMinimumTo.DefaultSelection = SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker.DefaultSelectionType.Latest;
            this.ucMinimumTo.Location = new System.Drawing.Point(76, 49);
            this.ucMinimumTo.Name = "ucMinimumTo";
            this.ucMinimumTo.Size = new System.Drawing.Size(315, 21);
            this.ucMinimumTo.SurveyDates = null;
            this.ucMinimumTo.TabIndex = 4;
            // 
            // ucMinimumFrom
            // 
            this.ucMinimumFrom.DefaultSelection = SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker.DefaultSelectionType.Latest;
            this.ucMinimumFrom.Location = new System.Drawing.Point(76, 22);
            this.ucMinimumFrom.Name = "ucMinimumFrom";
            this.ucMinimumFrom.Size = new System.Drawing.Size(315, 21);
            this.ucMinimumFrom.SurveyDates = null;
            this.ucMinimumFrom.TabIndex = 2;
            // 
            // ucAnalysisTo
            // 
            this.ucAnalysisTo.DefaultSelection = SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker.DefaultSelectionType.Latest;
            this.ucAnalysisTo.Location = new System.Drawing.Point(76, 49);
            this.ucAnalysisTo.Name = "ucAnalysisTo";
            this.ucAnalysisTo.Size = new System.Drawing.Size(315, 21);
            this.ucAnalysisTo.SurveyDates = null;
            this.ucAnalysisTo.TabIndex = 4;
            // 
            // ucAnalysisFrom
            // 
            this.ucAnalysisFrom.DefaultSelection = SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker.DefaultSelectionType.Latest;
            this.ucAnalysisFrom.Location = new System.Drawing.Point(76, 22);
            this.ucAnalysisFrom.Name = "ucAnalysisFrom";
            this.ucAnalysisFrom.Size = new System.Drawing.Size(315, 21);
            this.ucAnalysisFrom.SurveyDates = null;
            this.ucAnalysisFrom.TabIndex = 2;
            // 
            // frmAnalysisConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 589);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstSites);
            this.Controls.Add(this.label1);
            this.Name = "frmAnalysisConfig";
            this.Text = "Sandbar Analysis Configuration";
            this.Load += new System.EventHandler(this.frmAnalysisConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valInputCellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valOutputCellSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSites;
        private ucSurveyDatePicker ucAnalysisFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private ucSurveyDatePicker ucAnalysisTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private ucSurveyDatePicker ucMinimumTo;
        private System.Windows.Forms.Label label5;
        private ucSurveyDatePicker ucMinimumFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboInterpolationMethod;
        private System.Windows.Forms.Label lblInterpolationMethod;
        private System.Windows.Forms.NumericUpDown valOutputCellSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown valInputCellSize;
        private System.Windows.Forms.Label label6;
    }
}