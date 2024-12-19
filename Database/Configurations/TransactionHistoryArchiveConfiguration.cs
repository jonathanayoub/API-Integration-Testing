using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class TransactionHistoryArchiveConfiguration : IEntityTypeConfiguration<TransactionHistoryArchive>
{
    public void Configure(EntityTypeBuilder<TransactionHistoryArchive> builder)
    {
        builder.ToTable("TransactionHistoryArchive", "Production");

        builder.HasKey(a => a.TransactionId);
    }
}