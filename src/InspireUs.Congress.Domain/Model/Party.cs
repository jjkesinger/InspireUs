using System;
using System.ComponentModel;

namespace InspireUs.Congress.Domain.Model
{
	public enum Party
	{
        [Description("N/A")]
        None,
		[Description("Democratic")]
		D,
        [Description("Republican")]
        R,
        [Description("Libertarian")]
        L,
        [Description("Independent")]
        I,
        [Description("Independent Democrat")]
        ID
    }
}

