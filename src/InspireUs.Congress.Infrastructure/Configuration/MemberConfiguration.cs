using System;
using InspireUs.Congress.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspireUs.Congress.Infrastructure.Configuration
{
	public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.OwnsOne(f => f.Address, b =>
            {
                b.Property(e => e.Address1).HasColumnName("Address1");
                b.Property(e => e.Address2).HasColumnName("Address2");
                b.Property(e => e.City).HasColumnName("AddressCity");
                b.Property(e => e.State).HasColumnName("AddressState");
                b.Property(e => e.ZipCode).HasColumnName("AddressZipCode");
            });

            builder.OwnsOne(f => f.District, b =>
            {
                b.Property(e => e.State).HasColumnName("StateRepresented");
                b.Property(e => e.DistrictNumber).HasColumnName("DistrictRepresented");
            });
        }
    }
}

