using Microsoft.Data.SqlClient;

namespace MyCompany.Store.DataAccess.Connection
{
    public interface IConnectionFactory
    {
        SqlConnection GetConnection();
    }
}
