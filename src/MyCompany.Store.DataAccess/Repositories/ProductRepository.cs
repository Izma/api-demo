using Dapper;
using MyCompany.Store.DataAccess.Connection;
using MyCompany.Store.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Store.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        /// <summary>
        /// Method for get a product list
        /// </summary>
        /// <returns>list of type <see cref="ProductModel"/></returns>
        public async Task<IQueryable<ProductModel>> GetProductsAsync()
        {
            return await WithConnection(async db =>
            {
                var result = await db.QueryAsync<ProductModel>(sql: "[dbo].[spGetProducts]", commandType: CommandType.StoredProcedure, param: null).ConfigureAwait(false);
                return result.AsQueryable();
            }).ConfigureAwait(false);
        }
    }
}
