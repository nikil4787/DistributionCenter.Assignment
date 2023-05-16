using System;
using System.Xml.Serialization;
using DistributionCenter.Requests;

namespace DistributionCenter.Console.App
{
    [XmlType("Container")]
	public class Container
	{
		public string Id { get; set; }
		public DateTime ShippingDate { get; set; }
		public List<Parcel> parcels { get; set; }
	}
}

