using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.Sandbars
{
    public class StageDischargeCurve
    {
        public string SiteName { get; internal set; }
        public Nullable<double> CoeffA { get; internal set; }
        public Nullable<double> CoeffB { get; internal set; }
        public Nullable<double> CoeffC { get; internal set; }

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

        public StageDischargeCurve(string sSiteName, Nullable<double> fCoeffA, Nullable<double> fCoeffB, Nullable<double> fCoeffC)
        {
            SiteName = sSiteName;
            CoeffA = fCoeffA;
            CoeffB = fCoeffB;
            CoeffC = fCoeffC;
        }

        public string CurveAsCSV(double fMinDischarge, double fMaxDischarge, double fDischargeIncrement)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("stage,discharge");

            for (double fDischarge  = fMinDischarge; fDischarge <= fMaxDischarge;fDischarge+=fDischargeIncrement)
                sb.AppendLine(string.Format("{0},{1}", fDischarge, Stage(fDischarge).Value));

            return sb.ToString();
        }
    }
}
