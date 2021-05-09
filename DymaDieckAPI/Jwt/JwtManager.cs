using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

namespace DymaDieckAPI.Jwt
{
    public static class JwtManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Use the below code to generate symmetric Secret Key
        ///     var hmac = new HMACSHA256();
        ///     var key = Convert.ToBase64String(hmac.Key);
        /// </summary>
        private static string Secret = ConfigurationManager.AppSettings["secret"];
        private static string Issuer = ConfigurationManager.AppSettings["issuer"];
        private static string tokenMinutesToExpire = ConfigurationManager.AppSettings["tokenMinutesToExpire"];
        private static string validateTokenExpiration = ConfigurationManager.AppSettings["validateTokenExpiration"];

        //public static string GenerateToken(string userName, long NPK_Employee, int NPK_Client, string imei, int isSupervisor, int NPK_User)
        //{
        //    var symmetricKey = Convert.FromBase64String(Secret);
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var now = DateTime.UtcNow;
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //                {
        //                    new Claim(ClaimTypes.Name, userName),
        //                    new Claim(ClaimTypes.SerialNumber, imei),
        //                    new Claim("IsSupevisor",isSupervisor.ToString()),
        //                    new Claim("NFK_Employee",NPK_Employee.ToString()),
        //                    new Claim("NFK_User",NPK_User.ToString()),                           
        //                    new Claim("NFK_Client",NPK_Client.ToString())                            
        //                }),

        //        Expires = now.AddMinutes(Convert.ToInt32(tokenMinutesToExpire)),
        //        Issuer = Issuer,
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var stoken = tokenHandler.CreateToken(tokenDescriptor);
        //    var token = tokenHandler.WriteToken(stoken);

        //    return token;
        //}

        public static string GenerateTokenWeb(string Usuario, long NPK_Usuario, string nombre, string ApellidoPaterno, string ApellidoMaterno)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, Usuario),
                            new Claim("NPK_Usuario",NPK_Usuario.ToString()),
                            new Claim(ClaimTypes.GivenName,nombre),
                        }),

                Expires = now.AddMinutes(Convert.ToInt32(tokenMinutesToExpire)),
                Issuer = Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        // COMPRUEBA LA CADUCIDAD DEL TOKEN
        public static bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            var valid = false;

            if ((expires.HasValue && DateTime.UtcNow < expires) && (notBefore.HasValue && DateTime.UtcNow > notBefore))
            {
                valid = true;
            }

            return valid;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {                   
                    RequireExpirationTime = (validateTokenExpiration=="1"?true:false),
                    ValidateLifetime = (validateTokenExpiration=="1"?true:false),
                    LifetimeValidator = LifetimeValidator,
                    ValidIssuer = Issuer,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateIssuerSigningKey = true
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception ex)
            {
                log.Error(string.Format("ValidateToken {0}", token), ex);
                return null;
            }
        }
        public static ClaimsPrincipal GetPrincipalOffline(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = false,
                    ValidateLifetime = false,
                    ValidIssuer = Issuer,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateIssuerSigningKey = true
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception ex)
            {
                log.Error(string.Format("ValidateToken {0}", token), ex);
                return null;
            }
        }
    }
}