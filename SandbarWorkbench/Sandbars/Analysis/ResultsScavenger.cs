using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars.Analysis
{
    public class ResultsScavenger
    {
        public string m_sDBCon { get; internal set; }

        // Results of the scavange are only populated AFTER the Run() method is called.
        public long ModelRunID { get; internal set; }
        public long IncrementalResults { get; internal set; }
        public long BinnedResults { get; internal set; }

        public ResultsScavenger(string sDBCon)
        {
            m_sDBCon = sDBCon;
            ResetScavengeInfo();
        }

        private void ResetScavengeInfo()
        {
            ModelRunID = 0;
            IncrementalResults = 0;
            BinnedResults = 0;
        }

        public void Run(string sTitle, string sRemarks, System.IO.FileInfo fiInputs, System.IO.FileInfo fiIncremental, System.IO.FileInfo fiBinned)
        {
            ResetScavengeInfo();

            if (!fiIncremental.Exists)
            {
                Exception ex = new Exception("The incremental analysis file does not exist.");
                ex.Data["File"] = fiIncremental.FullName;
                throw ex;
            }

            if (!fiBinned.Exists)
            {
                Exception ex = new Exception("The binned analysis file does not exist.");
                ex.Data["File"] = fiBinned.FullName;
                throw ex;
            }

            string sInputs = string.Empty;
            if (fiInputs is System.IO.FileInfo && fiInputs.Exists)
                sInputs = System.IO.File.ReadAllText(fiInputs.FullName);

            using (SQLiteConnection dbCon = new SQLiteConnection(m_sDBCon))
            {
                dbCon.Open();
                SQLiteTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    SQLiteCommand dbCom = new SQLiteCommand("INSERT INTO ModelRuns (Title, Remarks, RunTypeID, InputXML, AnalysisFolder, AddedBy, UpdatedBy, InstallationGuid, RunBy)" +
                        " VALUES (@Title, @Remarks, @RunTypeID, @InputXML, @AnalysisFolder, @EditedBy, @EditedBy, @InstallationGuid, @EditedBy)", dbTrans.Connection, dbTrans);

                    dbCom.Parameters.AddWithValue("Title", sTitle);
                    dbCom.Parameters.AddWithValue("RunTypeID", SandbarWorkbench.Properties.Settings.Default.RunTypeID_UserGenerated);
                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                    dbCom.Parameters.AddWithValue("InstallationGuid", SandbarWorkbench.Properties.Settings.Default.InstallationHash.ToString());
                    dbCom.Parameters.AddWithValue("AnalysisFolder", fiInputs.DirectoryName);

                    if (string.IsNullOrEmpty(sRemarks))
                        dbCom.Parameters.Add("Remarks", System.Data.DbType.String).Value = DBNull.Value;
                    else
                        dbCom.Parameters.AddWithValue("Remarks", sRemarks);

                    if (string.IsNullOrEmpty(sInputs))
                        dbCom.Parameters.Add("InputXML", System.Data.DbType.String).Value = DBNull.Value;
                    else
                    {
                        dbCom.Parameters.AddWithValue("InputXML", sInputs);
                    }

                    dbCom.ExecuteNonQuery();

                    dbCom = new SQLiteCommand("SELECT  last_insert_rowid()", dbTrans.Connection, dbTrans);
                    ModelRunID = (long)dbCom.ExecuteScalar();

                    // Incremental results
                    // siteid,sitecode,surveyid,surveydate,sectiontypeid,section,sectionid,elevation,area,vol
                    string[] sIncrementalColumns = { "SectionID", "Elevation", "Area", "Volume" };
                    IncrementalResults = ProcessCSVFile(ref dbTrans, fiIncremental, ModelRunID, "ModelResultsIncremental", sIncrementalColumns);

                    // Binned results
                    // siteid,sitecode,surveyid,surveydate,sectionid,section,binid,bin,area,vol
                    string[] sBinnedColumns = { "SectionID", "BinID", "Area", "Volume" };
                    BinnedResults = ProcessCSVFile(ref dbTrans, fiBinned, ModelRunID, "ModelResultsBinned", sBinnedColumns);

                    dbTrans.Commit();
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    ex.Data["Incremental File"] = fiIncremental.FullName;
                    ex.Data["Binned File"] = fiBinned.FullName;
                    throw;
                }
            }
        }

        /// <summary>
        /// Generic CSV file loader. Takes an array of string columns
        /// </summary>
        /// <param name="dbTrans"></param>
        /// <param name="fiCSV"></param>
        /// <param name="nModelRunID"></param>
        /// <param name="sTable"></param>
        /// <param name="sColumns"></param>
        /// <remarks>The array of column names must match both the database columns in the target table and also the CSV
        /// file row headers. This array is used to build the SQL insert statement and also find the index of the associated
        /// columns in the CSV</remarks>
        private long ProcessCSVFile(ref SQLiteTransaction dbTrans, System.IO.FileInfo fiCSV, long nModelRunID, string sTable, string[] sColumns)
        {
            long nRowsInserted = 0;
            string sSQL = string.Format("INSERT INTO {0} (RunID, {1}) VALUES ({2}, @{3})", sTable, string.Join(", ", sColumns), nModelRunID, string.Join(", @", sColumns));
            System.Diagnostics.Debug.Print(sSQL);
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);

            // Create a parameter for each column. Column names ending in ID are long integers, everything else is double
            sColumns.ToList<string>().ForEach(x => dbCom.Parameters.Add(x.ToLower(), x.ToLower().EndsWith("id") ? System.Data.DbType.Int64 : System.Data.DbType.Double));

            using (System.IO.StreamReader sr = new System.IO.StreamReader(fiCSV.FullName))
            {
                // This dictionary will contain keys that are SQL parameter names and the index of the associated column in the CSV
                Dictionary<string, int> dColumnIndices = null;
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] sCurrentParts = currentLine.Split(',');

                    // Reading first row. Build the dictionary of the SQL parameter names and associated CSV column index
                    // This is done this way so that only columns passed into this function in the argument array are used
                    // from the CSV and all other CSV columns are ignored.
                    if (dColumnIndices == null)
                    {
                        dColumnIndices = new Dictionary<string, int>();
                        for (int i = 0; i < sCurrentParts.Count<string>(); i++)
                        {
                            if (dbCom.Parameters.Contains(sCurrentParts[i]))
                                dColumnIndices[sCurrentParts[i]] = i;
                        }

                        if (dColumnIndices.Count != dbCom.Parameters.Count)
                        {
                            Exception ex = new Exception("Failed to find columns in the analysis result CSV file for all specified database fields");
                            ex.Data["CSV File"] = fiCSV.FullName;
                            ex.Data["Columns"] = string.Join(",", sColumns);
                            ex.Data["Table"] = sTable;
                            ex.Data["SQL"] = dbCom.CommandText;
                            throw ex;
                        }
                    }
                    else
                    {
                        // Process a row of data
                        foreach (SQLiteParameter param in dbCom.Parameters)
                        {
                            if (param.DbType == System.Data.DbType.Int64)
                                param.Value = long.Parse(sCurrentParts[dColumnIndices[param.ParameterName]]);
                            else
                                param.Value = double.Parse(sCurrentParts[dColumnIndices[param.ParameterName]]);
                        }

                        nRowsInserted += dbCom.ExecuteNonQuery();
                    }
                }
            }

            return nRowsInserted;
        }
    }
}
