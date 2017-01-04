using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using SandbarWorkbench.ModelRuns;

namespace SandbarWorkbench.DBHelpers
{
    class SyncHelpers
    {
        public string SchemaName { get; internal set; }
        public string MasterDBCon { get; internal set; }
        public string LocalDBCon { get; internal set; }

        public bool LookupTables { get; set; }
        public bool ModelRunTables { get; set; }

        public delegate void ProgressUpdate(int nOverall, int nTask);
        public event ProgressUpdate OnProgressUpdate;

        public List<string> Messages;

        public SyncHelpers(string sSchemaName, string sMasterDBCon, string sLocalDBCon)
        {
            Init(sSchemaName, sMasterDBCon, sLocalDBCon);
        }

        public SyncHelpers()
        {
            Init("SandbarData", DBCon.ConnectionStringMaster, DBCon.ConnectionStringLocal);
        }

        private void Init(string sSchemaName, string sMasterDBCon, string sLocalDBCon)
        {
            SchemaName = sSchemaName;
            MasterDBCon = sMasterDBCon;
            LocalDBCon = sLocalDBCon;

        }

        private void AddMessage(string sMessage, int nOverall, int nTask)
        {
            if (Messages == null)
                Messages = new List<string>();

            Messages.Add(sMessage);

            // If there's a subscribed event handler
            if (OnProgressUpdate != null)
                OnProgressUpdate(nOverall, nTask);
        }

        public void Synchronize()
        {
            Messages = new List<string>();
            AddMessage("Initializing database synchronization...", 0, 0);

            if (LookupTables)
                SynchronizeLookupTables();

            if (ModelRunTables)
                SynchronizeResults();

            AddMessage("Local database synchronization completed successfully.", 100, 100);
        }

        public void SynchronizeLookupTables()
        {
            AddMessage("Initializing lookup table synchronization...", 0, 0);

            using (MySqlConnection conMaster = new MySqlConnection(MasterDBCon))
            {
                conMaster.Open();

                // Retrieve the list of lookup tables that should be synced
                List<LookupTableDef> LookupTables = new List<LookupTableDef>();
                MySqlCommand dbCom = new MySqlCommand("SELECT TableName FROM TableChangeLog WHERE (Synchronize <> 0) ORDER BY Sequence", conMaster);
                MySqlDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                    LookupTables.Add(new LookupTableDef(dbRead.GetString("TableName")));
                dbRead.Close();

                using (SQLiteConnection conLocal = new SQLiteConnection(LocalDBCon))
                {
                    conLocal.Open();
                    SQLiteTransaction dbTrans = conLocal.BeginTransaction();

                    try
                    {
                        int nTable = 0;
                        foreach (LookupTableDef aTable in LookupTables)
                        {
                            nTable += 1;
                            int nTaskProgress = (int)Math.Ceiling(100.0 * (double)nTable / (double)LookupTables.Count);

                            // Load the last changed and field schema from both master and local. Then verify that the schemas match (will throw exception if fails)
                            aTable.RetrievePropertiesFromMaster(SchemaName, conMaster);
                            aTable.RetrievePropertiesFromLocal(conLocal);
                            aTable.VerifySchemasMatch();

                            // A sync is needed if the local has never been synced or the latest change date on master is newer than local
                            if (aTable.RequiresSync)
                            {
                                AddMessage(string.Format("\tSynchronizing lookup table {0}", aTable.TableName), 30, nTaskProgress);

                                if (SynchronizeLookupTable(conMaster, ref dbTrans, aTable))
                                {
                                    // Update the local TableChangeLog to reflect the update
                                    SQLiteCommand cLocal = new SQLiteCommand("UPDATE TableChangeLog SET UpdatedOn = @UpdatedOn WHERE TableName = @TableName", conLocal, dbTrans);
                                    cLocal.Parameters.AddWithValue("UpdatedOn", aTable.MasterLastChanged.Value);
                                    cLocal.Parameters.AddWithValue("TableName", aTable.TableName);
                                    if (cLocal.ExecuteNonQuery() != 1)
                                        throw new Exception("Error updating the TableChangeLog on local");
                                }
                            }
                            else
                            {
                                AddMessage(string.Format("\tNo updates for the {0} table. Skipping.", aTable.TableName), 30, nTaskProgress);
                            }
                        }

                        dbTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        AddMessage(string.Format("Error: {0}", ex.Message), -1, -1);
                        AddMessage("Local database rolled back. No changes committed.", -1, -1);
                        dbTrans.Rollback();
                        throw;
                    }
                }
            }

            AddMessage("Lookup table synchronization completed successfully.", 50, 100);
        }

        private bool SynchronizeLookupTable(MySqlConnection conMaster, ref SQLiteTransaction dbTrans, LookupTableDef aTable)
        {
            // Query for checking if row exists on master
            MySqlCommand cReadMaster = new MySqlCommand(string.Format("SELECT * FROM {0} WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), conMaster);
            MySqlParameter pMaster_PrimaryKey = cReadMaster.Parameters.Add(aTable.MasterPrimaryKey, MySqlDbType.Int64);

            SQLiteCommand comUpdateLocal = aTable.BuildUpdateCommand(ref dbTrans);

            // Query for deleting local rows
            SQLiteCommand comDeleteLocal = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
            SQLiteParameter pDelete_PrimaryKey = comDeleteLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.Int64);

            // Connection to read local rows (needs to be separate to the connection used to insert/update/delete rows)
            using (SQLiteConnection conReadLocal = new SQLiteConnection(LocalDBCon))
            {
                conReadLocal.Open();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 1 - loop over rows on local. Update them if they are newer on master and delete them if they don't exist on master

                // Loop over all rows in local table
                SQLiteCommand comReadLocal = new SQLiteCommand(string.Format("SELECT {0}, UpdatedOn FROM {1}", aTable.MasterPrimaryKey, aTable.TableName), conReadLocal);
                SQLiteDataReader readLocal = comReadLocal.ExecuteReader();
                while (readLocal.Read())
                {
                    pMaster_PrimaryKey.Value = readLocal.GetInt64(readLocal.GetOrdinal(aTable.MasterPrimaryKey));
                    MySqlDataReader dbReadMaster = cReadMaster.ExecuteReader();
                    if (dbReadMaster.Read())
                    {
                        // This row currently exists on both local and master. Check it's update date
                        if (dbReadMaster.GetDateTime("UpdatedOn") > readLocal.GetDateTime(readLocal.GetOrdinal("UpdatedOn")))
                        {
                            // The row on Master has been updated more recently than the row on local. Update local.
                            foreach (SQLiteParameter aParam in comUpdateLocal.Parameters)
                                aParam.Value = dbReadMaster[aParam.ParameterName];

                            aTable.LocalUpdates += comUpdateLocal.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // This row exists on local but not on master. Delete the local copy.
                        pDelete_PrimaryKey.Value = readLocal.GetInt64(readLocal.GetOrdinal(aTable.MasterPrimaryKey));
                        aTable.LocalDeletes += comDeleteLocal.ExecuteNonQuery();
                    }
                    dbReadMaster.Close();
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 2 - loop over rows on master. Insert them into local if their added on date is newer than the date that local was last updated.

                // Query to lookup a single row in local
                SQLiteCommand comSelectLocal = new SQLiteCommand(string.Format("SELECT {0} FROM {1} WHERE {0} = @{0}", aTable.MasterPrimaryKey, aTable.TableName), conReadLocal);
                SQLiteParameter pPrimaryKey = comSelectLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.Int64);

                // Prepared command to insert local records
                SQLiteCommand comInsertLocal = aTable.BuildInsertCommand(ref dbTrans);

                // Loop over rows in master and find those that are not in local.
                // Note that the UpdatedOn > @UpdatedOn is not strickly necessary, but it does help when old records on master are missing from local due to developer manual manipulation
                cReadMaster = new MySqlCommand(string.Format("SELECT * FROM {0} WHERE (AddedOn > @UpdatedOn) OR (UpdatedOn > @UpdatedOn)", aTable.TableName), conMaster);
                cReadMaster.Parameters.AddWithValue("@UpdatedOn", aTable.LocalLastChanged);
                MySqlDataReader dbReadMasterNew = cReadMaster.ExecuteReader();
                while (dbReadMasterNew.Read())
                {
                    pPrimaryKey.Value = dbReadMasterNew.GetInt64(aTable.MasterPrimaryKey);
                    object objPrimaryKey = comSelectLocal.ExecuteScalar();
                    if (objPrimaryKey == null)
                    {
                        // Insert missing row into local
                        foreach (SQLiteParameter aParam in comInsertLocal.Parameters)
                            aParam.Value = dbReadMasterNew[aParam.ParameterName];

                        aTable.LocalInserts += comInsertLocal.ExecuteNonQuery();
                    }
                }
                dbReadMasterNew.Close();

            }

            System.Diagnostics.Debug.Print("{0} inserts = {1}, updates = {2}, deletes = {3}", aTable.TableName, aTable.LocalInserts, aTable.LocalUpdates, aTable.LocalDeletes);
            return aTable.LocalChanges;
        }

        private void SynchronizeResults()
        {
            AddMessage("Initializing model run synchronization...", 51, 0);

            Dictionary<long, ModelRuns.ModelRunMaster> dMasterRuns = ModelRuns.ModelRunMaster.Load();
            Dictionary<long, ModelRuns.ModelRunLocal> dLocalRuns = ModelRuns.ModelRunLocal.Load();

            using (MySql.Data.MySqlClient.MySqlConnection conMaster = new MySql.Data.MySqlClient.MySqlConnection(DBCon.ConnectionStringMaster))
            {
                conMaster.Open();
                MySql.Data.MySqlClient.MySqlTransaction transMaster = conMaster.BeginTransaction();

                using (System.Data.SQLite.SQLiteConnection conLocal = new System.Data.SQLite.SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    conLocal.Open();
                    System.Data.SQLite.SQLiteTransaction transLocal = conLocal.BeginTransaction();

                    try
                    {
                        int nModelRun = 0;

                        // Loop over all runs on master
                        foreach (ModelRunMaster masterRun in dMasterRuns.Values)
                        {
                            nModelRun += 1;
                            int nTaskProgress = (int)Math.Ceiling(100.0 * (double)nModelRun / (double)(dMasterRuns.Count + dLocalRuns.Count));

                            if (masterRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash)
                            {
                                // Find the local run that has the corresponding master run ID
                                List<ModelRunLocal> lLocalRuns = dLocalRuns.Values.Where<ModelRunLocal>(x => x.MasterID == masterRun.ID).ToList<ModelRunLocal>();
                                if (lLocalRuns != null && lLocalRuns.Count > 0)
                                {
                                    // found the corresponding local run. Check if the local run is still set to sync.
                                    if (lLocalRuns[0].Sync)
                                    {
                                        // Check if either has been updated and then update the older of the two.
                                        if (lLocalRuns[0].UpdatedOn > masterRun.UpdatedOn)
                                        {
                                            AddMessage(string.Format("\tUpdating model run on master with ID {0}", lLocalRuns[0].MasterID), 75, nTaskProgress);
                                            masterRun.Update(lLocalRuns[0], ref transMaster);
                                        }
                                        else if (masterRun.UpdatedOn > lLocalRuns[0].UpdatedOn)
                                        {
                                            AddMessage(string.Format("\tUpdating local model run with master ID {0}", masterRun.ID), 75, nTaskProgress);
                                            lLocalRuns[0].Update(masterRun, ref transLocal);
                                        }
                                    }
                                    else
                                    {
                                        // Run owned by this installation exists on both master and local, but the local is set to not sync. Delete on master.
                                        AddMessage(string.Format("\tRemoving model run on master with ID {0}", masterRun.ID), 75, nTaskProgress);
                                        ModelRunMaster.Delete(masterRun.ID, ref transMaster);
                                    }
                                }
                                else
                                {
                                    // Run belonging to this installation is on master but no longer on local. Delete on master
                                    AddMessage(string.Format("\tRemoving model run on master with ID {0}", masterRun.ID), 75, nTaskProgress);
                                    ModelRunMaster.Delete(masterRun.ID, ref transMaster);
                                }
                            }
                            else
                            {
                                List<ModelRunLocal> lLocalRuns = dLocalRuns.Values.Where<ModelRunLocal>(x => x.MasterID == masterRun.ID).ToList<ModelRunLocal>();
                                if (lLocalRuns.Count < 1)
                                {
                                    // Run found on master that belongs to another installation and doesn't exist on local. Insert to local.
                                    AddMessage(string.Format("\tDownloading model run with ID {0}", masterRun.ID), 75, nTaskProgress);
                                    ModelRunLocal.Insert(masterRun, ref transLocal);
                                }
                                else
                                {
                                    // Run found on master that belongs to another installation that already exists on local. Update.
                                    // Check if either has been updated and then update the older of the two.
                                    if (lLocalRuns[0].UpdatedOn > masterRun.UpdatedOn)
                                    {
                                        AddMessage(string.Format("\tUpdating model run on master with ID {0}", lLocalRuns[0].MasterID), 75, nTaskProgress);
                                        masterRun.Update(lLocalRuns[0], ref transMaster);
                                    }
                                    else if (masterRun.UpdatedOn > lLocalRuns[0].UpdatedOn)
                                    {
                                        AddMessage(string.Format("\tUpdating local model run with master ID {0}", masterRun.ID), 75, nTaskProgress);
                                        lLocalRuns[0].Update(masterRun, ref transLocal);
                                    }
                                }

                            }
                        }

                        // Loop over all rows on local
                        foreach (ModelRunLocal localRun in dLocalRuns.Values)
                        {
                            nModelRun += 1;
                            int nTaskProgress = (int)Math.Ceiling(100.0 * (double)nModelRun / (double)(dMasterRuns.Count + dLocalRuns.Count));

                            if (localRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash)
                            {
                                if (localRun.Sync)
                                {
                                    if (!dMasterRuns.ContainsKey(localRun.MasterID))
                                    {
                                        // This run was generated on this installation, its set to sync, but it is missing from master. Insert run to master.
                                        AddMessage(string.Format("\tUploading model run with ID {0}", localRun.ID), 90, nTaskProgress);
                                        ModelRunMaster.Insert(localRun, ref transMaster, ref transLocal);
                                    }
                                }
                                else
                                {
                                    if (dMasterRuns.ContainsKey(localRun.MasterID))
                                    {
                                        // This run was generated on this installation and exists on master, but it is no longer set to sync. Delete on master.
                                        // This use case should be handled above during the looping over all master runs
                                        //ModelRunMaster.Delete(localRun.MasterID, ref transMaster);
                                    }
                                }
                            }
                            else
                            {
                                if (!dMasterRuns.ContainsKey(localRun.MasterID))
                                {
                                    // This is a run from a different installation that no longer exists on master. Delete local.
                                    AddMessage(string.Format("\tRemoving local model run with ID {0}", localRun.MasterID), 90, nTaskProgress);
                                    ModelRunLocal.Delete(localRun.MasterID, ref transLocal);
                                }
                            }
                        }

                        transLocal.Commit();
                        transMaster.Commit();
                        AddMessage("Model runs synchronized successfully.", 90, 100);
                    }
                    catch (Exception ex)
                    {
                        AddMessage(string.Format("ERROR: {0}", ex.Message), -1, -1);
                        transLocal.Rollback();
                        transMaster.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
