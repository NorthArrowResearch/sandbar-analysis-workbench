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

namespace SandbarWorkbench.Reaches
{
    public partial class frmReachPropertiesEdit : Form
    {
        public long ID { get; internal set; }

        public frmReachPropertiesEdit(long nReachID = 0)
        {
            InitializeComponent();
            ID = nReachID;
        }

        private void frmReachPropertiesEdit_Load(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                try
                {
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();
                        MySqlCommand dbCom = new MySqlCommand("SELECT ReachCode, Title FROM Reaches WHERE ReachID = @ReachID", dbCon);
                        dbCom.Parameters.AddWithValue("ReachID", ID);
                        MySqlDataReader dbRead = dbCom.ExecuteReader();
                        dbRead.Read();

                        txtReachCode.Text = dbRead.GetString("ReachCode");
                        txtReachName.Text = dbRead.GetString("Title");
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
            if (string.IsNullOrEmpty(txtReachCode.Text))
            {
                MessageBox.Show("You must provide a reach code, typically of the form #_XXX", "Missing Reach Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtReachName.Text))
            {
                MessageBox.Show("You must provide a reach name.", "Missing Reach Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MySqlCommand dbCom = null;
                    if (ID < 1)
                        dbCom = new MySqlCommand("INSERT INTO Reaches (ReachCode, Title, AddedBy, UpdatedBy) VALUES (@ReachCode, @Title, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans);
                    else
                    {
                        dbCom = new MySqlCommand("UPDATE Reaches SET ReachCode = @ReachCode, Title = @Title, UpdatedBy = @EditedBy WHERE ReachID = @ReachID", dbTrans.Connection, dbTrans);
                        dbCom.Parameters.AddWithValue("ReachID", ID);
                    }

                    dbCom.Parameters.AddWithValue("ReachCode", txtReachCode.Text);
                    dbCom.Parameters.AddWithValue("Title", txtReachName.Text);
                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                    dbCom.ExecuteNonQuery();

                    if (ID < 1)
                    {
                        ID = dbCom.LastInsertedId;
                    }

                    dbTrans.Commit();
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    ExceptionHandling.NARException.HandleException(ex);
                }
            }
        }
    }
}
