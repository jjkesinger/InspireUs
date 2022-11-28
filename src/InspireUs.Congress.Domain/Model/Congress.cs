using System;
namespace InspireUs.Congress.Domain.Model
{
	public class Congress
	{
		public Congress(string nth)
		{
            Nth = nth;
		}

		public string Nth { get; }
	}
}

