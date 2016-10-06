using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.DBHelpers
{
    class SyncHelpers
    {
        public string MasterDBCon { get; internal set; }
        public string LocalDBCon { get; internal set; }

        public SyncHelpers(string sMasterDBCon, string sLocalDBCon)
        {
            MasterDBCon = sMasterDBCon;
            LocalDBCon = sLocalDBCon;
        }

        public void SyncLookupData()
        {
            using (MySqlConnection conMaster = new MySqlConnection(MasterDBCon))
            {
                conMaster.Open();

                using (SQLiteConnection conLocal = new SQLiteConnection(LocalDBCon))
                {
                    conLocal.Open();

                    DateTime dtLastLocalUpdate;

                    LookupDataVersion masterVersion = DBHelpers.MySQLHelpers.GetMasterLookupDataVersion();
                    LookupDataVersion localVersion = DBHelpers.SQLiteHelpers.GetLocalLookupDataVersion(DBCon.ConnectionString.Replace("workbench.sqlite", "SandbarTest.sqlite"));

                    if (masterVersion.MHashID > localVersion.MHashID)
                    {
                        SQLiteTransaction dbTrans = conLocal.BeginTransaction();

                        try
                        {
                            Step01_DeleteOldData(conMaster, ref dbTrans, localVersion.AddedOn);

                            // Update the local lookup data versions to reflect the update

                            // Prepared Query to insert rows into local
                            SQLiteCommand comLocalVersions = new SQLiteCommand("INSERT INTO LookupDataVersions (MHashID, AddedOn, AddedBy, InstallationHash) VALUES (@MHashID, @AddedOn, @AddedBy, @InstallationHash)", conLocal, dbTrans);
                            SQLiteParameter pMHasHID = comLocalVersions.Parameters.Add("@MHashID", System.Data.DbType.Int64);
                            SQLiteParameter pAddedOn = comLocalVersions.Parameters.Add("@AddedOn", System.Data.DbType.DateTime);
                            SQLiteParameter pAddedBy = comLocalVersions.Parameters.Add("@AddedBy", System.Data.DbType.String);
                            SQLiteParameter pInstallationHash = comLocalVersions.Parameters.Add("@InstallationHash", System.Data.DbType.String);

                            // Loop over all the newer update versions in master 
                            MySqlCommand comMasterVersions = new MySqlCommand("SELECT MHashID, AddedOn, AddedBy, InstallationHash FROM LookupDataVersions WHERE AddedOn > @UpdatedOn ORDER BY AddedOn", conMaster);
                            comMasterVersions.Parameters.AddWithValue("UpdatedOn", localVersion.AddedOn);
                            MySqlDataReader readMaster = comMasterVersions.ExecuteReader();
                            while (readMaster.Read())
                            {
                                pMHasHID.Value = readMaster.GetInt64("MHashID");
                                pAddedOn.Value = readMaster.GetDateTime("AddedOn");
                                pAddedBy.Value = readMaster.GetString("AddedBy");
                                pInstallationHash.Value = readMaster.GetString("InstallationHash");
                                comLocalVersions.ExecuteNonQuery();
                            }

                            dbTrans.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbTrans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        private DatabaseChanges Step01_DeleteOldData(MySqlConnection conMaster, ref SQLiteTransaction dbTrans, DateTime dtLocalLastUpdatedOn)
        {
            DatabaseChanges changeCounter = new DatabaseChanges();

            // Query for checking if row exists on master
            MySqlCommand cReadMaster = new MySqlCommand("SELECT * FROM Sites WHERE MSiteID = @MSiteID", conMaster);
            MySqlParameter pMaster_MSiteID = cReadMaster.Parameters.Add("@MSiteID", MySqlDbType.Int64);

            // Query for updating local rows
            SQLiteCommand comUpdateLocal = new SQLiteCommand("UPDATE Sites SET UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy, Title = @Title WHERE MSiteID = @MSiteID", dbTrans.Connection, dbTrans);
            SQLiteParameter pUpdate_UpdatedOn = comUpdateLocal.Parameters.Add("@UpdatedOn", System.Data.DbType.DateTime);
            SQLiteParameter pUpdate_UpdatedBy = comUpdateLocal.Parameters.Add("@UpdatedBy", System.Data.DbType.String);
            SQLiteParameter pUpdate_Title = comUpdateLocal.Parameters.Add("@Title", System.Data.DbType.String);
            SQLiteParameter pUpdate_MSiteID = comUpdateLocal.Parameters.Add("@MSiteID", System.Data.DbType.UInt64);

            // Query for deleting local rows
            SQLiteCommand comDeleteLocal = new SQLiteCommand("DELETE FROM Sites WHERE MSiteID = @MSiteID", dbTrans.Connection, dbTrans);
            SQLiteParameter pDelete_MSiteID = comDeleteLocal.Parameters.Add("@MSiteID", System.Data.DbType.Int64);

            // Connection to read local rows (needs to be separate to the connection used to insert/update/delete rows)
            using (SQLiteConnection conReadLocal = new SQLiteConnection(LocalDBCon))
            {
                conReadLocal.Open();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 1 - loop over rows on local. Update them if they are newer on master and delete them if they don't exist on master

                // Loop over all rows in local table
                SQLiteCommand comReadLocal = new SQLiteCommand("SELECT MSiteID, UpdatedOn FROM Sites", conReadLocal);
                SQLiteDataReader readLocal = comReadLocal.ExecuteReader();
                while (readLocal.Read())
                {
                    pMaster_MSiteID.Value = readLocal.GetInt64(readLocal.GetOrdinal("MSiteID"));
                    MySqlDataReader dbReadMaster = cReadMaster.ExecuteReader();
                    if (dbReadMaster.Read())
                    {
                        // This row currently exists on both local and master. Check it's update date
                        if (dbReadMaster.GetDateTime("UpdatedOn") > readLocal.GetDateTime(readLocal.GetOrdinal("UpdatedOn")))
                        {
                            // The row on Master has been updated more recently than the row on local. Update local.
                            pUpdate_UpdatedOn.Value = dbReadMaster.GetDateTime("UpdatedOn");
                            pUpdate_UpdatedBy.Value = dbReadMaster.GetString("UpdatedBy");
                            pUpdate_Title.Value = dbReadMaster.GetString("Title");
                            pUpdate_MSiteID.Value = dbReadMaster.GetInt64("MSiteID");
                            changeCounter.Updated += comUpdateLocal.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // This row exists on local but not on master. Delete the local copy.
                        pDelete_MSiteID.Value =readLocal.GetInt64( readLocal.GetOrdinal("MSiteID"));
                       changeCounter.Deleted += comDeleteLocal.ExecuteNonQuery();
                    }
                    dbReadMaster.Close();
                }
                
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 2 - loop over rows on master. Insert them into local if their added on date is newer than the date that local was last updated.
                
                // Query to lookup a single row in local
                SQLiteCommand comSelectLocal = new SQLiteCommand("SELECT MSiteID FROM SITES WHERE MSiteID = @MSiteID", conReadLocal);
                SQLiteParameter pMSiteID = comSelectLocal.Parameters.Add("@MSiteID", System.Data.DbType.Int64);

                // Prepared command to insert local records
                SQLiteCommand comInsertLocal = new SQLiteCommand("INSERT INTO Sites (MSiteID, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (@MSiteID, @Title, @AddedOn, @AddedBy, @UpdatedOn, @UpdatedBy)", dbTrans.Connection, dbTrans);
                SQLiteParameter pInsert_MSiteID = comInsertLocal.Parameters.Add("@MSiteID", System.Data.DbType.UInt64);
                SQLiteParameter pInsert_Title = comInsertLocal.Parameters.Add("@Title", System.Data.DbType.String);
                SQLiteParameter pInsert_AddedOn = comInsertLocal.Parameters.Add("@AddedOn", System.Data.DbType.DateTime);
                SQLiteParameter pInsert_AddedBy = comInsertLocal.Parameters.Add("@AddedBy", System.Data.DbType.String);
                SQLiteParameter pInsert_UpdatedOn = comInsertLocal.Parameters.Add("@UpdatedOn", System.Data.DbType.DateTime);
                SQLiteParameter pInsert_UpdatedBy = comInsertLocal.Parameters.Add("@UpdatedBy", System.Data.DbType.String);

                // Loop over rows in master and find those that 
                cReadMaster = new MySqlCommand("SELECT * FROM Sites WHERE AddedOn > @UpdatedOn", conMaster);
                cReadMaster.Parameters.AddWithValue("@UpdatedOn", dtLocalLastUpdatedOn);
                MySqlDataReader dbReadMasterNew = cReadMaster.ExecuteReader();
                while (dbReadMasterNew.Read())
                {
                    pMSiteID.Value = dbReadMasterNew.GetInt64("MSiteID");
                    object objSiteID = comSelectLocal.ExecuteScalar();
                    if (objSiteID == null)
                    {
                        // Insert missing row into local
                        pInsert_MSiteID.Value = dbReadMasterNew.GetInt64("MSiteID");
                        pInsert_Title.Value = dbReadMasterNew.GetString("Title");
                        pInsert_AddedOn.Value = dbReadMasterNew.GetDateTime("AddedOn");
                        pInsert_AddedBy.Value = dbReadMasterNew.GetString("AddedBy");
                        pInsert_UpdatedOn.Value = dbReadMasterNew.GetDateTime("UpdatedOn");
                        pInsert_UpdatedBy.Value = dbReadMasterNew.GetString("UpdatedBy");
                       changeCounter.Inserted += comInsertLocal.ExecuteNonQuery();
                    }
                }
                dbReadMasterNew.Close();

            }

            System.Diagnostics.Debug.Print(changeCounter.ToString());
            return changeCounter;
        }

        public class DatabaseChanges
        {
            public int Inserted { get; set; }
            public int Updated { get; set; }
            public int Deleted { get; set; }

            public DatabaseChanges()
            {
                Inserted = 0;
                Updated = 0;
                Deleted = 0;
            }

            public override string ToString()
            {
                return string.Format("{0} Inserted, {1} Updated, {2} Deleted",Inserted,Updated, Deleted);
            }
        }

    }
}
