using InspireUs.Congress.Domain;
using InspireUs.Congress.Infrastructure.Configuration;
using InspireUs.Congress.Shared.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InspireUs.Congress.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString, bool isDevelopment)
    {
        services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
        services.AddDbContext<CongressDbContext>((options) =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(
                    typeof(ServiceRegistration).Assembly.FullName);

                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });

            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
                //options.UseModel(CompiledModels.CongressDbContextModel.Instance);
            }
        });

        services.AddDomain();
        return services;
    }
}

