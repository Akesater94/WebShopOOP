using Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class PaymentAlternativeConfiguration : IEntityTypeConfiguration<PaymentAlternative>
{
    public void Configure(EntityTypeBuilder<PaymentAlternative> builder)
    {
        builder.HasKey(pa => pa.Id);

        builder.Property(pa => pa.Name).HasMaxLength(256).IsRequired();
        builder.Property(pa => pa.Fee).IsRequired();
    }
}
