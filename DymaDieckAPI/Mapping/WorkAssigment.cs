using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YfosERPAPI.Mapping
{
    public class WorkAssigment
    {
        public long NPK_WorkAssignment { get; set; }

        public int NFK_WeekYear { get; set; }

        public long NFK_Employee { get; set; }

        public string AssignDate { get; set; }

        public long? NFK_Job { get; set; }

        public long? NFK_Supervisor { get; set; }

        public string StartTime { get; set; }

        public string FinishTime { get; set; }        

        public string NumberWeekYear { get; set; }

        public string Supervisor { get; set; }

        public string JobNumber { get; set; }

        public string JobDescription { get; set; }

        public string Observations { get; set; }
    }
}