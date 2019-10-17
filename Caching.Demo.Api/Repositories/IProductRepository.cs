using System.Collections.Generic;
using Caching.Demo.Api.Models;

namespace Caching.Demo.Api.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Get();
        public Product Store(Product product);
    }
}