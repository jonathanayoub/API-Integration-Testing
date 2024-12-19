using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class PurchaseOrderHeaderConfiguration : IEntityTypeConfiguration<PurchaseOrderHeader>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderHeader> builder)
    {
        builder.ToTable("PurchaseOrderHeader", "Purchasing");

        builder.HasKey(a => a.PurchaseOrderId);

        builder.HasOne(a => a.Employee)
            .WithMany(b=>b.PurchaseOrderHeaders)
            .HasForeignKey(a => a.EmployeeId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Vendor)
            .WithMany(b=>b.PurchaseOrderHeaders)
            .HasForeignKey(a => a.VendorId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.ShipMethod)
            .WithMany(b=>b.PurchaseOrderHeaders)
            .HasForeignKey(a => a.ShipMethodId).OnDelete(DeleteBehavior.NoAction);
    }
}