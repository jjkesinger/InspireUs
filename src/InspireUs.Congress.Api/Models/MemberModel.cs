using System;

namespace InspireUs.Congress.Api.Models
{
	public class MemberModel
	{
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string Party { get; set; }
		public string State { get; set; }
		public string? District { get; set; }
	}
}