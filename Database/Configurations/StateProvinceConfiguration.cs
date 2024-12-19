using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvinceEntity>
{
    public void Configure(EntityTypeBuilder<StateProvinceEntity> builder)
    {
        builder.ToTable("StateProvince", "Person");

        builder.HasKey(a => a.StateProvinceId);

        builder.HasOne(a => a.CountryRegion)
            .WithMany(b => b.StateProvinces)
            .HasForeignKey(a => a.CountryRegionCode).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.SalesTerritory)
            .WithMany(b => b.StateProvinces)
            .HasForeignKey(a => a.TerritoryId).OnDelete(DeleteBehavior.NoAction);
    }
}