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
        private readonly Uri _seleniumUrl;

        public SyncController(MemberService memberService,
            [NotNull] IConfiguration configuration)
		{
            var url = configuration.GetConnectionString("SeleniumUrl");
            ArgumentException.ThrowIfNullOrEmpty(url);

            _seleniumUrl = new Uri(url);
            _memberService = memberService;
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

        [HttpGet(Name = "SyncLegislation")]
        public async Task<int> SyncLegislation()
        {
            Legislation[] legislation;

            var options = new FirefoxOptions();
            using (var service = new LegislationWebScrapingService(_seleniumUrl,
                options, CreateRemoteWebDriver))
            {
                legislation = service.GetCongressGovData();
            }
            
            return await Task.FromResult(legislation.Length); //TODO
        }

        private IWebDriver CreateRemoteWebDriver(Uri uri, DriverOptions driverOptions)
        {
            return new RemoteWebDriver(uri, driverOptions);
        }
    }
}
