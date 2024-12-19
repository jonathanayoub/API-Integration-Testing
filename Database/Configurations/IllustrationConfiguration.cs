using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class IllustrationConfiguration : IEntityTypeConfiguration<Illustration>
{
    public void Configure(EntityTypeBuilder<Illustration> builder)
    {
        builder.ToTable("Illustration", "Production");

        builder.HasKey(a => a.IllustrationId);
    }
}