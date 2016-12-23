using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.DataGridViews
{
    public partial class frmDataGridView : Form
    {
        public DataGridViewTypeBase TypeInfo { get; internal set; }
        private DataTable GridItems { get; set; }

        private long SelectedID
        {
            get
            {
                DataRowView drv = (DataRowView)grdData.SelectedRows[0].DataBoundItem;
                DataRow dr = drv.Row;
                return (long)dr["ID"];
            }
        }

        public frmDataGridView(DataGridViewTypeBase theTypeInfo)
        {
            InitializeComponent();
            TypeInfo = theTypeInfo;
            this.Text = TypeInfo.MenuItemText;
        }

        private void frmDataGridView_Load(object sender, EventArgs e)
        {
            this.Icon = (Icon)Icon.Clone();

            Helpers.DataGridViewHelpers.ConfigureDataGridView(ref grdData, DockStyle.Fill, false, true);
            LoadDataGridView();
        }

        private void LoadDataGridView(long nSelectID = 0)
        {
            GridItems = new DataTable();

            try
            {
                using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    dbCon.Open();
                    SQLiteCommand dbCom = new SQLiteCommand(TypeInfo.SelectSQL, dbCon);

                    if (TypeInfo is DataGridViewTypeLookupList)
                        dbCom.Parameters.AddWithValue("ListID", ((DataGridViewTypeLookupList)TypeInfo).ListID);

                    DataTable dt = new DataTable();
                    dt.Load(dbCom.ExecuteReader());
                    grdData.DataSource = dt;

                    // Hide the ID column
                    grdData.Columns[0].Visible = false;

                    // Format the audit trail date time columns
                    if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.DateFormat_AuditFields))
                    {
                        foreach (DataGridViewColumn aCol in grdData.Columns)
                        {
                            if (string.Compare(aCol.Name, "Added On", true) == 0 || string.Compare(aCol.Name, "Updated On", true) == 0)
                            {
                                aCol.DefaultCellStyle.Format = SandbarWorkbench.Properties.Settings.Default.DateFormat_AuditFields;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void AddEdit_Click(object sender, EventArgs e)
        {
            long ID = 0;
            if (((ToolStripMenuItem)sender).Name.ToLower().Contains("edit"))
            {
                ID = SelectedID;
            }
            AddEditItem(ID);
        }

        private void AddEditItem(long ID)
        {
            try
            {
                Form frm = null;

                if (TypeInfo.SelectSQL.ToLower().Contains("reaches"))
                    frm = new Reaches.frmReachPropertiesEdit(ID);
                else if (TypeInfo.SelectSQL.ToLower().Contains("segments"))
                    frm = new Segments.frmSegmentPropertiesEdit(ID);
                else if (TypeInfo.SelectSQL.ToLower().Contains("trips"))
                    frm = new Trips.frmTripPropertiesEdit(ID);
                else if (TypeInfo.SelectSQL.ToLower().Contains("bins"))
                    frm = new AnalysisBins.frmAnalysisBinProperties(ID);
                else
                {
                    DataGridViews.DataGridViewTypeLookupList dgvlTag = (DataGridViews.DataGridViewTypeLookupList)TypeInfo;
                    frm = new frmLookupItemEdit(dgvlTag.ListID, dgvlTag.Noun, ID);
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataGridView(ID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                long ID = SelectedID;

                if (MessageBox.Show(string.Format("Are you sure that you want to delete the selected {0}? This action is permanent and cannot be undone.", TypeInfo.Noun.ToLower()), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    using (MySqlConnection conMaster = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        conMaster.Open();
                        MySqlTransaction transMaster = conMaster.BeginTransaction();

                        using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                        {
                            dbCon.Open();
                            SQLiteTransaction transLocal = dbCon.BeginTransaction();

                            try
                            {
                                MySqlCommand comMaster = new MySqlCommand(TypeInfo.DeleteSQL, transMaster.Connection, transMaster);
                                comMaster.Parameters.AddWithValue("ID", ID);
                                comMaster.ExecuteNonQuery();

                                SQLiteCommand comLocal = new SQLiteCommand(TypeInfo.DeleteSQL, transLocal.Connection, transLocal);
                                comLocal.Parameters.AddWithValue("ID", ID);
                                comLocal.ExecuteNonQuery();

                                transMaster.Commit();
                                transLocal.Commit();

                                LoadDataGridView();
                            }
                            catch
                            {
                                transMaster.Rollback();
                                transLocal.Rollback();
                                throw;
                            }
                        }
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

                sync.SynchronizeLookupTables();
                LoadDataGridView(nSelectID);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void exportTableToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Helpers.DataGridViewHelpers.ExportToCSV(ref grdData, string.Format("Export {0}", this.TypeInfo.Noun), this.TypeInfo.Noun.Replace(" ", "_"), true);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView drv = (DataRowView)grdData.Rows[e.RowIndex].DataBoundItem;
                DataRow dr = drv.Row;
                AddEditItem( (long)dr["ID"]);
            }
        }
    }
}
