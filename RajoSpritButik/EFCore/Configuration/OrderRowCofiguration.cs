using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class OrderRowCofiguration : IEntityTypeConfiguration<OrderRow>
{
    public void Configure(EntityTypeBuilder<OrderRow> builder)
    {
        builder.HasKey(or => or.Id);

        builder.HasOne(or => or.Product).WithMany(p => p.OrderRows).HasForeignKey(or => or.ProductId);
        builder.HasOne(or => or.Order).WithMany(o => o.OrderRows).HasForeignKey(or => or.OrderId);
    }
}
