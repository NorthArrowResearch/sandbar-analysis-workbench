﻿using System;
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
        public Dictionary<double, Values> IncrementalResults { get; internal set; }
        public Dictionary<long, Values> BinnedResults { get; internal set; }

        public SurveyResults(long nSurveyID, DateTime dtSurveyDate)
        {
            SurveyID = nSurveyID;
            SurveyDate = dtSurveyDate;
            IncrementalResults = new Dictionary<double, Values>();
            BinnedResults = new Dictionary<long, Values>();
        }
    }

    public class CampsiteResults
    {
        public readonly long SurveyID;
        public readonly DateTime SurveyDate;
        // bin ID to area
        public readonly Dictionary<long, double> BinnedResults;

        public CampsiteResults(long surveyID, DateTime surveyDate)
        {
            SurveyID = surveyID;
            SurveyDate = surveyDate;
            BinnedResults = new Dictionary<long, double>();
        }
    }

    public class ModelResults
    {
        public long ModelID { get; internal set; }
        public string Title { get; internal set; }
        public Dictionary<long, SectionTypeResults> SectionTypes { get; internal set; }
        public Dictionary<long, CampsiteResults> CampsiteResults { get; internal set; }

        public ModelResults(string sDBCon, long SiteID, long nModelID, string sTitle)
        {
            ModelID = nModelID;
            Title = sTitle;
            SectionTypes = new Dictionary<long, SectionTypeResults>();
            CampsiteResults = new Dictionary<long, CampsiteResults>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDBCon))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("Select * FROM vwIncrementalResults WHERE (SiteID = @SiteID) AND (RunID = @ModelID) AND (Area IS NOT NULL) AND (Volume IS NOT NULL)", dbCon);
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
                    SectionTypes[nSectionTypeID].Surveys[nSurveyID].IncrementalResults[fElevation] = new Values(dbRead.GetDouble(dbRead.GetOrdinal("Area")), dbRead.GetDouble(dbRead.GetOrdinal("Volume")));
                }
                dbRead.Close();

                dbCom = new SQLiteCommand("SELECT * FROM vwBinnedResults WHERE (SiteID = @SiteID) AND (RunID = @ModelID)", dbCon);
                dbCom.Parameters.AddWithValue("@SiteID", SiteID);
                dbCom.Parameters.AddWithValue("@ModelID", ModelID);

                dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nSectionTypeID = dbRead.GetInt64(dbRead.GetOrdinal("SectionTypeID"));
                    if (!SectionTypes.ContainsKey(nSectionTypeID))
                        SectionTypes[nSectionTypeID] = new SectionTypeResults(nSectionTypeID);

                    long nSurveyID = dbRead.GetInt64(dbRead.GetOrdinal("SurveyID"));
                    if (!SectionTypes[nSectionTypeID].Surveys.ContainsKey(nSurveyID))
                        SectionTypes[nSectionTypeID].Surveys[nSurveyID] = new SurveyResults(nSurveyID, dbRead.GetDateTime(dbRead.GetOrdinal("SurveyDate")));

                    long nBinID = dbRead.GetInt64(dbRead.GetOrdinal("BinID"));
                    //System.Diagnostics.Debug.Assert(!dResults[nSurveyID][nSectionTypeID].Elevations.ContainsKey(fElevation), "There should only be one value per elevation");
                    SectionTypes[nSectionTypeID].Surveys[nSurveyID].BinnedResults[nBinID] = new Values(dbRead.GetDouble(dbRead.GetOrdinal("Area")), dbRead.GetDouble(dbRead.GetOrdinal("Volume")));
                }
                dbRead.Close();

                dbCom = new SQLiteCommand("SELECT * FROM vwCampsiteResults WHERE (SiteID = @SiteID) AND (RunID = @ModelID)", dbCon);
                dbCom.Parameters.AddWithValue("@SiteID", SiteID);
                dbCom.Parameters.AddWithValue("@ModelID", ModelID);

                dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nSurveyID = dbRead.GetInt64(dbRead.GetOrdinal("SurveyID"));
                    long binID = dbRead.GetInt64(dbRead.GetOrdinal("BinID"));

                    if (!CampsiteResults.ContainsKey(nSurveyID))
                        CampsiteResults[nSurveyID] = new CampsiteResults(nSurveyID, dbRead.GetDateTime(dbRead.GetOrdinal("SurveyDate")));

                    CampsiteResults[nSurveyID].BinnedResults[binID] = dbRead.GetDouble(dbRead.GetOrdinal("Area"));
                }
                dbRead.Close();
            }
        }
    }
}
