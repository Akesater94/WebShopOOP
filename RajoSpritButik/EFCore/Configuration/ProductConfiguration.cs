using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(256);

        builder.Property(p => p.Stock).IsRequired();

        builder.HasOne(p => p.Category).WithMany(c => c.Products);
        builder.HasOne(p => p.Manufacturer).WithMany(m => m.Products);

    }
}
