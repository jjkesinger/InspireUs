using System;
using Microsoft.EntityFrameworkCore;

namespace InspireUs.Congress.Shared.Configuration
{
	public interface IModelConfiguration
	{
		void ConfigureModel(ModelBuilder modelBuilder);
	}
}

