using System;
using System.Diagnostics.CodeAnalysis;
using InspireUs.Congress.Domain.Services;

namespace InspireUs.Congress.WebScraper
{
	public class WebScrapingServiceBuilder
    {
        private readonly ICreateWebDriver _createWebDriver;
        private readonly LegislationService _legislationService;
        private readonly MemberService _memberService;
        private readonly ILogger<WebScrapingServiceBuilder> _logger;

        private string? _query;

		public WebScrapingServiceBuilder(
            [NotNull] ICreateWebDriver createWebDriver,
            [NotNull] LegislationService legislationService,
            [NotNull] MemberService memberService,
            [NotNull] ILogger<WebScrapingServiceBuilder> logger)
		{
            _createWebDriver = createWebDriver;
            _legislationService = legislationService;
            _memberService = memberService;
            _logger = logger;
        }

        public WebScrapingServiceBuilder WithQuery(string query)
        {
            _query = query;
            return this;
        }

        public async Task Run(CancellationToken stoppingToken)
        {
            if (string.IsNullOrWhiteSpace(_query))
            {
                var e = new InvalidOperationException("Query has not been defined.");
                _logger.LogError(e, e.Message);

                throw e;
            }

            if (_query.Contains("legislation"))
            {
                using (var service = new LegislationWebScrapingService(_createWebDriver, _logger, _query))
                {
                    try
                    {
                        await service.GetCongressGovDataByBatch(_legislationService.AddLegislations, stoppingToken);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, e.Message);
                    }
                }
            }
            else if (_query.Contains("members"))
            {
                using(var service = new MemberWebScrapingService(_createWebDriver, _logger))
                {
                    try
                    {
                        await service.GetCongressGovDataByBatch(_memberService.AddMembers, stoppingToken);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, e.Message);
                    }
                }
            }
            else
            {
                var e = new NotImplementedException($"Query {_query} is not implemented.");
                _logger.LogError(e, e.Message);

                throw e;
            }
        }
    }
}

