using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.ModelRuns
{
    public class ModelRunMaster : ModelRunBase
    {
        public ModelRunMaster(long nMasterID, string sTitle, string sRemarks, long nRunTypeID, bool bPublished, string sInstallation, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy, DateTime dtRunOn, string sRunBy)
                : base(nMasterID, sTitle, sRemarks, nRunTypeID, bPublished, sInstallation, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy, dtRunOn, sRunBy)
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
                        , dbRead.GetBoolean(dbRead.GetOrdinal("Published"))
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
            dbCom.Parameters.AddWithValue("UpdatedOn", localRun.UpdatedOn);
            dbCom.Parameters.AddWithValue("UpdatedBy", localRun.UpdatedBy);
            dbCom.Parameters.AddWithValue("MasterRunID", localRun.MasterID);

            if (string.IsNullOrEmpty(localRun.Remarks))
            {
                MySqlParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
                pRemarks.Value = DBNull.Value;
            }
            else
                dbCom.Parameters.AddWithValue("Remarks", localRun.Remarks);

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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            System.Diagnostics.Debug.Print("Inserting local installation LocalRunID {0} onto master.", localRun.ID);

            System.Diagnostics.Debug.Assert(localRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash, "Only local runs should be inserted into master");

            MySqlCommand dbCom = new MySqlCommand("INSERT INTO ModelRuns (Title, Remarks, RunTypeID, AddedOn, AddedBy, InstallationGuid, UpdatedOn, UpdatedBy, RunOn, RunBy)" +
                " VALUES (@Title, @Remarks, @RunTypeID, @AddedOn, @AddedBy, @InstallationGuid, @UpdatedOn, @UpdatedBy, @RunOn, @RunBy)", transMaster.Connection, transMaster);

            dbCom.Parameters.AddWithValue("Title", localRun.Title);
            dbCom.Parameters.AddWithValue("RunTypeID", localRun.RunTypeID);
            dbCom.Parameters.AddWithValue("AddedOn", localRun.AddedOn);
            dbCom.Parameters.AddWithValue("AddedBy", localRun.AddedBy);
            dbCom.Parameters.AddWithValue("InstallationGuid", localRun.Installation);
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
            long nMasterRunID = dbCom.LastInsertedId;

            ModelRunMaster theRun = new ModelRunMaster(nMasterRunID, localRun.Title, localRun.Remarks, localRun.RunTypeID, localRun.Published, localRun.Installation.ToString(), localRun.AddedOn
                , localRun.AddedBy, localRun.UpdatedOn, localRun.UpdatedBy, localRun.RunOn, localRun.RunBy);

            // Update the local run with the new MasterID
            System.Data.SQLite.SQLiteCommand comLocal = new System.Data.SQLite.SQLiteCommand("UPDATE ModelRuns SET MasterRunID = @MasterRunID WHERE LocalRunID = @LocalRunID", transLocal.Connection, transLocal);
            comLocal.Parameters.AddWithValue("MasterRunID", theRun.ID);
            comLocal.Parameters.AddWithValue("LocalRunID", localRun.ID);
            comLocal.ExecuteNonQuery();

            // Now insert all the child records for this model run
            using (System.Data.SQLite.SQLiteConnection conLocal = new System.Data.SQLite.SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                conLocal.Open();

                // Prepare the local command to insert child records
                comLocal = new System.Data.SQLite.SQLiteCommand("SELECT * FROM ModelResultsIncremental WHERE RunID = @RunID", conLocal);
                comLocal.Parameters.AddWithValue("RunID", localRun.ID);
                System.Data.SQLite.SQLiteDataReader readLocal = comLocal.ExecuteReader();

                bool bDone = false;
                while (!bDone)
                {
                    StringBuilder sCommand = new StringBuilder("INSERT INTO ModelResultsIncremental (RunID, SectionID, Elevation, Area, Volume, SurveyArea, SurveyVol, MinArea, MinVol) VALUES ");

                    int iCounter = 0;
                    List<string> Rows = new List<string>();
                    while (!bDone && iCounter < 1000)
                    {
                        if (readLocal.Read())
                        {
                            iCounter++;
                            Rows.Add(string.Format("({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                                theRun.ID,
                                readLocal.GetInt64(readLocal.GetOrdinal("SectionID")),
                                readLocal.GetDouble(readLocal.GetOrdinal("Elevation")),
                                GetValue(ref readLocal, "Area"),
                                GetValue(ref readLocal, "Volume"),
                                GetValue(ref readLocal, "SurveyArea"),
                                GetValue(ref readLocal, "SurveyVol"),
                                GetValue(ref readLocal, "MinArea"),
                                GetValue(ref readLocal, "MinVol"))
                                );
                        }
                        else
                        {
                            bDone = true;
                        }
                    }
                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");
                    if (iCounter > 0)
                    {
                        using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), transMaster.Connection, transMaster))
                        {
                            myCmd.ExecuteNonQuery();
                        }

                    }
                }
                readLocal.Close();


                // NOW DO IT ALL AGAIN



                // Prepare the local command to insert child BINNED records
                comLocal = new System.Data.SQLite.SQLiteCommand("SELECT * FROM ModelResultsBinned WHERE RunID = @RunID", conLocal);
                comLocal.Parameters.AddWithValue("RunID", localRun.ID);
                readLocal = comLocal.ExecuteReader();
                bool bDoneBinned = false;
                while (!bDoneBinned)
                {
                    StringBuilder sCommand = new StringBuilder("INSERT INTO ModelResultsBinned(RunID, SectionID, BinID, Area, Volume, SurveyArea, SurveyVol, MinArea, MinVol) VALUES ");
                    int iCounter = 0;
                    List<string> Rows = new List<string>();
                    while (!bDoneBinned && iCounter < 1000)
                    {
                        if (readLocal.Read())
                        {
                            iCounter++;
                            Rows.Add(string.Format("({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                                theRun.ID,
                                readLocal.GetInt64(readLocal.GetOrdinal("SectionID")),
                                readLocal.GetDouble(readLocal.GetOrdinal("BinID")),
                                GetValue(ref readLocal, "Area"),
                                GetValue(ref readLocal, "Volume"),
                                GetValue(ref readLocal, "SurveyArea"),
                                GetValue(ref readLocal, "SurveyVol"),
                                GetValue(ref readLocal, "MinArea"),
                                GetValue(ref readLocal, "MinVol"))
                                );
                        }
                        else
                        {
                            bDoneBinned = true;
                        }
                    }
                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");
                    if (iCounter > 0)
                    {
                        using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), transMaster.Connection, transMaster))
                        {
                            myCmd.ExecuteNonQuery();
                        }

                    }
                }
                readLocal.Close();

            }
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            return theRun;
        }

        private static object GetValue(ref System.Data.SQLite.SQLiteDataReader dbRead, string sColumn)
        {
            if (dbRead.IsDBNull(dbRead.GetOrdinal(sColumn)))
                return "NULL";
            else
                return dbRead.GetDouble(dbRead.GetOrdinal(sColumn));
        }
    }
}
