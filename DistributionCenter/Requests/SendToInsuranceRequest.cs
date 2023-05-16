using System;
using DistributionCenter.Models;
using MediatR;

namespace DistributionCenter.Requests
{
	public class SendToInsuranceRequest : IRequest<Response>
    {
		public SendToInsuranceRequest()
		{
		}
        public Parcel Parcel { get; set; }
    }
}

