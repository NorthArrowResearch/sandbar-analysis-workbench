using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.AnalysisBins
{
    class AnalysisBinCRUD : DBHelpers.CRUDManager
    {
        public AnalysisBinCRUD()
            : base("AnalysisBins", "BinID", new string[] { "Title", "LowerDischarge", "UpperDischarge", "IsActive", "DisplayColor" })
        {

        }

        protected override void SaveLocal(ref SQLiteTransaction dbTrans, ref DBHelpers.DatabaseObject obj, string sSQL)
        {
            System.Diagnostics.Debug.Assert(obj.ID > 0, "The object should already have been saved to master which would generate the ID");
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            dbCom.Parameters.AddWithValue("IsActive", ((AnalysisBin)obj).IsActive);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            dbCom.Parameters.AddWithValue("DisplayColor", ((AnalysisBin)obj).DisplayColor);

            SQLiteParameter pLowerdischarge = dbCom.Parameters.Add("LowerDischarge", System.Data.DbType.Double);
            if (((AnalysisBin)obj).LowerDischarge.HasValue)
                pLowerdischarge.Value = ((AnalysisBin)obj).LowerDischarge;
            else
                pLowerdischarge.Value = DBNull.Value;

            SQLiteParameter pUpper = dbCom.Parameters.Add("UpperDischarge", System.Data.DbType.Double);
            if (((AnalysisBin)obj).UpperDischarge.HasValue)
                pUpper.Value = ((AnalysisBin)obj).UpperDischarge;
            else
                pLowerdischarge.Value = DBNull.Value;

            dbCom.ExecuteNonQuery();
        }

        protected override long SaveMaster(ref MySqlTransaction dbTrans, ref DBHelpers.DatabaseObject obj)
        {
            MySqlCommand dbCom = null;

            if (obj.ID > 0)
            {
                dbCom = new MySqlCommand(UpdateSQL, dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            }
            else
            {
                dbCom = new MySqlCommand(InsertSQL, dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue(PrimaryKey, DBNull.Value);
            }

            dbCom.Parameters.AddWithValue("IsActive", ((AnalysisBin)obj).IsActive);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            dbCom.Parameters.AddWithValue("DisplayColor", ((AnalysisBin)obj).DisplayColor);

            MySqlParameter pLowerdischarge = dbCom.Parameters.Add("LowerDischarge", MySqlDbType.Double);
            if (((AnalysisBin)obj).LowerDischarge.HasValue)
                pLowerdischarge.Value = ((AnalysisBin)obj).LowerDischarge.Value;
            else
                pLowerdischarge.Value = DBNull.Value;

            MySqlParameter pUpper = dbCom.Parameters.Add("UpperDischarge", MySqlDbType.Double);
            if (((AnalysisBin)obj).UpperDischarge.HasValue)
                pUpper.Value = ((AnalysisBin)obj).UpperDischarge.Value;
            else
                pUpper.Value = DBNull.Value;

            dbCom.ExecuteNonQuery();

            obj.ID = dbCom.LastInsertedId;
            System.Diagnostics.Debug.Assert(obj.ID > 0, "The next code to execute is relying on there being a master ID at this point");
            return obj.ID;
        }
    }
}
