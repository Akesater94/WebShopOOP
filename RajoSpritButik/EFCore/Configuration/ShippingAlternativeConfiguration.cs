using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class ShippingAlternativeConfiguration : IEntityTypeConfiguration<ShippingAlternative>
{
    public void Configure(EntityTypeBuilder<ShippingAlternative> builder)
    {
        builder.HasKey(sa => sa.Id);

        builder.Property(sa => sa.Name).IsRequired().HasMaxLength(256);
        builder.Property(sa => sa.Price).IsRequired();
    }
}
