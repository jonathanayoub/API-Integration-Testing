using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product", "Production");

        builder.HasKey(p => p.ProductId);

        builder.HasOne(p => p.ProductModel)
            .WithMany(b=>b.Products)
            .HasForeignKey(p => p.ProductModelId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ProductSubcategory)
            .WithMany(b=>b.Products)
            .HasForeignKey(p => p.ProductSubcategoryId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.SizeUnitMeasureCodeNavigation)
            .WithMany(b=>b.ProductSizeUnitMeasureCodeNavigation)
            .HasForeignKey(p => p.SizeUnitMeasureCode).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.WeightUnitMeasureCodeNavigation)
            .WithMany(b=>b.ProductWeightUnitMeasureCodeNavigation)
            .HasForeignKey(p => p.WeightUnitMeasureCode).OnDelete(DeleteBehavior.NoAction);
    }
}