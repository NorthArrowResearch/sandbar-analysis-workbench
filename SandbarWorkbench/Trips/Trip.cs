using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.Trips
{
    public class Trip
    {
        public long ID { get; internal set; }
        public DateTime TripDate { get; internal set; }
        public string Remarks { get; internal set; }

        private const string InsertSQL = "INSERT INTO Trips (TripID, TripDate, Remarks, AddedBy, UpdatedBy) VALUES (@TripID, @TripDate, @Remarks, @EditedBy, @EditedBy)";
        private const string UpdateSQL = "UPDATE Trips SET TripDate = @TripDate, Remarks = @Remarks, UpdatedBy = @EditedBy, UpdatedOn = @UpdatedOn WHERE TripID = @TripID";
        private const string DeleteSQL = "DELETE FROM Trips WHERE TripID = @TripID";

        public Trip(long nID, DateTime dtTripDate, string sRemarks)
        {
            ID = nID;
            TripDate = dtTripDate;
            Remarks = sRemarks;
        }

        public void Save()
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
                        // Must do the master save first. If this is an insert it
                        // will generate the ID that is then used in the local insert.
                        string sLocalSQL = ID > 0 ? UpdateSQL : InsertSQL;
                        SaveMaster(ref transMaster);
                        SaveLocal(ref transLocal, sLocalSQL);

                        transMaster.Commit();
                        transLocal.Commit();
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

        private void SaveLocal(ref SQLiteTransaction dbTrans, string sSQL)
        {
            System.Diagnostics.Debug.Assert(ID > 0, "The object should already have been saved to master which would generate the ID");
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("TripID", ID);
            dbCom.Parameters.AddWithValue("TripDate", TripDate);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);

            SQLiteParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
            if (string.IsNullOrEmpty(Remarks))
                pRemarks.Value = DBNull.Value;
            else
                pRemarks.Value = Remarks;

            dbCom.ExecuteNonQuery();
        }

        private long SaveMaster(ref MySqlTransaction dbTrans)
        {
            MySqlCommand dbCom = null;

            if (ID > 0)
            {
                dbCom = new MySqlCommand(UpdateSQL, dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue("TripID", ID);
            }
            else
            {
                dbCom = new MySqlCommand(InsertSQL, dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue("TripID", DBNull.Value);
            }

            dbCom.Parameters.AddWithValue("TripDate", TripDate);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            DBHelpers.MySQLHelpers.AddStringParameterN(ref dbCom, Remarks, "Remarks");

            dbCom.ExecuteNonQuery();

            ID = dbCom.LastInsertedId;
            System.Diagnostics.Debug.Assert(ID > 0, "The next code to execute is relying on there being a master ID at this point");
            return ID;
        }

        public static void Delete(long nID)
        {
            System.Diagnostics.Debug.Assert(nID > 0, "Should only attempt to delete an item that already has been inserted.");
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
                        MySqlCommand comMaster = new MySqlCommand(DeleteSQL, transMaster.Connection, transMaster);
                        comMaster.Parameters.AddWithValue("TripID", nID);
                        comMaster.ExecuteNonQuery();

                        SQLiteCommand comLocal = new SQLiteCommand(DeleteSQL, transLocal.Connection, transLocal);
                        comLocal.Parameters.AddWithValue("TripID", nID);
                        comLocal.ExecuteNonQuery();

                        transMaster.Commit();
                        transLocal.Commit();
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
}
