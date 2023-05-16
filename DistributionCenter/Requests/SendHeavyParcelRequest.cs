using System;
using DistributionCenter.Models;
using MediatR;

namespace DistributionCenter.Requests
{
	public class SendHeavyParcelRequest : IRequest<Response>
	{
		public SendHeavyParcelRequest()
		{
		}

		public Parcel Parcel { get; set; }
	}
}

