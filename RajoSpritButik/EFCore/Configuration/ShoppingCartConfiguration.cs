using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Name).IsRequired().HasMaxLength(256);

        builder.HasOne(sc => sc.User).WithMany(u => u.ShoppingCarts).HasForeignKey(sc => sc.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}
