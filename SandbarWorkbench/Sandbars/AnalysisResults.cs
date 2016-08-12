using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.Sandbars
{
    class AnalysisResults
    {
    }

    public class SectionValues
    {
        public Dictionary<double, Values> Elevations { get; set; }

        public SectionValues()
        {
            Elevations = new Dictionary<double, Values>();
        }
    }

    public class Values
    {
        public double Area { get; internal set; }
        public double Vol { get; internal set}

        public Values(double fArea, double fVol)
        {
            Area = fArea;
            Vol = fVol;
        }
    }
}
