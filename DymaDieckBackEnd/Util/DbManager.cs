using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DymaDieckBackend.Util
{
    public static class DbManager
    {
        public static Func<string, DbConnection> ConnectionFactory = (clientConnectionString) => new SqlConnection(clientConnectionString);
       // public static Func<DbConnection> DeviceAdminFactory = () => new SqlConnection(ConnectionString.DeviceAdminConnection);

        public static class ConnectionString
        {
            public static string Connection = ConfigurationManager.ConnectionStrings["DieckDb"].ConnectionString;
        }
    }
}
