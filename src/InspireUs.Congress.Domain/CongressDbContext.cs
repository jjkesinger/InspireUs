using InspireUs.Congress.Domain.Model;
using InspireUs.Congress.Shared.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InspireUs.Congress.Domain
{

    public class CongressDbContext : DbContext
    {
        private readonly IModelConfiguration _modelConfiguration;

        public CongressDbContext(DbContextOptions<CongressDbContext> options, IModelConfiguration modelConfiguration) :
            base(options)
        {
            _modelConfiguration = modelConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CongressDbContext).Assembly);
            _modelConfiguration.ConfigureModel(modelBuilder);
        }
    }
}