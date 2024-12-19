using ApiIntegrationTesting.Database.Entities.Shield;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations.Shield;

public sealed class SecurityGroupSecurityFunctionEntityConfiguration : IEntityTypeConfiguration<SecurityGroupSecurityFunctionEntity>
{
    public void Configure(EntityTypeBuilder<SecurityGroupSecurityFunctionEntity> builder)
    {
        builder.ToTable("SecurityGroupSecurityFunction", "Shield");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("SecurityGroupSecurityFunctionId");

        builder.Property(a => a.RecordId).HasColumnName("SecurityGroupSecurityFunctionGuid");

        builder.HasOne(a => a.SecurityGroup)
            .WithMany(b => b.SecurityGroupSecurityFunctionEntities)
            .HasForeignKey(c => c.GroupId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.SecurityFunction)
            .WithMany(b => b.SecurityGroupSecurityFunctionEntities)
            .HasForeignKey(c => c.FunctionId).OnDelete(DeleteBehavior.NoAction);
    }
}
