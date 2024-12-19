using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class CountryRegionConfiguration : IEntityTypeConfiguration<CountryRegionEntity>
{
    public void Configure(EntityTypeBuilder<CountryRegionEntity> builder)
    {
        builder.ToTable("CountryRegion", "Person");

        builder.HasKey(a => a.CountryRegionCode);

    }
}