using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
{
    public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
    {
        builder.ToTable("PhoneNumberType", "Person");

        builder.HasKey(a => a.PhoneNumberTypeId);

    }
}