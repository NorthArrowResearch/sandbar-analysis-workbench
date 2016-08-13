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
        public Dictionary<double, Values> Elevations { get; set; }

        public SectionTypeResults(long nSectionTypeID)
        {
            SectionTypeID = nSectionTypeID;
            Elevations = new Dictionary<double, Values>();
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
        public Dictionary<long, SectionTypeResults> Sections { get; internal set; }

        public SurveyResults(long nSurveyID)
        {
            Sections = new Dictionary<long, SectionTypeResults>();
        }
    }

    public class ModelResults
    {
        public long ModelID { get; internal set; }
        public string Title { get; internal set; }
        public Dictionary<long, SurveyResults> Surveys { get; internal set; }

        public ModelResults(string sDBCon, long SiteID, long nModelID)
        {
            ModelID = nModelID;
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
                    if (!Surveys.ContainsKey(nSurveyID))
                        Surveys[nSurveyID] = new SurveyResults(nSurveyID);

                    long nSectionTypeID = dbRead.GetInt64(dbRead.GetOrdinal("SectionTypeID"));
                    if (!Surveys[nSurveyID].Sections.ContainsKey(nSectionTypeID))
                        Surveys[nSurveyID].Sections[nSectionTypeID] = new SectionTypeResults(nSectionTypeID);

                    double fElevation = dbRead.GetDouble(dbRead.GetOrdinal("Elevation"));
                    //System.Diagnostics.Debug.Assert(!dResults[nSurveyID][nSectionTypeID].Elevations.ContainsKey(fElevation), "There should only be one value per elevation");
                    Surveys[nSurveyID].Sections[nSectionTypeID].Elevations[fElevation] = new Values(dbRead.GetDouble(dbRead.GetOrdinal("Area")), dbRead.GetDouble(dbRead.GetOrdinal("Volume")));
                }
            }
        }
    }
}
