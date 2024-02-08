using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using naru.ui;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbars : Form
    {
        SortableBindingList<SandbarSite> SandbarSites;

        public frmSandbars()
        {
            InitializeComponent();

            grdData.AutoGenerateColumns = false;
            grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "SiteID", "SiteID", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode5", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "River Mile", "RiverMile", true, eAlignment: DataGridViewContentAlignment.MiddleRight);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Bank", "RiverSide", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Name", "Title", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Eddy Size", "EddySize", true, false, "#,##0", eAlignment: DataGridViewContentAlignment.MiddleRight);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Surveys", "SurveyCount", true, false, "#,##0", eAlignment: DataGridViewContentAlignment.MiddleRight);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 8k", "ExpansionRatio8k", true, eAlignment: DataGridViewContentAlignment.MiddleRight);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 45k", "ExpansionRatio8k45k", true, eAlignment: DataGridViewContentAlignment.MiddleRight);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Stage Change", "StageChange8k45k", true, eAlignment: DataGridViewContentAlignment.MiddleRight);
            Helpers.DataGridViewHelpers.AddDataGridViewLinkColumn(ref grdData, "GDAWS", "PrimaryGDAWS", true);

        }

        private void frmSandbars_Load(object sender, EventArgs e)
        {
            // Fix bug where the form icon uses the Visual Studio default when launched maximized
            // http://stackoverflow.com/questions/888865/problem-with-icon-on-creating-new-maximized-mdi-child-form-in-net
            this.Icon = (Icon)Icon.Clone();

            tt.SetToolTip(chkRiverMile, "Check this box to activate the filtering of sandbar sites by river miles.");
            tt.SetToolTip(valUpstream, "The most upstream river mile (RM) of sandbar sites shown in the list. RM zero is the Glen Canyon Dam.");
            tt.SetToolTip(valDownstream, "The most downstream river mile (RM) of sandbar sites shown in the list. RM zero is the Glen Canyon Dam.");
            tt.SetToolTip(txtTitle, "Enter partial or complete sanbar site name to filter the list on the right. This name matches anywhere in the sandbar site name (start, middle or end). Remove all text from this box to clear the name filter.");

            naru.db.sqlite.CheckedListItem.LoadCheckListbox(ref lstSiteTypes, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 2", false);
            for (int i = 0; i < lstSiteTypes.Items.Count; i++)
            {
                if (lstSiteTypes.Items[i].ToString() == "Sandbar Monitoring")
                {
                    lstSiteTypes.SetItemChecked(i, true);
                    break;
                }
            }

            LoadData();
            FilterItems(sender, e);
        }

        public void LoadData(long nSelectID = 0)
        {
            SandbarSites = SandbarSite.LoadSandbarSites(DBCon.ConnectionStringLocal);
            DataView custDV = new DataView();
            grdData.DataSource = SandbarSites;

            if (nSelectID > 0)
            {
                grdData.ClearSelection();
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    if (((SandbarSite)grdData.Rows[i].DataBoundItem).SiteID == nSelectID)
                    {
                        grdData.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }

        private void FilterItemsRiverMileUpstream(object sender, EventArgs e)
        {
            valDownstream.Value = Math.Min(valDownstream.Value, valUpstream.Value);
            FilterItemsRiverMile(null, null);
        }

        private void FilterItemsRiverMileDownstream(object sender, EventArgs e)
        {
            valUpstream.Value = Math.Max(valUpstream.Value, valDownstream.Value);
            FilterItemsRiverMile(null, null);
        }

        private void FilterItemsRiverMile(object sender, EventArgs e)
        {
            chkRiverMile.CheckedChanged -= FilterItems;
            chkRiverMile.Checked = true;
            chkRiverMile.CheckedChanged += FilterItems;
            FilterItems(null, null);
        }

        private void FilterItems(object sender, EventArgs e)
        {
            SortableBindingList<SandbarSite> lFilteredItems = SandbarSites;

            if (chkRiverMile.Checked)
            {
                lFilteredItems = new SortableBindingList<SandbarSite>(lFilteredItems.Where(ss => (ss.RiverMile <= (double)valUpstream.Value && ss.RiverMile >= (double)valDownstream.Value)).ToList<SandbarSite>());
            }

            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                lFilteredItems = new SortableBindingList<SandbarSite>(lFilteredItems.Where(ss => ss.Title.ToLower().Contains(txtTitle.Text.ToLower()) || ss.SiteCode5.ToLower().Contains(txtTitle.Text.ToLower())).ToList<SandbarSite>());
            }

            List<long> activeTypes = new List<long>();
            for(int i = 0; i < lstSiteTypes.CheckedItems.Count; i++)
            {
                naru.db.NamedObject item = (naru.db.NamedObject)lstSiteTypes.CheckedItems[i];
                activeTypes.Add(item.ID);
            }

            if (activeTypes.Count > 0 && activeTypes.Count < lstSiteTypes.Items.Count)
            {
                lFilteredItems = new SortableBindingList<SandbarSite>(lFilteredItems.Where(ss => activeTypes.Contains(ss.SiteType.Value)).ToList<SandbarSite>());
            }

            grdData.DataSource = lFilteredItems;
        }

        private void EnterNumericUpDown(object sender, EventArgs e)
        {
            NumericUpDown theControl = (NumericUpDown)sender;
            theControl.Select(0, theControl.Text.Length);
        }

        private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;
                frmSandbarProperties frm = new frmSandbarProperties(ref selSite);

                try
                {
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
            }
        }

        private void editPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;

                Sandbars.frmSandbarPropertiesEdit frm = new frmSandbarPropertiesEdit(DBCon.ConnectionStringLocal, selSite.SiteID);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    MasterDatabaseChanged(selSite.SiteID);
                //}
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void grdData_MouseClick(object sender, MouseEventArgs e)
        {
            var hti = grdData.HitTest(e.X, e.Y);
            //grdData.ClearSelection();
            if (hti.RowY > 1 && hti.ColumnX > 0)
                grdData.Rows[hti.RowIndex].Selected = true;
        }

        private void addNewSandbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSandbarPropertiesEdit frm = new frmSandbarPropertiesEdit(DBCon.ConnectionStringLocal);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DBCon.BackupRequiredOnClose = true;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void deleteSelectedSandbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.SelectedRows[0].DataBoundItem is SandbarSite)
            {
                SandbarSite theSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show(string.Format("Are you sure that you want to delete the sandbar site called '{0}'? This process is permanent and cannot be undone.", theSite.SiteCode5), "Confirm Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                    {
                        dbCon.Open();

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            SQLiteCommand dbCom = new SQLiteCommand("DELETE FROM SandbarSites WHERE SiteID = @SiteID", dbCon);
                            dbCom.Parameters.AddWithValue("SiteID", theSite.SiteID);
                            dbCom.ExecuteNonQuery();
                        }
                        catch (SQLiteException ex)
                        {
                            if (ex.Message.ToLower().Contains("foreign key"))
                            {
                                if (ex.Message.Contains("FK_RemoteCameras_SiteID"))
                                {
                                    MessageBox.Show("This sandbar site is referenced by one or more remote camera locations and cannot be deleted. Edit the relevant remote camera location(s) and disassociate them from this sandbar site before attempting to delete this item.", "Delete Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    throw;
                            }
                            else
                                throw;
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

        private void browseTopoFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData)
                && System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData))
            {
                if (grdData.SelectedRows[0].DataBoundItem is SandbarSite)
                {
                    SandbarSite aSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;

                    // Use the software settings to determine if sandbar folders are 4 digit codes "003L" or the newer more consistent 5 digits "0003L"
                    string sFolder = aSite.SiteCode5;
                    if (string.Compare("sitecode5", SandbarWorkbench.Properties.Settings.Default.SandbarIdentification, true) != 0)
                        sFolder = aSite.SiteCode;

                    sFolder = System.IO.Path.Combine(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData, string.Format("{0}corgrids", sFolder));
                    if (!System.IO.Directory.Exists(sFolder))
                    {
                        if (MessageBox.Show(string.Format("The sandbar topo folder {0} does not exist. Do you want to create it now?", sFolder), "Missing Sandbar Site Topo Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                            == DialogResult.Yes)
                        {
                            System.IO.Directory.CreateDirectory(sFolder);
                        }
                    }

                    if (System.IO.Directory.Exists(sFolder))
                    {
                        System.Diagnostics.Process.Start(sFolder);
                    }
                }
            }
        }

        private void sandbarAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Analysis.frmAnalysisConfig frm = new Analysis.frmAnalysisConfig(grdData.SelectedRows.Cast<DataGridViewRow>().Select(x => x.DataBoundItem as SandbarSite).ToList<SandbarSite>());
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }

        }

        private void grdData_SelectionChanged(object sender, EventArgs e)
        {
            if (grdData.SelectedRows.Count == 1)
            {
                SandbarSite ss = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;
                ucThumbail.UpdateThumbnail(ss.RemoteCameraSiteCode, ss.BestPhotoTime);
            }
        }

        private void toolBrowse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData)
               && System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData))
            {
                System.Diagnostics.Process.Start(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>http://stackoverflow.com/questions/5251224/merge-toolstrip-mdi-child-parent</remarks>
        private void frmSandbars_FormClosing(object sender, FormClosingEventArgs e)
        {
            ToolStripManager.RevertMerge(((frmMain)this.MdiParent).toolStrip1);
        }

        private void toolBestPhoto_Click(object sender, EventArgs e)
        {
            if (grdData.SelectedRows.Count > 5)
            {
                if (MessageBox.Show(string.Format("Do you want to open the best photo for all {0} selected sites?", grdData.SelectedRows.Count), SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }

            foreach (DataGridViewRow dgvr in grdData.SelectedRows)
            {
                if (dgvr.DataBoundItem is SandbarSite)
                {
                    SandbarSite selSite = dgvr.DataBoundItem as SandbarSite;
                    if (selSite.RemoteCameraID.HasValue)
                    {
                        Pictures.PictureInfo pic = Pictures.PictureInfo.GetPictureInfo(selSite.RemoteCameraSiteCode, selSite.BestPhotoTime);
                        System.IO.FileInfo fiImage = pic.BestImage;
                        if (fiImage is System.IO.FileInfo && fiImage.Exists)
                        {
                            System.Diagnostics.Process.Start(fiImage.FullName);
                        }
                    }
                }
            }
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdData.Columns[e.ColumnIndex].Name.ToLower().Contains("gdaws"))
            {
                if (grdData.Rows[e.RowIndex].DataBoundItem is SandbarSite)
                {
                    SandbarSite selSite = grdData.Rows[e.RowIndex].DataBoundItem as SandbarSite;
                    if (!string.IsNullOrEmpty(selSite.PrimaryGDAWSLink))
                        System.Diagnostics.Process.Start(selSite.PrimaryGDAWSLink);
                }
            }
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Helpers.DataGridViewHelpers.ExportToCSV(ref grdData, "Export Sandbar Sites", "sandbar_sites", true);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void frmSandbars_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void viewPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.SelectedRows.Count < 1)
                return;

            SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;
            frmSandbarProperties frm = new frmSandbarProperties(ref selSite);

            try
            {
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void editSandbar(object sender, EventArgs e)
        {
            if (grdData.SelectedRows.Count < 1)
                return;

            SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;
            frmSandbarPropertiesEdit frm = new frmSandbarPropertiesEdit(DBCon.ConnectionStringLocal, selSite.SiteID);

            try
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DBCon.BackupRequiredOnClose = true;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void lstSiteTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void lstSiteTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterItems(sender, e);
        }
    }
}