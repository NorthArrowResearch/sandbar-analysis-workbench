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
            tt.SetToolTip(txtName, string.Format("Unique name for the {0}. Max 50 characters.", Noun.ToLower()));

            if (ID <1)
            {
                this.Text = string.Format("Add New {0}", Noun);
            }
            else
            {
                this.Text = string.Format("Edit {0} Properties", Noun);
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                    {
                        dbCon.Open();
                        SQLiteCommand dbCom = new SQLiteCommand("SELECT Title FROM LookupListItems WHERE ItemID = @ItemID", dbCon);
                        dbCom.Parameters.AddWithValue("ItemID", ID);
                        SQLiteDataReader dbRead = dbCom.ExecuteReader();
                        dbRead.Read();

                        txtName.Text = dbRead.GetString(dbRead.GetOrdinal("Title"));
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
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                ListItemCRUD crud = new ListItemCRUD(ListID);
                DBHelpers.DatabaseObject obj = new DBHelpers.DatabaseObject(ID, txtName.Text, DateTime.Now,Environment.UserName, DateTime.Now,  Environment.UserName);
                crud.Save(ref obj);
            }
            catch (SQLiteException ex)
            {
                string sNoun = string.Empty;

                if (ex.Message.ToLower().Contains("ux_lookuplistitems_title"))
                {
                    sNoun = "Name";
                    txtName.Select();
                }

                if (!string.IsNullOrEmpty(sNoun))
                {
                    string sMessage = string.Format("A {0} with this {0} already exists on the master database. Please choose a unique {0}. {1}", Noun, sNoun.ToLower(), SandbarWorkbench.Properties.Resources.SyncRequiredWarning);
                    string sTitle = string.Format("Duplicate {0}", sNoun);

                    MessageBox.Show(sMessage, sTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
