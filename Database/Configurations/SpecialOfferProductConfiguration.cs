using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class SpecialOfferProductConfiguration : IEntityTypeConfiguration<SpecialOfferProduct>
{
    public void Configure(EntityTypeBuilder<SpecialOfferProduct> builder)
    {
        builder.ToTable("SpecialOfferProduct", "Sales");

        builder.HasKey(a => new {a.SpecialOfferId, a.ProductId});

        builder.HasOne(a => a.Product)
            .WithMany(b=>b.SpecialOfferProducts)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.SpecialOffer)
            .WithMany(b=>b.SpecialOfferProducts)
            .HasForeignKey(a => a.SpecialOfferId).OnDelete(DeleteBehavior.NoAction);
    }
}