using System;
using InspireUs.Congress.Domain;
using InspireUs.Congress.Infrastructure;
using InspireUs.Congress.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InspireUs.Congress.Api.DesignTime
{
    public class CongressDbContextFactory : IDesignTimeDbContextFactory<CongressDbContext>
    {
        private const string AdminConnectionString = "CONGRESS_ADMIN_CONNECTIONSTRING";

        public CongressDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable(AdminConnectionString);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ApplicationException(
                    $"Please set the environment variable {AdminConnectionString}");
            }

            var options = new DbContextOptionsBuilder<CongressDbContext>()
                .UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(
                        typeof(ServiceRegistration).Assembly.FullName);
                })
                .Options;

            return new CongressDbContext(options, new SqlModelConfiguration());
        }
    }
}

