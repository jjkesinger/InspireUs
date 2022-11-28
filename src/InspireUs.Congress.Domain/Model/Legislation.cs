using System;
namespace InspireUs.Congress.Domain.Model
{
	public class Legislation
	{
		public Legislation(string billNumber, string congressNth,
			string title, string sponserMemberId)
		{
			ArgumentException.ThrowIfNullOrEmpty(billNumber, nameof(billNumber));
            ArgumentException.ThrowIfNullOrEmpty(congressNth, nameof(congressNth));
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentException.ThrowIfNullOrEmpty(sponserMemberId, nameof(sponserMemberId));

            BillNumber = billNumber;
            CongressNth = congressNth;
            Title = title;
			SponserMemberId = sponserMemberId;
		}

		public string BillNumber { get; }
        public string CongressNth { get; }

        public string Title { get; private set; }
		public string SponserMemberId { get; private set; }
	}
}

