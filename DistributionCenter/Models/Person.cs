using System;
using System.Xml.Serialization;

namespace DistributionCenter.Models
{
	public class Person
	{
		public string Name { get; set; }
		public Address Address { get; set; }

	}
	[XmlType("Company")]
    public class Company : Person
    {
        

    }

    public class Address
    {
		public string Street { get; set; }
		public string HouseNumber { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
	}
}

