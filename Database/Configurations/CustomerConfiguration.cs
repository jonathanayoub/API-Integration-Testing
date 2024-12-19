using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("Customer", "Sales");

        builder.HasKey(a => a.CustomerId);

        builder.HasOne(a => a.Person)
            .WithMany(b=>b.Customers)
            .HasForeignKey(a => a.PersonId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.TerritoryEntity)
            .WithMany(b=>b.Customers)
            .HasForeignKey(a => a.TerritoryId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.StoreEntity)
            .WithMany(b=>b.Customers)
            .HasForeignKey(a => a.StoreId);
    }
}