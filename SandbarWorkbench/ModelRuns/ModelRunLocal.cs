using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.ModelRuns
{
    public class ModelRunLocal : ModelRunBase
    {
        public long MasterID { get; internal set; }
        public bool Sync { get; internal set; }
        public System.IO.DirectoryInfo AnalysisFolder { get; internal set; }

        public ModelRunLocal(long nID, long nMasterID, string sTitle, bool bSync, string sRemarks, long nRunTypeID, string sInstallation, string sAnalysisFolder, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy, DateTime dtRunOn, string sRunBy)
                : base(nID, sTitle, sRemarks, nRunTypeID, sInstallation, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy, dtRunOn, sRunBy)
        {
            MasterID = nMasterID;
            Sync = bSync;

            AnalysisFolder = null;
            if (!string.IsNullOrEmpty(sAnalysisFolder) && System.IO.Directory.Exists(sAnalysisFolder))
                AnalysisFolder = new System.IO.DirectoryInfo(sAnalysisFolder);
        }

        public void Update(ModelRunMaster masterRun, ref SQLiteTransaction dbTrans)
        {
            System.Diagnostics.Debug.Print("Updating LocalRunID {0} with with MasterID {1}", ID, masterRun.ID);

            SQLiteCommand dbCom = new SQLiteCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("@Title", masterRun.Title);
            dbCom.Parameters.AddWithValue("UpdatedOn", masterRun.UpdatedOn);
            dbCom.Parameters.AddWithValue("UpdatedBy", masterRun.UpdatedBy);
            dbCom.Parameters.AddWithValue("MasterRunID", masterRun.ID);

            if (string.IsNullOrEmpty(masterRun.Remarks))
            {
                SQLiteParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
                pRemarks.Value = DBNull.Value;
            }
            else
                dbCom.Parameters.AddWithValue("Remarks", masterRun.Remarks);

            dbCom.ExecuteNonQuery();

            Title = masterRun.Title;
            Remarks = masterRun.Remarks;
            UpdatedOn = masterRun.UpdatedOn;
            UpdatedBy = masterRun.UpdatedBy;
        }

        public static Dictionary<long, ModelRunLocal> Load()
        {
            Dictionary<long, ModelRunLocal> dRuns = new Dictionary<long, ModelRunLocal>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM ModelRuns ORDER BY RunOn DESC", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nMasterID = 0;
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("MasterRunID")))
                        nMasterID = dbRead.GetInt64(dbRead.GetOrdinal("MasterRunID"));

                    long ID = dbRead.GetInt64(dbRead.GetOrdinal("LocalRunID"));

                    dRuns[ID] = new ModelRunLocal(
                        ID
                        , nMasterID
                        , dbRead.GetString(dbRead.GetOrdinal("Title"))
                        , dbRead.GetBoolean(dbRead.GetOrdinal("Sync"))
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Remarks")
                        , dbRead.GetInt64(dbRead.GetOrdinal("RunTypeID"))
                        , dbRead.GetString(dbRead.GetOrdinal("InstallationGuid"))
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AnalysisFolder")
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

        public static void Delete(long nMasterID, ref SQLiteTransaction dbTrans)
        {
            System.Diagnostics.Debug.Print("Deleting run on local with master ID {0}", nMasterID);

            SQLiteCommand dbCom = new SQLiteCommand("DELETE FROM ModelRuns WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("MasterRunID", nMasterID);
            dbCom.ExecuteNonQuery();
        }

        public static ModelRunLocal Insert(ModelRunMaster masterRun, ref SQLiteTransaction dbTrans)
        {
            System.Diagnostics.Debug.Print("Inserting run onto local with MasterRunID {0}", masterRun.ID);
            System.Diagnostics.Debug.Assert(masterRun.Installation != SandbarWorkbench.Properties.Settings.Default.InstallationHash, "Shouldn't be able to insert runs from master that were generated on this computer");

            SQLiteCommand dbCom = new SQLiteCommand("INSERT INTO ModelRuns (MasterRunID, Title, Sync, Remarks, RunTypeID, AddedOn, AddedBy, InstallationGuid, UpdatedOn, UpdatedBy, RunOn, RunBy)" +
                " VALUES (@MasterRunID, @Title, 1, @Remarks, @RunTypeID, @AddedOn, @AddedBy, @InstallationGuid, @UpdatedOn, @UpdatedBy, @RunOn, @RunBy)", dbTrans.Connection, dbTrans);

            dbCom.Parameters.AddWithValue("MasterRunID", masterRun.ID);
            dbCom.Parameters.AddWithValue("Title", masterRun.Title);
            dbCom.Parameters.AddWithValue("RunTypeID", masterRun.RunTypeID);
            dbCom.Parameters.AddWithValue("AddedOn", masterRun.AddedOn);
            dbCom.Parameters.AddWithValue("AddedBy", masterRun.AddedBy);
            dbCom.Parameters.AddWithValue("InstallationGuid", masterRun.Installation.ToString());
            dbCom.Parameters.AddWithValue("UpdatedOn", masterRun.UpdatedOn);
            dbCom.Parameters.AddWithValue("UpdatedBy", masterRun.UpdatedBy);
            dbCom.Parameters.AddWithValue("RunOn", masterRun.RunOn);
            dbCom.Parameters.AddWithValue("RunBy", masterRun.RunBy);

            if (string.IsNullOrEmpty(masterRun.Remarks))
            {
                SQLiteParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
                pRemarks.Value = DBNull.Value;
            }
            else
                dbCom.Parameters.AddWithValue("Remarks", masterRun.Remarks);
            
            dbCom.ExecuteNonQuery();

            dbCom = new SQLiteCommand("SELECT last_insert_rowid()", dbTrans.Connection, dbTrans);
            Int64 nLocalRunID = (Int64)dbCom.ExecuteScalar();

            ModelRunLocal theRun = new ModelRunLocal(nLocalRunID, masterRun.ID, masterRun.Title, true, masterRun.Remarks, masterRun.RunTypeID, masterRun.Installation.ToString(), string.Empty,  masterRun.AddedOn
                , masterRun.AddedBy, masterRun.UpdatedOn, masterRun.UpdatedBy, masterRun.RunOn, masterRun.RunBy);

            // Now insert all the child records for this model run
            using (MySql.Data.MySqlClient.MySqlConnection conMaster = new MySql.Data.MySqlClient.MySqlConnection(DBCon.ConnectionStringMaster))
            {
                // Prepare the local command to insert child records
                dbCom = new SQLiteCommand("INSERT INTO ModelResultsIncremental (RunID, SectionID, Elevation, Area, Volume) VALUES (@RunID, @SectionID, @Elevation, @Area, @Volume)", dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue("RunID", theRun.ID);
                SQLiteParameter pSectionID = dbCom.Parameters.Add("SectionID", System.Data.DbType.Int64);
                SQLiteParameter pElevation = dbCom.Parameters.Add("Elevation", System.Data.DbType.Double);
                SQLiteParameter pArea = dbCom.Parameters.Add("Area", System.Data.DbType.Double);
                SQLiteParameter pVolume = dbCom.Parameters.Add("Volume", System.Data.DbType.Double);

                conMaster.Open();
                MySql.Data.MySqlClient.MySqlCommand comMaster = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM ModelResultsIncremental WHERE RunID = @RunID", conMaster);
                comMaster.Parameters.AddWithValue("RunID", masterRun.ID);
                MySql.Data.MySqlClient.MySqlDataReader readMaster = comMaster.ExecuteReader();
                while (readMaster.Read())
                {
                    pSectionID.Value = readMaster.GetInt64("SectionID");
                    pElevation.Value = readMaster.GetDouble("Elevation");
                    pArea.Value = readMaster.GetDouble("Area");
                    pVolume.Value = readMaster.GetDouble("Volume");
                    dbCom.ExecuteNonQuery();
                }
            }

            return theRun;
        }

        /// <summary>
        /// Update run on the local DB
        /// </summary>
        /// <param name="dbTrans"></param>
        /// <param name="sTitle"></param>
        /// <param name="sRemarks"></param>
        /// <param name="bSync"></param>
        /// <remarks>This version of the update is called by the workbench user interface forms
        /// to save changes made through the UI to the local DB. Note that this method should
        /// be accompanied by similar updates to the master DB - especially based on whether the
        /// local run is still to be synced!</remarks>
        public void Update(ref SQLiteTransaction dbTrans, string sTitle, string sRemarks, bool bSync)
        {
            System.Diagnostics.Debug.Print("Updating LocalRunID {0} with with MasterID {1}", ID, MasterID);

            SQLiteCommand dbCom = new SQLiteCommand("UPDATE ModelRuns SET Title = @Title, Sync = @Sync, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy, MasterRunID = @MasterRunID WHERE LocalRunID = @LocalRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("@Title", sTitle);
            dbCom.Parameters.AddWithValue("Sync", bSync);
            DBHelpers.SQLiteHelpers.AddStringParameterN(ref dbCom, sRemarks, "Remarks");
            dbCom.Parameters.AddWithValue("UpdatedOn", DateTime.Now);
            dbCom.Parameters.AddWithValue("UpdatedBy", Environment.UserName);

            SQLiteParameter pMasterRunID = dbCom.Parameters.Add("Sync", System.Data.DbType.Boolean);
            if (bSync)
                pMasterRunID.Value = MasterID;
            else
                pMasterRunID.Value = DBNull.Value;

            dbCom.ExecuteNonQuery();

            Title = sTitle;
            Remarks = sRemarks;
            Sync = bSync;
            UpdatedOn = DateTime.Now;
            UpdatedBy = UpdatedBy;
        }
    }
}
