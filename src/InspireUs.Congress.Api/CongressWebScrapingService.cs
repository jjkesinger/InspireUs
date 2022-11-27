using System;
using OpenQA.Selenium;
using System.Dynamic;
using System.Text.RegularExpressions;
using InspireUs.Congress.Domain.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using InspireUs.Congress.Shared;

namespace InspireUs.Congress.Api
{
    public partial class CongressWebScrapingService : IDisposable
    {
        private int Page;
        private int? PageTotal;
        private string? Url = $"https://congress.gov/search?pageSize=250&q=%7B%22source%22%3A%22members%22%7D";

        private readonly Func<Uri, DriverOptions, IWebDriver> _createWebDriver;
        private readonly Uri _webDriverUri;
        private readonly DriverOptions _webDriverOptions;
        private readonly List<Member> Members = new List<Member>();

        private IWebDriver? _driver;

        public CongressWebScrapingService(
            Uri uri,
            DriverOptions driverOptions,
            Func<Uri, DriverOptions, IWebDriver> createDriver)
        {
            _createWebDriver = createDriver;
            _webDriverOptions = driverOptions;
            _webDriverUri = uri;

            SetWebDriver();
        }

        public Member[] GetCongressMembers()
        {
            if (_driver is null)
            {
                ArgumentNullException.ThrowIfNull(_driver, nameof(_driver));
            }

            bool isBotDetected = false;

            _driver.Navigate().GoToUrl(Url);

            PageTotal = GetPageTotal();
            while (Page < PageTotal)
            {
                var memberElements = _driver.FindElements(By.CssSelector("#main > ol > li.expanded"));
                if (memberElements.Any())
                {
                    foreach (var member in memberElements)
                    {
                        dynamic obj = new ExpandoObject();
                        var serviceHistory = new List<ServiceTime>();

                        foreach (var item in member.Text.Split(Environment.NewLine))
                        {
                            if (FirstNumberRegex().IsMatch(item))
                            {
                                const int adj = 2;
                                var index = item.IndexOf('.');
                                var start = index + adj;
                                var length = item.LastIndexOf('-') - index - adj;

                                if (start == 1 || length < 0)
                                {
                                    throw new InvalidOperationException("Name was not in the correct format.");
                                }

                                var names = item.Substring(start, length).Split(' ');
                                var last = names[0].TrimEnd(',');
                                var first = names[1];
                                var middle = names.Length > 2 && !string.IsNullOrWhiteSpace(names[2]) ? names[2] : null;

                                obj.FirstName = first;
                                obj.Middle = middle;
                                obj.LastName = last;
                            }
                            else if (item.StartsWith("State: "))
                            {
                                var state = item.Remove(0, "State: ".Length);
                                obj.State = state;
                            }
                            else if (item.StartsWith("District: "))
                            {
                                obj.District = int.TryParse(item.Remove(0, "District: ".Length), out var district) ? district : (int?)null;
                            }
                            else if (item.StartsWith("Party: "))
                            {
                                var party = item.Remove(0, "Party: ".Length);
                                obj.Party = party;
                            }
                            else if (item.StartsWith("Senate: "))
                            {
                                obj.District = null; //no districts for senators

                                var memberType = MemberType.S;
                                var houseItem = item.Remove(0, "Senate: ".Length);

                                var terms = houseItem.Split(", ");
                                foreach (var term in terms)
                                {
                                    var startYear = int.Parse(term.Substring(0, 4));
                                    var sEndYear = term.Substring(term.IndexOf('-') + 1, 4);
                                    var endYear = sEndYear == "Pres" ? (int?)null : int.Parse(sEndYear);

                                    serviceHistory.Add(new ServiceTime(memberType, startYear, endYear));
                                }
                            }
                            else if (item.StartsWith("House: "))
                            {
                                var memberType = MemberType.R;
                                var houseItem = item.Remove(0, "House: ".Length);

                                var terms = houseItem.Split(", ");
                                foreach (var term in terms)
                                {
                                    var startYear = int.Parse(term.Substring(0, 4));

                                    var sEndYear = term.Substring(term.IndexOf('-') + 1, 4);
                                    var endYear = sEndYear == "Pres" ? (int?)null : int.Parse(sEndYear);

                                    serviceHistory.Add(new ServiceTime(memberType, startYear, endYear));
                                }
                            }
                        }

                        var image = member.FindElements(By.CssSelector("div.member-image > img"));
                        obj.ImageUrl = image.Any() ? image[0].GetAttribute("src") : null;

                        Members.Add(new Member(obj.FirstName, obj.Middle, obj.LastName,
                            new District(EnumExtensions.GetValueFromDescription<State>(obj.State), obj.District),
                            EnumExtensions.GetValueFromDescription<Party>(obj.Party), serviceHistory.ToArray(), 0, obj.ImageUrl));
                    }
                }
                else
                {
                    isBotDetected = true;
                    break;
                }

                NavigateToNextPage();
            }

            if (isBotDetected)
            {
                SetWebDriver();
                GetCongressMembers();
            }

            return Members.ToArray();
        }

        private int? GetPageTotal()
        {
            return 10;
        }

        private void NavigateToNextPage()
        {
            Page++;

            var links = _driver?.FindElements(By.CssSelector("#searchTune > div.basic-search-tune-number > div.pagination > a.next"));
            if (links.Any())
            {
                Url = links[0].GetAttribute("href");
                links[0].Click();
            }

            Thread.Sleep(2000);
        }

        private void SetWebDriver()
        {
            _driver?.Quit();
            _driver = _createWebDriver(_webDriverUri, _webDriverOptions);
        }

        #region Dispose

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Members.Clear();
                    Url = null;
                }

                _driver?.Quit();

                disposedValue = true;
            }
        }

        ~CongressWebScrapingService()
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
