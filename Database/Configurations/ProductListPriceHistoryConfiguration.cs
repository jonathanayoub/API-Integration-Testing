﻿using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ProductListPriceHistoryConfiguration : IEntityTypeConfiguration<ProductListPriceHistory>
{
    public void Configure(EntityTypeBuilder<ProductListPriceHistory> builder)
    {
        builder.ToTable("ProductListPriceHistory", "Production");

        builder.HasKey(a => new {a.ProductId, a.StartDate});

        builder.HasOne(a => a.Product)
            .WithMany(b=>b.ProductListPriceHistory)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);

    }
}