using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.Sandbars
{
    public class SandbarSection
    {
        public long SectionID { get; internal set; }
        public long SectionTypeID { get; internal set; }
        public double Uncertainty { get; internal set; }

        public SandbarSection(long nSectionID, long nSectionTypeID, double fUncertainty)
        {
            SectionID = nSectionID;
            nSectionTypeID = SectionTypeID;
            Uncertainty = fUncertainty;
        }
    }
}
