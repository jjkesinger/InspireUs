using System;
using InspireUs.Congress.Shared.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InspireUs.Congress.Infrastructure.Configuration
{
	public class SqlModelConfiguration : IModelConfiguration
	{
		public void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
        }
    }
}

