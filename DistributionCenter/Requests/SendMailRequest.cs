using System;
using DistributionCenter.Models;
using MediatR;

namespace DistributionCenter.Requests
{
	public class SendMailRequest : IRequest<Response>
    {
		public SendMailRequest()
		{
		}

		public Parcel Parcel { get; set; }
	}
}

