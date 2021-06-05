using Microsoft.Data.SqlClient;

namespace MyCompany.Store.DataAccess.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
