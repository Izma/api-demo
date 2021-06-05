using MyCompany.Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Store.Services
{
    public interface IProductService
    {
        Task<IList<ProductModel>> GetProductsAsync();
    }
}
