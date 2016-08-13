using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars
{
    public class SectionTypeResults
    {
        public long SectionTypeID { get; internal set; }
        public Dictionary<long, SurveyResults> Surveys { get; set; }

        public SectionTypeResults(long nSectionTypeID)
        {
            SectionTypeID = nSectionTypeID;
            Surveys = new Dictionary<long, SurveyResults>();
        }
    }

    public class Values
    {
        public double Area { get; internal set; }
        public double Vol { get; internal set; }

        public Values(double fArea, double fVol)
        {
            Area = fArea;
            Vol = fVol;
        }
    }

    public class SurveyResults
    {
        public long SurveyID { get; internal set; }
        public DateTime SurveyDate { get; internal set; }
        public Dictionary<double, Values> Elevations { get; internal set; }

        public SurveyResults(long nSurveyID, DateTime dtSurveyDate)
        {
            SurveyID = nSurveyID;
            SurveyDate = dtSurveyDate;
            Elevations = new Dictionary<double, Values>();

        }
    }

    public class ModelResults
    {
        public long ModelID { get; internal set; }
        public string Title { get; internal set; }
        public Dictionary<long, SectionTypeResults> SectionTypes { get; internal set; }

        public ModelResults(string sDBCon, long SiteID, long nModelID, string sTitle)
        {
            ModelID = nModelID;
            Title = sTitle;
            SectionTypes = new Dictionary<long, SectionTypeResults>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDBCon))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("Select * FROM vwIncrementalResults WHERE (SiteID = @SiteID) AND (RunID = @ModelID)", dbCon);
                dbCom.Parameters.AddWithValue("@SiteID", SiteID);
                dbCom.Parameters.AddWithValue("@ModelID", ModelID);

                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nSectionTypeID = dbRead.GetInt64(dbRead.GetOrdinal("SectionTypeID"));
                    if (!SectionTypes.ContainsKey(nSectionTypeID))
                        SectionTypes[nSectionTypeID] = new SectionTypeResults(nSectionTypeID);

                    long nSurveyID = dbRead.GetInt64(dbRead.GetOrdinal("SurveyID"));
                    if (!SectionTypes[nSectionTypeID].Surveys.ContainsKey(nSurveyID))
                        SectionTypes[nSectionTypeID].Surveys[nSurveyID] = new SurveyResults(nSurveyID, dbRead.GetDateTime(dbRead.GetOrdinal("SurveyDate")));

                    double fElevation = dbRead.GetDouble(dbRead.GetOrdinal("Elevation"));
                    //System.Diagnostics.Debug.Assert(!dResults[nSurveyID][nSectionTypeID].Elevations.ContainsKey(fElevation), "There should only be one value per elevation");
                    SectionTypes[nSectionTypeID].Surveys[nSurveyID].Elevations[fElevation] = new Values(dbRead.GetDouble(dbRead.GetOrdinal("Area")), dbRead.GetDouble(dbRead.GetOrdinal("Volume")));
                }
            }
        }
    }
}
