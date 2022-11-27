using System;
using InspireUs.Congress.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspireUs.Congress.Domain.Model.Configuration
{
	public class MemberConfiguration : IEntityTypeConfiguration<Member>
	{
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(v => v.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(f => f.Address, b =>
            {
                b.Property(e => e.Address1).HasMaxLength(100);
                b.Property(e => e.Address2).HasMaxLength(100);
                b.Property(e => e.City).HasMaxLength(100);
                b.Property(e => e.State).HasPrecision(1); //maybe not do this
                b.Property(e => e.ZipCode).HasMaxLength(100);
            });

            builder.OwnsOne(f => f.District, b =>
            {
                b.Property(e => e.State).HasPrecision(1); //maybe not do this
                b.Property(e => e.DistrictNumber).HasPrecision(1); //maybe not do this
            });

            builder.OwnsMany(f => f.ServiceHistory);
        }
    }
}

