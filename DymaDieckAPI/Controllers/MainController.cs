using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DymaDieckAPI.Filters;

namespace DymaDieckAPI.Controllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE, OPTIONS")]
    [RoutePrefix("api/v1/main")]
    public class MainController : ApiController
    {
        /// <summary>
        /// Retorno de version
        /// </summary>
        /// <returns></returns>
        [JwtAuthentication]
        [Route("version"), HttpGet, ResponseType(typeof(string))]
        public string version()
        {
            return "1.0.1";
        }
    }
}
