using System.Collections.Generic;
using Caching.Demo.Api.Models;

namespace Caching.Demo.Api.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> Get();
        public Product GetById(int id);
        public Product Store(Product product);
    }
}
