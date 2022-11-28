using System;

namespace InspireUs.Congress.Domain.Model
{
	public class Member
	{
		//Ctor for EF only
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        private Member() : this(string.Empty, string.Empty, default, string.Empty, null, default, null, default) { }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        public Member(string id, string firstName, string? middleName, string lastName,
			District district, Party party, ICollection<ServiceTime> serviceHistory,
			string? pictureUrl = null, Address? address = null,
			int? phone = null, string? website = null, string? contactUrl = null)
		{
            ArgumentException.ThrowIfNullOrEmpty(id, nameof(id));
            ArgumentException.ThrowIfNullOrEmpty(firstName, nameof(firstName));
			ArgumentException.ThrowIfNullOrEmpty(lastName, nameof(lastName));
			ArgumentNullException.ThrowIfNull(district, nameof(district));
            ArgumentNullException.ThrowIfNull(party, nameof(party));
            ArgumentNullException.ThrowIfNull(serviceHistory, nameof(serviceHistory));

			Id = id;
			FirstName = firstName;
			MiddleName = middleName;
			LastName = lastName;
			District = district;
			Party = party;
			PictureUrl = pictureUrl;
            ServiceHistory = serviceHistory;
			MemberType = serviceHistory.OrderByDescending(f => f.StartYear).FirstOrDefault()?.MemberType ?? MemberType.UNKNOWN;

			if (address == null)
			{
				address = new Address();
			}

			Address = address;
			Phone = phone;
			WebsiteUrl = website;
			ContactUrl = contactUrl;
        }

		public string Id { get; private set; }
		public string LastName { get; private set; }
		public string? MiddleName { get; private set; }
		public string FirstName { get; private set; }
		public District District { get; private set; }
		public Party Party { get; private set; }
		public ICollection<ServiceTime> ServiceHistory { get; private set; }
		public MemberType MemberType { get; private set; }
        public Address Address { get; private set; }
        public string? PictureUrl { get; private set; }

		public int? Phone { get; private set; }
		public string? WebsiteUrl { get; private set; }
		public string? ContactUrl { get; private set; }
	}
}

