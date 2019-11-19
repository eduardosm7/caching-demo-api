using System;
using Caching.Demo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Caching.Demo.Api.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
        private string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
        private string DB_USER = Environment.GetEnvironmentVariable("DB_USER");
        private string DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={DB_HOST};Database={DB_NAME};Username={DB_USER};Password={DB_PASSWORD}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

    }
}