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
        private string Noun { get; set; }
        private string SelectSQL { get; set; }
        private string DeleteSQL { get; set; }
        private DataTable GridItems { get; set; }

        private long SelectedID
        {
            get
            {
                return (long)((DataRow)grdData.SelectedRows[0].DataBoundItem)["ID"];
            }
        }

        public frmDataGridView(string sFormName, string sNoun, string sSelectSQL, string sDeleteSQL)
        {
            InitializeComponent();

            Noun = sNoun;
            SelectSQL = sSelectSQL;
            DeleteSQL = sDeleteSQL;
            this.Text = sFormName;
        }

        private void frmDataGridView_Load(object sender, EventArgs e)
        {
            Helpers.DataGridViewHelpers.ConfigureDataGridView(ref grdData, DockStyle.Fill, false, true);
            LoadDataGridView();
        }

        private void LoadDataGridView(long nSelectID = 0)
        {
            try
            {
                using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    dbCon.Open();
                    SQLiteCommand dbCom = new SQLiteCommand(SelectSQL, dbCon);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(SelectSQL, dbCon);
                    da.Fill(GridItems);

                    // Hide the first, ID column
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

                if (SelectSQL.ToLower().Contains("reaches"))
                    frm = new Reaches.frmReachPropertiesEdit(ID);
                else if (SelectSQL.ToLower().Contains("segments"))
                    frm = new Segments.frmSegmentPropertiesEdit(ID);
                else
                    throw new Exception(string.Format("Unhandled add/edit operation for data gridview type {0}", Noun));

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

                if (MessageBox.Show(string.Format("Are you sure that you want to delete the selected {0}? This action is permanent and cannot be undone.", Noun.ToLower()), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();
                        MySqlCommand dbCom = new MySqlCommand(DeleteSQL, dbCon);
                        dbCom.Parameters.AddWithValue("ReachID", SelectedID);
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
