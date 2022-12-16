using System;
using System.ComponentModel;

namespace InspireUs.Congress.Domain.Model
{
	public enum BillType
	{
		[Description("H.R.")]
		HR,
        [Description("S.")]
        S,
        [Description("H.Amdt.")]
        HAmdt,
        [Description("S.Amdt.")]
        SAmdt,
        [Description("H.Res.")]
        HRes,
        [Description("S.Res.")]
        SRes,
        [Description("H.J.Res.")]
        HJRes,
        [Description("S.J.Res.")]
        SJRes,
        [Description("H.Con.Res.")]
        HConRes,
        [Description("S.Con.Res.")]
        SConRes
	}
}

