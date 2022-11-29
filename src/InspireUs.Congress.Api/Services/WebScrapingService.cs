using System;
using InspireUs.Congress.Domain.Model;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InspireUs.Congress.Api.Services
{
    public abstract partial class WebScrapingService<T> : IDisposable where T : class
    {
        private int Page = 0;
        private int PageTotal;
        private string? Url;
        private bool IsBotDetected;

        private readonly Func<Uri, DriverOptions, IWebDriver> _createWebDriver;
        private readonly Uri _webDriverUri;
        private readonly DriverOptions _webDriverOptions;

        protected IWebDriver Driver { get; private set; }
        protected readonly List<T> Data = new List<T>();

        public virtual int PageSize { get; } = 250;
        protected abstract string Query { get; }

        protected WebScrapingService(Uri seleniumUri,
            DriverOptions driverOptions,
            Func<Uri, DriverOptions, IWebDriver> createDriver)
        {
            _createWebDriver = createDriver;
            _webDriverOptions = driverOptions;
            _webDriverUri = seleniumUri;

            Driver = createDriver(seleniumUri, driverOptions);
            if (Driver is null)
            {
                ArgumentNullException.ThrowIfNull(Driver, nameof(Driver));
            }
        }

        
        public T[] GetCongressGovData(int? startPage = null, int? pageTotal = null)
        {
            try
            {
                if (string.IsNullOrEmpty(Url))
                {
                    if (string.IsNullOrEmpty(Query))
                        ArgumentException.ThrowIfNullOrEmpty(Query, nameof(Query));

                    Page = startPage ?? Page;
                    Url = BuildUrl(Query, PageSize, Page);
                }

                Driver.Navigate().GoToUrl(Url);

                var ttlPages = GetPageTotal();
                PageTotal = pageTotal.HasValue && pageTotal.Value < ttlPages ? pageTotal.Value : ttlPages;
                while (Page < PageTotal && !IsBotDetected)
                {
                    PopulateData();
                    ClickToNextPage();
                }

                if (IsBotDetected)
                {
                    ResetWebDriver();
                    GetCongressGovData();
                }

                var data = Data.ToArray();
                Data.Clear();
                return data;
            }
            catch (Exception e)
            {
                Driver?.Quit();
                throw new AggregateException($"Exception Page {Page}", e);
            }
        }

        protected abstract void PopulateData();

        protected virtual int GetPageTotal()
        {
            var pageTotalElement = Driver.FindElements(
                By.CssSelector("#searchTune > div.basic-search-tune-number > div.pagination > span.results-number"));
            if (pageTotalElement.Any())
            {
                var pgTotal = pageTotalElement[0].Text;
                var x = string.Concat(Regex.Matches(pgTotal, "\\d+").Select(f => f.Value));
                return int.Parse(x);
            }

            return 0;
        }

        private string BuildUrl(string query, int pageSize, int startPage)
        {
            return $"https://www.congress.gov/search?q={query}&pageSize={pageSize}&page={startPage}";
        }

        private void ClickToNextPage()
        {
            Page++;

            var links = Driver.FindElements(
                By.CssSelector("#searchTune > div.basic-search-tune-number > div.pagination > a.next"));

            if (links.Any())
            {
                Url = links[0].GetAttribute("href");
                links[0].Click();

                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => {
                    var loaderElement = By.CssSelector("body > div.actionLoaderWrapper");
                    if (d.FindElements(loaderElement).Any())
                    {
                        return !d.FindElement(loaderElement).Displayed;
                    }

                    //cant find loader, must be intercepted
                    IsBotDetected = true;
                    return true;
                }
                );
            }
            else
            {
                if (Page != PageTotal)
                {
                    throw new InvalidOperationException("Missing Next Button");
                }
            }
        }

        private void ResetWebDriver()
        {
            Driver.Quit();
            Driver = _createWebDriver(_webDriverUri, _webDriverOptions);
            IsBotDetected = false;
        }

        #region Dispose

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Data.Clear();
                    Url = null;
                }

                Driver?.Quit();

                disposedValue = true;
            }
        }

        ~WebScrapingService()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        [GeneratedRegex("^\\d")]
        private static partial Regex FirstNumberRegex();
        #endregion
    }
}

