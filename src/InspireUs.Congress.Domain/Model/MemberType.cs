using System;
using System.ComponentModel;

namespace InspireUs.Congress.Domain.Model
{
	public enum MemberType
	{
		[Description("Unknown")]
		UNKNOWN,
		[Description("Representative")]
		R,
		[Description("Senator")]
		S
	}
}

