using ApiIntegrationTesting.Database.Entities.Shield;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations.Shield;

public sealed class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<UserRefreshTokenEntity> builder)
    {
        builder.ToTable("UserRefreshToken", "Shield");

        builder.HasKey(a => a.UserRefreshTokenId);

        builder.Property(b => b.RecordId).HasColumnName("UserRefreshTokenGuid");
        builder.Property(b => b.BusinessEntityId).HasColumnName("BusinessEntityId");
        builder.Property(b => b.IpAddress).HasColumnName("IpAddress");
        builder.Property(b => b.RefreshToken).HasColumnName("RefreshToken");
        builder.Property(b => b.IsExpired).HasColumnName("IsExpired");
        builder.Property(b => b.IsRevoked).HasColumnName("IsRevoked");
        builder.Property(b => b.RevokedOn).HasColumnName("RevokedOn");

        builder.HasOne(a => a.BusinessEntity)
            .WithMany()
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.UserAccountEntity)
            .WithMany(b => b.UserRefreshTokenEntities)
            .HasForeignKey(c => c.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

    }
}
