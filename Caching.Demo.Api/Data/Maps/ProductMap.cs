using Caching.Demo.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caching.Demo.Api.Data
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar(1024)");
            builder.Property(x => x.Description).IsRequired().HasColumnType("varchar(1024)");
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
        }
    }
}