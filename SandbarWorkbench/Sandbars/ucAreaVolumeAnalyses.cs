using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;

namespace SandbarWorkbench.Sandbars
{
    public partial class ucAreaVolumeAnalyses : UserControl
    {
        public SandbarSite SandbarSite { get; set; }
        private BindingList<ModelRun> ModelRuns;

        private Dictionary<long, ModelResults> ModelResultData;

        private List<string> SelectedAnalyses
        {
            get
            {
                List<string> lResult = new List<string>();
                foreach (DataGridViewRow aRow in grdAnalyses.Rows)
                {
                    if ((bool)aRow.Cells[0].Value)
                    {
                        lResult.Add(((ModelRun)aRow.DataBoundItem).RunID.ToString());
                    }
                }
                return lResult;
            }
        }

        public ucAreaVolumeAnalyses()
        {
            InitializeComponent();
        }

        private void ucAreaVolumeAnalyses_Load(object sender, EventArgs e)
        {
            if (SandbarSite == null)
                return;

            ConfigureAnalysesDataGridView();
            ModelRuns = ModelRun.Load(DBCon.ConnectionString);
            grdAnalyses.DataSource = ModelRuns;

            string sSQL = string.Format("SELECT ItemID, Title FROM LookupListItems WHERE ListID = {0}", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
            CheckedListItem.LoadComboWithListItems(ref chkAreaSectionTypes, DBCon.ConnectionString, sSQL, false);
            CheckedListItem.LoadComboWithListItems(ref chkVolSectionTypes, DBCon.ConnectionString, sSQL, false);
        }

        private void ConfigureAnalysesDataGridView()
        {
            grdAnalyses.RowHeadersVisible = false;
            grdAnalyses.AllowUserToAddRows = false;
            grdAnalyses.AllowUserToDeleteRows = false;
            grdAnalyses.AllowUserToResizeRows = false;
            grdAnalyses.AutoGenerateColumns = false;
            grdAnalyses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Helpers.DataGridViewHelpers.AddDataGridViewCheckboxColumn(ref grdAnalyses, "Visible");
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Title", "Title", true, "", DataGridViewAutoSizeColumnMode.DisplayedCells);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run On", "AddedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run By", "AddedBy", true);
        }

        private void grdAnalyses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool bDataAdded = false;
            foreach (DataGridViewRow aRow in grdAnalyses.Rows)
            {
                long nModelID = ((ModelRun)aRow.DataBoundItem).RunID;
                if ((bool)aRow.Cells[0].Value)
                {
                    if (ModelResultData == null)
                        ModelResultData = new Dictionary<long, ModelResults>();

                    if (!ModelResultData.ContainsKey(nModelID))
                    {
                        ModelResultData[nModelID] = new ModelResults(DBCon.ConnectionString, SandbarSite.SiteID, nModelID);
                        bDataAdded = true;
                    }
                }
                else
                {
                    if (ModelResultData.ContainsKey(nModelID))
                        ModelResultData.Remove(nModelID);
                }
            }

            if (bDataAdded)
                UpdateChart(null, null);
        }

        private void UpdateChart(object sender, EventArgs e)
        {
            chtData.Series.Clear();

            Nullable<double> fLowerElev = SandbarSite.SDCurve.Stage((double)valDisLower.Value);
            Nullable<double> fUpperElev = SandbarSite.SDCurve.Stage((double)valDisLower.Value);

            if (fLowerElev.HasValue)
            {
                foreach (CheckedListItem sectionTypeItem in chkAreaSectionTypes.CheckedItems)
                {
                    foreach (long nModelID in ModelResultData.Keys)
                    {
                        foreach (long nSurveyID in ModelResultData[nModelID].Surveys.Keys)
                        {


                            // See if this model result contains the section type
                            if (ModelResultData[nModelID].ContainsKey(sectionTypeItem.Value))
                            {
                                Series theSeries = chtData.Series.Add(string.Format("{0} - {1}", nModelID, sectionTypeItem.Value));
                                foreach (double fElevation in AnalystResultData[nModelID].dResults.Keys)
                                {
                                    if (fElevation > fLowerElev)
                                    {
                                        theSeries.Points.AddXY(, AnalystResultData[nModelID].dResults[sectionTypeItem.Value][])
                                    }
                                }

                            }
                        }
                    }
                }

            }



        }
    }
}
