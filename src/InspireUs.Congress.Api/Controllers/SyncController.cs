using System;
using InspireUs.Congress.Domain.Model;
using InspireUs.Congress.Domain.Services;
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
        private readonly IConfiguration _configuration;

        public SyncController(MemberService memberService,
            IConfiguration configuration)
		{
            _configuration = configuration;
            _memberService = memberService;
		}

        [HttpGet(Name = "Sync")]
        public async Task<int> Sync()
		{
            Member[] members;

            var options = new FirefoxOptions();
            var uri = new Uri(_configuration.GetConnectionString("SeleniumUrl"));

            using (var service = new CongressWebScrapingService(uri, options, CreateRemoteWebDriver))
            {
                members = service.GetCongressMembers();
            }

            return await _memberService.AddMembers(members);
        }

        private IWebDriver CreateRemoteWebDriver(Uri uri, DriverOptions driverOptions)
        {
            return new RemoteWebDriver(uri, driverOptions);
        }
    }
}
