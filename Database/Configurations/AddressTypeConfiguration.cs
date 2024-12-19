using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressTypeEntity>
{
    public void Configure(EntityTypeBuilder<AddressTypeEntity> builder)
    {
        builder.ToTable("AddressType", "Person");
        builder.HasKey(a => a.AddressTypeId);
    }
}