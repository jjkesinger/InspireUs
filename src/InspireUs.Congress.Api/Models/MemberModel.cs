using System;

namespace InspireUs.Congress.Api.Models
{
	public class MemberModel
	{
		public MemberModel()
		{
			ServiceHistory = new List<ServiceTimeModel>();
			Legislation = new List<LegislationModel>();
		}

		public string FirstName { get; set; } = string.Empty;
		public string? MiddleName { get; set; }
		public string LastName { get; set; } = string.Empty;
		public string Party { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
		public string MemberType { get; set; } = string.Empty;
        public string? District { get; set; }
		public IEnumerable<ServiceTimeModel> ServiceHistory { get; set; }
		public IEnumerable<LegislationModel> Legislation { get; set; }
	}
}