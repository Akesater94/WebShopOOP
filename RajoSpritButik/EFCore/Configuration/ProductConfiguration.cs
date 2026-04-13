using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(256);

        builder.Property(p => p.Stock).IsRequired();
        builder.Property(p => p.Showcase).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Description).IsRequired().HasMaxLength(256);

        builder.HasOne(p => p.Category).WithMany(c => c.Products);
        builder.HasOne(p => p.Manufacturer).WithMany(m => m.Products);

    }
}
