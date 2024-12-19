using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class EmployeeDepartmentHistoryConfiguration : IEntityTypeConfiguration<EmployeeDepartmentHistory>
{
    public void Configure(EntityTypeBuilder<EmployeeDepartmentHistory> builder)
    {
        builder.ToTable("EmployeeDepartmentHistory", "HumanResources");

        builder.HasKey(a => new {a.BusinessEntityId, a.DepartmentId, a.ShiftId, a.StartDate});

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b => b.EmployeeDepartmentHistory)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Department)
            .WithMany(b => b.EmployeeDepartmentHistory)
            .HasForeignKey(a => a.DepartmentId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Shift)
            .WithMany(b => b.EmployeeDepartmentHistory)
            .HasForeignKey(a => a.ShiftId).OnDelete(DeleteBehavior.NoAction);
    }
}