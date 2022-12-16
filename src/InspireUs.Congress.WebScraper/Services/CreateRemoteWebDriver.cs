using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace InspireUs.Congress.WebScraper
{
    public class CreateRemoteWebDriver : ICreateWebDriver
    {
        private readonly DriverOptions _driverOptions;
        private readonly string _url;

        public CreateRemoteWebDriver(string url, DriverOptions options)
        {
            ArgumentNullException.ThrowIfNull(url, nameof(url));

            _driverOptions = options;
            _url = url;
        }

        public IWebDriver Create()
        {
            return new RemoteWebDriver(new Uri(_url), _driverOptions);
        }
    }

    public interface ICreateWebDriver
    {
        IWebDriver Create();
    }
}

