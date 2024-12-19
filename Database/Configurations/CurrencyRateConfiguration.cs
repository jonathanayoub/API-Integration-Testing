using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
{
    public void Configure(EntityTypeBuilder<CurrencyRate> builder)
    {
        builder.ToTable("CurrencyRate", "Sales");

        builder.HasKey(a => a.CurrencyRateId);

        builder.HasOne(a => a.FromCurrencyCodeNavigation)
            .WithMany()
            .HasForeignKey(a => a.FromCurrencyCode).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.ToCurrencyCodeNavigation)
            .WithMany()
            .HasForeignKey(a => a.ToCurrencyCode).OnDelete(DeleteBehavior.NoAction);

    }
}