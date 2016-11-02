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

namespace SandbarWorkbench.Segments
{
    public partial class frmSegments : Form
    {
        SortableBindingList<Segment> GridItems;

        public frmSegments()
        {
            InitializeComponent();

            grdData.AutoGenerateColumns = false;

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "SegmentID", "SegmentID", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Segment Code", "SegmentCode", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Name", "Title", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Upstream RM", "UpstreamRiverMile", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Downstream RM", "DownstreamRiverMile", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Added On", "AddedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Added By", "AddedBy", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Updated On", "UpdatedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Updated By", "UpdatedBy", true);
        }

        private void frmSegments_Load(object sender, EventArgs e)
        {
            Helpers.DataGridViewHelpers.ConfigureDataGridView(ref grdData, DockStyle.Fill, false);
            LoadData();
        }

        private void LoadData(long nSelectID = 0)
        {
            try
            {
                GridItems = Segment.LoadSegments();
                DataView custDV = new DataView();
                grdData.DataSource = GridItems;

                if (nSelectID > 0)
                {
                    grdData.ClearSelection();
                    for (int i = 0; i < grdData.Rows.Count; i++)
                    {
                        if (((Segment)grdData.Rows[i].DataBoundItem).ID == nSelectID)
                        {
                            grdData.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void AddEditReach_Click(object sender, EventArgs e)
        {
            try
            {
                long ID = 0;
                if (((ToolStripMenuItem)sender).Name.ToLower().Contains("edit"))
                {
                    ID = ((DBHelpers.DatabaseObject)grdData.SelectedRows[0].DataBoundItem).ID;
                }

                frmSegmentPropertiesEdit frm = new frmSegmentPropertiesEdit(ID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MasterDatabaseChanged(ID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void DeleteReach_Click(object sender, EventArgs e)
        {
            try
            {
                Segment delItem = (Segment)grdData.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show(string.Format("Are you sure that you want to delete the segment '{0'? This action is permanent and cannot be undone.", delItem.SegmentCode), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();
                        MySqlCommand dbCom = new MySqlCommand("DELETE FROM Reaches WHERE ReachID = @ReachID", dbCon);
                        dbCom.Parameters.AddWithValue("ReachID", delItem.ID);
                        dbCom.ExecuteNonQuery();
                        MasterDatabaseChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
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
    }
}
