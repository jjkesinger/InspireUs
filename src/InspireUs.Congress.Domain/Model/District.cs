using System;

namespace InspireUs.Congress.Domain.Model
{
	public class District
	{
		private District() : this(default) { }

		public District(State state, int? districtNumber = null)
		{
			State = state;
			DistrictNumber = districtNumber;
		}

		public int? DistrictNumber { get; }
		public State State { get; }
	}
}

