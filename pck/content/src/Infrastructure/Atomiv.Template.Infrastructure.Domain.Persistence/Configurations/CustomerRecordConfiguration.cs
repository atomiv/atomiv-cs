﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Configurations
{
    public class CustomerRecordConfiguration : IEntityTypeConfiguration<CustomerRecord>
    {
        public void Configure(EntityTypeBuilder<CustomerRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.ReferenceNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}