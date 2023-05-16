using System;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;

namespace DistributionCenter.Handlers
{
	public class SendRegularParcelHandler : IRequestHandler<SendRegularParcelRequest, Response>
    {
		public SendRegularParcelHandler() 
		{
		}
        public async Task<Response> Handle(SendRegularParcelRequest request, CancellationToken cancellationToken)
        {
            // Logic to be written for handling parcels. Not mentioned in the assignment documents


            return new Response("Regular parcel received at Regular Parcel Department Handler");
        }
    }
	
}

