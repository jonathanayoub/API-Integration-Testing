using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class PersonCreditCardConfiguration : IEntityTypeConfiguration<PersonCreditCard>
{
    public void Configure(EntityTypeBuilder<PersonCreditCard> builder)
    {
        builder.ToTable("PersonCreditCard", "Sales");

        builder.HasKey(a => new { a.BusinessEntityId, a.CreditCardId});

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b=>b.PersonCreditCards)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.CreditCard)
            .WithMany(b=>b.PersonCreditCards)
            .HasForeignKey(a => a.CreditCardId).OnDelete(DeleteBehavior.NoAction);

    }
}