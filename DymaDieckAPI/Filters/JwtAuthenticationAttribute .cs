using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using DymaDieckAPI.Filters;
using DymaDieckAPI.Jwt;

namespace DymaDieckAPI.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("You need an authorization token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);


            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);

            else
                context.Principal = principal;


        }
        
        private static bool ValidateToken(string token, out DymaDieckAPI.Models.LoginResult username)
        {
            username = null;
           
            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            username = new DymaDieckAPI.Models.LoginResult();

            string userName = identity.FindFirst(ClaimTypes.Name).Value;
            username.Usuario = userName;

            string imei = identity.FindFirst(ClaimTypes.GivenName).Value;
            username.Nombre = imei;
          
            string NFK_User = identity.FindFirst(x => x.Type == "NPK_Usuario").Value;
            username.NPK_Usuario = (NFK_User == "" ? 0 : Convert.ToInt32(NFK_User));

            if (string.IsNullOrEmpty(username.Usuario))
                return false;
          
            // More validate to check whether username exists in system

            return true;
        }
        
        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            //DymaDieckBackend.DeviceAdmin.vw_UserAuthorized usuario;
            DymaDieckAPI.Models.LoginResult usuario;
            if (ValidateToken(token, out usuario))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Usuario),
                    new Claim("NPK_Usuario",usuario.NPK_Usuario.ToString()),
                    new Claim(ClaimTypes.GivenName,usuario.Nombre),
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);
                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}