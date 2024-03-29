﻿namespace SandbarWorkbench.Sandbars.Analysis
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalysisConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.lstSites = new System.Windows.Forms.ListBox();
            this.grpAnalysisDateRange = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpMinSurfaceDateRange = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboInterpolationMethod = new System.Windows.Forms.ComboBox();
            this.lblInterpolationMethod = new System.Windows.Forms.Label();
            this.valOutputCellSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.valInputCellSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdCampsites = new System.Windows.Forms.Button();
            this.txtCampsites = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdBrowseMainPy = new System.Windows.Forms.Button();
            this.txtMainPy = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdBrowseResults = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdBrowseCompExtents = new System.Windows.Forms.Button();
            this.txtCompExtents = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdBrowseInputs = new System.Windows.Forms.Button();
            this.txtInputs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.chkBinned = new System.Windows.Forms.CheckBox();
            this.chkCampsiteAnalysis = new System.Windows.Forms.CheckBox();
            this.ucMinimumTo = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.ucMinimumFrom = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.ucAnalysisTo = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.ucAnalysisFrom = new SandbarWorkbench.Sandbars.Analysis.ucSurveyDatePicker();
            this.chkReuseRasters = new System.Windows.Forms.CheckBox();
            this.grpAnalysisDateRange.SuspendLayout();
            this.grpMinSurfaceDateRange.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valOutputCellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valInputCellSize)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected sandbar sites";
            // 
            // lstSites
            // 
            this.lstSites.FormattingEnabled = true;
            this.lstSites.Location = new System.Drawing.Point(16, 156);
            this.lstSites.Name = "lstSites";
            this.lstSites.Size = new System.Drawing.Size(177, 173);
            this.lstSites.TabIndex = 2;
            // 
            // grpAnalysisDateRange
            // 
            this.grpAnalysisDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnalysisDateRange.Controls.Add(this.label3);
            this.grpAnalysisDateRange.Controls.Add(this.ucAnalysisTo);
            this.grpAnalysisDateRange.Controls.Add(this.label2);
            this.grpAnalysisDateRange.Controls.Add(this.ucAnalysisFrom);
            this.grpAnalysisDateRange.Location = new System.Drawing.Point(199, 156);
            this.grpAnalysisDateRange.Name = "grpAnalysisDateRange";
            this.grpAnalysisDateRange.Size = new System.Drawing.Size(401, 83);
            this.grpAnalysisDateRange.TabIndex = 3;
            this.grpAnalysisDateRange.TabStop = false;
            this.grpAnalysisDateRange.Text = "Anaylsis Date Range";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From:";
            // 
            // grpMinSurfaceDateRange
            // 
            this.grpMinSurfaceDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMinSurfaceDateRange.Controls.Add(this.label4);
            this.grpMinSurfaceDateRange.Controls.Add(this.ucMinimumTo);
            this.grpMinSurfaceDateRange.Controls.Add(this.label5);
            this.grpMinSurfaceDateRange.Controls.Add(this.ucMinimumFrom);
            this.grpMinSurfaceDateRange.Location = new System.Drawing.Point(200, 245);
            this.grpMinSurfaceDateRange.Name = "grpMinSurfaceDateRange";
            this.grpMinSurfaceDateRange.Size = new System.Drawing.Size(400, 83);
            this.grpMinSurfaceDateRange.TabIndex = 4;
            this.grpMinSurfaceDateRange.TabStop = false;
            this.grpMinSurfaceDateRange.Text = "Minimum Surface Date Range";
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
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkReuseRasters);
            this.groupBox3.Controls.Add(this.cboInterpolationMethod);
            this.groupBox3.Controls.Add(this.lblInterpolationMethod);
            this.groupBox3.Controls.Add(this.valOutputCellSize);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.valInputCellSize);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(16, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 90);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Raster Properties";
            // 
            // cboInterpolationMethod
            // 
            this.cboInterpolationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterpolationMethod.FormattingEnabled = true;
            this.cboInterpolationMethod.Location = new System.Drawing.Point(354, 55);
            this.cboInterpolationMethod.Name = "cboInterpolationMethod";
            this.cboInterpolationMethod.Size = new System.Drawing.Size(220, 21);
            this.cboInterpolationMethod.TabIndex = 5;
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
            // valOutputCellSize
            // 
            this.valOutputCellSize.DecimalPlaces = 2;
            this.valOutputCellSize.Location = new System.Drawing.Point(146, 56);
            this.valOutputCellSize.Name = "valOutputCellSize";
            this.valOutputCellSize.Size = new System.Drawing.Size(79, 20);
            this.valOutputCellSize.TabIndex = 3;
            this.valOutputCellSize.ValueChanged += new System.EventHandler(this.CellSizeChanged);
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
            // valInputCellSize
            // 
            this.valInputCellSize.DecimalPlaces = 2;
            this.valInputCellSize.Location = new System.Drawing.Point(146, 28);
            this.valInputCellSize.Name = "valInputCellSize";
            this.valInputCellSize.Size = new System.Drawing.Size(79, 20);
            this.valInputCellSize.TabIndex = 1;
            this.valInputCellSize.ValueChanged += new System.EventHandler(this.CellSizeChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Input text file cell size";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cmdCampsites);
            this.groupBox4.Controls.Add(this.txtCampsites);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cmdBrowseMainPy);
            this.groupBox4.Controls.Add(this.txtMainPy);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmdBrowseResults);
            this.groupBox4.Controls.Add(this.txtResults);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cmdBrowseCompExtents);
            this.groupBox4.Controls.Add(this.txtCompExtents);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cmdBrowseInputs);
            this.groupBox4.Controls.Add(this.txtInputs);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(16, 431);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(584, 178);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Files and Folders";
            // 
            // cmdCampsites
            // 
            this.cmdCampsites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCampsites.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdCampsites.Location = new System.Drawing.Point(553, 82);
            this.cmdCampsites.Name = "cmdCampsites";
            this.cmdCampsites.Size = new System.Drawing.Size(23, 23);
            this.cmdCampsites.TabIndex = 8;
            this.cmdCampsites.UseVisualStyleBackColor = true;
            this.cmdCampsites.Click += new System.EventHandler(this.cmdBrowseCampsiteExtents_Click);
            // 
            // txtCampsites
            // 
            this.txtCampsites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCampsites.Location = new System.Drawing.Point(142, 83);
            this.txtCampsites.Name = "txtCampsites";
            this.txtCampsites.ReadOnly = true;
            this.txtCampsites.Size = new System.Drawing.Size(405, 20);
            this.txtCampsites.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Input campsite data";
            // 
            // cmdBrowseMainPy
            // 
            this.cmdBrowseMainPy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseMainPy.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowseMainPy.Location = new System.Drawing.Point(553, 142);
            this.cmdBrowseMainPy.Name = "cmdBrowseMainPy";
            this.cmdBrowseMainPy.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowseMainPy.TabIndex = 14;
            this.cmdBrowseMainPy.UseVisualStyleBackColor = true;
            this.cmdBrowseMainPy.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMainPy
            // 
            this.txtMainPy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainPy.Location = new System.Drawing.Point(142, 143);
            this.txtMainPy.Name = "txtMainPy";
            this.txtMainPy.ReadOnly = true;
            this.txtMainPy.Size = new System.Drawing.Size(405, 20);
            this.txtMainPy.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Sandbar analysis Main.py";
            // 
            // cmdBrowseResults
            // 
            this.cmdBrowseResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseResults.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowseResults.Location = new System.Drawing.Point(553, 112);
            this.cmdBrowseResults.Name = "cmdBrowseResults";
            this.cmdBrowseResults.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowseResults.TabIndex = 11;
            this.cmdBrowseResults.UseVisualStyleBackColor = true;
            this.cmdBrowseResults.Click += new System.EventHandler(this.cmdBrowseResults_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(142, 113);
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(405, 20);
            this.txtResults.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Model results folder";
            // 
            // cmdBrowseCompExtents
            // 
            this.cmdBrowseCompExtents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseCompExtents.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowseCompExtents.Location = new System.Drawing.Point(553, 52);
            this.cmdBrowseCompExtents.Name = "cmdBrowseCompExtents";
            this.cmdBrowseCompExtents.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowseCompExtents.TabIndex = 5;
            this.cmdBrowseCompExtents.UseVisualStyleBackColor = true;
            this.cmdBrowseCompExtents.Click += new System.EventHandler(this.cmdBrowseCompExtents_Click);
            // 
            // txtCompExtents
            // 
            this.txtCompExtents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompExtents.Location = new System.Drawing.Point(142, 53);
            this.txtCompExtents.Name = "txtCompExtents";
            this.txtCompExtents.ReadOnly = true;
            this.txtCompExtents.Size = new System.Drawing.Size(405, 20);
            this.txtCompExtents.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Computation extents";
            // 
            // cmdBrowseInputs
            // 
            this.cmdBrowseInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseInputs.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowseInputs.Location = new System.Drawing.Point(553, 22);
            this.cmdBrowseInputs.Name = "cmdBrowseInputs";
            this.cmdBrowseInputs.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowseInputs.TabIndex = 2;
            this.cmdBrowseInputs.UseVisualStyleBackColor = true;
            this.cmdBrowseInputs.Click += new System.EventHandler(this.cmdBrowseInputs_Click);
            // 
            // txtInputs
            // 
            this.txtInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputs.Location = new System.Drawing.Point(142, 23);
            this.txtInputs.Name = "txtInputs";
            this.txtInputs.ReadOnly = true;
            this.txtInputs.Size = new System.Drawing.Size(405, 20);
            this.txtInputs.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Input topo data";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(525, 618);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(444, 618);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(16, 618);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 9;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtRemarks);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtTitle);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(16, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(584, 95);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Model Run Description";
            // 
            // txtRemarks
            // 
            this.txtRemarks.AcceptsReturn = true;
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(60, 49);
            this.txtRemarks.MaxLength = 1000;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(514, 40);
            this.txtRemarks.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Remarks";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(60, 20);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(514, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Title";
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Checked = true;
            this.chkIncremental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncremental.Location = new System.Drawing.Point(16, 114);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(122, 17);
            this.chkIncremental.TabIndex = 10;
            this.chkIncremental.Text = "Incremental Analysis";
            this.chkIncremental.UseVisualStyleBackColor = true;
            // 
            // chkBinned
            // 
            this.chkBinned.AutoSize = true;
            this.chkBinned.Checked = true;
            this.chkBinned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBinned.Location = new System.Drawing.Point(156, 114);
            this.chkBinned.Name = "chkBinned";
            this.chkBinned.Size = new System.Drawing.Size(100, 17);
            this.chkBinned.TabIndex = 11;
            this.chkBinned.Text = "Binned Analysis";
            this.chkBinned.UseVisualStyleBackColor = true;
            // 
            // chkCampsiteAnalysis
            // 
            this.chkCampsiteAnalysis.AutoSize = true;
            this.chkCampsiteAnalysis.Checked = true;
            this.chkCampsiteAnalysis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCampsiteAnalysis.Location = new System.Drawing.Point(274, 114);
            this.chkCampsiteAnalysis.Name = "chkCampsiteAnalysis";
            this.chkCampsiteAnalysis.Size = new System.Drawing.Size(110, 17);
            this.chkCampsiteAnalysis.TabIndex = 12;
            this.chkCampsiteAnalysis.Text = "Campsite Analysis";
            this.chkCampsiteAnalysis.UseVisualStyleBackColor = true;
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
            // chkReuseRasters
            // 
            this.chkReuseRasters.AutoSize = true;
            this.chkReuseRasters.Location = new System.Drawing.Point(245, 30);
            this.chkReuseRasters.Name = "chkReuseRasters";
            this.chkReuseRasters.Size = new System.Drawing.Size(312, 17);
            this.chkReuseRasters.TabIndex = 6;
            this.chkReuseRasters.Text = "Reuse existing DEM rasters (excludes min and max surfaces)";
            this.chkReuseRasters.UseVisualStyleBackColor = true;
            // 
            // frmAnalysisConfig
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(610, 653);
            this.Controls.Add(this.chkCampsiteAnalysis);
            this.Controls.Add(this.chkBinned);
            this.Controls.Add(this.chkIncremental);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpMinSurfaceDateRange);
            this.Controls.Add(this.grpAnalysisDateRange);
            this.Controls.Add(this.lstSites);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(626, 636);
            this.Name = "frmAnalysisConfig";
            this.Text = "Sandbar Analysis Configuration";
            this.Load += new System.EventHandler(this.frmAnalysisConfig_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmAnalysisConfig_HelpRequested);
            this.grpAnalysisDateRange.ResumeLayout(false);
            this.grpAnalysisDateRange.PerformLayout();
            this.grpMinSurfaceDateRange.ResumeLayout(false);
            this.grpMinSurfaceDateRange.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valOutputCellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valInputCellSize)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSites;
        private ucSurveyDatePicker ucAnalysisFrom;
        private System.Windows.Forms.GroupBox grpAnalysisDateRange;
        private System.Windows.Forms.Label label3;
        private ucSurveyDatePicker ucAnalysisTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpMinSurfaceDateRange;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdBrowseResults;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdBrowseCompExtents;
        private System.Windows.Forms.TextBox txtCompExtents;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdBrowseInputs;
        private System.Windows.Forms.TextBox txtInputs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdBrowseMainPy;
        private System.Windows.Forms.TextBox txtMainPy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Button cmdCampsites;
        private System.Windows.Forms.TextBox txtCampsites;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.CheckBox chkBinned;
        private System.Windows.Forms.CheckBox chkCampsiteAnalysis;
        private System.Windows.Forms.CheckBox chkReuseRasters;
    }
}