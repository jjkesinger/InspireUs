using System;
using InspireUs.Congress.Domain;
using InspireUs.Congress.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace InspireUs.Congress.Domain.Services
{
	public class MemberService
	{
		private readonly CongressDbContext _context;

		public MemberService(CongressDbContext context)
		{
			_context = context;
		}

		public async Task<int> AddMembers(IEnumerable<Member> members)
		{
			var existingIds = _context.Set<Member>()
				.Where(f => members.Select(s => s.Id).Contains(f.Id))
				.Select(g => g.Id)
				.ToArray();

			foreach(var member in members.Where(f => !existingIds.Contains(f.Id)))
			{
				_context.Add(member);
			}
			
			return await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Member>> GetMembers()
		{
            return await _context.Set<Member>()
				.Include(f => f.Legislations)
                .AsNoTracking()
				.Select(member =>
					new Member(member.Id, member.FirstName,
					member.MiddleName, member.LastName, member.District,
					member.Party, member.ServiceHistory, member.PictureUrl,
					member.Address, member.Phone, member.WebsiteUrl, member.ContactUrl,
					member.Legislations))
				.TagWith($"{nameof(MemberService)}|{nameof(GetMembers)}")
                .ToListAsync();
		}
    }
}

