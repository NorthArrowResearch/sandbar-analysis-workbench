using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Eddy Size", "EddySize", true, "#,##0", eAlignment: DataGridViewContentAlignment.MiddleRight);
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

            LoadData();
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
            BindingList<SandbarSite> lFilteredItems = SandbarSites;

            if (chkRiverMile.Checked)
            {
                lFilteredItems = new BindingList<SandbarSite>(lFilteredItems.Where(ss => (ss.RiverMile <= (double)valUpstream.Value && ss.RiverMile >= (double)valDownstream.Value)).ToList<SandbarSite>());
            }

            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                lFilteredItems = new BindingList<SandbarSite>(lFilteredItems.Where(ss => ss.Title.ToLower().Contains(txtTitle.Text.ToLower())).ToList<SandbarSite>());
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
                frm.ShowDialog();
            }
        }

        private void editPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;

                Sandbars.frmSandbarPropertiesEdit frm = new frmSandbarPropertiesEdit(DBCon.ConnectionStringMaster, selSite.SiteID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MasterDatabaseChanged(selSite.SiteID);
                }
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
                frmSandbarPropertiesEdit frm = new frmSandbarPropertiesEdit(DBCon.ConnectionStringMaster);
                if (frm.ShowDialog() == DialogResult.OK)
                    MasterDatabaseChanged(frm.ID);
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
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            MySqlCommand dbCom = new MySqlCommand("DELETE FROM SandbarSites WHERE SiteID = @SiteID", dbCon);
                            dbCom.Parameters.AddWithValue("SiteID", theSite.SiteID);
                            dbCom.ExecuteNonQuery();
                            MasterDatabaseChanged();
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

        private void MasterDatabaseChanged(long nSelectID = 0)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                sync.SyncLookupData();
                LoadData(nSelectID);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
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
           catch(Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }           

        }
    }
}
