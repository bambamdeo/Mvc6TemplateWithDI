

using Microsoft.Data.SqlClient;
using ServiceLayer.Interface;

namespace ServiceLayer.Services
{
    public class ConnectionManager
    {
        public static string _connection;
        public ConnectionManager(string connection)
        {
            _connection = connection;
        }
     
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection _sqlConnection = new SqlConnection(_connection);
            return _sqlConnection;
        }
    }
}