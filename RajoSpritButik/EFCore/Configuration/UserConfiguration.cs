using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name).IsRequired().HasMaxLength(256);

        builder.Property(u => u.CreatedAt).IsRequired();

        builder.HasOne(u => u.Role).WithMany(r => r.Users);
        builder.HasOne(u => u.Address).WithMany(a => a.Users);
    }
}
