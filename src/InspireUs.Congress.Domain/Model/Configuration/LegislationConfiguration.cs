using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspireUs.Congress.Domain.Model.Configuration
{
    public class LegislationConfiguration : IEntityTypeConfiguration<Legislation>
    {
        public void Configure(EntityTypeBuilder<Legislation> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.BillNumber).HasMaxLength(30);
        }
    }
}

