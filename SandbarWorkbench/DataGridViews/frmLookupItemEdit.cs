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

namespace SandbarWorkbench.DataGridViews
{
    public partial class frmLookupItemEdit : Form
    {
        public long ID { get; set; }
        public long ListID { get; set; }
        public string Noun { get; set; }

        public frmLookupItemEdit(long nListID, string sNoun, long nID = 0)
        {
            InitializeComponent();
            ID = nID;
            ListID = nListID;
            Noun = sNoun;
        }

        private void frmReachPropertiesEdit_Load(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();
                        MySqlCommand dbCom = new MySqlCommand("SELECT Title FROM LookupListItems WHERE ItemID = @ItemID", dbCon);
                        dbCom.Parameters.AddWithValue("ItemID", ID);
                        MySqlDataReader dbRead = dbCom.ExecuteReader();
                        dbRead.Read();

                        txtName.Text = dbRead.GetString("Title");
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

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show(string.Format("You must provide a name for the {0}.", Noun), "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
            {
                dbCon.Open();
                MySqlTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    MySqlCommand dbCom = null;
                    if (ID < 1)
                    {
                        dbCom = new MySqlCommand("INSERT INTO LookupListItems (ListID, Title, AddedBy, UpdatedBy) VALUES (@ListID, @Title, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans);
                        dbCom.Parameters.AddWithValue("ListID", ListID);
                    }
                    else
                    {
                        dbCom = new MySqlCommand("UPDATE LookupListItems SET Title = @Title, UpdatedBy = @EditedBy WHERE ItemID = @ItemID", dbTrans.Connection, dbTrans);
                        dbCom.Parameters.AddWithValue("ItemID", ID);
                    }

                    dbCom.Parameters.AddWithValue("Title", txtName.Text);
                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                    dbCom.ExecuteNonQuery();

                    if (ID < 1)
                    {
                        ID = dbCom.LastInsertedId;
                    }

                    dbTrans.Commit();
                }
                catch (MySqlException exMaster)
                {
                    if (exMaster.Message.ToLower().Contains("duplicate"))
                    {
                        string sNoun = string.Empty;
                        if (exMaster.Message.ToLower().Contains("title"))
                        {
                            txtName.Select();
                            sNoun = "name";
                        }

                        MessageBox.Show(string.Format("Another {0} already exists in the master database with this name. Each reach must possess a unique name.", sNoun), "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                        throw;

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
}
