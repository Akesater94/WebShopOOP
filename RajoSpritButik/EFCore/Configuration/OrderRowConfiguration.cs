using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

internal class OrderRowConfiguration : IEntityTypeConfiguration<OrderRow>
{
    public void Configure(EntityTypeBuilder<OrderRow> builder)
    {
        builder.HasKey(or => or.Id);

        builder.Property(or => or.Quantity).IsRequired();

        builder.HasOne(or => or.Product).WithMany(p => p.OrderRows).HasForeignKey(or => or.ProductId);
        builder.HasOne(or => or.Order).WithMany(o => o.OrderRows).HasForeignKey(or => or.OrderId);
    }
}
