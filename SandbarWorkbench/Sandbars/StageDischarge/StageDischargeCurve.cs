using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.Sandbars.StageDischarge
{
    public class SDCurve
    {
        public long SiteID { get; internal set; }
        public string SiteName { get; internal set; }
        public Nullable<double> CoeffA { get; internal set; }
        public Nullable<double> CoeffB { get; internal set; }
        public Nullable<double> CoeffC { get; internal set; }

        public SortableBindingList<SDValue> StageDischargeSamples { get; internal set; }

        public bool HasAllValues
        {
            get { return CoeffA.HasValue && CoeffB.HasValue && CoeffC.HasValue; }
        }

        public Nullable<double> Stage(double fDischarge)
        {
            Nullable<double> fResult = new Nullable<double>();
            if (CoeffA.HasValue && CoeffB.HasValue && CoeffC.HasValue)
                fResult= CoeffA + (CoeffB * fDischarge) + (CoeffC.Value * Math.Pow(fDischarge, 2));

            return fResult;
        }

        public SDCurve(long nSiteID, string sSiteName, Nullable<double> fCoeffA, Nullable<double> fCoeffB, Nullable<double> fCoeffC)
        {
            SiteID = nSiteID;
            SiteName = sSiteName;
            CoeffA = fCoeffA;
            CoeffB = fCoeffB;
            CoeffC = fCoeffC;

            // Call the load method to instantiate this dictionary.
            StageDischargeSamples = null;
        }

        public string CurveAsCSV(double fMinDischarge, double fMaxDischarge, double fDischargeIncrement)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("stage,discharge");

            for (double fDischarge  = fMinDischarge; fDischarge <= fMaxDischarge;fDischarge+=fDischargeIncrement)
                sb.AppendLine(string.Format("{0},{1}", fDischarge, Stage(fDischarge).Value));

            return sb.ToString();
        }

        public int LoadStageDischargeValues()
        {
            StageDischargeSamples = SDValue.Load(this.SiteID);
            return StageDischargeSamples.Count;
        }
    }
}
