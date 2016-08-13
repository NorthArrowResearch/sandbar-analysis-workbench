using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars
{
    public class IncrementalResults
    {
        public double LowerElevation { get; set; }
        public double UpperElevation { get; set; }

        // survey -> SectionID -> 
        public ModelResults

        public IncrementalResults(string sDBCon, long SiteID, long ModelID)
        {
            Results = new Dictionary<long, ModelResults>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDBCon))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("Select * FROM vwIncrementalResults WHERE (SiteID = @SiteID) AND (RunID = @ModelID)", dbCon);
                dbCom.Parameters.AddWithValue("@SiteID", SiteID);
                dbCom.Parameters.AddWithValue("@ModelID", ModelID);

                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nSurveyID = dbRead.GetInt64(dbRead.GetOrdinal("SurveyID"));
                    if (!dResults.ContainsKey(nSurveyID))
                        dResults[nSurveyID] = new Dictionary<long, SectionValues>();

                    long nSectionTypeID = dbRead.GetInt64(dbRead.GetOrdinal("SectionTypeID"));
                    if (!dResults[nSurveyID].ContainsKey(nSectionTypeID))
                        dResults[nSurveyID][nSectionTypeID] = new SectionValues();

                    double fElevation = dbRead.GetDouble(dbRead.GetOrdinal("Elevation"));
                    System.Diagnostics.Debug.Assert(!dResults[nSurveyID][nSectionTypeID].Elevations.ContainsKey(fElevation), "There should only be one value per elevation");
                    dResults[nSurveyID][nSectionTypeID].Elevations[fElevation] = new Values(dbRead.GetDouble(dbRead.GetOrdinal("Area")), dbRead.GetDouble(dbRead.GetOrdinal("Volume")));
                }
            }
        }
    }
}
