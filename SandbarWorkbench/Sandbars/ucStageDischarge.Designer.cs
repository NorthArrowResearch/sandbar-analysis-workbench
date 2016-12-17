namespace SandbarWorkbench.Sandbars
{
    partial class ucStageDischarge
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.txtStage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valDischarge = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSamples = new System.Windows.Forms.GroupBox();
            this.cboSamples = new System.Windows.Forms.ComboBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdExportSamples = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDischarge)).BeginInit();
            this.grpSamples.SuspendLayout();
            this.SuspendLayout();
            // 
            // chtData
            // 
            chartArea6.Name = "ChartArea1";
            this.chtData.ChartAreas.Add(chartArea6);
            this.chtData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chtData.Legends.Add(legend6);
            this.chtData.Location = new System.Drawing.Point(3, 58);
            this.chtData.Name = "chtData";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chtData.Series.Add(series6);
            this.chtData.Size = new System.Drawing.Size(633, 490);
            this.chtData.TabIndex = 0;
            this.chtData.Text = "chtData";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chtData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 551);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpSamples);
            this.panel1.Controls.Add(this.cmdExport);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 49);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.valDischarge);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculator";
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Image = global::SandbarWorkbench.Properties.Resources.export;
            this.cmdExport.Location = new System.Drawing.Point(601, 16);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(23, 23);
            this.cmdExport.TabIndex = 2;
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // txtStage
            // 
            this.txtStage.Location = new System.Drawing.Point(241, 17);
            this.txtStage.Name = "txtStage";
            this.txtStage.ReadOnly = true;
            this.txtStage.Size = new System.Drawing.Size(81, 20);
            this.txtStage.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stage (m)";
            // 
            // valDischarge
            // 
            this.valDischarge.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valDischarge.Location = new System.Drawing.Point(90, 17);
            this.valDischarge.Maximum = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.valDischarge.Name = "valDischarge";
            this.valDischarge.Size = new System.Drawing.Size(81, 20);
            this.valDischarge.TabIndex = 1;
            this.valDischarge.ValueChanged += new System.EventHandler(this.valDischarge_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discharge (cfs)";
            // 
            // grpSamples
            // 
            this.grpSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSamples.Controls.Add(this.cmdExportSamples);
            this.grpSamples.Controls.Add(this.cmdDelete);
            this.grpSamples.Controls.Add(this.cmdEdit);
            this.grpSamples.Controls.Add(this.cmdAdd);
            this.grpSamples.Controls.Add(this.cboSamples);
            this.grpSamples.Location = new System.Drawing.Point(341, 0);
            this.grpSamples.Name = "grpSamples";
            this.grpSamples.Size = new System.Drawing.Size(254, 49);
            this.grpSamples.TabIndex = 1;
            this.grpSamples.TabStop = false;
            this.grpSamples.Text = "Samples";
            // 
            // cboSamples
            // 
            this.cboSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSamples.FormattingEnabled = true;
            this.cboSamples.Location = new System.Drawing.Point(6, 17);
            this.cboSamples.Name = "cboSamples";
            this.cboSamples.Size = new System.Drawing.Size(131, 21);
            this.cboSamples.TabIndex = 0;
            this.cboSamples.SelectedIndexChanged += new System.EventHandler(this.cboSamples_SelectedIndexChanged);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.Image = global::SandbarWorkbench.Properties.Resources.Add;
            this.cmdAdd.Location = new System.Drawing.Point(172, 16);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(23, 23);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Image = global::SandbarWorkbench.Properties.Resources.edit;
            this.cmdEdit.Location = new System.Drawing.Point(199, 16);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(23, 23);
            this.cmdEdit.TabIndex = 4;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.Image = global::SandbarWorkbench.Properties.Resources.Delete;
            this.cmdDelete.Location = new System.Drawing.Point(226, 16);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(23, 23);
            this.cmdDelete.TabIndex = 0;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdExportSamples
            // 
            this.cmdExportSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExportSamples.Image = global::SandbarWorkbench.Properties.Resources.export;
            this.cmdExportSamples.Location = new System.Drawing.Point(145, 16);
            this.cmdExportSamples.Name = "cmdExportSamples";
            this.cmdExportSamples.Size = new System.Drawing.Size(23, 23);
            this.cmdExportSamples.TabIndex = 2;
            this.cmdExportSamples.UseVisualStyleBackColor = true;
            // 
            // ucStageDischarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucStageDischarge";
            this.Size = new System.Drawing.Size(639, 551);
            this.Load += new System.EventHandler(this.ucStageDischarge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDischarge)).EndInit();
            this.grpSamples.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valDischarge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.GroupBox grpSamples;
        private System.Windows.Forms.Button cmdExportSamples;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ComboBox cboSamples;
    }
}
