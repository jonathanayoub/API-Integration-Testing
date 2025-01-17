﻿using ApiIntegrationTesting.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiIntegrationTesting.Database.Configurations;

public class JobCandidateConfiguration : IEntityTypeConfiguration<JobCandidate>
{
    public void Configure(EntityTypeBuilder<JobCandidate> builder)
    {
        builder.ToTable("JobCandidate", "HumanResources");

        builder.HasKey(a => a.JobCandidateId);

        builder.HasOne(a => a.BusinessEntity)
            .WithMany(b => b.JobCandidates)
            .HasForeignKey(a => a.BusinessEntityId).OnDelete(DeleteBehavior.NoAction);


    }
}