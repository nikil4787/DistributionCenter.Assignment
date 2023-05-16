using System;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;

namespace DistributionCenter.Handlers
{
	public class SendMailHandler : IRequestHandler<SendMailRequest, Response>
    {
		public SendMailHandler()
		{
		}

        public async Task<Response> Handle(SendMailRequest request, CancellationToken cancellationToken)
        {
            // Logic to be written for handling parcels. Not mentioned in the assignment documents


            return new Response("Mail received at Mail Department Handler");
        }
    }
}

