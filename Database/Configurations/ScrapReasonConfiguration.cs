using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class ScrapReasonConfiguration : IEntityTypeConfiguration<ScrapReason>
{
    public void Configure(EntityTypeBuilder<ScrapReason> builder)
    {
        builder.ToTable("ScrapReason", "Production");

        builder.HasKey(a => a.ScrapReasonId);
    }
}