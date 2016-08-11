using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.Sandbars
{
    public class StageDischargeCurve
    {
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
                fResult= CoeffA + (CoeffB * fDischarge) - Math.Pow(CoeffC.Value * fDischarge, 2);

            return fResult;
        }

        public StageDischargeCurve(Nullable<double> fCoeffA, Nullable<double> fCoeffB, Nullable<double> fCoeffC)
        {
            CoeffA = fCoeffA;
            CoeffB = fCoeffB;
            CoeffC = fCoeffC;
        }
    }
}
