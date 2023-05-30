﻿using BackendEvaluation.Domain.Models.Item;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BackendEvaluation.Infrastructure.Persistence.Configurations;
public class ItemConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Items", "itm");
        builder.HasKey(c => c.Id);
        builder.HasAlternateKey(x => x.Id);
    }
}