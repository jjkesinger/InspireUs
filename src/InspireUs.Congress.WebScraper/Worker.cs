using System.Data;
using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium.Chrome;

namespace InspireUs.Congress.WebScraper;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(
        [NotNull] IServiceScopeFactory scopeFactory,
        [NotNull] ILogger<Worker> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var query = "%7B%22source%22%3A%22members%22%7D";
        await ProcessQueryMessage(query, stoppingToken);

        for (var i = 117; i > 3; i = i - 2)
        {
            query = $"{{\"source\":\"legislation\",\"congress\":{i},\"type\":\"bills\"}}";
            var query2 = $"{{\"source\":\"legislation\",\"congress\":{i - 1},\"type\":\"bills\"}}";

            var task = Task.Run(() => ProcessQueryMessage(query, stoppingToken), stoppingToken);
            var task2 = Task.Run(() => ProcessQueryMessage(query2, stoppingToken), stoppingToken);
            await Task.WhenAll(task, task2);
        }

        await Task.Delay(1000 * 60 * 5, stoppingToken);
    }

    private async Task ProcessQueryMessage(string query, CancellationToken stoppingToken)
    {
        try
        {
            _logger.LogInformation($"Beginning web scraping of {query}");

            using (var scope = _scopeFactory.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<WebScrapingServiceBuilder>();
                await runner.WithQuery(query).Run(stoppingToken);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
        finally
        {
            _logger.LogInformation($"Completed web scraping of {query}");
        }
    }
}
