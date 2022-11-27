using System;

namespace InspireUs.Congress.Domain.Model
{
	public class ServiceTime
	{
        //Ctor for EF only
        private ServiceTime(): this(default, default) { }

		public ServiceTime(MemberType memberType, int startYear, int? endYear = null)
		{
			MemberType = memberType;
			StartYear = startYear;
			EndYear = endYear;
		}

		public MemberType MemberType { get; private set; }
		public int StartYear { get; private set; }
		public int? EndYear { get; private set; }
	}
}

