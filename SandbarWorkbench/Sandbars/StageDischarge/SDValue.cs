using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using naru.ui;

namespace SandbarWorkbench.Sandbars.StageDischarge
{
    public class SDValue : AuditTrail
    {
        public long SampleID { get; internal set; }
        public long SiteID { get; internal set; }
        public Nullable<DateTime> SampleDate { get; internal set; }
        public string SampleTime { get; internal set; }
        public string SampleCode { get; internal set; }
        public Nullable<double> ElevationLocal { get; internal set; }
        public double ElevationSP { get; internal set; }
        public Nullable<long> SampleCount { get; internal set; }
        public double Flow { get; internal set; }
        public double FlowMS { get; internal set; }
        public string Comments { get; internal set; }

        public string Title
        {
            get { return ToolTip.Replace("\n", ", "); }
        }

        public SDValue(long nSampleID, long nSiteID, Nullable<DateTime> dtSampleDate, string sSampleTime, string sSampleCode,
            Nullable<double> fLocalElev, double fSPElevation, Nullable<long> nSampleCount, double fFlow, double fFlowMS, string sComments,
            DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
            : base(dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy)
        {
            SampleID = nSampleID;
            SiteID = nSiteID;
            SampleDate = dtSampleDate;
            SampleTime = sSampleTime;
            SampleCode = sSampleCode;
            ElevationLocal = fLocalElev;
            ElevationSP = fSPElevation;
            SampleCount = nSampleCount;
            Flow = fFlow;
            FlowMS = fFlowMS;
            Comments = sComments;
        }

        public override string ToString()
        {
            return Title;
        }

        public string ToolTip
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (SampleDate.HasValue)
                    sb.AppendLine(SampleDate.Value.ToString("d-MMM-yyy"));

                if (!string.IsNullOrEmpty(SampleCode))
                    sb.AppendLine(string.Format("Code: {0}", SampleCode));

                if (ElevationLocal.HasValue)
                    sb.AppendLine(string.Format("Local elev: {0:#,##0.000}", ElevationLocal));

                sb.AppendLine(string.Format("SP elev: {0:#,##0.000}", ElevationSP));

                if (SampleCount.HasValue)
                    sb.AppendLine(string.Format("Count: {0:#,##0}", SampleCount));

                sb.AppendLine(string.Format("Flow: {0:#,##0.000}", Flow));
                sb.AppendLine(string.Format("Flow ms⁻¹: {0:#,##0.000}", FlowMS));

                if (!string.IsNullOrEmpty(Comments))
                    sb.AppendLine(Comments);

                System.Diagnostics.Debug.Assert(sb.Length > 0, "There should always be at lesat one item in the tooltip, or the format should be adjusted.");
                return sb.ToString();
            }
        }

        public string ToCSV()
        {
            string sValue = (SampleDate.HasValue ? SampleDate.Value.ToString("yyyy-MM-dd") : "");
            sValue += "," + SampleTime;
            sValue += "," + SampleCode;
            sValue += "," + (ElevationLocal.HasValue ? ElevationLocal.Value.ToString() : "");
            sValue += "," + ElevationSP;
            sValue += "," + (SampleCount.HasValue ? SampleCount.Value.ToString() : "");
            sValue += "," + Flow.ToString();
            sValue += "," + FlowMS.ToString();
            sValue += "," + Comments.Replace(",", "");
            return sValue;
        }

        public static string CSVHeaderRow()
        {
            return "Sample Date,Sample Time,Sample Code,Local Elevation, SP Elevation, Sample Count, Flow, Flow MS, Comments";
        }

        public static SortableBindingList<SDValue> Load(long nSiteID)
        {
            SortableBindingList<SDValue> dValues = new SortableBindingList<SDValue>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM StageDischarges WHERE SiteID = @SiteID ORDER BY SampleDate", dbCon);
                dbCom.Parameters.AddWithValue("SiteID", nSiteID);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nSampleID = dbRead.GetInt64(dbRead.GetOrdinal("SampleID"));

                    dValues.Add(new SDValue(nSampleID, nSiteID,
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueNDT(ref dbRead, "SampleDate"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SampleTime"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SampleCode"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ElevationLocal"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "ElevationSP"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SampleCount"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "Flow"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "FlowMS"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Comments"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueDT(ref dbRead, "AddedOn"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AddedBy"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueDT(ref dbRead, "UpdatedOn"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "UpdatedBy")));
                }
            }

            return dValues;
        }

        /// <summary>
        /// Deletes a stage discharge sample on both local and master
        /// </summary>
        /// <param name="nSampleID">The primary key, unique identifier of the sample</param>
        public static void Delete(long nSampleID)
        {

            using (SQLiteConnection conLocal = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                conLocal.Open();
                SQLiteTransaction transLocal = conLocal.BeginTransaction();

                try
                {
                    SQLiteCommand comLocal = new SQLiteCommand("DELETE FROM StageDischarges WHERE SampleID = @SampleID", transLocal.Connection, transLocal);
                    comLocal.Parameters.AddWithValue("SampleID", nSampleID);
                    comLocal.ExecuteNonQuery();
                    transLocal.Commit();
                }
                catch (Exception ex)
                {
                    transLocal.Rollback();
                    throw;
                }
            }
        }
    }
}
