using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

internal class ShoppingCartRowConfiguration : IEntityTypeConfiguration<ShoppingCartRow>
{
    public void Configure(EntityTypeBuilder<ShoppingCartRow> builder)
    {
        builder.HasKey(scr => scr.Id);
        builder.Property(sc => sc.Quantity).IsRequired();

        builder.HasOne(scr => scr.ShoppingCart).WithMany(sc => sc.ShoppingCartRows);
        builder.HasOne(scr => scr.Product).WithMany(p => p.ShoppingCartRows);
    }
}
