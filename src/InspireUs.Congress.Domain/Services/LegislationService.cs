using System;
using InspireUs.Congress.Domain.Model;

namespace InspireUs.Congress.Domain.Services
{
	public class LegislationService
	{
        private readonly CongressDbContext _context;

        public LegislationService(CongressDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddLegislations(IEnumerable<Legislation> legislations)
        {
            await _context.AddRangeAsync(legislations);
            return await _context.SaveChangesAsync();
        }
    }
}

