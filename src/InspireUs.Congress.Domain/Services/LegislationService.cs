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
            var existingIds = _context.Set<Legislation>()
                .Where(f => legislations.Select(s => s.Id).Contains(f.Id))
                .Select(g => g.Id)
                .ToArray();

            foreach (var member in legislations.Where(f => !existingIds.Contains(f.Id)))
            {
                _context.Add(member);
            }

            return await _context.SaveChangesAsync();
        }
    }
}

