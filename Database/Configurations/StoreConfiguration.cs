using ApiIntegrationTesting.Database.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<StoreEntity>
{
    public void Configure(EntityTypeBuilder<StoreEntity> builder)
    {
        builder.ToTable("Store", "Sales");

        builder.HasKey(a => a.BusinessEntityId);

        builder.HasOne(a => a.StoreBusinessEntity)
            .WithMany(b => b.Stores)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.PrimarySalesPerson)
            .WithMany()
            .HasForeignKey(a => a.SalesPersonId).OnDelete(DeleteBehavior.NoAction);
    }
}