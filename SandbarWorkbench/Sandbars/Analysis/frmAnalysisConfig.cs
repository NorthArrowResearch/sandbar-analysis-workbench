using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using System.Diagnostics;


namespace SandbarWorkbench.Sandbars.Analysis
{
    public partial class frmAnalysisConfig : Form
    {
        private List<SandbarSite> SitesToProcess { get; set; }
        StringBuilder outputStringBuilder = new StringBuilder();
        StringBuilder errorStringBuilder = new StringBuilder();

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
            ConfigureToolTips();
            txtTitle.Text = string.Format("Run by {0} on {1} with {2} site{3}", Environment.UserName, Environment.MachineName, SitesToProcess.Count, SitesToProcess.Count > 1 ? "s" : "");
            lstSites.DataSource = SitesToProcess.Select(x => x.SiteCode5).ToList<string>();

            long nDefaultInterpolation = SandbarWorkbench.Properties.Settings.Default.Default_Interpolation;
            ListItem.LoadComboWithListItems(ref cboInterpolationMethod, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 8 ORDER BY Title", nDefaultInterpolation);

            valInputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize;
            valOutputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize;

            // Files and folders
            Helpers.IOHelpers.FillTextBoxFolder(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData, ref txtInputs);
            Helpers.IOHelpers.FillTextBoxFolder(Properties.Settings.Default.CampsitesFolder, ref txtCampsites);
            Helpers.IOHelpers.FillTextBoxFolder(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarAnalysisResults, ref txtResults);
            Helpers.IOHelpers.FillTextBoxFile(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile, ref txtCompExtents);
            Helpers.IOHelpers.FillTextBoxFile(SandbarWorkbench.Properties.Settings.Default.SandbarAnalysisMainPy, ref txtMainPy);
        }

        private void ConfigureToolTips()
        {
            tt.SetToolTip(txtTitle, "Title for this sandbar analysis model run. Max 50 characters.");
            tt.SetToolTip(txtRemarks, "Optional, miscellaneous remarks and comments about this sandbar analysis model run. Max 1000 characters.");
            tt.SetToolTip(lstSites, "The list of sandbar sites that will be included in this model run. To change this list, cancel this form and select a different set on the main list of sandbar sites.");
            tt.SetToolTip(grpAnalysisDateRange, "The date range for surveys (across all the sites listed) that will be included in the sandbar analysis. The from and to dates are included in the analysis.");
            tt.SetToolTip(grpMinSurfaceDateRange, "The date range for surveys (across all the sites listed) that will be included in the minimum surface calculation. The from and to dates are included in the analysis.");
            tt.SetToolTip(valInputCellSize, "The point spacing, in meters, of the points contained in the raw input CSV text files.");
            tt.SetToolTip(valOutputCellSize, "The cell size, in meters of the rasters generated from the raw input CSV text files.");
            tt.SetToolTip(cboInterpolationMethod, "If the input point spacing and the output raster cell size are different then the selected inerpolation method determines how the data are resampled.");
            tt.SetToolTip(txtInputs, "The top level folder containing the input raw point text files. Typically ends with \"corgrids\". Defaults to the setting defined on the Options form.");
            tt.SetToolTip(txtCompExtents, "The ShapeFile that contains the computational extent polygons for all sandbar sites.");
            tt.SetToolTip(txtResults, "The top level folder where the sandbar analysis results are saved. A separate time-stamped folder will be created inside the specified folder for this individual model run.");
            tt.SetToolTip(txtMainPy, "The location of the sandbar analysis Python main.py script file. This file is not included with the Workbench and needs to be obtained separately. See online help for details.");
        }

        public void CellSizeChanged(object sender, EventArgs e)
        {
            lblInterpolationMethod.Enabled = valInputCellSize.Value != valOutputCellSize.Value;
            cboInterpolationMethod.Enabled = lblInterpolationMethod.Enabled;
        }

        private void cmdBrowseInputs_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFolder("Input Topo Data", ref txtInputs, false);
        }

        private void cmdBrowseCompExtents_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFile("Computational Extents ShapeFile", "ShapeFiles (*.shp)|*.shp", ref txtCompExtents, false);
        }

        private void cmdBrowseCampsiteExtents_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFolder("Campsite Extents ShapeFile", ref txtCampsites, false);
        }

        private void cmdBrowseResults_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFolder("Model Results Folder", ref txtResults, false);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("You must provide a title for this model run.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Select();
                return false;
            }

            if (lstSites.Items.Count < 1)
            {
                MessageBox.Show("There are no sandbar sites selected. Return to the main sandbar site data grid and select one or more sites.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.SpatialReference))
            {
                MessageBox.Show("There is no spatial reference defined. Cancel this form and go to Tools > Options to define the spatial reference for sandbar analyses.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.GDALWarp))
            {
                MessageBox.Show("You must specify the path to the GDAL Warp utility. Cancel this form and go to Tools > Options to define the path to the GDAL Warp executable.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (valInputCellSize.Value <= 0)
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

            if (!Helpers.IOHelpers.ValidateFolderTextbox("input topo data", ref txtInputs, cmdBrowseInputs))
                return false;

            if (!Helpers.IOHelpers.ValidateFolderTextbox("model results folder", ref txtResults, cmdBrowseResults))
                return false;

            if (!Helpers.IOHelpers.ValidateFileTextbox("computational extents shapefile", ref txtCompExtents, cmdBrowseCompExtents))
                return false;

            if (!Helpers.IOHelpers.ValidateFileTextbox("sandbar analysis Main.py python file", ref txtMainPy, cmdBrowseMainPy))
                return false;

            if (!chkBinned.Checked && !chkIncremental.Checked && !chkCampsiteAnalysis.Checked)
            {
                MessageBox.Show("You must choose to perform one of the three analysis types, incremental, binned or campsite.", Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            System.IO.FileInfo fiBinned = null;
            System.IO.FileInfo fiIncremental = null;
            System.IO.FileInfo fiCampsites = null;
            System.IO.FileInfo fiLog = null;

            try
            {
                System.IO.FileInfo fiInputs = GenerateInputXML(out fiBinned, out fiIncremental, out fiCampsites, out fiLog);

                var outputFrm = new frmRunOutput();
                outputFrm.Show(this); // if you need non-modal window

                try
                {
                    List<string> lCommands = SandbarWorkbench.Properties.Settings.Default.PythonConfig.Split('\n').ToList<string>(); // sSetup.Split('&').toList<string>();
                    lCommands.Insert(0, "echo off");
                    lCommands.Add("echo off");
                    lCommands.Add(string.Format("python {0} {1}", txtMainPy.Text, fiInputs.FullName));
                    // Hack: The first exist drops out of Python environment
                    // Second exit drops out of the batch terminal environment
                    lCommands.Add("exit");
                    lCommands.Add("exit");

                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = true;
                    psi.RedirectStandardInput = true;
                    psi.RedirectStandardOutput = true;
                    psi.RedirectStandardError = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;

                    System.Diagnostics.Process proc = new Process();
                    proc.StartInfo = psi;
                    proc.EnableRaisingEvents = false;
                    proc.OutputDataReceived += (innerSender, eventArgs) =>
                    {
                        outputFrm.AppendOutput(eventArgs.Data, Color.Black);
                        outputStringBuilder.AppendLine(eventArgs.Data);
                        Console.WriteLine("StdOut::: " + eventArgs.Data);
                    };
                    proc.ErrorDataReceived += (innerSender, eventArgs) =>
                    {
                        outputFrm.AppendOutput(eventArgs.Data, Color.Red);
                        errorStringBuilder.AppendLine(eventArgs.Data);
                        Console.WriteLine("StdErr::: " + eventArgs.Data);
                    };

                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.BeginErrorReadLine();

                    int cmdIndex = 0;
                    while (!proc.HasExited)
                    {
                        if (proc.Threads.Count == 1 && cmdIndex < lCommands.Count)
                        {
                            string sCmd = lCommands[cmdIndex].Trim();
                            if (!string.IsNullOrEmpty(sCmd))
                            {
                                Debug.Print(sCmd);
                                proc.StandardInput.WriteLine(sCmd);
                            }
                            cmdIndex++;
                        }
                        Application.DoEvents();
                    }

                    string sMessage = string.Empty;
                    bool bIncrementalResults = fiIncremental != null && fiIncremental.Exists;
                    bool bBinnedResults = fiBinned != null && fiBinned.Exists;
                    bool bCampsiteResults = fiCampsites != null && fiCampsites.Exists;
                    if (bIncrementalResults || bBinnedResults || bCampsiteResults)
                    {
                        ResultsScavenger scav = new ResultsScavenger(DBCon.ConnectionStringLocal);
                        scav.Run(txtTitle.Text, txtRemarks.Text, fiInputs, fiIncremental, fiBinned, fiCampsites);

                        sMessage = string.Format("Model Run ID {0} inserted into the local database with {1} incremental and {2} binned analysis results.", scav.ModelRunID, scav.IncrementalResults, scav.BinnedResults);
                    }
                    else
                        sMessage = "The process completed but one or both of the incremental and binned result files were not found.";

                    outputFrm.CloseWithOk(sMessage);

                    if (proc.ExitCode != 0)
                    {
                        Exception ex = new Exception("Python Script Error");
                        //ex.Data["Python Script path"] = txtPyGUT.Text;
                        ex.Data["Params"] = psi.Arguments;
                        //ex.Data["Standard Error"] = stdErr.ReadToEnd();
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    //outputFrm.CloseWithOk("Caught Exception");
                    ExceptionHandling.NARException.HandleException(ex, false);
                    this.DialogResult = DialogResult.None;
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
                this.DialogResult = DialogResult.None;
            }
        }

        private System.IO.FileInfo GenerateInputXML(out System.IO.FileInfo fiBinned, out System.IO.FileInfo fiIncremental, out System.IO.FileInfo fiCampsites, out System.IO.FileInfo fiLog)
        {
            Dictionary<long, string> dSectionTypes = LoadSectionTypes();

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode nodTopLevel = xmlDoc.CreateElement("SandbarAnalysis");
            xmlDoc.AppendChild(nodTopLevel);

            //Create an XML declaration. 
            XmlDeclaration xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.InsertBefore(xmldecl, nodTopLevel);


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Metadata
            XmlNode nodMetaData = xmlDoc.CreateElement("MetaData");
            nodTopLevel.AppendChild(nodMetaData);

            XmlNode nodMeta = xmlDoc.CreateElement("Meta");
            XmlAttribute attName = xmlDoc.CreateAttribute("Name");
            attName.Value = "date";
            nodMeta.Attributes.Append(attName);
            nodMeta.InnerText = DateTime.Now.ToString("o");
            nodMetaData.AppendChild(nodMeta);

            nodMeta = xmlDoc.CreateElement("Meta");
            attName = xmlDoc.CreateAttribute("Name");
            attName.Value = "system";
            nodMeta.Attributes.Append(attName);
            nodMeta.InnerText = Environment.MachineName;
            nodMetaData.AppendChild(nodMeta);

            nodMeta = xmlDoc.CreateElement("Meta");
            attName = xmlDoc.CreateAttribute("Name");
            attName.Value = "user";
            nodMeta.Attributes.Append(attName);
            nodMeta.InnerText = Environment.UserName;
            nodMetaData.AppendChild(nodMeta);

            nodMeta = xmlDoc.CreateElement("Meta");
            attName = xmlDoc.CreateAttribute("Name");
            attName.Value = "version";
            nodMeta.Attributes.Append(attName);
            nodMeta.InnerText = 1.ToString();
            nodMetaData.AppendChild(nodMeta);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Outputs

            XmlNode nodOutputs = xmlDoc.CreateElement("Outputs");
            nodTopLevel.AppendChild(nodOutputs);

            string sAnalysisFolder = System.IO.Path.Combine(txtResults.Text, string.Format("ModelRun_{0:yyyyMMdd_HHmmss}", DateTime.Now));

            string sLogFile = System.IO.Path.Combine(sAnalysisFolder, "log.xml");
            fiLog = new System.IO.FileInfo(sLogFile);
            XmlNode nodLog = xmlDoc.CreateElement("Log");
            nodLog.InnerText = System.IO.Path.GetFileName(sLogFile);
            nodOutputs.AppendChild(nodLog);

            XmlNode nodBinned = xmlDoc.CreateElement("BinnedResults");
            fiBinned = null;
            if (chkBinned.Checked)
            {
                fiBinned = new System.IO.FileInfo(System.IO.Path.Combine(sAnalysisFolder, "results_binned.csv"));
                nodBinned.InnerText = System.IO.Path.GetFileName(fiBinned.FullName);
            }
            nodOutputs.AppendChild(nodBinned);

            XmlNode nodIncremental = xmlDoc.CreateElement("IncrementalResults");
            fiIncremental = null;
            if (chkIncremental.Checked)
            {
                fiIncremental = new System.IO.FileInfo(System.IO.Path.Combine(sAnalysisFolder, "results_incremental.csv"));
                nodIncremental.InnerText = System.IO.Path.GetFileName(fiIncremental.FullName);
            }
            nodOutputs.AppendChild(nodIncremental);

            XmlNode nodCampsites = xmlDoc.CreateElement("CampsiteResults");
            fiCampsites = null;
            if (chkCampsiteAnalysis.Checked)
            {
                fiCampsites = new System.IO.FileInfo(System.IO.Path.Combine(sAnalysisFolder, "results_campsites.csv"));
                nodCampsites.InnerText = System.IO.Path.GetFileName(fiCampsites.FullName);
            }
            nodOutputs.AppendChild(nodCampsites);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Inputs

            XmlNode nodInputs = xmlDoc.CreateElement("Inputs");
            nodTopLevel.AppendChild(nodInputs);

            XmlNode nodTopLevelFolder = xmlDoc.CreateElement("TopLevelFolder");
            nodTopLevelFolder.InnerText = txtInputs.Text;
            nodInputs.AppendChild(nodTopLevelFolder);

            XmlNode nodCompExtents = xmlDoc.CreateElement("CompExtentShpPath");
            nodCompExtents.InnerText = txtCompExtents.Text;
            nodInputs.AppendChild(nodCompExtents);

            XmlNode nodCampsiteExtents = xmlDoc.CreateElement("CampsiteFolder");
            nodCampsiteExtents.InnerText = txtCampsites.Text;
            nodInputs.AppendChild(nodCampsiteExtents);

            XmlNode nodSRS = xmlDoc.CreateElement("srsEPSG");
            nodSRS.InnerText = SandbarWorkbench.Properties.Settings.Default.SpatialReference;
            nodInputs.AppendChild(nodSRS);

            XmlNode nodWarp = xmlDoc.CreateElement("GDALWarp");
            nodWarp.InnerText = SandbarWorkbench.Properties.Settings.Default.GDALWarp;
            nodInputs.AppendChild(nodWarp);

            XmlNode nodInCellSize = xmlDoc.CreateElement("CSVCellSize");
            nodInCellSize.InnerText = valInputCellSize.Value.ToString();
            nodInputs.AppendChild(nodInCellSize);

            XmlNode nodOutCellSize = xmlDoc.CreateElement("RasterCellSize");
            nodOutCellSize.InnerText = valOutputCellSize.Value.ToString();
            nodInputs.AppendChild(nodOutCellSize);

            XmlNode nodIncrement = xmlDoc.CreateElement("ElevationIncrement");
            nodIncrement.InnerText = SandbarWorkbench.Properties.Settings.Default.ElevationIncrement.ToString();
            nodInputs.AppendChild(nodIncrement);

            XmlNode nodBenchmark = xmlDoc.CreateElement("ElevationBenchmark");
            nodBenchmark.InnerText = SandbarWorkbench.Properties.Settings.Default.BenchmarkStage.ToString();
            nodInputs.AppendChild(nodBenchmark);

            XmlNode nodResample = xmlDoc.CreateElement("ResampleMethod");
            nodResample.InnerText = cboInterpolationMethod.Text.ToLower(); ;
            nodInputs.AppendChild(nodResample);

            XmlNode nodReuse = xmlDoc.CreateElement("ReUseRasters");
            nodReuse.InnerText = chkReuseRasters.Checked.ToString();
            nodInputs.AppendChild(nodReuse);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Section Type and Analysis Bin Lookups
            XmlNode nodSectionTypes = xmlDoc.CreateElement("SectionTypes");
            nodInputs.AppendChild(nodSectionTypes);

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @ListID ORDER BY ItemID", dbCon);
                dbCom.Parameters.AddWithValue("ListID", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    XmlNode nodSection = xmlDoc.CreateElement("Section");
                    XmlAttribute attID = xmlDoc.CreateAttribute("id");
                    attID.Value = dbRead.GetInt64(dbRead.GetOrdinal("ItemID")).ToString();
                    nodSection.Attributes.Append(attID);

                    XmlAttribute attTitle = xmlDoc.CreateAttribute("title");
                    attTitle.Value = dbRead.GetString(dbRead.GetOrdinal("Title"));
                    nodSection.Attributes.Append(attTitle);

                    nodSectionTypes.AppendChild(nodSection);
                }
                dbRead.Close();


                foreach (string binType in new List<string> { "AnalysisBins", "CampsiteBins" })
                {
                    XmlNode nodBins = xmlDoc.CreateElement(binType);
                    nodInputs.AppendChild(nodBins);

                    dbCom = new SQLiteCommand("SELECT BinID, Title, LowerDischarge, UpperDischarge FROM AnalysisBins WHERE (IsActive <> 0) AND (BinType = @BinType) ORDER BY BinID", dbCon);
                    dbCom.Parameters.AddWithValue("BinType", binType);
                    dbRead = dbCom.ExecuteReader();
                    while (dbRead.Read())
                    {
                        XmlNode nodBin = xmlDoc.CreateElement("Bin");
                        XmlAttribute attID = xmlDoc.CreateAttribute("id");
                        attID.Value = dbRead.GetInt64(dbRead.GetOrdinal("BinID")).ToString();
                        nodBin.Attributes.Append(attID);

                        XmlAttribute attTitle = xmlDoc.CreateAttribute("title");
                        attTitle.Value = dbRead.GetString(dbRead.GetOrdinal("Title"));
                        nodBin.Attributes.Append(attTitle);

                        XmlAttribute attLD = xmlDoc.CreateAttribute("lower");
                        if (dbRead.IsDBNull(dbRead.GetOrdinal("LowerDischarge")))
                            attLD.Value = string.Empty;
                        else
                            attLD.Value = dbRead.GetDouble(dbRead.GetOrdinal("LowerDischarge")).ToString();
                        nodBin.Attributes.Append(attLD);

                        XmlAttribute attUD = xmlDoc.CreateAttribute("upper");
                        if (dbRead.IsDBNull(dbRead.GetOrdinal("UpperDischarge")))
                            attUD.Value = string.Empty;
                        else
                            attUD.Value = dbRead.GetDouble(dbRead.GetOrdinal("UpperDischarge")).ToString();
                        nodBin.Attributes.Append(attUD);

                        nodBins.AppendChild(nodBin);
                    }
                    dbRead.Close();
                }
            }

            XmlNode nodSites = xmlDoc.CreateElement("Sites");
            nodInputs.AppendChild(nodSites);

            foreach (SandbarSite aSite in SitesToProcess)
            {
                XmlNode nodSite = xmlDoc.CreateElement("Site");
                XmlAttribute attSiteCode5 = xmlDoc.CreateAttribute("code5");
                attSiteCode5.Value = aSite.SiteCode5;
                nodSite.Attributes.Append(attSiteCode5);

                XmlAttribute attSiteCode4 = xmlDoc.CreateAttribute("code4");
                attSiteCode4.Value = aSite.SiteCode;
                nodSite.Attributes.Append(attSiteCode4);

                XmlAttribute attSiteID = xmlDoc.CreateAttribute("id");
                attSiteID.Value = aSite.SiteID.ToString();
                nodSite.Attributes.Append(attSiteID);

                XmlNode nodSurveys = xmlDoc.CreateElement("Surveys");

                foreach (SandbarSurvey aSurvey in aSite.Surveys)
                {
                    if ((aSurvey.SurveyDate >= ucAnalysisFrom.SelectedDate.Value && aSurvey.SurveyDate <= ucAnalysisTo.SelectedDate.Value)
                        || (aSurvey.SurveyDate >= ucMinimumFrom.SelectedDate.Value && aSurvey.SurveyDate <= ucMinimumTo.SelectedDate.Value))
                    {
                        XmlNode nodSurvey = xmlDoc.CreateElement("Survey");

                        XmlAttribute attSurveyDate = xmlDoc.CreateAttribute("date");
                        attSurveyDate.Value = aSurvey.SurveyDate.ToString("yyyy-MM-dd");
                        nodSurvey.Attributes.Append(attSurveyDate);

                        XmlAttribute attSurveyID = xmlDoc.CreateAttribute("id");
                        attSurveyID.Value = aSurvey.SurveyID.ToString();
                        nodSurvey.Attributes.Append(attSurveyID);

                        XmlAttribute attStageDischargeA = xmlDoc.CreateAttribute("stagedisa");
                        attStageDischargeA.Value = aSurvey.SDCurve is null ? "" : aSurvey.SDCurve.CoeffA.ToString();
                        nodSurvey.Attributes.Append(attStageDischargeA);

                        XmlAttribute attStageDischargeB = xmlDoc.CreateAttribute("stagedisb");
                        attStageDischargeB.Value = aSurvey.SDCurve is null ? "" : aSurvey.SDCurve.CoeffB.ToString();
                        nodSurvey.Attributes.Append(attStageDischargeB);

                        XmlAttribute attStageDischargeC = xmlDoc.CreateAttribute("stagedisc");
                        attStageDischargeC.Value = aSurvey.SDCurve is null ? "" : aSurvey.SDCurve.CoeffC.ToString();
                        nodSurvey.Attributes.Append(attStageDischargeC);

                        XmlAttribute attAnalysis = xmlDoc.CreateAttribute("analysis");
                        attAnalysis.Value = (aSurvey.SurveyDate >= ucAnalysisFrom.SelectedDate.Value && aSurvey.SurveyDate <= ucAnalysisTo.SelectedDate.Value).ToString();
                        nodSurvey.Attributes.Append(attAnalysis);

                        XmlAttribute attMinimum = xmlDoc.CreateAttribute("minimum");
                        attMinimum.Value = (aSurvey.SurveyDate >= ucMinimumFrom.SelectedDate.Value && aSurvey.SurveyDate <= ucMinimumTo.SelectedDate.Value).ToString();
                        nodSurvey.Attributes.Append(attMinimum);

                        XmlNode nodSections = xmlDoc.CreateElement("Sections");
                        nodSurvey.AppendChild(nodSections);

                        foreach (SandbarSection aSection in aSurvey.Sections)
                        {
                            if (nodSurvey.ParentNode == null)
                            {
                                // This is the first section for this survey and site.
                                nodSites.AppendChild(nodSite);
                                nodSite.AppendChild(nodSurveys);
                                nodSurveys.AppendChild(nodSurvey);
                                nodSurvey.AppendChild(nodSections);
                            }

                            XmlNode nodSection = xmlDoc.CreateElement("Section");
                            nodSections.AppendChild(nodSection);

                            XmlAttribute attSectionID = xmlDoc.CreateAttribute("id");
                            attSectionID.Value = aSection.SectionID.ToString();
                            nodSection.Attributes.Append(attSectionID);

                            XmlAttribute attSectionTypeID = xmlDoc.CreateAttribute("sectiontypeid");
                            attSectionTypeID.Value = aSection.SectionTypeID.ToString();
                            nodSection.Attributes.Append(attSectionTypeID);

                            XmlAttribute attSectionType = xmlDoc.CreateAttribute("sectiontype");
                            attSectionType.Value = dSectionTypes[aSection.SectionTypeID];
                            nodSection.Attributes.Append(attSectionType);

                            XmlAttribute attUncertainty = xmlDoc.CreateAttribute("uncertainty");
                            attUncertainty.Value = aSection.Uncertainty.ToString();
                            nodSection.Attributes.Append(attUncertainty);
                        }
                    }
                }
            }

            System.IO.Directory.CreateDirectory(sAnalysisFolder);
            string sInputXMLFile = System.IO.Path.Combine(sAnalysisFolder, "inputs");
            sInputXMLFile = System.IO.Path.ChangeExtension(sInputXMLFile, "xml");
            xmlDoc.Save(sInputXMLFile);
            return new System.IO.FileInfo(sInputXMLFile);
        }

        private Dictionary<long, string> LoadSectionTypes()
        {
            Dictionary<long, string> dResult = new Dictionary<long, string>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @ListID", dbCon);
                dbCom.Parameters.AddWithValue("ListID", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                    dResult[dbRead.GetInt64(dbRead.GetOrdinal("ItemID"))] = dbRead.GetString(dbRead.GetOrdinal("Title"));
            }
            return dResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFile("Sandbar Analysis Main.oy Python File", "Python Scripts (*.py)|*.py", ref txtMainPy, true);
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void frmAnalysisConfig_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
