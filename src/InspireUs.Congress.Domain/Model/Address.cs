using System;
namespace InspireUs.Congress.Domain.Model
{
	public class Address
	{
		public Address() : this(null, null, null, null, null) { }

		public Address(string? address1, string? address2, string? city, State? state, string? zipCode)
		{
			Address1 = address1;
			Address2 = address2;
			City = city;
			State = state;
			ZipCode = zipCode;
		}

		public string? Address1 { get; }
		public string? Address2 { get; }
		public string? City { get; }
		public State? State { get; }
		public string? ZipCode { get; }
	}
}

