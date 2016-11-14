using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.ModelRuns
{
    public class ModelRunMaster : ModelRunBase
    {
        public ModelRunMaster(long nMasterID, string sTitle, string sRemarks, long nRunTypeID, string sInstallation, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy, DateTime dtRunOn, string sRunBy)
                : base(nMasterID, sTitle, sRemarks, nRunTypeID, sInstallation, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy, dtRunOn, sRunBy)
        {

        }

        public static Dictionary<long, ModelRunMaster> Load()
        {
            Dictionary<long, ModelRunMaster> dRuns = new Dictionary<long, ModelRunMaster>();

            using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
            {
                dbCon.Open();
                MySqlCommand dbCom = new MySqlCommand("SELECT * FROM ModelRuns", dbCon);
                MySqlDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    string sRemarks = string.Empty;
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("Remarks")))
                        sRemarks = dbRead.GetString(dbRead.GetOrdinal("Remarks"));

                    long ID = dbRead.GetInt64(dbRead.GetOrdinal("MasterRunID"));

                    dRuns[ID] = new ModelRunMaster(
                        ID
                        , dbRead.GetString(dbRead.GetOrdinal("Title"))
                        , sRemarks
                        , dbRead.GetInt64(dbRead.GetOrdinal("RunTypeID"))
                        , dbRead.GetString(dbRead.GetOrdinal("InstallationGuid"))
                        , dbRead.GetDateTime(dbRead.GetOrdinal("AddedOn"))
                        , dbRead.GetString(dbRead.GetOrdinal("AddedBy"))
                        , dbRead.GetDateTime(dbRead.GetOrdinal("UpdatedOn"))
                        , dbRead.GetString(dbRead.GetOrdinal("UpdatedBy"))
                        , dbRead.GetDateTime(dbRead.GetOrdinal("RunOn"))
                        , dbRead.GetString(dbRead.GetOrdinal("RunBy"))
                        );
                }
            }

            return dRuns;
        }

        public void Update(ModelRunLocal localRun, ref MySqlTransaction dbTrans)
        {
            System.Diagnostics.Debug.Print("Updating MasterRunID {0} with LocalRunID {1}", localRun.MasterID, localRun.ID);

            MySqlCommand dbCom = new MySqlCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("@Title", localRun.Title);
            dbCom.Parameters.AddWithValue("@Remarks", localRun.Remarks);
            dbCom.Parameters.AddWithValue("UpdatedOn", localRun.UpdatedOn);
            dbCom.Parameters.AddWithValue("UpdatedBy", localRun.UpdatedBy);
            dbCom.ExecuteNonQuery();
        
            Title = localRun.Title;
            Remarks = localRun.Remarks;
            UpdatedOn = localRun.UpdatedOn;
            UpdatedBy = localRun.UpdatedBy;
        }

        public static void Delete(long nMasterID, ref MySqlTransaction dbTrans)
        {
            System.Diagnostics.Debug.Print("Deleting run on master with MasterID {0}", nMasterID);

            MySqlCommand dbCom = new MySqlCommand("DELETE FROM ModelRuns WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("MasterRunID", nMasterID);
            dbCom.ExecuteNonQuery();
        }

        public static ModelRunMaster Insert(ModelRunLocal localRun, ref MySqlTransaction transMaster, ref System.Data.SQLite.SQLiteTransaction transLocal)
        {
            System.Diagnostics.Debug.Print("Inserting local installation LocalRunID {0} onto master.", localRun.ID);

            System.Diagnostics.Debug.Assert(localRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash, "Only local runs should be inserted into master");

            MySqlCommand dbCom = new MySqlCommand("INSERT INTO ModelRuns (Title, Remarks, RunTypeID, AddedOn, AddedBy, InstallationGuid, UpdatedOn, UpdatedBy, RunOn, RunBy)" +
                " VALUES (@Title, @Remarks, @RunTypeID, @AddedOn, @AddedBy, @InstallationGuid, @UpdatedOn, @UpdatedBy, @RunOn, @RunBy)", transMaster.Connection, transMaster);

            dbCom.Parameters.AddWithValue("Title", localRun.Title);
            dbCom.Parameters.AddWithValue("RunTypeID", localRun.RunTypeID);
            dbCom.Parameters.AddWithValue("AddedOn", localRun.AddedOn);
            dbCom.Parameters.AddWithValue("AddedBy", localRun.AddedBy);
            dbCom.Parameters.AddWithValue("UpdatedOn", localRun.UpdatedOn);
            dbCom.Parameters.AddWithValue("UpdatedBy", localRun.UpdatedBy);
            dbCom.Parameters.AddWithValue("RunOn", localRun.RunOn);
            dbCom.Parameters.AddWithValue("RunBy", localRun.RunBy);

            if (string.IsNullOrEmpty(localRun.Remarks))
            {
                MySqlParameter pRemarks = dbCom.Parameters.Add("Remarks", MySqlDbType.String);
                pRemarks.Value = DBNull.Value;
            }
            else
                dbCom.Parameters.AddWithValue("Remarks", localRun.Remarks);

            dbCom.ExecuteNonQuery();
            long nMasterRunID = 0; // dbCom.LastInsertedId;

            ModelRunMaster theRun = new ModelRunMaster(nMasterRunID, localRun.Title, localRun.Remarks, localRun.RunTypeID, localRun.Installation.ToString(), localRun.AddedOn
                , localRun.AddedBy, localRun.UpdatedOn, localRun.UpdatedBy, localRun.RunOn, localRun.RunBy);

            // Update the local run with the new MasterID
            System.Data.SQLite.SQLiteCommand comLocal = new System.Data.SQLite.SQLiteCommand("UPDATE ModelRuns SET MasterRunID = @MasterRunID WHERE LocalRunID = @LocalRunID", transLocal.Connection, transLocal);
            comLocal.Parameters.AddWithValue("MasterRunID", theRun.ID);
            comLocal.Parameters.AddWithValue("LocalRunID", localRun.ID);
            comLocal.ExecuteNonQuery();

            // Now insert all the child records for this model run
            using (System.Data.SQLite.SQLiteConnection conLocal = new System.Data.SQLite.SQLiteConnection (DBCon.ConnectionStringLocal))
            {
                // Prepare the local command to insert child records
                dbCom = new MySqlCommand("INSERT INTO ModelResultsIncremental (RunID, SectionID, Elevation, Area, Volume) VALUES (@SectionID, @Elevation, @Area, @Volume)", transMaster.Connection, transMaster);
                dbCom.Parameters.AddWithValue("RunID", theRun.ID);
                MySqlParameter pSectionID = dbCom.Parameters.Add("SectionID", MySqlDbType.Int64);
                MySqlParameter pElevation = dbCom.Parameters.Add("Elevation", MySqlDbType.Double);
                MySqlParameter pArea = dbCom.Parameters.Add("Area", MySqlDbType.Double);
                MySqlParameter pVolume = dbCom.Parameters.Add("Volume", MySqlDbType.Double);

                conLocal.Open();
                comLocal = new System.Data.SQLite.SQLiteCommand("SELECT * FROM ModelResultsIncremental WHERE RunID = @RunID", conLocal);
                comLocal.Parameters.AddWithValue("RunID", localRun.ID);
                System.Data.SQLite.SQLiteDataReader readLocal = comLocal.ExecuteReader();
                while (readLocal.Read())
                {
                    pSectionID.Value = readLocal.GetInt64(readLocal.GetOrdinal("SectionID"));
                    pElevation.Value = readLocal.GetDouble(readLocal.GetOrdinal("Elevation"));
                    pArea.Value = readLocal.GetDouble(readLocal.GetOrdinal("Area"));
                    pVolume.Value = readLocal.GetDouble(readLocal.GetOrdinal("Volume"));
                    dbCom.ExecuteNonQuery();
                }
            }

            return theRun;
        }
    }
}
