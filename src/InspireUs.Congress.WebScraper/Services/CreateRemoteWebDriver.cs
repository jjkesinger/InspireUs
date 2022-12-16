using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace InspireUs.Congress.WebScraper
{
    public class CreateRemoteWebDriver : ICreateWebDriver
    {
        private readonly DriverOptions _driverOptions;
        private readonly IEnumerable<string> _urls;

        public CreateRemoteWebDriver(IEnumerable<string> urls,
            DriverOptions options)
        {
            _driverOptions = options;
            _urls = urls;
        }

        public IWebDriver Create()
        {
            var url = GetAvailableUrl();
            ArgumentNullException.ThrowIfNull(url, nameof(url));

            return new RemoteWebDriver(new Uri(url), _driverOptions);
        }

        private string GetAvailableUrl()
        {
            string? url = null;
            do
            {
                url = GetAvailableRemote();
            }
            while (string.IsNullOrEmpty(url));

            return url;
        }

        private string? GetAvailableRemote()
        {
            try
            {
                foreach (var url in _urls)
                {
                    var remotedriver = new RemoteWebDriver(new Uri(url), _driverOptions);
                    remotedriver.Quit();
                    remotedriver.Dispose();
                    return url;
                }

            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
    }

    public interface ICreateWebDriver
    {
        IWebDriver Create();
    }
}

