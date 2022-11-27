using System;
using InspireUs.Congress.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using InspireUs.Congress.Api.Models;
using InspireUs.Congress.Shared;

namespace InspireUs.Congress.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MemberController : ControllerBase
	{
		private readonly MemberService _memberService;

		public MemberController(MemberService memberService)
		{
			_memberService = memberService;
		}

        [HttpGet(Name = "GetMembers")]
        public IAsyncEnumerable<MemberModel> GetMembers()
		{
			var members = _memberService.GetMembersAsyncEnumerable();
            return members.Select(member => new MemberModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                State = member.District.State.GetDescription(),
                District = member.District.DistrictNumber?.ToString(),
                Party = member.Party.GetDescription()
            });
		}

        [HttpGet(Name = "GetAllMembersAsync")]
        public async Task<IEnumerable<MemberModel>> GetAllMembersAsync()
        {
            var members = await _memberService.GetMembersAsync();
            return members.Select(member => new MemberModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                State = member.District.State.GetDescription(),
                District = member.District.DistrictNumber?.ToString(),
                Party = member.Party.GetDescription()
            });
        }

        [HttpGet(Name = "GetMembersSync")]
        public List<MemberModel> GetMembersSync()
        {
            var members = _memberService.GetMembersSync();
            return members.Select(member => new MemberModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                State = member.District.State.GetDescription(),
                District = member.District.DistrictNumber?.ToString(),
                Party = member.Party.GetDescription()
            }).ToList();
        }
    }
}

