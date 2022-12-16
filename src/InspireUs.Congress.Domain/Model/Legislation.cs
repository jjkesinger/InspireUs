using System;
using InspireUs.Congress.Shared;

namespace InspireUs.Congress.Domain.Model
{
	public class Legislation
	{
		//for EF only
		private Legislation(): this(string.Empty, string.Empty, null, null, null, null) { }

		public Legislation(string billNumber, string congressNth,
			string? title, string? sponserMemberId, DateTime? introDate, string? id)
		{
			ArgumentException.ThrowIfNullOrEmpty(billNumber, nameof(billNumber));
            ArgumentException.ThrowIfNullOrEmpty(congressNth, nameof(congressNth));

            BillNumber = billNumber;
            CongressNth = congressNth;
            Title = title;
			SponserMemberId = sponserMemberId;
			IntroducedDate = introDate;
			Id = id ?? $"{congressNth}{billNumber}";

			var billNo = string.Concat(billNumber.ToArray()
				.Reverse().TakeWhile(char.IsNumber).Reverse());
			var billType = billNumber.Replace(billNo, "");
            BillType = EnumExtensions.GetValueFromDescription<BillType>(billType);
		}

		public string Id { get; }
		public string BillNumber { get; }
		public BillType BillType { get; }
        public string? Title { get; private set; }
		public DateTime? IntroducedDate { get; private set; }

        public virtual UsCongress? Congress { get; private set; }
        public string CongressNth { get; }

        public virtual Member? SponserMember { get; private set; }
		public string? SponserMemberId { get; private set; }
	}
}

