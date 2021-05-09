using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DymaDieckAPI.Filters;
using DymaDieckAPI.Jwt;
using DymaDieckAPI.Models;
using DymaDieckBackend;

namespace DymaDieckAPI.Controllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE, OPTIONS")]
    [RoutePrefix("api/v1/token")]
    public class TokenController : BaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
               

        [AllowAnonymous]
        [Route("loginWeb"), HttpPost, ResponseType(typeof(LoginResult))]
        public HttpResponseMessage LoginWeb(Models.LoginFormWeb datos)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var authorized = DymaDieckBackend.Actions.Task.LoginUserWeb(datos.username, datos.password);
                    var result = new LoginResult();

                    result.NPK_Usuario = authorized.NPK_Usuario;
                    result.Usuario = authorized.Usuario;
                    result.Nombre = authorized.Nombre;

                    result.ApellidoPaterno = authorized.ApellidoPaterno;
                    result.ApellidoMaterno = authorized.ApellidoMaterno;
                    result.Administrador = authorized.Administrador;
                    result.Vendedor = authorized.Vendedor;
                    result.Almacen = authorized.Almacen;
                    result.TipoUsuario = authorized.TipoUsuario;
                    result.Token = JwtManager.GenerateTokenWeb(authorized.Usuario, authorized.NPK_Usuario, authorized.Nombre, authorized.ApellidoPaterno, authorized.ApellidoMaterno);                    
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception ex)
                {
                    log.Info(">>>>>>>>>> Login Web");
                    log.Error(ex);
                    log.Info("<<<<<<<<<< Login Web");
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex.Message);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

       

    }
}