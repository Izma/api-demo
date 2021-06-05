using Microsoft.Data.SqlClient;
using MyCompany.Store.DataAccess.Connection;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MyCompany.Store.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using var cn = _connectionFactory.GetConnection();
                await cn.OpenAsync().ConfigureAwait(false);
                return await getData(cn).ConfigureAwait(false);
            }
            catch (TimeoutException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }
    }
}
