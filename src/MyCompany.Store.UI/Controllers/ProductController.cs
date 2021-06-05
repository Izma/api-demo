using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Store.UI.Controllers
{
       [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("api/products")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync().ConfigureAwait(false);
            if (products?.Count > 0)
                return Ok(products);
            return NotFound();
        }

        [HttpGet]
        [Route("api/product/{productId:int}/details")]
        public IActionResult GetProductById(int productId)
        {
            return Ok(productId);
        }

        [Route("api/product")]
        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok();
        }
    }
}
