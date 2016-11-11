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

        public void Update(ModelRunLocal masterRun, ref MySqlTransaction dbTrans)
        {
            MySqlCommand dbCom = new MySqlCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("@Title", masterRun.Title);
            dbCom.Parameters.AddWithValue("@Remarks", masterRun.Remarks);
            dbCom.Parameters.AddWithValue("UpdatedOn", masterRun.UpdatedOn);
            dbCom.Parameters.AddWithValue("UpdatedBy", masterRun.UpdatedBy);
            dbCom.ExecuteNonQuery();

            Title = masterRun.Title;
            Remarks = masterRun.Remarks;
            UpdatedOn = masterRun.UpdatedOn;
            UpdatedBy = masterRun.UpdatedBy;
        }

        public static void Delete(long nMasterID, ref MySqlTransaction dbTrans)
        {
            MySqlCommand dbCom = new MySqlCommand("DELETE FROM ModelRuns WHERE MasterRunID = @MasterRunID", dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue("MasterRunID", nMasterID);
            //dbCom.ExecuteNonQuery();
            System.Diagnostics.Debug.Print("Master: " + dbCom.CommandText);
        }

        public static ModelRunMaster Insert(ModelRunLocal localRun, ref MySqlTransaction dbTrans)
        {
            System.Diagnostics.Debug.Assert(localRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash, "Only local runs should be inserted into master");

            MySqlCommand dbCom = new MySqlCommand("INSERT INTO ModelRuns (Title, Remarks, RunTypeID, AddedOn, AddedBy, InstallationGuid, UpdatedOn, UpdatedBy, RunOn, RunBy)" +
                " VALUES (@Title, @Remarks, @RunTypeID, @AddedOn, @AddedBy, @InstallationGuid, @UpdatedOn, @UpdatedBy, @RunOn, @RunBy)", dbTrans.Connection, dbTrans);

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

            ModelRunMaster theRun = new ModelRunMaster(dbCom.LastInsertedId, localRun.Title, localRun.Remarks, localRun.RunTypeID, localRun.Installation.ToString(), localRun.AddedOn
                , localRun.AddedBy, localRun.UpdatedOn, localRun.UpdatedBy, localRun.RunOn, localRun.RunBy);

            return theRun;
        }
    }
}
