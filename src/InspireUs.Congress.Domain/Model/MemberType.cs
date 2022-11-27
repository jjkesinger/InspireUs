using System;
using System.ComponentModel;

namespace InspireUs.Congress.Domain.Model
{
	public enum MemberType
	{
		[Description("Representative")]
		R,
		[Description("Senator")]
		S
	}
}

