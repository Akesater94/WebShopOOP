using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class UserContactInfoConfiguration : IEntityTypeConfiguration<UserContactInfo>
{
    public void Configure(EntityTypeBuilder<UserContactInfo> builder)
    {
        builder.HasKey();
        // Inte klar... behöver fortsättas
    }
}
