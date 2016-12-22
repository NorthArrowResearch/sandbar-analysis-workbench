using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.DBHelpers
{
    public abstract class CRUDManager
    {
        public string DBTable { get; internal set; }
        public string PrimaryKey { get; internal set; }

        protected static string InsertSQL { get; set; }
        protected static string UpdateSQL { get; set; }
        
        public CRUDManager(string sDBTable, string sPrimaryKey, string sInsertSQL, string sUpdateSQL)
        {
            DBTable = sDBTable;
            PrimaryKey = sPrimaryKey;
            InsertSQL = sInsertSQL;
            UpdateSQL = sUpdateSQL;
        }

        protected abstract void SaveLocal(ref SQLiteTransaction dbTrans, ref DatabaseObject obj, string sSQL);
        protected abstract long SaveMaster(ref MySqlTransaction dbTrans , ref DatabaseObject obj);

        public void Save(ref DatabaseObject obj)
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
                        string sLocalSQL = obj.ID > 0 ? UpdateSQL : InsertSQL;
                        SaveMaster(ref transMaster, ref obj);
                        SaveLocal(ref transLocal, ref obj, sLocalSQL);

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
        
        public void Delete(long nID)
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
                        string sDeleteSQL = string.Format("DELETE FROM {0} WHERE {1} = @{1}", DBTable, PrimaryKey);
                        MySqlCommand comMaster = new MySqlCommand(sDeleteSQL, transMaster.Connection, transMaster);
                        comMaster.Parameters.AddWithValue(PrimaryKey, nID);
                        comMaster.ExecuteNonQuery();

                        SQLiteCommand comLocal = new SQLiteCommand(sDeleteSQL, transLocal.Connection, transLocal);
                        comLocal.Parameters.AddWithValue(PrimaryKey, nID);
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
