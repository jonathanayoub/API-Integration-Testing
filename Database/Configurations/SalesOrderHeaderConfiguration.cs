using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
{
    public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
    {
        builder.ToTable("SalesOrderHeader", "Sales");

        builder.HasKey(a => a.SalesOrderId);

        builder.HasOne(a => a.CustomerEntity)
            .WithMany(b => b.SalesOrderHeaders)
            .HasForeignKey(a => a.CustomerId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.SalesPerson)
            .WithMany(b=>b.SalesOrderHeaders)
            .HasForeignKey(a => a.SalesPersonId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.TerritoryEntity)
            .WithMany(b=> b.SalesOrderHeaders)
            .HasForeignKey(a => a.TerritoryId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.BillToAddressEntity)
            .WithMany(b => b.SalesOrderHeaderBillToAddresses)
            .HasForeignKey(a => a.BillToAddressId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.ShipToAddressEntity)
            .WithMany(b => b.SalesOrderHeaderShipToAddress)
            .HasForeignKey(a => a.ShipToAddressId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.ShipMethod)
            .WithMany(b=> b.SalesOrderHeaders)
            .HasForeignKey(a => a.ShipMethodId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.CreditCard)
            .WithMany(b=>b.SalesOrderHeaders)
            .HasForeignKey(a => a.CreditCardId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.CurrencyRate)
            .WithMany(b=> b.SalesOrderHeaders)
            .HasForeignKey(a => a.CurrencyRateId).OnDelete(DeleteBehavior.NoAction);

    }
}