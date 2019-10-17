using System.Collections.Generic;
using Caching.Demo.Api.Models;
using Caching.Demo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caching.Demo.Api.Controllers
{
    [Route("")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("product")]
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.Get();
        }

        [Route("product")]
        [HttpPost]
        public Product Store([FromBody]Product product)
        {
            return _productService.Store(product);
        }

    }
}