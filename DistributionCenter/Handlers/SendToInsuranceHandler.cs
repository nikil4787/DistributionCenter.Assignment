using System;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;

namespace DistributionCenter.Handlers
{
	public class SendToInsuranceHandler : IRequestHandler<SendToInsuranceRequest,Response>
	{
		public SendToInsuranceHandler()
		{
		}

        public async Task<Response> Handle(SendToInsuranceRequest request, CancellationToken cancellationToken)
        {
            // Logic to be written for handling parcels. Not mentioned in the assignment documents


            return new Response("Insurance received at Insurance Department Handler");
        }
    }
}

