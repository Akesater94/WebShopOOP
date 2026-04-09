using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(ua => ua.Id);

        builder.HasOne(ua => ua.Address).WithMany(a => a.UserAddresses);
        builder.HasOne(ua => ua.User).WithMany(u => u.UserAddresses);
    }
}
