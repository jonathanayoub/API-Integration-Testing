using ApiIntegrationTesting.Database.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactTypeEntity>
{
    public void Configure(EntityTypeBuilder<ContactTypeEntity> builder)
    {
        builder.ToTable("ContactType", "Person");

        builder.HasKey(a => a.ContactTypeId);
    }
}