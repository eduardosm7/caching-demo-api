using System;
using System.Collections.Generic;
using System.Text.Json;
using Caching.Demo.Api.Data;
using Caching.Demo.Api.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Caching.Demo.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreDataContext _context;
        private readonly IDistributedCache _cache;

        public ProductRepository
        (
            StoreDataContext context,
            IDistributedCache cache
        )
        {
            _context = context;
            _cache = cache;
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            // Check if is in cache
            var cachedProductString = _cache.GetString(id.ToString());
            if (cachedProductString != null)
            {
                // Demonstration purposes
                Console.WriteLine("=======================================");
                Console.WriteLine("Cache HIT");
                Console.WriteLine("=======================================");

                return JsonSerializer.Deserialize<Product>(cachedProductString);
            }
            // Demonstration purposes
            Console.WriteLine("=======================================");
            Console.WriteLine("Cache MISS");
            Console.WriteLine("=======================================");
            return _context.Products.Find(id);
        }

        public Product Store(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            // Caching
            var options = new DistributedCacheEntryOptions();
            _cache.SetString(product.Id.ToString(), JsonSerializer.Serialize(product), options);

            // Demonstration purposes
            Console.WriteLine("=======================================");
            Console.WriteLine("Saved object in cache");
            Console.WriteLine(_cache.GetString(product.Id.ToString()));
            Console.WriteLine("=======================================");

            return product;
        }

    }
}