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
using System.Data.SQLite;

namespace SandbarWorkbench.Trips
{
    public partial class frmTripPropertiesEdit : Form
    {
        public long ID { get; internal set; }

        public frmTripPropertiesEdit(long nID = 0)
        {
            InitializeComponent();
            ID = nID;
        }

        private void frmTripPropertiesEdit_Load(object sender, EventArgs e)
        {
            tt.SetToolTip(dtTripDate, "Date of departure for this river trip.");
            tt.SetToolTip(txtRemarks, "Optional, miscellaneous remarks and comments about this river trip. Max 1000 characters.");

            if (ID > 0)
            {
                try
                {
                    using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                    {
                        dbCon.Open();
                        SQLiteCommand dbCom = new SQLiteCommand("SELECT TripDate, Remarks FROM Trips WHERE TripID = @TripID", dbCon);
                        dbCom.Parameters.AddWithValue("TripID", ID);
                        SQLiteDataReader dbRead = dbCom.ExecuteReader();
                        if (dbRead.Read())
                        {
                            dtTripDate.Value = dbRead.GetDateTime(dbRead.GetOrdinal("TripDate"));

                            if (!dbRead.IsDBNull(dbRead.GetOrdinal("Remarks")))
                                txtRemarks.Text = dbRead.GetString(dbRead.GetOrdinal("Remarks"));
                        }
                        else
                            throw new Exception("Unable to retrieve trip information");
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
            }
        }

        private bool ValidateForm()
        {
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
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                DBHelpers.DatabaseObject theItem = new Trip(ID, dtTripDate.Value, txtRemarks.Text, DateTime.Now, "", DateTime.Now, "");
                TripCRUD crud = new TripCRUD();
               crud.Save(ref theItem);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
                this.DialogResult = DialogResult.None;
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }

        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
