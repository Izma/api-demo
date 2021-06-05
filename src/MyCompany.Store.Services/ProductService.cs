using MyCompany.Store.DataAccess.Repositories;
using MyCompany.Store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Store.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Method for get product list
        /// </summary>
        /// <returns>List of type <see cref="ProductModel"/></returns>
        public async Task<IList<ProductModel>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync().ConfigureAwait(false);
            if(products?.Any() != true)
            {
                return new List<ProductModel>();
            }
            return products.ToList();
        }
    }
}
