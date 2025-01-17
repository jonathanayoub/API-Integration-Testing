﻿using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class CountryRegionCurrencyConfiguration : IEntityTypeConfiguration<CountryRegionCurrency>
{
    public void Configure(EntityTypeBuilder<CountryRegionCurrency> builder)
    {
        builder.ToTable("CountryRegionCurrency", "Sales");

        builder.HasKey(a => new {a.CountryRegionCode, a.CurrencyCode});

        builder.HasOne(a => a.CountryRegionEntityCodeNavigation)
            .WithMany()
            .HasForeignKey(a => a.CountryRegionCode).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.CurrencyCodeNavigation)
            .WithMany()
            .HasForeignKey(a => a.CurrencyCode).OnDelete(DeleteBehavior.NoAction);
    }
}