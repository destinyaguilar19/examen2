using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace DymaDieckAPI.Controllers
{
    /// <summary>
    /// Funciones genericas heredadas a los demas Controllers
    /// </summary>
    public class BaseController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public long GetNPK_Employee()
        {           
            var usuario = HttpContext.Current.User.Identity as ClaimsIdentity;
            return int.Parse(usuario.Claims.Where(r => r.Type == "NFK_Employee").FirstOrDefault().Value);
        }
        public int GetNPK_Client()
        {
            var usuario = HttpContext.Current.User.Identity as ClaimsIdentity;
            return int.Parse(usuario.Claims.Where(r => r.Type == "NFK_Client").FirstOrDefault().Value);           
        }

        public bool IsSupervisor()
        {
            var usuario = HttpContext.Current.User.Identity as ClaimsIdentity;
            return (usuario.Claims.Where(r => r.Type == "IsSupervisor").FirstOrDefault().Value == "1" ? true : false);
        }

        public int GetNpkUser()
        {
            var usuario = HttpContext.Current.User.Identity as ClaimsIdentity;
            return int.Parse(usuario.Claims.Where(r => r.Type == "NPK_Usuario").FirstOrDefault().Value);
        }

        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DieckDb"].ToString();
        }

        //public string GetConnectionString(int npk_cliente)
        //{

        //    if (npk_cliente > 0)
        //    {
        //        var cliente = DymaDieckBackend.Actions.Task.GetClient(npk_cliente);
        //        return string.Format("Server={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=300;MultipleActiveResultSets=True;", cliente.HostServerDB.Trim(), cliente.DBName.Trim(), cliente.DBUser.Trim(), cliente.DBPassword.Trim());
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        public void CreateDirectoryIfNotExists(string filePath)
        {
            var directory = new FileInfo(filePath).Directory;
            if (directory == null) throw new Exception("Directory not found");
            Directory.CreateDirectory(directory.FullName);
        }
      
        
    }
}
