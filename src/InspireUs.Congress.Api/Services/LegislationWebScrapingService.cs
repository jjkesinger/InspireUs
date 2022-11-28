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

        protected override string Query => "%7B%22source%22%3A%legislation%22%7D";

        protected override void PopulateData()
        {
            var listElements = Driver.FindElements(By.CssSelector("#main > ol > li.expanded"));
            if (listElements.Any())
            {
                foreach (var member in listElements)
                {
                    dynamic obj = new ExpandoObject();

                    foreach (var item in member.Text.Split(Environment.NewLine))
                    {

                    }

                    Data.Add(new Legislation(obj.BillNumber, obj.CongressNth, obj.Title, obj.SponserMemberId));
                }
            }
        }
    }
}

