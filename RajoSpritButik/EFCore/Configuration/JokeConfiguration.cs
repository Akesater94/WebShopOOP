using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configuration;

internal class JokeConfiguration : IEntityTypeConfiguration<Joke>
{
    public void Configure(EntityTypeBuilder<Joke> builder)
    {
        builder.HasKey(j => j.Id);
        builder.Property(j => j.Value).IsRequired().HasMaxLength(512);
        builder.Property(j => j.CreatedAt).IsRequired();
    }
}
