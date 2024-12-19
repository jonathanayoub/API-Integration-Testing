using ApiIntegrationTesting.Database.Entities.Person;
using ApiIntegrationTesting.Database.Entities.Shield;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations.Shield;

public sealed class UserAccountConfiguration : IEntityTypeConfiguration<UserAccountEntity>
{
    public void Configure(EntityTypeBuilder<UserAccountEntity> builder)
    {
        builder.ToTable("UserAccount", "Shield");

        builder.HasKey(a => a.BusinessEntityId);

        builder.Property(b => b.RecordId).HasColumnName("rowguid");

        builder.Property(b => b.PasswordHash).HasColumnName("PasswordHash");

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b => b.UserAccounts)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Person)
            .WithOne(b => b.UserAccount)
            .HasForeignKey<PersonEntity>(c => c.BusinessEntityId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.EmailAddress)
            .WithMany()
            .HasForeignKey(x => x.PrimaryEmailAddressId).OnDelete(DeleteBehavior.NoAction)
            .HasPrincipalKey(y => y.EmailAddressId);

    }
}
