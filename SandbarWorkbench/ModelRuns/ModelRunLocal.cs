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
        public System.IO.DirectoryInfo AnalysisFolder { get; internal set; }

        public ModelRunLocal(long nID, string sTitle, bool bSync, string sRemarks, long nRunTypeID, bool bPublished, string sInstallation, string sAnalysisFolder, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy, DateTime dtRunOn, string sRunBy)
                : base(nID, sTitle, sRemarks, nRunTypeID, bPublished, sInstallation, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy, dtRunOn, sRunBy)
        {
            AnalysisFolder = null;
            if (!string.IsNullOrEmpty(sAnalysisFolder) && System.IO.Directory.Exists(sAnalysisFolder))
                AnalysisFolder = new System.IO.DirectoryInfo(sAnalysisFolder);
        }

        //public void Update(ModelRunMaster masterRun, ref SQLiteTransaction dbTrans)
        //{
        //    System.Diagnostics.Debug.Print("Updating LocalRunID {0} with with MasterID {1}", ID, masterRun.ID);

        //    SQLiteCommand dbCom = new SQLiteCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
        //    dbCom.Parameters.AddWithValue("@Title", masterRun.Title);
        //    dbCom.Parameters.AddWithValue("UpdatedOn", masterRun.UpdatedOn);
        //    dbCom.Parameters.AddWithValue("UpdatedBy", masterRun.UpdatedBy);
        //    dbCom.Parameters.AddWithValue("MasterRunID", masterRun.ID);

        //    if (string.IsNullOrEmpty(masterRun.Remarks))
        //    {
        //        SQLiteParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
        //        pRemarks.Value = DBNull.Value;
        //    }
        //    else
        //        dbCom.Parameters.AddWithValue("Remarks", masterRun.Remarks);

        //    dbCom.ExecuteNonQuery();

        //    Title = masterRun.Title;
        //    Remarks = masterRun.Remarks;
        //    UpdatedOn = masterRun.UpdatedOn;
        //    UpdatedBy = masterRun.UpdatedBy;
        //}

        public static Dictionary<long, ModelRunLocal> Load(long nLocalModelRunID = 0)
        {
            Dictionary<long, ModelRunLocal> dRuns = new Dictionary<long, ModelRunLocal>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = null;

                if (nLocalModelRunID > 0)
                {
                    dbCom = new SQLiteCommand("SELECT * FROM ModelRuns WHERE LocalRunID = @LocalRunID ORDER BY RunOn DESC", dbCon);
                    dbCom.Parameters.AddWithValue("LocalRunID", nLocalModelRunID);
                }
                else
                    dbCom = new SQLiteCommand("SELECT * FROM ModelRuns ORDER BY RunOn DESC", dbCon);

                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nMasterID = 0;
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("MasterRunID")))
                        nMasterID = dbRead.GetInt64(dbRead.GetOrdinal("MasterRunID"));

                    long ID = dbRead.GetInt64(dbRead.GetOrdinal("LocalRunID"));

                    dRuns[ID] = new ModelRunLocal(
                        ID
                        , dbRead.GetString(dbRead.GetOrdinal("Title"))
                        , dbRead.GetBoolean(dbRead.GetOrdinal("Sync"))
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Remarks")
                        , dbRead.GetInt64(dbRead.GetOrdinal("RunTypeID"))
                        , dbRead.GetBoolean(dbRead.GetOrdinal("Published"))
                        , dbRead.GetString(dbRead.GetOrdinal("InstallationGuid"))
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AnalysisFolder")
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

        public static ModelRunLocal LoadSingle(long nLocalModelRunID)
        {
            Dictionary<long, ModelRunLocal> dRuns = Load();
            return dRuns[nLocalModelRunID];
        }

        public static void Delete(long id, ref SQLiteTransaction dbTrans)
        {
            System.Diagnostics.Debug.Print("Deleting run on local with ID {0}", id);

            SQLiteCommand dbCom = new SQLiteCommand("DELETE FROM ModelRuns WHERE LocalRunID = @LocalRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("LocalRunID", id);
            dbCom.ExecuteNonQuery();
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
        public void Update(ref SQLiteTransaction dbTrans, string sTitle, string sRemarks)
        {
            System.Diagnostics.Debug.Print("Updating LocalRunID {0}", ID);

            SQLiteCommand dbCom = new SQLiteCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy WHERE LocalRunID = @LocalRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("LocalRunID", ID);
            dbCom.Parameters.AddWithValue("Title", sTitle);
            naru.db.sqlite.SQLiteHelpers.AddStringParameterN(ref dbCom, sRemarks, "Remarks");
            dbCom.Parameters.AddWithValue("UpdatedOn", DateTime.Now);
            dbCom.Parameters.AddWithValue("UpdatedBy", Environment.UserName);

            dbCom.ExecuteNonQuery();

            Title = sTitle;
            Remarks = sRemarks;
            UpdatedOn = DateTime.Now;
            UpdatedBy = UpdatedBy;
        }
    }
}
