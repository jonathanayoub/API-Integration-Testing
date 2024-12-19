using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class EmailAddressConfiguration : IEntityTypeConfiguration<EmailAddress>
{
    public void Configure(EntityTypeBuilder<EmailAddress> builder)
    {
        builder.ToTable("EmailAddress", "Person");

        builder.Property(x => x.EmailAddressName).HasColumnName("EmailAddress");

        builder.HasKey(a => a.EmailAddressId);

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b=>b.EmailAddresses)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);
    }
}