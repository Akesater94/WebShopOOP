using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configuration;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(256);

        builder.HasMany(c => c.Addresses).WithOne(a => a.Country).HasForeignKey(a => a.CountryId);
        builder.HasMany(c => c.Manufacturers).WithOne(m => m.Country).HasForeignKey(m => m.CountryId);
    }
}
