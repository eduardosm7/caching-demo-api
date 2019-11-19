using System.Collections.Generic;
using Caching.Demo.Api.Models;
using Caching.Demo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caching.Demo.Api.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.Get();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public Product Store([FromBody]Product product)
        {
            return _productService.Store(product);
        }

    }
}