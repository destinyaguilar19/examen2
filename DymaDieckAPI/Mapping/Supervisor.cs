using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YfosERPAPI.Mapping
{
    public class Supervisor
    {
        public long NPK_SupervisorCustomer { get; set; }

        public int NFK_Client { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}