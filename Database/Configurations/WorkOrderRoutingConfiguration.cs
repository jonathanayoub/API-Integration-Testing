using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class WorkOrderRoutingConfiguration : IEntityTypeConfiguration<WorkOrderRouting>
{
    public void Configure(EntityTypeBuilder<WorkOrderRouting> builder)
    {
        builder.ToTable("WorkOrderRouting", "Production");

        builder.HasKey(a => new {a.ProductId, a.OperationSequence});

        builder.HasOne(a => a.Product)
            .WithMany(b=>b.WorkOrderRoutings)
            .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Location)
            .WithMany(b=>b.WorkOrderRoutings)
            .HasForeignKey(a => a.LocationId).OnDelete(DeleteBehavior.NoAction);

    }
}