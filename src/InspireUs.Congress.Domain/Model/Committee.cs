using System;
namespace InspireUs.Congress.Domain.Model
{
	public class Committee
	{
		public Committee(string name, CommitteeType committeeType)
		{
			ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

            Name = name;
			CommitteeType = CommitteeType;
		}

		public string Name { get; }
		public CommitteeType CommitteeType { get; private set; }
	}
}

