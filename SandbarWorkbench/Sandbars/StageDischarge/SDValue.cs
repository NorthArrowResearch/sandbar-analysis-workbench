using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
            get { return ToolTip; }
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
            return ToolTip;
        }

        public string ToolTip
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (SampleDate.HasValue)
                    sb.AppendLine(SampleDate.Value.ToString("dd-MMM-yyy"));

                if (!string.IsNullOrEmpty(SampleCode))
                    sb.AppendLine(string.Format("Code: {0}", SampleCode));

                if (ElevationLocal.HasValue)
                    sb.AppendLine(string.Format("Local elev: {0}", ElevationLocal));

                sb.AppendLine(string.Format("SP elev: {0}", ElevationSP));

                if (SampleCount.HasValue)
                    sb.AppendLine(string.Format("Count: {0}", SampleCount));

                sb.AppendLine(string.Format("Flow: {0}", Flow));
                sb.AppendLine(string.Format("Flow ms⁻¹: {0}", FlowMS));

                if (!string.IsNullOrEmpty(Comments))
                    sb.AppendLine(Comments);

                return sb.ToString();
            }
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
                        DBHelpers.SQLiteHelpers.GetSafeValueNDT(ref dbRead, "SampleDate"),
                        DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SampleTime"),
                        DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SampleCode"),
                        DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ElevationLocal"),
                        DBHelpers.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "ElevationSP"),
                        DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SampleCount"),
                        DBHelpers.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "Flow"),
                        DBHelpers.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "FlowMS"),
                        DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Comments"),
                        DBHelpers.SQLiteHelpers.GetSafeValueDT(ref dbRead, "AddedOn"),
                        DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AddedBy"),
                        DBHelpers.SQLiteHelpers.GetSafeValueDT(ref dbRead, "UpdatedOn"),
                        DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "UpdatedBy")));
                }
            }

            return dValues;
        }
    }
}
