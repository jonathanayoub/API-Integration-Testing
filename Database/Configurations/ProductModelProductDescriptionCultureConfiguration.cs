﻿using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ProductModelProductDescriptionCultureConfiguration : IEntityTypeConfiguration<ProductModelProductDescriptionCulture>
{
    public void Configure(EntityTypeBuilder<ProductModelProductDescriptionCulture> builder)
    {
        builder.ToTable("ProductModelProductDescriptionCulture", "Production");

        builder.HasKey(a => new {a.ProductModelId, a.ProductDescriptionId, a.CultureId});

        builder.HasOne(a => a.ProductModel)
            .WithMany()
            .HasForeignKey(a => a.ProductModelId);

        builder.HasOne(a => a.ProductDescription)
            .WithMany()
            .HasForeignKey(a => a.ProductDescriptionId);

    }
}