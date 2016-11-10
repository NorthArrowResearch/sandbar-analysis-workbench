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
                using (MySql.Data.MySqlClient.MySqlConnection dbCon = new MySql.Data.MySqlClient.MySqlConnection(DBCon.ConnectionStringMaster))
                {
                    dbCon.Open();

                    MySql.Data.MySqlClient.MySqlCommand dbCom = null;
                    if (ID > 0)
                    {
                        dbCom = new MySqlCommand("UPDATE Trips SET TripDate = @TripDate, Remarks = @Remarks, UpdatedBy = @EditedBy WHERE TripID = @TripID", dbCon);
                        dbCom.Parameters.AddWithValue("TripID", ID);
                    }
                    else
                        dbCom = new MySqlCommand("INSERT INTO Trips (TripDate, Remarks, AddedBy, UpdatedBy) VALUES (@TripDate, @Remarks, @EditedBy, @EditedBy)", dbCon);

                    dbCom.Parameters.AddWithValue("TripDate", dtTripDate.Value);

                    MySqlParameter pRemarks = dbCom.Parameters.Add("Remarks", MySqlDbType.VarChar);
                    if (string.IsNullOrEmpty(txtRemarks.Text))
                        pRemarks.Value = DBNull.Value;
                    else
                        pRemarks.Value = txtRemarks.Text;

                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                    dbCom.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }
    }
}
