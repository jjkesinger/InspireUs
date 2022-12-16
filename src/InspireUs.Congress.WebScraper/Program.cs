using InspireUs.Congress.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

namespace InspireUs.Congress.WebScraper;

public class Program
{
    public static void Main(string[] args)
    {
        var isDev = true;

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((builder, services) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("CongressConnection");
                ArgumentException.ThrowIfNullOrEmpty(connectionString);

                if (isDev)
                {
                    IdentityModelEventSource.ShowPII = true;
                }

                services.AddInfrastructure(connectionString, isDev);
                services.AddHostedService<Worker>();
                services.AddScoped<WebScrapingServiceBuilder>();
                services.AddScoped<ICreateWebDriver, CreateRemoteWebDriver>((services) =>
                {
                    var options = new ChromeOptions();
                    var seleniumUrls = builder.Configuration.GetConnectionString("SeleniumUrls");
                    ArgumentException.ThrowIfNullOrEmpty(seleniumUrls);

                    return new CreateRemoteWebDriver(seleniumUrls.Split(','), options);
                });
                
            })
            .Build();
        
        host.Run();
    }
}
