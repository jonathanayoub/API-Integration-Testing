﻿using ApiIntegrationTesting.Database.Entities.Shield;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations.Shield;

public sealed class SecurityGroupSecurityRoleEntityConfiguration : IEntityTypeConfiguration<SecurityGroupSecurityRoleEntity>
{
    public void Configure(EntityTypeBuilder<SecurityGroupSecurityRoleEntity> builder)
    {
        builder.ToTable("SecurityGroupSecurityRole", "Shield");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("SecurityGroupSecurityRoleId");

        builder.Property(a => a.RecordId).HasColumnName("SecurityGroupSecurityRoleGuid");

        builder.HasOne(a => a.SecurityGroup)
            .WithMany(b => b.SecurityGroupSecurityRoleEntities)
            .HasForeignKey(c => c.GroupId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.SecurityRole)
            .WithMany(b => b.SecurityGroupSecurityRoleEntities)
            .HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.NoAction);

    }
}
