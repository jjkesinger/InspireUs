using System;
namespace InspireUs.Congress.Domain.Model
{
	public class UsCongress
	{
		//for efcore only
		private UsCongress(): this(string.Empty) { }

		public UsCongress(string nth): this(nth, new List<Legislation>())
		{
            
		}

		public UsCongress(string nth, ICollection<Legislation>? legislations,
			int? startDate = null, int? endDate = null)
		{
            Nth = nth;
			StartDate = startDate;
			EndDate = endDate;

			if (legislations == null)
			{
				legislations = new List<Legislation>();
            }

			Legislations = legislations;
        }

		public string Nth { get; }
		public int? StartDate { get; private set; }
		public int? EndDate { get; private set; }

        public ICollection<Legislation> Legislations { get; private set; }
    }
}

