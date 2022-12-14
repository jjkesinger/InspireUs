using System;
using InspireUs.Congress.Domain.Model;

namespace InspireUs.Congress.Api.Models
{
	public class ServiceTimeModel
	{
		public int StartYear { get; set; }
		public int? EndYear { get; set; }
		public string MemberType { get; set; } = string.Empty;
	}
}

