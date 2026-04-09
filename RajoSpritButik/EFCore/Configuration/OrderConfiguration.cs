using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Status).IsRequired().HasMaxLength(256);


        builder.HasOne(o => o.ShippingAlternative).WithMany(sa => sa.Orders).HasForeignKey(o => o.ShippingAlternativeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(o => o.PaymentAlternative).WithMany(pa => pa.Orders).HasForeignKey(o => o.PaymentAlternativeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(o => o.Address).WithMany(a => a.Orders).HasForeignKey(o => o.AddressId).OnDelete(DeleteBehavior.Restrict);
    }
}
