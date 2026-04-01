using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
{
    public void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Value).IsRequired().HasMaxLength(256);
        builder.HasOne(c => c.ContactType).WithMany(c => c.ContactInfos).IsRequired().HasForeignKey(c => c.ContactTypeId).OnDelete(DeleteBehavior.Restrict);
}
}
