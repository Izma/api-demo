using MyCompany.Store.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Store.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<IQueryable<ProductModel>> GetProductsAsync();
    }
}
