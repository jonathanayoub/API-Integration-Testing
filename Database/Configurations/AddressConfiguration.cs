using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("Address", "Person");

        builder.HasKey(a => a.AddressId);

        builder.HasOne(a => a.StateProvince)
            .WithMany(b => b.Addresses)
            .HasForeignKey(a => a.StateProvinceId).OnDelete(DeleteBehavior.NoAction);
    }
}