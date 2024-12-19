using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class BillOfMaterialsConfiguration : IEntityTypeConfiguration<BillOfMaterials>
{
    public void Configure(EntityTypeBuilder<BillOfMaterials> builder)
    {
        builder.ToTable("BillOfMaterials", "Production");

        builder.HasKey(a => a.BillOfMaterialsId);

        builder.HasOne(a => a.Component)
            .WithMany(b=>b.BillOfMaterialsComponents)
            .HasForeignKey(a => a.ComponentId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.ProductAssembly)
            .WithMany(b=>b.BillOfMaterialsProductAssemblies)
            .HasForeignKey(a => a.ProductAssemblyId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.UnitMeasureCodeNavigation)
            .WithMany(b=>b.BillOfMaterials)
            .HasForeignKey(a => a.UnitMeasureCode).OnDelete(DeleteBehavior.NoAction);
    }
}