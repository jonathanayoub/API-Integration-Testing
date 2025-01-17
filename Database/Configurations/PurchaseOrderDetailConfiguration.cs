﻿using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class PurchaseOrderDetailConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
    {
        builder.ToTable("PurchaseOrderDetail", "Purchasing");

        builder.HasKey(a => new {a.PurchaseOrderId, a.PurchaseOrderDetailId});

        builder.HasOne(a => a.Product)
            .WithMany(b=> b.PurchaseOrderDetails)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.PurchaseOrder)
            .WithMany(b=>b.PurchaseOrderDetails)
            .HasForeignKey(a => a.PurchaseOrderId).OnDelete(DeleteBehavior.NoAction);
    }
}