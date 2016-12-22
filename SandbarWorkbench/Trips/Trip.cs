using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.Trips
{
    public class Trip : DBHelpers.LookupTableItem
    {
        public DateTime TripDate { get; internal set; }
        public string Remarks { get; internal set; }

        public Trip(long nID, DateTime dtTripDate, string sRemarks)
            : base(nID, "Trips", "TripID"
                  , "INSERT INTO Trips (TripID, TripDate, Remarks, AddedBy, UpdatedBy) VALUES (@TripID, @TripDate, @Remarks, @EditedBy, @EditedBy)"
                  , "UPDATE Trips SET TripDate = @TripDate, Remarks = @Remarks, UpdatedBy = @EditedBy, UpdatedOn = @UpdatedOn WHERE TripID = @TripID")
        {
            TripDate = dtTripDate;
            Remarks = sRemarks;
        }

        protected override void SaveLocal(ref SQLiteTransaction dbTrans, string sSQL)
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

        protected override long SaveMaster(ref MySqlTransaction dbTrans)
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

    }
}
