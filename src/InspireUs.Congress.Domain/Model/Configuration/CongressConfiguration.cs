using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspireUs.Congress.Domain.Model.Configuration
{
    public class CongressConfiguration : IEntityTypeConfiguration<UsCongress>
    {
        public void Configure(EntityTypeBuilder<UsCongress> builder)
        {
            builder.HasKey(f => f.Nth);
            builder.Property(f => f.Nth).HasMaxLength(10);
            builder.Property(f => f.StartDate).IsRequired(true);
            builder.Property(f => f.EndDate).IsRequired(true);

            builder.HasData(GetCongressUpUntil(118));

            builder.HasMany(f => f.Legislations)
                .WithOne(g => g.Congress)
                .HasForeignKey(k => k.CongressNth);
        }

        private List<UsCongress> GetCongressUpUntil(int last)
        {
            var start = 1789;
            var end = 1790;

            var congress = new List<UsCongress>();
            for (int i = 1; i <= last; i++)
            {
                congress.Add(new UsCongress(GetNumberWithOrdinalSuffix(i), null, start, end));

                start = start + 2;
                end = end + 2;
            }

            return congress;
        }

        private static string GetNumberWithOrdinalSuffix(int num)
        {
            string number = num.ToString();
            if (number.EndsWith("11")) return $"{num}th";
            if (number.EndsWith("12")) return $"{num}th";
            if (number.EndsWith("13")) return $"{num}th";
            if (number.EndsWith("1")) return $"{num}st";
            if (number.EndsWith("2")) return $"{num}nd";
            if (number.EndsWith("3")) return $"{num}rd";
            return $"{num}th";
        }
    }
}

