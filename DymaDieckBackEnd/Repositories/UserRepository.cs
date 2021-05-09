using System;
using System.Data;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using DymaDieckBackend.Entity;

namespace DymaDieckBackend.Repositories
{
    public class UserRepository
    {
        private string sqlConnectionString = "";

        public UserRepository(string ConnectionString)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException("ConnectionString is required");
            this.sqlConnectionString = ConnectionString;
        }            
        

        public vwUsuario AuthenticateUserWeb(string username, string password)
        {
            vwUsuario resp;
            using (var connection = Util.DbManager.ConnectionFactory(sqlConnectionString))
            {
                connection.Open();
               
                var parameters = new DynamicParameters();
                parameters.Add("@Usuario", username, DbType.String, ParameterDirection.Input, null);
                parameters.Add("@contraseña", password, DbType.String, ParameterDirection.Input, null);
                
                resp = connection.Query<vwUsuario>("select * From Usuario with(nolock) Where Usuario = @Usuario And contraseña = @contraseña And Activo = 1", parameters).FirstOrDefault();
                if (resp == null)
                    throw new Exception("User not Autorized");
                return resp;
            }
        }
    }
}
