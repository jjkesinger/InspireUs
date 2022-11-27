using InspireUs.Congress.Domain.Services;
using InspireUs.Congress.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;

namespace InspireUs.Congress.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration
            .GetConnectionString("CongressConnection");

        builder.Services.AddInfrastructure(connectionString,
            builder.Environment.IsDevelopment());

        if (builder.Environment.IsDevelopment())
        {
            IdentityModelEventSource.ShowPII = true;
        }

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}

