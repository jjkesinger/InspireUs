using System;

namespace InspireUs.Congress.Domain.Model
{
	public class Member
	{
		//Ctor for EF only
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        private Member() : this(string.Empty, default, string.Empty, null, default, null, default) { }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        public Member(string firstName, string? middleName, string lastName,
			District district, Party party, ICollection<ServiceTime> serviceHistory,
			int id = 0, string? pictureUrl = null, Address? address = null,
			int? phone = null, string? website = null, string? contactUrl = null)
		{
			ArgumentException.ThrowIfNullOrEmpty(firstName, nameof(firstName));
			ArgumentException.ThrowIfNullOrEmpty(lastName, nameof(lastName));
			ArgumentNullException.ThrowIfNull(district, nameof(district));
            ArgumentNullException.ThrowIfNull(party, nameof(party));
            ArgumentNullException.ThrowIfNull(serviceHistory, nameof(serviceHistory));

			if (serviceHistory.Count() == 0)
			{
				throw new ArgumentException("Missing service history", nameof(serviceHistory));
			}

			Id = id;
			FirstName = firstName;
			MiddleName = middleName;
			LastName = lastName;
			District = district;
			Party = party;
			ServiceHistory = serviceHistory;
			PictureUrl = pictureUrl;

			if (address == null)
			{
				address = new Address();
			}

			Address = address;
			Phone = phone;
			WebsiteUrl = website;
			ContactUrl = contactUrl;
        }

		public int Id { get; }
		public string LastName { get; private set; }
		public string? MiddleName { get; private set; }
		public string FirstName { get; private set; }
		public District District { get; set; }
		public Party Party { get; private set; }
		public ICollection<ServiceTime> ServiceHistory { get; private set; }
		public MemberType MemberType { get; }
        public Address Address { get; private set; }
        public string? PictureUrl { get; private set; }

		public int? Phone { get; private set; }
		public string? WebsiteUrl { get; private set; }
		public string? ContactUrl { get; private set; }
	}
}

