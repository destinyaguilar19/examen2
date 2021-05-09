using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YfosERPAPI.Mapping
{
    public class Job
    {
        public long NPK_Job { get; set; }

        public string JobNumber { get; set; }

        public string Description { get; set; }

        public int NFK_TypeJob { get; set; }

        public string TypeJob { get; set; }

        public int NFK_TypeProject { get; set; }

        public string TypeProject { get; set; }        

        public int NFK_Client { get; set; }

        public string ClientName { get; set; }

        public string ClientCode { get; set; }

        public int NFK_County { get; set; }

        public string County { get; set; }

        public int NFK_City { get; set; }

        public string City { get; set; }

        public int NFK_StatusJob { get; set; }

        public string StatusJob { get; set; }

        public int ApplyHours { get; set; }

        [JsonIgnore]
        public int Active { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public int CreateBy { get; set; }
        [JsonIgnore]
        public DateTime? ModificationDate { get; set; }
        [JsonIgnore]
        public int? ModificationBy { get; set; }
                
        
    }
}