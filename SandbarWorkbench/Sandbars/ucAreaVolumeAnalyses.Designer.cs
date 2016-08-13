namespace SandbarWorkbench.Sandbars
{
    partial class ucAreaVolumeAnalyses
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer_Vert = new System.Windows.Forms.SplitContainer();
            this.grpVolume = new System.Windows.Forms.GroupBox();
            this.chkVolSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.chkVolume = new System.Windows.Forms.CheckBox();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.chkAreaSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.valDisUpper = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valDisLower = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grdAnalyses = new System.Windows.Forms.DataGridView();
            this.splitContainer_Horiz = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Vert)).BeginInit();
            this.splitContainer_Vert.Panel1.SuspendLayout();
            this.splitContainer_Vert.Panel2.SuspendLayout();
            this.splitContainer_Vert.SuspendLayout();
            this.grpVolume.SuspendLayout();
            this.grpArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDisUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDisLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Horiz)).BeginInit();
            this.splitContainer_Horiz.Panel1.SuspendLayout();
            this.splitContainer_Horiz.Panel2.SuspendLayout();
            this.splitContainer_Horiz.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Vert
            // 
            this.splitContainer_Vert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Vert.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Vert.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Vert.Name = "splitContainer_Vert";
            // 
            // splitContainer_Vert.Panel1
            // 
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpVolume);
            this.splitContainer_Vert.Panel1.Controls.Add(this.grpArea);
            this.splitContainer_Vert.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer_Vert.Panel2
            // 
            this.splitContainer_Vert.Panel2.Controls.Add(this.chtData);
            this.splitContainer_Vert.Size = new System.Drawing.Size(885, 499);
            this.splitContainer_Vert.SplitterDistance = 210;
            this.splitContainer_Vert.TabIndex = 0;
            // 
            // grpVolume
            // 
            this.grpVolume.Controls.Add(this.chkVolSectionTypes);
            this.grpVolume.Controls.Add(this.chkVolume);
            this.grpVolume.Location = new System.Drawing.Point(5, 189);
            this.grpVolume.Name = "grpVolume";
            this.grpVolume.Size = new System.Drawing.Size(200, 85);
            this.grpVolume.TabIndex = 2;
            this.grpVolume.TabStop = false;
            this.grpVolume.Text = "                      ";
            // 
            // chkVolSectionTypes
            // 
            this.chkVolSectionTypes.CheckOnClick = true;
            this.chkVolSectionTypes.FormattingEnabled = true;
            this.chkVolSectionTypes.Location = new System.Drawing.Point(25, 22);
            this.chkVolSectionTypes.Name = "chkVolSectionTypes";
            this.chkVolSectionTypes.Size = new System.Drawing.Size(169, 49);
            this.chkVolSectionTypes.TabIndex = 2;
            this.chkVolSectionTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkVolSectionTypes_ItemCheck);
            // 
            // chkVolume
            // 
            this.chkVolume.AutoSize = true;
            this.chkVolume.Location = new System.Drawing.Point(11, -1);
            this.chkVolume.Name = "chkVolume";
            this.chkVolume.Size = new System.Drawing.Size(61, 17);
            this.chkVolume.TabIndex = 0;
            this.chkVolume.Text = "Volume";
            this.chkVolume.UseVisualStyleBackColor = true;
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.chkAreaSectionTypes);
            this.grpArea.Controls.Add(this.chkArea);
            this.grpArea.Location = new System.Drawing.Point(5, 97);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(200, 85);
            this.grpArea.TabIndex = 1;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "               ";
            // 
            // chkAreaSectionTypes
            // 
            this.chkAreaSectionTypes.CheckOnClick = true;
            this.chkAreaSectionTypes.FormattingEnabled = true;
            this.chkAreaSectionTypes.Location = new System.Drawing.Point(25, 22);
            this.chkAreaSectionTypes.Name = "chkAreaSectionTypes";
            this.chkAreaSectionTypes.Size = new System.Drawing.Size(169, 49);
            this.chkAreaSectionTypes.TabIndex = 1;
            this.chkAreaSectionTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkVolSectionTypes_ItemCheck);
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(11, -1);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(48, 17);
            this.chkArea.TabIndex = 0;
            this.chkArea.Text = "Area";
            this.chkArea.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.valDisUpper);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.valDisLower);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Discharge";
            // 
            // valDisUpper
            // 
            this.valDisUpper.Location = new System.Drawing.Point(74, 47);
            this.valDisUpper.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.valDisUpper.Name = "valDisUpper";
            this.valDisUpper.Size = new System.Drawing.Size(120, 20);
            this.valDisUpper.TabIndex = 3;
            this.valDisUpper.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Upper";
            // 
            // valDisLower
            // 
            this.valDisLower.Location = new System.Drawing.Point(74, 19);
            this.valDisLower.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.valDisLower.Name = "valDisLower";
            this.valDisLower.Size = new System.Drawing.Size(120, 20);
            this.valDisLower.TabIndex = 1;
            this.valDisLower.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lower";
            // 
            // chtData
            // 
            chartArea2.Name = "ChartArea1";
            this.chtData.ChartAreas.Add(chartArea2);
            this.chtData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chtData.Legends.Add(legend2);
            this.chtData.Location = new System.Drawing.Point(0, 0);
            this.chtData.Name = "chtData";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtData.Series.Add(series2);
            this.chtData.Size = new System.Drawing.Size(671, 499);
            this.chtData.TabIndex = 0;
            this.chtData.Text = "chart1";
            // 
            // grdAnalyses
            // 
            this.grdAnalyses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAnalyses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnalyses.Location = new System.Drawing.Point(0, 0);
            this.grdAnalyses.Name = "grdAnalyses";
            this.grdAnalyses.Size = new System.Drawing.Size(885, 176);
            this.grdAnalyses.TabIndex = 0;
            this.grdAnalyses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAnalyses_CellContentClick);
            this.grdAnalyses.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAnalyses_CellValueChanged);
            // 
            // splitContainer_Horiz
            // 
            this.splitContainer_Horiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Horiz.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Horiz.Name = "splitContainer_Horiz";
            this.splitContainer_Horiz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Horiz.Panel1
            // 
            this.splitContainer_Horiz.Panel1.Controls.Add(this.splitContainer_Vert);
            // 
            // splitContainer_Horiz.Panel2
            // 
            this.splitContainer_Horiz.Panel2.Controls.Add(this.grdAnalyses);
            this.splitContainer_Horiz.Size = new System.Drawing.Size(885, 679);
            this.splitContainer_Horiz.SplitterDistance = 499;
            this.splitContainer_Horiz.TabIndex = 1;
            // 
            // ucAreaVolumeAnalyses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_Horiz);
            this.Name = "ucAreaVolumeAnalyses";
            this.Size = new System.Drawing.Size(885, 679);
            this.Load += new System.EventHandler(this.ucAreaVolumeAnalyses_Load);
            this.splitContainer_Vert.Panel1.ResumeLayout(false);
            this.splitContainer_Vert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Vert)).EndInit();
            this.splitContainer_Vert.ResumeLayout(false);
            this.grpVolume.ResumeLayout(false);
            this.grpVolume.PerformLayout();
            this.grpArea.ResumeLayout(false);
            this.grpArea.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valDisUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valDisLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnalyses)).EndInit();
            this.splitContainer_Horiz.Panel1.ResumeLayout(false);
            this.splitContainer_Horiz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Horiz)).EndInit();
            this.splitContainer_Horiz.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Vert;
        private System.Windows.Forms.GroupBox grpVolume;
        private System.Windows.Forms.CheckBox chkVolume;
        private System.Windows.Forms.GroupBox grpArea;
        private System.Windows.Forms.CheckBox chkArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown valDisUpper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valDisLower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdAnalyses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtData;
        private System.Windows.Forms.SplitContainer splitContainer_Horiz;
        private System.Windows.Forms.CheckedListBox chkVolSectionTypes;
        private System.Windows.Forms.CheckedListBox chkAreaSectionTypes;
    }
}
