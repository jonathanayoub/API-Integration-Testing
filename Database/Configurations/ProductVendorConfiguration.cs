using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ProductVendorConfiguration : IEntityTypeConfiguration<ProductVendor>
{
    public void Configure(EntityTypeBuilder<ProductVendor> builder)
    {
        builder.ToTable("ProductVendor", "Purchasing");

        builder.HasKey(a => new {a.ProductId, a.BusinessEntityId});

        builder.HasOne(a => a.Product)
            .WithMany(b=>b.ProductVendors)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b => b.ProductVendors)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.UnitMeasureCodeNavigation)
            .WithMany(b => b.ProductVendors)
            .HasForeignKey(a => a.UnitMeasureCode);
    }
}