using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Caching.Demo.Api.Data;
using Caching.Demo.Api.Models;

namespace Caching.Demo.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreDataContext _context;

        public ProductRepository
        (
            StoreDataContext context
        )
        {
            _context = context;
        }
        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        public Product Store(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

    }
}