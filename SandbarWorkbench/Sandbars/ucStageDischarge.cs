﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SandbarWorkbench.Sandbars.StageDischarge;

namespace SandbarWorkbench.Sandbars
{
    public partial class ucStageDischarge : UserControl
    {
        public BindingList<StageDischarge.SDCurve> SDCurves { get; internal set; }
        public Dictionary<long, AnalysisBins.AnalysisBin> Bins { get; internal set; }

        private long m_site_id;
        public long SiteID
        {
            get { return m_site_id; }
            set
            {
                m_site_id = value;
                SDCurves = new BindingList<StageDischarge.SDCurve>(StageDischarge.SDCurve.Load(DBCon.ConnectionStringLocal, value));
                cboCurves.DataSource = SDCurves;
                cboCurves.DisplayMember = "DisplayTitle";
                cboCurves.ValueMember = "CurveID";
            }
        }

        public ucStageDischarge()
        {
            InitializeComponent();
        }

        private void ucStageDischarge_Load(object sender, EventArgs e)
        {
            if (SDCurves == null || SDCurves.Count < 1)
            {
                groupBox1.Visible = false;
                chtData.Visible = false;
                return;
            }

            tt.SetToolTip(valDischarge, "Specify a discharge (in cubic feet per second) to see the corresponding stage displayed in the adjacent text box and also in the chart below.");
            tt.SetToolTip(txtStage, "The stage (in meters) that corresponds with the discharge entered in the adjacent box.");
            tt.SetToolTip(cmdExport, "Export a comma separated value (CSV) text file representing points along the stage discharge curve at a user-defined interval.");

            Bins = AnalysisBins.AnalysisBin.Load(DBCon.ConnectionStringLocal, AnalysisBins.AnalysisBin.BinnedAnalysisTypes.BinnedAnalysis);
            LoadStageDischargeCurves();

            chtData.ChartAreas[0].AxisX.Title = "Discharge (cfs)";
            chtData.ChartAreas[0].AxisX.LabelStyle.Format = "#,##0";
            chtData.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chtData.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chtData.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.GhostWhite;
            chtData.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chtData.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.LightGray;

            chtData.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chtData.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chtData.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.GhostWhite;
            chtData.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chtData.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.LightGray;

            chtData.ChartAreas[0].AxisY.Title = "Stage (m)";

            // Should trigger calculation of stage.
            valDischarge.Value = 8000;
        }

        private void LoadStageDischargeCurves()
        {
            if (SDCurves == null || SDCurves.Count < 1)
                return;

            chtData.Series.Clear();

            foreach (SDCurve curve in SDCurves)
            {
                Series theSeries = chtData.Series.Add(string.Format("Stage Discharge Curve{0:d MMM yyyy}", curve.EffectiveDate));
                theSeries.ChartType = SeriesChartType.Line;

                Nullable<double> fMinStage = new Nullable<double>();
                Nullable<double> fStage;
                if (curve.HasAllValues)
                {
                    for (double fQ = 7500; fQ < 50000; fQ += 1000)
                    {
                        fStage = curve.Stage(fQ);
                        theSeries.Points.AddXY(fQ, fStage);

                        if (fMinStage.HasValue)
                            fMinStage = Math.Min(fStage.Value, fMinStage.Value);
                        else
                            fMinStage = fStage;
                    }

                    chtData.ChartAreas[0].AxisY.Minimum = Math.Floor(fMinStage.Value / 10.0) * 10;

                    Series BinSeries = chtData.Series.Add(string.Format("Analysis Bin Discharges for {0: d MMM yyyy}", curve.EffectiveDate));
                    BinSeries.ChartType = SeriesChartType.Point;
                    BinSeries.BorderWidth = 2;
                    BinSeries.MarkerSize = 10;
                    BinSeries.MarkerStyle = MarkerStyle.Circle;
                    BinSeries.Color = theSeries.Color;

                    SortedList<double, double> lBins = AnalysisBins.AnalysisBin.GetActiveBinBoundaries(Bins.Values);
                    foreach (double fBin in lBins.Values)
                    {
                        fStage = curve.Stage(fBin);
                        if (fStage.HasValue)
                        {
                            int nPoint = BinSeries.Points.AddXY(fBin, fStage);
                            BinSeries.Points[nPoint].Label = string.Format("{0:#,##0} cfs stage is {1:0.00}", fBin, fStage.Value);
                        }
                    }
                }
            }

            //LoadStageDischargeValues();
        }

        //private void LoadStageDischargeValues()
        //{
        //    if (this.SDCurve.LoadStageDischargeValues() > 0)
        //    {
        //        string sSampleSeries = "Samples";
        //        Series seriesSV = chtData.Series.FindByName(sSampleSeries);
        //        if (seriesSV == null)
        //        {
        //            seriesSV = new Series("Samples");
        //            chtData.Series.Insert(0, seriesSV); // This ensures that the sample points get displayed at the bottom of the Z order.
        //        }
        //        seriesSV.ChartType = SeriesChartType.Point;
        //        seriesSV.Color = Color.DarkGray;
        //        seriesSV.MarkerStyle = MarkerStyle.Circle;
        //        seriesSV.BorderWidth = 2;
        //        seriesSV.MarkerSize = 10;

        //        foreach (StageDischarge.SDValue aSample in SDCurve.StageDischargeSamples)
        //        {
        //            int nPoint = seriesSV.Points.AddXY(aSample.Flow, aSample.ElevationSP);
        //            seriesSV.Points[nPoint].ToolTip = aSample.ToolTip;
        //        }
        //    }
        //}

        private void valDischarge_ValueChanged(object sender, EventArgs e)
        {
            if (cboCurves.SelectedItem is SDCurve)
            {
                Nullable<double> fStage = ((SDCurve) cboCurves.SelectedItem).Stage((double)valDischarge.Value);
                if (fStage.HasValue)
                    txtStage.Text = fStage.Value.ToString("#,##0.00");
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            //SaveFileDialog frm = new SaveFileDialog();
            //frm.Title = "Export Stage Discharge Curve";
            //frm.Filter = "Comma Separated Value Files (*.csv)|*.csv";
            //frm.InitialDirectory = System.IO.Path.GetDirectoryName(DBCon.DatabasePath);
            //frm.FileName = string.Format("{0}_stage_discharge_curve", SDCurve.SiteName);

            //frm.AddExtension = true;

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    System.IO.File.WriteAllText(frm.FileName, SDCurve.CurveAsCSV(8000, 45000, 500));
            //    if (System.IO.File.Exists(frm.FileName))
            //    {
            //        System.Diagnostics.Process.Start(frm.FileName);
            //    }
            //}
        }

        private void cboCurves_SelectedIndexChanged(object sender, EventArgs e)
        {
            valDischarge_ValueChanged(sender, e);
        }

        //private void cboSamples_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string sSelectedSample = "Selected Sample";

        //    Series selSampleSeries = chtData.Series.FindByName(sSelectedSample);
        //    if (selSampleSeries == null)
        //    {
        //        selSampleSeries = new Series(sSelectedSample);
        //        chtData.Series.Insert(0, selSampleSeries);
        //        selSampleSeries.ChartType = SeriesChartType.Point;
        //        selSampleSeries.Color = Color.Red;
        //        selSampleSeries.MarkerStyle = MarkerStyle.Square;
        //        selSampleSeries.BorderWidth = 2;
        //        selSampleSeries.MarkerSize = 15;
        //    }

        //    selSampleSeries.Points.Clear();
        //    if (cboSamples.SelectedItem is StageDischarge.SDValue)
        //    {
        //        StageDischarge.SDValue sdValue = (StageDischarge.SDValue)cboSamples.SelectedItem;
        //        int ptIndex = selSampleSeries.Points.AddXY(sdValue.Flow, sdValue.ElevationSP);
        //        selSampleSeries.Points[ptIndex].ToolTip = sdValue.ToolTip;
        //    }
        //}

        //private void cmdAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        StageDischarge.frmSDSample frm = new StageDischarge.frmSDSample(SDCurve.SiteID);
        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

        //            LoadStageDischargeValues();
        //            cboSamples.DataSource = SDCurve.StageDischargeSamples;

        //            for (int i = 0; i < cboSamples.Items.Count; i++)
        //            {
        //                if (((StageDischarge.SDValue)cboSamples.Items[i]).SampleID == frm.ID)
        //                {
        //                    cboSamples.SelectedIndex = i;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandling.NARException.HandleException(ex);
        //    }
        //    finally
        //    {
        //        System.Windows.Forms.Cursor.Current = Cursors.Default;
        //    }
        //}

        //private void cmdEdit_Click(object sender, EventArgs e)
        //{
        //    if (cboSamples.SelectedItem is StageDischarge.SDValue)
        //    {
        //        try
        //        {
        //            StageDischarge.frmSDSample frm = new StageDischarge.frmSDSample((StageDischarge.SDValue)cboSamples.SelectedItem);
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

        //                LoadStageDischargeValues();
        //                cboSamples.DataSource = SDCurve.StageDischargeSamples;

        //                for (int i = 0; i < cboSamples.Items.Count; i++)
        //                {
        //                    if (((StageDischarge.SDValue)cboSamples.Items[i]).SampleID == frm.ID)
        //                    {
        //                        cboSamples.SelectedIndex = i;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ExceptionHandling.NARException.HandleException(ex);
        //        }
        //        finally
        //        {
        //            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
        //        }
        //    }

        //}

        //private void cmdDelete_Click(object sender, EventArgs e)
        //{
        //    if (cboSamples.SelectedItem is StageDischarge.SDValue)
        //    {

        //        if (MessageBox.Show("Are you sure that you want to delete the selected stage discharge sample? This action is permanent and cannot be undone!",
        //            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
        //        {
        //            return;
        //        }

        //        try
        //        {
        //            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

        //            StageDischarge.SDValue.Delete(((StageDischarge.SDValue)cboSamples.SelectedItem).SampleID);
        //            LoadStageDischargeValues();
        //            cboSamples.DataSource = SDCurve.StageDischargeSamples;
        //        }
        //        catch (Exception ex)
        //        {
        //            ExceptionHandling.NARException.HandleException(ex);
        //        }
        //        finally
        //        {
        //            System.Windows.Forms.Cursor.Current = Cursors.Default;
        //        }

        //    }
        //}

        //private void cmdExportSamples_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog frm = new SaveFileDialog();
        //    frm.Title = "Export Stage Discharge Samples";
        //    frm.Filter = "Comma Separated Value Files (*.csv)|*.csv";
        //    frm.InitialDirectory = System.IO.Path.GetDirectoryName(DBCon.DatabasePath);
        //    frm.FileName = string.Format("{0}_stage_discharge_samples", SDCurve.SiteName);

        //    frm.AddExtension = true;

        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        System.IO.File.WriteAllText(frm.FileName, SDCurve.SamplesAsCSV());
        //        if (System.IO.File.Exists(frm.FileName))
        //        {
        //            System.Diagnostics.Process.Start(frm.FileName);
        //        }
        //    }
        //}
    }
}
