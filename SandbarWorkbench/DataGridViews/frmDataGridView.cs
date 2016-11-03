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

                    grdData.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void AddEdit_Click(object sender, EventArgs e)
        {
            try
            {
                long ID = 0;
                if (((ToolStripMenuItem)sender).Name.ToLower().Contains("edit"))
                {
                    ID = SelectedID;
                }

                Form frm = null;

                if (TypeInfo.SelectSQL.ToLower().Contains("reaches"))
                    frm = new Reaches.frmReachPropertiesEdit(ID);
                else if (TypeInfo.SelectSQL.ToLower().Contains("segments"))
                    frm = new Segments.frmSegmentPropertiesEdit(ID);
                else
                {
                    DataGridViews.DataGridViewTypeLookupList dgvlTag = (DataGridViews.DataGridViewTypeLookupList)TypeInfo;
                    frm = new frmLookupItemEdit(dgvlTag.ListID, dgvlTag.Noun, ID);
                }

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

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show(string.Format("Are you sure that you want to delete the selected {0}? This action is permanent and cannot be undone.", TypeInfo.Noun.ToLower()), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();
                        MySqlCommand dbCom = new MySqlCommand(TypeInfo.DeleteSQL, dbCon);
                        dbCom.Parameters.AddWithValue("ID", SelectedID);
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
                LoadDataGridView(nSelectID);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
