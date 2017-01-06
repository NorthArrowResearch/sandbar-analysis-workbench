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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtInstallationGuid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMainPy = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.valBenchmark = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.valIncrement = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdBrowseGDALWarp = new System.Windows.Forms.Button();
            this.txtGDALWarp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdBrowseCompExtents = new System.Windows.Forms.Button();
            this.txtCompExtents = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSpatialReference = new System.Windows.Forms.TextBox();
            this.cboInterpolation = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.valDefaultOutputCellSize = new System.Windows.Forms.NumericUpDown();
            this.valDefaultInputCellSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cmdTestAWS = new System.Windows.Forms.Button();
            this.txtErrorLoggingKey = new System.Windows.Forms.TextBox();
            this.lblStreamName = new System.Windows.Forms.Label();
            this.chkAWSLoggingEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.cboAuditFieldDates = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboSurveyDates = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTripDates = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.txtPython = new System.Windows.Forms.TextBox();
            this.cmdHelp = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolderPaths)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valBenchmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valIncrement)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultOutputCellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultInputCellSize)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 355);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtInstallationGuid);
            this.tabPage1.Controls.Add(this.label9);
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
            // txtInstallationGuid
            // 
            this.txtInstallationGuid.Location = new System.Drawing.Point(122, 171);
            this.txtInstallationGuid.MaxLength = 256;
            this.txtInstallationGuid.Name = "txtInstallationGuid";
            this.txtInstallationGuid.ReadOnly = true;
            this.txtInstallationGuid.Size = new System.Drawing.Size(292, 20);
            this.txtInstallationGuid.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Installation GUID";
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
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.txtMainPy);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.valBenchmark);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.valIncrement);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.cmdBrowseGDALWarp);
            this.tabPage4.Controls.Add(this.txtGDALWarp);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.cmdBrowseCompExtents);
            this.tabPage4.Controls.Add(this.txtCompExtents);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.groupBox2);
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.button1.Location = new System.Drawing.Point(517, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMainPy
            // 
            this.txtMainPy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainPy.Location = new System.Drawing.Point(176, 172);
            this.txtMainPy.Name = "txtMainPy";
            this.txtMainPy.ReadOnly = true;
            this.txtMainPy.Size = new System.Drawing.Size(335, 20);
            this.txtMainPy.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(39, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Sandbar Analysis Main.py";
            // 
            // valBenchmark
            // 
            this.valBenchmark.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valBenchmark.Location = new System.Drawing.Point(420, 49);
            this.valBenchmark.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.valBenchmark.Name = "valBenchmark";
            this.valBenchmark.Size = new System.Drawing.Size(120, 20);
            this.valBenchmark.TabIndex = 9;
            this.valBenchmark.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(304, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Benchmark stage (cfs)";
            // 
            // valIncrement
            // 
            this.valIncrement.DecimalPlaces = 1;
            this.valIncrement.Location = new System.Drawing.Point(420, 18);
            this.valIncrement.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.valIncrement.Name = "valIncrement";
            this.valIncrement.Size = new System.Drawing.Size(120, 20);
            this.valIncrement.TabIndex = 7;
            this.valIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(300, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Elevation increment (m)";
            // 
            // cmdBrowseGDALWarp
            // 
            this.cmdBrowseGDALWarp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseGDALWarp.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowseGDALWarp.Location = new System.Drawing.Point(517, 142);
            this.cmdBrowseGDALWarp.Name = "cmdBrowseGDALWarp";
            this.cmdBrowseGDALWarp.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowseGDALWarp.TabIndex = 15;
            this.cmdBrowseGDALWarp.UseVisualStyleBackColor = true;
            this.cmdBrowseGDALWarp.Click += new System.EventHandler(this.cmdBrowseGDALWarp_Click);
            // 
            // txtGDALWarp
            // 
            this.txtGDALWarp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGDALWarp.Location = new System.Drawing.Point(176, 143);
            this.txtGDALWarp.Name = "txtGDALWarp";
            this.txtGDALWarp.ReadOnly = true;
            this.txtGDALWarp.Size = new System.Drawing.Size(335, 20);
            this.txtGDALWarp.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 147);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "GDAL warp executable";
            // 
            // cmdBrowseCompExtents
            // 
            this.cmdBrowseCompExtents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseCompExtents.Image = global::SandbarWorkbench.Properties.Resources.explorer;
            this.cmdBrowseCompExtents.Location = new System.Drawing.Point(517, 111);
            this.cmdBrowseCompExtents.Name = "cmdBrowseCompExtents";
            this.cmdBrowseCompExtents.Size = new System.Drawing.Size(23, 23);
            this.cmdBrowseCompExtents.TabIndex = 12;
            this.cmdBrowseCompExtents.UseVisualStyleBackColor = true;
            this.cmdBrowseCompExtents.Click += new System.EventHandler(this.cmdBrowseCompExtents_Click);
            // 
            // txtCompExtents
            // 
            this.txtCompExtents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompExtents.Location = new System.Drawing.Point(176, 112);
            this.txtCompExtents.Name = "txtCompExtents";
            this.txtCompExtents.ReadOnly = true;
            this.txtCompExtents.Size = new System.Drawing.Size(335, 20);
            this.txtCompExtents.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Computational extents shapefile";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtSpatialReference);
            this.groupBox2.Location = new System.Drawing.Point(6, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 121);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spatial Reference";
            // 
            // txtSpatialReference
            // 
            this.txtSpatialReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpatialReference.Location = new System.Drawing.Point(6, 19);
            this.txtSpatialReference.Multiline = true;
            this.txtSpatialReference.Name = "txtSpatialReference";
            this.txtSpatialReference.Size = new System.Drawing.Size(522, 96);
            this.txtSpatialReference.TabIndex = 0;
            // 
            // cboInterpolation
            // 
            this.cboInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterpolation.FormattingEnabled = true;
            this.cboInterpolation.Location = new System.Drawing.Point(176, 80);
            this.cboInterpolation.Name = "cboInterpolation";
            this.cboInterpolation.Size = new System.Drawing.Size(121, 21);
            this.cboInterpolation.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Default interpolation method";
            // 
            // valDefaultOutputCellSize
            // 
            this.valDefaultOutputCellSize.DecimalPlaces = 2;
            this.valDefaultOutputCellSize.Location = new System.Drawing.Point(176, 49);
            this.valDefaultOutputCellSize.Name = "valDefaultOutputCellSize";
            this.valDefaultOutputCellSize.Size = new System.Drawing.Size(120, 20);
            this.valDefaultOutputCellSize.TabIndex = 3;
            // 
            // valDefaultInputCellSize
            // 
            this.valDefaultInputCellSize.DecimalPlaces = 2;
            this.valDefaultInputCellSize.Location = new System.Drawing.Point(176, 18);
            this.valDefaultInputCellSize.Name = "valDefaultInputCellSize";
            this.valDefaultInputCellSize.Size = new System.Drawing.Size(120, 20);
            this.valDefaultInputCellSize.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Default raster output cell size (m)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Default input text file cell size (m)";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cmdTestAWS);
            this.tabPage5.Controls.Add(this.txtErrorLoggingKey);
            this.tabPage5.Controls.Add(this.lblStreamName);
            this.tabPage5.Controls.Add(this.chkAWSLoggingEnabled);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(546, 329);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Error Logging";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cmdTestAWS
            // 
            this.cmdTestAWS.Location = new System.Drawing.Point(11, 84);
            this.cmdTestAWS.Name = "cmdTestAWS";
            this.cmdTestAWS.Size = new System.Drawing.Size(156, 23);
            this.cmdTestAWS.TabIndex = 8;
            this.cmdTestAWS.Text = "Test AWS Message Log";
            this.cmdTestAWS.UseVisualStyleBackColor = true;
            this.cmdTestAWS.Visible = false;
            // 
            // txtErrorLoggingKey
            // 
            this.txtErrorLoggingKey.Location = new System.Drawing.Point(119, 36);
            this.txtErrorLoggingKey.Name = "txtErrorLoggingKey";
            this.txtErrorLoggingKey.ReadOnly = true;
            this.txtErrorLoggingKey.Size = new System.Drawing.Size(407, 20);
            this.txtErrorLoggingKey.TabIndex = 7;
            // 
            // lblStreamName
            // 
            this.lblStreamName.AutoSize = true;
            this.lblStreamName.Location = new System.Drawing.Point(29, 40);
            this.lblStreamName.Name = "lblStreamName";
            this.lblStreamName.Size = new System.Drawing.Size(86, 13);
            this.lblStreamName.TabIndex = 6;
            this.lblStreamName.Text = "Error logging key";
            // 
            // chkAWSLoggingEnabled
            // 
            this.chkAWSLoggingEnabled.AutoSize = true;
            this.chkAWSLoggingEnabled.Location = new System.Drawing.Point(11, 12);
            this.chkAWSLoggingEnabled.Name = "chkAWSLoggingEnabled";
            this.chkAWSLoggingEnabled.Size = new System.Drawing.Size(261, 17);
            this.chkAWSLoggingEnabled.TabIndex = 5;
            this.chkAWSLoggingEnabled.Text = "Share status and error information with developers";
            this.chkAWSLoggingEnabled.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.cboAuditFieldDates);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.cboSurveyDates);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.cboTripDates);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(546, 329);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Dates";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // cboAuditFieldDates
            // 
            this.cboAuditFieldDates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAuditFieldDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuditFieldDates.FormattingEnabled = true;
            this.cboAuditFieldDates.Location = new System.Drawing.Point(101, 71);
            this.cboAuditFieldDates.Name = "cboAuditFieldDates";
            this.cboAuditFieldDates.Size = new System.Drawing.Size(430, 21);
            this.cboAuditFieldDates.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Audit fields";
            // 
            // cboSurveyDates
            // 
            this.cboSurveyDates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSurveyDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSurveyDates.FormattingEnabled = true;
            this.cboSurveyDates.Location = new System.Drawing.Point(101, 44);
            this.cboSurveyDates.Name = "cboSurveyDates";
            this.cboSurveyDates.Size = new System.Drawing.Size(430, 21);
            this.cboSurveyDates.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Survey dates";
            // 
            // cboTripDates
            // 
            this.cboTripDates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTripDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTripDates.FormattingEnabled = true;
            this.cboTripDates.Location = new System.Drawing.Point(101, 17);
            this.cboTripDates.Name = "cboTripDates";
            this.cboTripDates.Size = new System.Drawing.Size(430, 21);
            this.cboTripDates.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Trip dates";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.txtPython);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(546, 329);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Python";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // txtPython
            // 
            this.txtPython.AcceptsReturn = true;
            this.txtPython.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPython.Location = new System.Drawing.Point(3, 3);
            this.txtPython.Multiline = true;
            this.txtPython.Name = "txtPython";
            this.txtPython.Size = new System.Drawing.Size(540, 323);
            this.txtPython.TabIndex = 0;
            // 
            // cmdHelp
            // 
            this.cmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdHelp.Location = new System.Drawing.Point(16, 373);
            this.cmdHelp.Name = "cmdHelp";
            this.cmdHelp.Size = new System.Drawing.Size(75, 23);
            this.cmdHelp.TabIndex = 2;
            this.cmdHelp.Text = "Help";
            this.cmdHelp.UseVisualStyleBackColor = true;
            this.cmdHelp.Click += new System.EventHandler(this.cmdHelp_Click);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 408);
            this.Controls.Add(this.cmdHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOptions";
            this.Text = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.frmOptions_HelpRequested);
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
            ((System.ComponentModel.ISupportInitialize)(this.valBenchmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valIncrement)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultOutputCellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDefaultInputCellSize)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button cmdTestAWS;
        private System.Windows.Forms.TextBox txtErrorLoggingKey;
        private System.Windows.Forms.Label lblStreamName;
        private System.Windows.Forms.CheckBox chkAWSLoggingEnabled;
        private System.Windows.Forms.TextBox txtInstallationGuid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ComboBox cboAuditFieldDates;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboSurveyDates;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTripDates;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdHelp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSpatialReference;
        private System.Windows.Forms.Button cmdBrowseCompExtents;
        private System.Windows.Forms.TextBox txtCompExtents;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button cmdBrowseGDALWarp;
        private System.Windows.Forms.TextBox txtGDALWarp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown valBenchmark;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown valIncrement;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox txtPython;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMainPy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolTip tt;
    }
}