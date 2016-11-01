using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars.Analysis
{
    public partial class frmAnalysisConfig : Form
    {
        private List<SandbarSite> SitesToProcess { get; set; }

        public frmAnalysisConfig(List<SandbarSite> lSites)
        {
            InitializeComponent();
            SitesToProcess = lSites;

            // Unique dates across all sites
            List<DateTime> lDates = new List<DateTime>();
            foreach (SandbarSite aSite in SitesToProcess)
            {
                lDates = lDates.Union<DateTime>(aSite.Surveys.Select<SandbarSurvey, DateTime>(x => x.SurveyDate).ToList<DateTime>()).ToList<DateTime>();
            }

            ucAnalysisFrom.SurveyDates = lDates;
            ucAnalysisTo.SurveyDates = lDates;
            ucMinimumFrom.SurveyDates = lDates;
            ucMinimumTo.SurveyDates = lDates;

            ucAnalysisFrom.DefaultSelection = ucSurveyDatePicker.DefaultSelectionType.Earliest;
            ucMinimumFrom.DefaultSelection = ucSurveyDatePicker.DefaultSelectionType.Earliest;
        }

        private void frmAnalysisConfig_Load(object sender, EventArgs e)
        {
            lstSites.DataSource = SitesToProcess.Select(x => x.SiteCode5).ToList<string>();

            long nDefaultInterpolation = SandbarWorkbench.Properties.Settings.Default.Default_Interpolation;
            ListItem.LoadComboWithListItems(ref cboInterpolationMethod, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 8 ORDER BY Title", nDefaultInterpolation);

            valInputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize;
            valOutputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize;
        }

        public void CellSizeChanged(object sender, EventArgs e)
        {
            lblInterpolationMethod.Enabled = valInputCellSize.Value != valOutputCellSize.Value;
            cboInterpolationMethod.Enabled = lblInterpolationMethod.Enabled;
        }
    }
}
