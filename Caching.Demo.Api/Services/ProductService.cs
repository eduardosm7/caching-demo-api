using System.Collections.Generic;
using Caching.Demo.Api.Models;
using Caching.Demo.Api.Repositories;

namespace Caching.Demo.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepositoty;

        public ProductService
        (
            IProductRepository productRepository
        )
        {
            _productRepositoty = productRepository;
        }

        public IEnumerable<Product> Get()
        {
            return _productRepositoty.Get();
        }

        public Product Store(Product product)
        {
            return _productRepositoty.Store(product);
        }

    }
}