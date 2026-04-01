using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.City).IsRequired().HasMaxLength(256);
            builder.Property(a => a.Street).IsRequired().HasMaxLength(256);
            builder.Property(a => a.StreetNumber).IsRequired().HasMaxLength(256);
            builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(16);
            builder.HasOne(a => a.Country).WithMany(c => c.Addresses).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
