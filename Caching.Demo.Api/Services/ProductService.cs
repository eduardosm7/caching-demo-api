using System.Collections.Generic;
using Caching.Demo.Api.Models;
using Caching.Demo.Api.Repositories;

namespace Caching.Demo.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService
        (
            IProductRepository productRepository
        )
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product Store(Product product)
        {
            return _productRepository.Store(product);
        }

    }
}