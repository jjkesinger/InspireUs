using System;
using System.Dynamic;
using System.Text.RegularExpressions;
using InspireUs.Congress.Domain.Model;
using OpenQA.Selenium;

namespace InspireUs.Congress.Api.Services
{
    public class LegislationWebScrapingService : WebScrapingService<Legislation>
    {
        public LegislationWebScrapingService(Uri seleniumUri,
            DriverOptions driverOptions,
            Func<Uri, DriverOptions, IWebDriver> createDriver) :
                base(seleniumUri, driverOptions, createDriver)
        { }

        protected override string Query => $"{{\"source\":\"legislation\"}}";

        protected override void PopulateData()
        {
            var listElements = Driver.FindElements(By.CssSelector("#main > ol > li.expanded"));
            if (listElements.Any())
            {
                foreach (var listElement in listElements)
                {
                    dynamic obj = new ExpandoObject();

                    var bill = listElement.FindElement(By.CssSelector("span.result-heading")).Text.Split('—');
                    obj.BillNumber = bill[0].Trim();
                    obj.CongressNth = bill[1].Substring(0, 6).Trim();

                    var titleElements = listElement.FindElements(By.CssSelector("span.result-title"));
                    obj.Title = titleElements.Any() ? titleElements[0].Text : null;

                    var resultItems = listElement.FindElements(By.CssSelector("span.result-item"));
                    if (resultItems.Any())
                    {
                        var links = resultItems.First().FindElements(By.CssSelector("a"));
                        if (links.Any())
                        {
                            var link = links[0].GetAttribute("href");
                            obj.SponserMemberId = link.Substring(link.LastIndexOf('/') + 1, 7);
                        }
                        else
                        {
                            obj.SponserMemberId = null;
                        }
                    }
                    else
                    {
                        obj.SponserMemberId = null;
                    }

                    Data.Add(new Legislation(obj.BillNumber, obj.CongressNth, obj.Title, obj.SponserMemberId));
                }
            }
        }
    }
}

