using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace SandbarWorkbench.AnalysisBins
{
    public class AnalysisBin : DBHelpers.DatabaseObject
    {
        // Database enumeration for analysis bins that belong to 
        // legacy binned analysis or new campsite analysis
        private const string BINNED_ANALYSIS = "AnalysisBins";
        private const string CAMPSITE_ANALYSIS = "CampsiteBins";

        public enum BinnedAnalysisTypes
        {
            BinnedAnalysis,
            CampsiteAnalysis
        };

        public Nullable<double> LowerDischarge { get; internal set; }
        public Nullable<double> UpperDischarge { get; internal set; }
        public bool IsActive { get; internal set; }
        public Color DisplayColor { get; internal set; }
        public readonly BinnedAnalysisTypes BinType;

        public override string ToString()
        {
            return Title;
        }

        public string DisplayColorHex
        {
            get { return "#" + DisplayColor.R.ToString("X2") + DisplayColor.G.ToString("X2") + DisplayColor.B.ToString("X2"); }
        }

        public AnalysisBin(long nBinID, string sTitle, Nullable<double> fLD, Nullable<double> fUD, bool bIsActive, BinnedAnalysisTypes binType, Color colDisplay, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
            : base(nBinID, sTitle, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy)
        {
            LowerDischarge = fLD;
            UpperDischarge = fUD;
            IsActive = bIsActive;
            DisplayColor = colDisplay;
            BinType = binType;
        }

        public AnalysisBin(string sTitle, Nullable<double> fLD, Nullable<double> fUD, bool bIsActive, BinnedAnalysisTypes binType, Color colDisplay, string sAddedBy)
          : base(0, sTitle, DateTime.Now, sAddedBy, DateTime.Now, sAddedBy)
        {
            LowerDischarge = fLD;
            UpperDischarge = fUD;
            IsActive = bIsActive;
            DisplayColor = colDisplay;
            BinType = binType;
        }

        public static AnalysisBin Load(long nBinID, AnalysisBin.BinnedAnalysisTypes eType)
        {
            Dictionary<long, AnalysisBin> dBins = Load(DBCon.ConnectionStringLocal, eType);
            return dBins[nBinID];
        }

        public static Dictionary<long, AnalysisBin> Load(string sDBCon, BinnedAnalysisTypes eType)
        {
            Dictionary<long, AnalysisBin> dResult = new Dictionary<long, AnalysisBin>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDBCon))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM AnalysisBins WHERE BinType = @BinType ORDER BY LowerDischarge", dbCon);

                switch (eType)
                {
                    case BinnedAnalysisTypes.BinnedAnalysis: dbCom.Parameters.AddWithValue("BinType", AnalysisBin.BINNED_ANALYSIS); break;
                    case BinnedAnalysisTypes.CampsiteAnalysis: dbCom.Parameters.AddWithValue("BinType", AnalysisBin.CAMPSITE_ANALYSIS); break;
                    default:
                        throw new Exception("Unhandled analysis type enumeration");
                }

                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    Nullable<double> fLD = new Nullable<double>();
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("LowerDischarge")))
                        fLD = dbRead.GetDouble(dbRead.GetOrdinal("LowerDischarge"));

                    Nullable<double> fUD = new Nullable<double>();
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("UpperDischarge")))
                        fUD = dbRead.GetDouble(dbRead.GetOrdinal("UpperDischarge"));

                    Color displayColor = new Color();
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("DisplayColor")))
                    {
                        string sHexColor = dbRead.GetString(dbRead.GetOrdinal("DisplayColor"));
                        if (!sHexColor.StartsWith("#"))
                            sHexColor = "#" + sHexColor;
                        displayColor = System.Drawing.ColorTranslator.FromHtml(sHexColor);
                    }

                    dResult[dbRead.GetInt64(dbRead.GetOrdinal("BinID"))] = new AnalysisBin(
                        dbRead.GetInt64(dbRead.GetOrdinal("BinID"))
                        , dbRead.GetString(dbRead.GetOrdinal("Title"))
                        , fLD
                        , fUD
                        , dbRead.GetBoolean(dbRead.GetOrdinal("IsActive"))
                        , eType
                        , displayColor
                        , dbRead.GetDateTime(dbRead.GetOrdinal("AddedOn"))
                        , dbRead.GetString(dbRead.GetOrdinal("AddedBy"))
                        , dbRead.GetDateTime(dbRead.GetOrdinal("UpdatedOn"))
                        , dbRead.GetString(dbRead.GetOrdinal("UpdatedBy"))
                        );
                }
            }

            return dResult;

        }

        /// <summary>
        /// Get a list of all ACTIVE bin boundaries, both lower and upper, that have a value (i.e. ignoring the null lower and upper values)
        /// </summary>
        /// <param name="lBins"></param>
        /// <returns></returns>
        public static SortedList<double, double> GetActiveBinBoundaries(IEnumerable<AnalysisBin> lBins)
        {
            SortedList<double, double> dBins = new SortedList<double, double>();

            foreach (AnalysisBin aBin in lBins)
            {
                if (aBin.IsActive)
                {
                    if (aBin.LowerDischarge.HasValue)
                        if (!dBins.ContainsKey(aBin.LowerDischarge.Value))
                            dBins.Add(aBin.LowerDischarge.Value, aBin.LowerDischarge.Value);

                    if (aBin.UpperDischarge.HasValue)
                        if (!dBins.ContainsKey(aBin.UpperDischarge.Value))
                            dBins.Add(aBin.UpperDischarge.Value, aBin.UpperDischarge.Value);
                }
            }

            return dBins;
        }
    }
}
