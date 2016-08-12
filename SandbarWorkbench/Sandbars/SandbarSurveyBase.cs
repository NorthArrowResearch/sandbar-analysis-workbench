using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.Sandbars
{
    public class SandbarSurveyBase
    {
        public long SurveyID { get; internal set; }
        public DateTime SurveyDate { get; internal set; }

        public SandbarSurveyBase(long nSurveyID, DateTime dSurveyDate)
        {
            SurveyID = nSurveyID;
            SurveyDate = dSurveyDate;
        }
    }
}
