using System;
using System.ComponentModel;

namespace InspireUs.Congress.Domain.Model
{
	public enum CommitteeType
	{
		[Description("Unknown")]
		UNKNOWN,
		[Description("House")]
		H,
		[Description("Senate")]
		S,
        [Description("Joint")]
        J,
		[Description("Commission")]
		C
    }
}

