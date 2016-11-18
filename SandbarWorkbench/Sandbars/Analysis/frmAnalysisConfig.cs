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

            // Files and folders
            IOHelpers.IOHelpers.FillTextBoxFolder(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData, ref txtInputs);
            IOHelpers.IOHelpers.FillTextBoxFolder(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarAnalysisResults, ref txtResults);
            IOHelpers.IOHelpers.FillTextBoxFile(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile, ref txtCompExtents);
        }

        public void CellSizeChanged(object sender, EventArgs e)
        {
            lblInterpolationMethod.Enabled = valInputCellSize.Value != valOutputCellSize.Value;
            cboInterpolationMethod.Enabled = lblInterpolationMethod.Enabled;
        }

        private void cmdBrowseInputs_Click(object sender, EventArgs e)
        {
            IOHelpers.IOHelpers.BrowseFillTextBoxFolder("Input Topo Data", ref txtInputs, false);
        }

        private void cmdBrowseCompExtents_Click(object sender, EventArgs e)
        {
            IOHelpers.IOHelpers.BrowseFillTextBoxFile("Computational Extents ShapeFile", "ShapeFiles (*.shp)|*.shp", ref txtCompExtents, false);
        }

        private void cmdBrowseResults_Click(object sender, EventArgs e)
        {
            IOHelpers.IOHelpers.BrowseFillTextBoxFolder("Model Results Folder", ref txtInputs, false);
        }

        private bool ValidateForm()
        {
            if (lstSites.Items.Count < 1)
            {
                MessageBox.Show("There are no sandbar sites selected. Return to the main sandbar site data grid and select one or more sites.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!ucAnalysisFrom.ValidateForm("analysis date range"))
                return false;

            if (!ucAnalysisTo.ValidateForm("analysis date range", ucAnalysisFrom))
                return false;

            if (!ucMinimumFrom.ValidateForm("minimum surface date range"))
                return false;

            if (!ucMinimumTo.ValidateForm("minimum surface date range", ucAnalysisFrom))
                return false;

            if (valInputCellSize.Value <=0)
            {
                MessageBox.Show("The input text file cell size must be greater than zero.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                valInputCellSize.Select();
                return false;
            }
            
            if (valOutputCellSize.Value <= 0)
            {
                MessageBox.Show("The output raster cell size must be greater than zero.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                valOutputCellSize.Select();
                return false;
            }

            if (valInputCellSize.Value != valOutputCellSize.Value)
            {
                if (!(cboInterpolationMethod.SelectedItem is ListItem))
                {
                    MessageBox.Show("You must choose an interpolation method when the input and output cell sizes are different.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboInterpolationMethod.Select();
                    return false;
                }
            }
            
            if (!IOHelpers.IOHelpers.ValidateFolderTextbox("input topo data", ref txtInputs, cmdBrowseInputs))
                return false;

            if (!IOHelpers.IOHelpers.ValidateFolderTextbox("model results folder", ref txtResults, cmdBrowseResults))
                return false;

            if (!IOHelpers.IOHelpers.ValidateFileTextbox("computational extents shapefile", ref txtCompExtents, cmdBrowseCompExtents))
                return false;
            
            return true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }



        }
    }
}
