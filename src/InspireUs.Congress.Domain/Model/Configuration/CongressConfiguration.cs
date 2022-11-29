using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InspireUs.Congress.Domain.Model.Configuration
{
    public class CongressConfiguration : IEntityTypeConfiguration<Congress>
    {
        public void Configure(EntityTypeBuilder<Congress> builder)
        {
            builder.HasKey(f => f.Nth);
            builder.HasData(GetCongressUpUntil(118));

            builder.HasMany(f => f.Legislations)
                .WithOne(g => g.Congress)
                .HasForeignKey(k => k.CongressNth);
        }

        private List<Congress> GetCongressUpUntil(int last)
        {
            var congress = new List<Congress>();
            for (int i = 1; i <= last; i++)
            {
                congress.Add(new Congress(GetNumberWithOrdinalSuffix(i)));
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

