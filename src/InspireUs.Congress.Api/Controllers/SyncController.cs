using System;
using System.Diagnostics.CodeAnalysis;
using InspireUs.Congress.Domain.Model;
using InspireUs.Congress.Domain.Services;
using InspireUs.Congress.Api.Services;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace InspireUs.Congress.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SyncController : ControllerBase
    {
        private readonly MemberService _memberService;
        private readonly LegislationService _legislationService;
        private readonly Uri _seleniumUrl;

        public SyncController([NotNull] MemberService memberService,
            [NotNull] LegislationService legislationService,
            [NotNull] IConfiguration configuration)
		{
            var url = configuration.GetConnectionString("SeleniumUrl");
            ArgumentException.ThrowIfNullOrEmpty(url);

            _seleniumUrl = new Uri(url);
            _memberService = memberService;
            _legislationService = legislationService;
		}

        [HttpGet(Name = "SyncMembers")]
        public async Task<int> SyncMembers()
		{
            Member[] members;

            var options = new FirefoxOptions();
            using (var service = new CongressWebScrapingService(_seleniumUrl,
                options, CreateRemoteWebDriver))
            {
                members = service.GetCongressGovData();
            }

            return await _memberService.AddMembers(members);
        }

        [HttpGet(Name = "SyncLegislations")]
        public async Task<int> SyncLegislations()
        {
            var options = new FirefoxOptions();
            using (var service = new BatchWebScrapingService(new LegislationWebScrapingService(_seleniumUrl,
                options, CreateRemoteWebDriver)))
            {
                await service.GetCongressGovDataByBatch(_legislationService.AddLegislations, 500);
            }

            return 0;
        }

        private IWebDriver CreateRemoteWebDriver(Uri uri, DriverOptions driverOptions)
        {
            return new RemoteWebDriver(uri, driverOptions);
        }
    }
}
