using System;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;

namespace DistributionCenter.Handlers
{
	public class SendHeavyParcelHandler : IRequestHandler<SendHeavyParcelRequest,Response>
    {
		public SendHeavyParcelHandler()
		{
		}
        public async Task<Response> Handle(SendHeavyParcelRequest request, CancellationToken cancellationToken)
        {
            // Logic to be written for handling parcels. Not mentioned in the assignment documents


            return new Response("Heavy Parcel received at Heavy Parcel Department Handler");
        }
    }
}

