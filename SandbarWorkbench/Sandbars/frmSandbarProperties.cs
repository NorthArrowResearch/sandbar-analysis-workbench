﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbarProperties : Form
    {
        private SandbarSite m_Site;

        public frmSandbarProperties()
        {
            InitializeComponent();
        }

        public frmSandbarProperties(ref SandbarSite aSite)
        {
            InitializeComponent();

            m_Site = aSite;
            if (m_Site is SandbarSite)
            {
                ucStageDischarge1.SDCurve = m_Site.SDCurve;
                ucAreaVolumeAnalyses1.SandbarSite = m_Site;
                ConfigureSurveysGrid();
            }
        }

        private void frmSandbarProperties_Load(object sender, EventArgs e)
        {
            if (m_Site is SandbarSite)
            {
                txtName.Text = m_Site.Title;
                txtRiverMile.Text = m_Site.RiverMile.ToString();
                txtSiteCode.Text = m_Site.SiteCode5;

                grdSurveys.DataSource = m_Site.Surveys;
                LoadBasicSandbarProperties();
            }
        }

        private void ConfigureSurveysGrid()
        {
            grdSurveys.RowHeadersVisible = false;
            grdSurveys.AllowUserToAddRows = false;
            grdSurveys.AllowUserToDeleteRows = false;
            grdSurveys.AllowUserToResizeRows = false;
            grdSurveys.AutoGenerateColumns = false;
            grdSurveys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //add them here
            var auditTrailProvider = new SandbarSurvey.MyTypeDescriptionProvider<AuditTrail>();
            System.ComponentModel.TypeDescriptor.AddProvider((new SandbarSurvey.MyTypeDescriptionProvider<AuditTrail>()), typeof(Sandbars.SandbarSurvey));

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdSurveys, "Survey Date", "SurveyDate", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdSurveys, "Trip Date", "TripDate", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdSurveys, "Eddy Count", "EddyCount", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdSurveys, "Channel Survey", "HasChannelStr", true);
            Helpers.DataGridViewHelpers.AddDataGridViewAuditColumns(ref grdSurveys);
        }

        private void LoadBasicSandbarProperties()
        {
            grdData.AllowUserToAddRows = false;
            grdData.AllowUserToAddRows = false;
            grdData.AllowUserToDeleteRows = false;
            grdData.AllowUserToResizeRows = false;
            grdData.AutoGenerateColumns = false;
            grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdData.ReadOnly = true;
            grdData.Dock = DockStyle.Fill;
            grdData.RowHeadersVisible = false;


            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Property", "Key", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Value", "Value", true);

            grdData.Rows.Add("Site Code", m_Site.SiteCode5);
            grdData.Rows.Add("River Mile", m_Site.RiverMile.ToString());
            grdData.Rows.Add("River Size", m_Site.RiverSide);
            grdData.Rows.Add("Title", m_Site.Title);
            grdData.Rows.Add("Alternate Title", m_Site.AlternateTitle);
            grdData.Rows.Add("Site Type", m_Site.SiteType);
            grdData.Rows.Add("History", m_Site.History);
            grdData.Rows.Add("Eddy Size", m_Site.EddySize.ToString());
            grdData.Rows.Add("Expansion Ratio 8k", m_Site.ExpansionRatio8k.ToString());
            grdData.Rows.Add("Expansion Ratio 45k", m_Site.ExpansionRatio45k.ToString());
            grdData.Rows.Add("Expansion Ratio 8k to 45k", m_Site.StageChange8k45k.ToString());
            grdData.Rows.Add("Primary GDAWS", m_Site.PrimaryGDAWS.ToString());
            grdData.Rows.Add("Secondary GDAWS", m_Site.SecondaryGDAWS.ToString());
            grdData.Rows.Add("Reach", m_Site.Reach is ListItem ? m_Site.Reach.ToString() : "");
            grdData.Rows.Add("Segment", m_Site.Segment is ListItem ? m_Site.Segment.ToString() : "");
            grdData.Rows.Add("Campsite Survey Record", m_Site.CampSiteSurveyRecord);
            grdData.Rows.Add("Remote Camera Record", m_Site.RemoteCameraID.HasValue ? m_Site.RemoteCameraID.ToString() : "");
            grdData.Rows.Add("Stage Discharge A", m_Site.SDCurve.CoeffA.HasValue ? m_Site.SDCurve.CoeffA.ToString() : "");
            grdData.Rows.Add("Stage Discharge B", m_Site.SDCurve.CoeffB.HasValue ? m_Site.SDCurve.CoeffB.ToString() : "");
            grdData.Rows.Add("Stage Discharge C", m_Site.SDCurve.CoeffC.HasValue ? m_Site.SDCurve.CoeffC.ToString() : "");
            grdData.Rows.Add("Northing", m_Site.Northing.HasValue ? m_Site.Northing.ToString() : "");
            grdData.Rows.Add("Easting", m_Site.Easting.HasValue ? m_Site.Easting.ToString() : "");
            grdData.Rows.Add("Latitude", m_Site.Latitude.HasValue ? m_Site.Latitude.Value.ToString("0.000°") : "");
            grdData.Rows.Add("Longitude", m_Site.Longitude.HasValue ? m_Site.Longitude.Value.ToString("0.000°") : "");
            grdData.Rows.Add("Initial Survey", m_Site.InitialSurvey);
            grdData.Rows.Add("Added On", m_Site.AddedOn.ToString());
            grdData.Rows.Add("Added By", m_Site.AddedBy);
            grdData.Rows.Add("Updated On", m_Site.UpdatedOn);
            grdData.Rows.Add("Updated By", m_Site.UpdatedBy);

            grdData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void viewSurveyPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdSurveys.SelectedRows[0].DataBoundItem is SandbarSurvey)
            {
                SandbarSurvey selSurvey = (SandbarSurvey)grdSurveys.SelectedRows[0].DataBoundItem;
                frmSurveyProperties frm = new frmSurveyProperties(ref selSurvey, false);
                frm.ShowDialog();
            }


        }

        private void addSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSurveyProperties frm = new frmSurveyProperties(m_Site.SiteID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                    sync.SynchronizeLookupTables();

                    m_Site = SandbarSite.LoadSandbarSite(DBCon.ConnectionStringLocal, m_Site.SiteID);
                    grdSurveys.DataSource = m_Site.Surveys;

                    for (int i = 0; i < grdSurveys.Rows.Count; i++)
                    {
                        if (((SandbarSurvey)grdSurveys.Rows[i].DataBoundItem).SurveyID == frm.Survey.SurveyID)
                        {
                            grdSurveys.ClearSelection();
                            grdSurveys.Rows[i].Selected = true;
                            grdSurveys.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
        }

        private void grdSurveys_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SandbarSurvey selSurvey = (SandbarSurvey)grdSurveys.SelectedRows[0].DataBoundItem;
                frmSurveyProperties frm = new frmSurveyProperties(ref selSurvey, false);
                frm.ShowDialog();
            }
        }

        private void deleteSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdSurveys.SelectedRows.Count > 0)
            {
                string sMessage = string.Format("Are you sure that you want to delete the {0} selected surveys." +
                    " All surveyed section data and associated model results will also be deleted both locally and on the master database." +
                    " This action is permanent cannot be undone.", grdSurveys.SelectedRows.Count);

                switch (MessageBox.Show(sMessage, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Cancel:
                        this.DialogResult = DialogResult.Cancel;
                        return;

                    case DialogResult.No:
                        return;
                }

                using (MySql.Data.MySqlClient.MySqlConnection dbCon = new MySql.Data.MySqlClient.MySqlConnection(DBCon.ConnectionStringMaster))
                {
                    Cursor.Current = Cursors.WaitCursor;

                    dbCon.Open();
                    MySql.Data.MySqlClient.MySqlTransaction dbTrans = dbCon.BeginTransaction();

                    try
                    {
                        MySql.Data.MySqlClient.MySqlCommand dbCom = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM SandbarSurveys WHERE SurveyID = @SurveyID", dbTrans.Connection, dbTrans);
                        MySql.Data.MySqlClient.MySqlParameter pSurveyID = dbCom.Parameters.Add("SurveyID", MySql.Data.MySqlClient.MySqlDbType.Int64);

                        foreach (DataGridViewRow row in grdSurveys.SelectedRows)
                        {
                            pSurveyID.Value = ((SandbarSurvey)row.DataBoundItem).SurveyID;
                            dbCom.ExecuteNonQuery();
                        }

                        dbTrans.Commit();

                        // Reload the data
                        DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                        sync.SynchronizeLookupTables();

                        m_Site = SandbarSite.LoadSandbarSite(DBCon.ConnectionStringLocal, m_Site.SiteID);
                        grdSurveys.DataSource = m_Site.Surveys;
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        ExceptionHandling.NARException.HandleException(ex);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void editSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdSurveys.SelectedRows.Count < 1)
                return;

            SandbarSurvey selSurvey = grdSurveys.SelectedRows[0].DataBoundItem as SandbarSurvey;
            frmSurveyProperties frm = new frmSurveyProperties(ref selSurvey, true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                    sync.SynchronizeLookupTables();

                    m_Site = SandbarSite.LoadSandbarSite(DBCon.ConnectionStringLocal, m_Site.SiteID);
                    grdSurveys.DataSource = m_Site.Surveys;

                    for (int i = 0; i < grdSurveys.Rows.Count; i++)
                    {
                        if (((SandbarSurvey)grdSurveys.Rows[i].DataBoundItem).SurveyID == frm.Survey.SurveyID)
                        {
                            grdSurveys.ClearSelection();
                            grdSurveys.Rows[i].Selected = true;
                            grdSurveys.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
