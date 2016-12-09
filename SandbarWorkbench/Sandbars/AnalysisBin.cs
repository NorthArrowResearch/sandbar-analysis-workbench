using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Drawing;

namespace SandbarWorkbench.Sandbars
{
    public class AnalysisBin
    {
        public long BinID { get; internal set; }
        public string Title { get; internal set; }
        public Nullable<double> LowerDischarge { get; internal set; }
        public Nullable<double> UpperDischarge { get; internal set; }
        public bool IsActive { get; internal set; }
        public Color DisplayColor { get; internal set; }
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }
        public DateTime UpdatedOn { get; internal set; }
        public string UpdatedBy { get; internal set; }

        public AnalysisBin(long nBinID, string sTitle, Nullable<double> fLD, Nullable<double> fUD, bool bIsActive, Color colDisplay, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
        {
            BinID = nBinID;
            Title = sTitle;
            LowerDischarge = fLD;
            UpperDischarge = fUD;
            IsActive = bIsActive;
            DisplayColor = colDisplay;
            AddedOn = dtAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dtUpdatedOn;
            UpdatedBy = sUpdatedBy;
        }

        public static Dictionary<long, AnalysisBin> Load(string sDBCon)
        {
            Dictionary<long, AnalysisBin> dResult = new Dictionary<long, AnalysisBin>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDBCon))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM AnalysisBins ORDER BY LowerDischarge", dbCon);
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
