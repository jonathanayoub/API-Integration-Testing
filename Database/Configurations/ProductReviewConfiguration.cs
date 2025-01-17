﻿using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.ToTable("ProductReview", "Production");

        builder.HasKey(a => a.ProductReviewId);

        builder.HasOne(a => a.Product)
            .WithMany(b=>b.ProductReviews)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);
    }
}