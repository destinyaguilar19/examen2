using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DymaDieckAPI.Models
{
    public class LoginResult
    {
        public long NPK_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Token { get; set; }
        public int? Administrador { get; set; }
        public int? Vendedor { get; set; }
        public int? Almacen { get; set; }
        public string TipoUsuario { get; set; }
    }
}