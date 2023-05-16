using System;
using DistributionCenter.Models;
using MediatR;

namespace DistributionCenter.Requests
{
	public class SendRegularParcelRequest : IRequest<Response>
    {
		public SendRegularParcelRequest()
		{
		}
        public Parcel Parcel { get; set; }
    }
}

