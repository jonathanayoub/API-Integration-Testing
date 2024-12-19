using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ProductProductPhotoConfiguration : IEntityTypeConfiguration<ProductProductPhoto>
{
    public void Configure(EntityTypeBuilder<ProductProductPhoto> builder)
    {
        builder.ToTable("ProductProductPhoto", "Production");

        builder.HasKey(a => new {a.ProductId, a.ProductPhotoId });

        builder.HasOne(a => a.Product)
            .WithMany(b=>b.ProductProductPhotos)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.ProductPhoto)
            .WithMany(b=> b.ProductProductPhotos)
            .HasForeignKey(a => a.ProductPhotoId).OnDelete(DeleteBehavior.NoAction);
    }
}