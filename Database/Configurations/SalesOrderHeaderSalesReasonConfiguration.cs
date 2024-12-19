using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class SalesOrderHeaderSalesReasonConfiguration : IEntityTypeConfiguration<SalesOrderHeaderSalesReason>
{
    public void Configure(EntityTypeBuilder<SalesOrderHeaderSalesReason> builder)
    {
        builder.ToTable("SalesOrderHeaderSalesReason", "Sales");

        builder.HasKey(a => new {a.SalesOrderId, a.SalesReasonId});

        builder.HasOne(a => a.SalesOrder)
            .WithMany(b=> b.SalesOrderHeaderSalesReasons)
            .HasForeignKey(a => a.SalesOrderId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.SalesReason)
            .WithMany()
            .HasForeignKey(a => a.SalesReasonId).OnDelete(DeleteBehavior.NoAction);

    }
}