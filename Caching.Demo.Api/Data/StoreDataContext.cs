using Caching.Demo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Caching.Demo.Api.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=caching-demo-psql;Database=caching-demo-psql;Username=admin;Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

    }
}