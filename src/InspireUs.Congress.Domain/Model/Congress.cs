using System;
namespace InspireUs.Congress.Domain.Model
{
	public class Congress
	{
		//for efcore only
		private Congress(): this(string.Empty) { }

		public Congress(string nth): this(nth, new List<Legislation>())
		{
            
		}

		public Congress(string nth, ICollection<Legislation> legislations)
		{
            Nth = nth;
			Legislations = legislations;
        }

		public string Nth { get; }
        public ICollection<Legislation> Legislations { get; private set; }
    }
}

