using System;
using OpenQA.Selenium;
using System.Dynamic;
using System.Text.RegularExpressions;
using InspireUs.Congress.Domain.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Firefox;
using InspireUs.Congress.Shared;
using OpenQA.Selenium.Support.UI;

namespace InspireUs.Congress.Api.Services
{
    public partial class CongressWebScrapingService : WebScrapingService<Member>
    {
        public CongressWebScrapingService(Uri seleniumUri,
            DriverOptions driverOptions,
            Func<Uri, DriverOptions, IWebDriver> createDriver) :
                base(seleniumUri, driverOptions, createDriver)
        { }

        protected override string Query => "%7B%22source%22%3A%22members%22%7D";

        protected override void PopulateData()
        {
            var memberElements = Driver.FindElements(By.CssSelector("#main > ol > li.expanded"));
            if (memberElements.Any())
            {
                foreach (var member in memberElements)
                {
                    dynamic obj = new ExpandoObject();
                    var serviceHistory = new List<ServiceTime>();

                    foreach (var item in member.Text.Split(Environment.NewLine))
                    {
                        if (Regex.IsMatch(item, "^\\d"))
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

                    var idElement = member.FindElements(By.CssSelector("span.result-heading > a"));
                    obj.Id = idElement.Any() ?
                        idElement[0].GetAttribute("href").Split('/').Last().Substring(0, 7)
                        : throw new InvalidElementStateException();

                    Data.Add(new Member(obj.Id, obj.FirstName, obj.Middle, obj.LastName,
                        new District(EnumExtensions.GetValueFromDescription<State>(obj.State), obj.District),
                        EnumExtensions.GetValueFromDescription<Party>(obj.Party), serviceHistory.ToArray(), obj.ImageUrl));
                }
            }
        }
    }
}
