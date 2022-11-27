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
			await _context.AddRangeAsync(members);
			return await _context.SaveChangesAsync();
		}

		public IAsyncEnumerable<Member> GetMembersAsyncEnumerable()
		{
			return _context.Set<Member>()
				.AsNoTracking()
				.Select(member =>
					new Member(member.FirstName,
					member.MiddleName, member.LastName, member.District,
					member.Party, member.ServiceHistory, member.Id,
					member.PictureUrl, member.Address, member.Phone,
					member.WebsiteUrl, member.ContactUrl))
                .TagWith($"{nameof(MemberService)}|{nameof(GetMembersAsyncEnumerable)}")
                .AsAsyncEnumerable();
		}

		public async Task<List<Member>> GetMembersAsync()
		{
            return await _context.Set<Member>()
                .AsNoTracking()
				.Select(member =>
					new Member(member.FirstName,
					member.MiddleName, member.LastName, member.District,
					member.Party, member.ServiceHistory, member.Id,
					member.PictureUrl, member.Address, member.Phone,
					member.WebsiteUrl, member.ContactUrl))
                .TagWith($"{nameof(MemberService)}|{nameof(GetMembersAsync)}")
                .ToListAsync();
		}

        public List<Member> GetMembersSync()
        {
            return _context.Set<Member>()
                .AsNoTracking()
                .Select(member =>
                    new Member(member.FirstName,
                    member.MiddleName, member.LastName, member.District,
                    member.Party, member.ServiceHistory, member.Id,
                    member.PictureUrl, member.Address, member.Phone,
                    member.WebsiteUrl, member.ContactUrl))
                .TagWith($"{nameof(MemberService)}|{nameof(GetMembersSync)}")
                .ToList();
        }
    }
}

