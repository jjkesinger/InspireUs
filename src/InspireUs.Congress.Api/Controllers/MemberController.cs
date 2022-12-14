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
        public async Task<IEnumerable<MemberModel>> GetMembers()
        {
            var members = await _memberService.GetMembers();
            return members.Select(member => new MemberModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                MiddleName = member.MiddleName,
                State = member.District.State.GetDescription(),
                District = member.District.DistrictNumber?.ToString(),
                Party = member.Party.GetDescription(),
                MemberType = member.MemberType.GetDescription(),
                ServiceHistory = member.ServiceHistory.Select(h => new ServiceTimeModel
                {
                    StartYear = h.StartYear,
                    EndYear = h.EndYear,
                    MemberType = h.MemberType.GetDescription()
                }),
                Legislation = member.Legislations.Select(l => new LegislationModel
                {
                    Name = l.BillNumber,
                    Title = l.Title
                })
            });
        }
    }
}

