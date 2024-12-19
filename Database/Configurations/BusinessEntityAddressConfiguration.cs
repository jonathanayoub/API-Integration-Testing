using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class BusinessEntityAddressConfiguration : IEntityTypeConfiguration<BusinessEntityAddressEntity>
{
    public void Configure(EntityTypeBuilder<BusinessEntityAddressEntity> builder)
    {
        builder.ToTable("BusinessEntityAddress", "Person");

        builder.HasKey(a => new {a.BusinessEntityId, a.AddressId, a.AddressTypeId });

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b => b.BusinessEntityAddresses)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Address)
            .WithMany()
            .HasForeignKey(a => a.AddressId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.AddressType)
            .WithMany(b => b.BusinessEntityAddresses)
            .HasForeignKey(a => a.AddressTypeId).OnDelete(DeleteBehavior.NoAction);

    }
}