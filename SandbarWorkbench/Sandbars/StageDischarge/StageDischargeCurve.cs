using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using naru.ui;

namespace SandbarWorkbench.Sandbars.StageDischarge
{
    public class SDCurve
    {
        public long SiteID { get; internal set; }
        public long CurveID { get; internal set; }
        public string SiteName { get; internal set; }
        public Nullable<double> CoeffA { get; internal set; }
        public Nullable<double> CoeffB { get; internal set; }
        public Nullable<double> CoeffC { get; internal set; }
        public DateTime EffectiveDate { get; internal set; }

        public String DisplayTitle { get { return string.Format("Effective {0:d MMM yyyy}", EffectiveDate); } }

        public SortableBindingList<SDValue> StageDischargeSamples { get; internal set; }

        public bool HasAllValues
        {
            get { return CoeffA.HasValue && CoeffB.HasValue && CoeffC.HasValue; }
        }

        public Nullable<double> Stage(double fDischarge)
        {
            Nullable<double> fResult = new Nullable<double>();
            if (CoeffA.HasValue && CoeffB.HasValue && CoeffC.HasValue)
                fResult = CoeffA + (CoeffB * fDischarge) + (CoeffC.Value * Math.Pow(fDischarge, 2));

            return fResult;
        }

        public SDCurve(long nSiteID, long curveID, string sSiteName, Nullable<double> fCoeffA, Nullable<double> fCoeffB, Nullable<double> fCoeffC, DateTime effectiveDate)
        {
            CurveID = curveID;
            SiteID = nSiteID;
            SiteName = sSiteName;
            CoeffA = fCoeffA;
            CoeffB = fCoeffB;
            CoeffC = fCoeffC;
            EffectiveDate = effectiveDate;

            // Call the load method to instantiate this dictionary.
            StageDischargeSamples = null;
        }

        public string CurveAsCSV(double fMinDischarge, double fMaxDischarge, double fDischargeIncrement)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("discharge,stage");

            for (double fDischarge = fMinDischarge; fDischarge <= fMaxDischarge; fDischarge += fDischargeIncrement)
                sb.AppendLine(string.Format("{0},{1}", fDischarge, Stage(fDischarge).Value));

            return sb.ToString();
        }

        public string SamplesAsCSV()
        {
            if (StageDischargeSamples == null)
                LoadStageDischargeValues();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(SDValue.CSVHeaderRow());

            foreach (SDValue aValue in this.StageDischargeSamples)
                sb.AppendLine(aValue.ToCSV());

            return sb.ToString();
        }

        public int LoadStageDischargeValues()
        {
            StageDischargeSamples = SDValue.Load(this.SiteID);
            return StageDischargeSamples.Count;
        }

        public static List<SDCurve> Load(string dbcon, long siteID)
        {
            List<SDCurve> curves = new List<SDCurve>();
            using (SQLiteConnection dbCon = new SQLiteConnection(dbcon))
            {
                dbCon.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM StageDischargeParams WHERE SiteID = @SiteID", dbCon))
                {
                    cmd.Parameters.AddWithValue("SiteID", siteID);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        curves.Add(new SDCurve(
                            siteID,
                            reader.GetInt64(reader.GetOrdinal("StageDischargeID")),
                        siteID.ToString(),
                   naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(reader, "ParameterA"),
                       naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(reader, "ParameterB"),
                        naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(reader, "ParameterC"),
                        reader.GetDateTime(reader.GetOrdinal("EffectiveDate"))
                        ));
                    }
                }
            }

            return curves;
        }
    }
}
