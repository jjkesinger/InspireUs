using System;
using InspireUs.Congress.Domain.Services;
using InspireUs.Congress.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InspireUs.Congress.Domain
{
	public static class DomainRegistration
	{
        public static IServiceCollection AddDomain(
        this IServiceCollection services)
        {
            services.AddScoped<MemberService>();
            services.AddScoped<LegislationService>();

            return services;
        }
    }
}

