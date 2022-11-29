using System;
using InspireUs.Congress.Domain.Model;

namespace InspireUs.Congress.Api.Services
{
    public class BatchWebScrapingService : IDisposable
    {
        private readonly LegislationWebScrapingService _decorated;

        public BatchWebScrapingService(LegislationWebScrapingService decorated)
        {
            _decorated = decorated;
        }

        public void Dispose()
        {
            _decorated.Dispose();
        }

        public async Task GetCongressGovDataByBatch(Func<IEnumerable<Legislation>, Task<int>> saveFunc, int batchSize)
        {
            var currentBatch = 0;
            
            IEnumerable<Legislation>? data;
            do
            {
                var startPage = currentBatch * (batchSize / _decorated.PageSize);

                data = _decorated.GetCongressGovData(startPage, startPage + (batchSize / _decorated.PageSize));
                await saveFunc(data);
           

                currentBatch++;
            } while (data?.Any() == true);
        }
    }
}

