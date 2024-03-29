﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace SandbarWorkbench.DBHelpers
{
    public class DataExporter
    {
        public enum ModelResultTypes
        {
            ResultsIncremental,
            ResultsBinned,
            ResultsCampsites
        }

        private string SQLQuery(ModelResultTypes eType)
        {
            string sSQL = string.Empty;

            switch (eType)
            {
                case ModelResultTypes.ResultsIncremental:

                    sSQL = "Select " +
                        "S.SiteID AS SiteID" +
                        ", SN.SiteCode5 AS SiteCode" +
                        ", MR.SectionID AS SectionID" +
                        ", I.Title AS Instrument" +
                        ", SS.Uncertainty AS Uncertainty" +
                        ", SS.SectionTypeID AS SectionTypeID" +
                        ", ST.Title AS SectionType" +
                        ", S.SurveyID AS SurveyID" +
                        ", strftime('%Y-%m-%d', S.SurveyDate) AS SurveyDate" +
                        ", MR.Elevation AS Elevation" +
                        ", MR.Area AS Area" +
                        ", MR.Volume AS Volume" +
                    " FROM ModelResultsIncremental MR" +
                        " INNER JOIN SandbarSections SS ON MR.SectionID = SS.SectionID" +
                        " INNER JOIN SandbarSurveys S ON S.SurveyID = SS.SurveyID" +
                        " INNER JOIN SandbarSites SN ON S.SiteID = SN.SiteID" +
                        " INNER JOIN LookupListItems ST ON SS.SectionTypeID = ST.ItemID" +
                        " INNER JOIN LookupListItems I ON SS.InstrumentID = I.ItemID" +
                    " WHERE MR.RunID = @RunID";
                    break;

                case ModelResultTypes.ResultsBinned:
                    sSQL = "Select " +
                        "S.SiteID AS SiteID " +
                        ", SN.SiteCode5 AS SiteCode " +
                        ", MR.SectionID AS SectionID " +
                        ", I.Title AS Instrument " +
                        ", SS.Uncertainty AS Uncertainty " +
                        ", SS.SectionTypeID AS SectionTypeID " +
                        ", ST.Title AS SectionType " +
                        ", S.SurveyID AS SurveyID " +
                        ", strftime('%Y-%m-%d', S.SurveyDate) AS SurveyDate " +
                        ", MR.BinID " +
                        ", B.LowerDischarge AS LowerDischarge " +
                        ", B.UpperDischarge AS UpperDischarge " +
                        ", MR.Area AS Area " +
                        ", MR.Volume AS Volume " +
                    " FROM ModelResultsBinned MR " +
                        " INNER JOIN AnalysisBins B ON MR.BinID = B.BinID " +
                        " INNER JOIN SandbarSections SS ON MR.SectionID = SS.SectionID " +
                        " INNER JOIN SandbarSurveys S ON S.SurveyID = SS.SurveyID " +
                        " INNER JOIN SandbarSites SN ON S.SiteID = SN.SiteID " +
                        " INNER JOIN LookupListItems ST ON SS.SectionTypeID = ST.ItemID " +
                        " INNER JOIN LookupListItems I ON SS.InstrumentID = I.ItemID" +
                    " WHERE MR.RunID = @RunID";
                    break;
                case ModelResultTypes.ResultsCampsites:
                   sSQL = @"
                        SELECT MR.RunID AS RunID,
                               S.SiteID AS SiteID,
                               S.SiteCode5 AS SiteCode,
                               S.SiteCode AS SiteCode,
                               SS.SurveyID AS SurveyID,
                               strftime('%Y-%m-%d', SS.SurveyDate) AS SurveyDate,
                               SS.TripID TripID,
                               MR.BinID As BinID,
                               B.Title AS BinName,
                               B.LowerDischarge AS LowerDischarge,
                               B.UpperDischarge AS UpperDischarge,
                               MR.Area AS Area
                          FROM ModelResultsCampsites MR
                               INNER JOIN
                               SandbarSurveys SS ON MR.SurveyID = SS.SurveyID
                               INNER JOIN
                               SandbarSites S ON SS.SiteID = S.SiteID
                               INNER JOIN
                               AnalysisBins B ON MR.BinID = B.BinID
                        WHERE MR.RunId = @RunID";
                    break;
                default:
                    throw new Exception("Unhandled model type");

            }

            return sSQL;
        }

        public string DB { get; internal set; }

        public DataExporter(string sDBCon)
        {
            DB = sDBCon;
        }

        public void Run(long nModelID, ModelResultTypes eType, bool bOpenFileWhenDone)
        {

            SaveFileDialog frm = new SaveFileDialog();
            frm.Title = string.Format("Export {0} Model Results", eType == ModelResultTypes.ResultsIncremental ? "Incremental" : "Binned");
            frm.Filter = "Comma Separated Value Files (*.csv)|*.csv";
            frm.InitialDirectory = System.IO.Path.GetDirectoryName(DBCon.DatabasePath);
            frm.FileName = string.Format("results_{0}", eType == ModelResultTypes.ResultsIncremental ? "Incremental" : "Binned");

            frm.AddExtension = true;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(frm.FileName, ExportToString(nModelID, eType));
                if (bOpenFileWhenDone && System.IO.File.Exists(frm.FileName))
                {
                    System.Diagnostics.Process.Start(frm.FileName);
                }
            }
        }

        private string ExportToString(long nModelID, ModelResultTypes eType)
        {
            var sb = new StringBuilder();
            System.Data.DataTable dt = new System.Data.DataTable();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(SQLQuery(eType), dbCon);
                da.SelectCommand.Parameters.AddWithValue("RunID", nModelID);
                da.Fill(dt);
            }

            sb.AppendLine(string.Join(",", dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray<string>()));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            return sb.ToString();
        }

    }
}
