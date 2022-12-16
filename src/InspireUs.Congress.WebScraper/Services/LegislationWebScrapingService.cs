using System;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Text.Json;
using System.Text.RegularExpressions;
using InspireUs.Congress.Domain.Model;
using OpenQA.Selenium;

namespace InspireUs.Congress.WebScraper
{
    public class LegislationWebScrapingService : WebScrapingService<Legislation>
    {
        private readonly ILogger _logger;

        public LegislationWebScrapingService(
            [NotNull] ICreateWebDriver createDriver,
            [NotNull] ILogger logger,
            [NotNull] string query) :
                base(createDriver)
        {
            _logger = logger;
            Query = query;
        }

        protected override string Query { get; }

        protected override void PopulateData()
        {
            var listElements = Driver.FindElements(By.CssSelector("#main > ol > li.expanded"));
            if (listElements.Any())
            {
                foreach (var listElement in listElements)
                {
                    dynamic obj = new ExpandoObject();

                    if (listElement.Text.StartsWith("BILL") || listElement.Text.StartsWith("LAW"))
                    {
                        foreach (var item in listElement.Text.Split(Environment.NewLine))
                        {
                            if (item.StartsWith("BILL") || item.StartsWith("LAW"))
                            {
                                continue;
                            }
                            else if (Regex.IsMatch(item, "^\\d{1,3}(,\\d{3})*(\\.\\d+)?\\."))
                            {
                                const int adj = 2;
                                var index = item.IndexOf('.');
                                var start = index + adj;
                                var length = item.Length - start;

                                if (start == 1 || length < 0)
                                {
                                    throw new InvalidOperationException("BillNumber was not in the correct format.");
                                }

                                var parts = item.Substring(start, length).Split(" — ");
                                obj.BillNumber = parts[0];

                                var l = parts[1].IndexOf("Congress");
                                obj.CongressNth = parts[1].Substring(0, l - 1);
                            }
                            else if(item.StartsWith("Sponsor:"))
                            {
                                var resultItems = listElement.FindElements(By.CssSelector("span.result-item"))
                                    .Where(f => f.Text.StartsWith("Sponsor"));

                                if (resultItems.Any())
                                {
                                    var links = resultItems.First().FindElements(By.CssSelector("a"));
                                    if (links.Any())
                                    {
                                        var link = links[0].GetAttribute("href");
                                        obj.SponsorMemberId = link.Substring(link.LastIndexOf('/') + 1, 7);
                                    }
                                }

                                if (item.Contains("(Introduced "))
                                {
                                    if (obj.IntroducedDate = DateTime.TryParse(
                                        item.Substring(item.IndexOf("Introduced") + "Introduced".Length + 1, 10),
                                        out var introDate))
                                    {
                                        obj.IntroducedDate = introDate;
                                    }
                                    else
                                    {
                                        obj.IntroducedDate = null;
                                    }
                                }
                            }
                            else if(item.StartsWith("Committees:"))
                            {
                                //TODO
                            }
                            else if (item.StartsWith("Latest Action:"))
                            {
                                continue;
                            }
                            else if (item.StartsWith("Tracker:"))
                            { 
                                break; //don't need anything after this
                            }
                            else
                            {
                                    obj.Title = item.Trim();
                            }
                        }

                        if (!((IDictionary<String, object>)obj).ContainsKey("SponsorMemberId"))
                        {
                            obj.SponsorMemberId = null;
                        }

                        if (!((IDictionary<String, object>)obj).ContainsKey("IntroducedDate"))
                        {
                            obj.IntroducedDate = null;
                        }

                        _logger.LogTrace($"Adding legislation: {JsonSerializer.Serialize(obj)}");

                        Data.Add(new Legislation(obj.BillNumber, obj.CongressNth, obj.Title, obj.SponsorMemberId, obj.IntroducedDate, null));
                    }
                    else if (listElement.Text.StartsWith("AMENDMENT"))
                    {

                    }
                    else if (listElement.Text.StartsWith("RESOLUTION"))
                    {

                    }
                    else if (listElement.Text.StartsWith("JOINT RESOLUTION"))
                    {

                    }
                    else if (listElement.Text.StartsWith("CONCURRENT RESOLUTION"))
                    {

                    }
                }
            }
        }
    }
}

