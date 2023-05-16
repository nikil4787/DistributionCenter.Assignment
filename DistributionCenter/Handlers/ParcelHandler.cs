using System;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;
namespace DistributionCenter.Handlers
{
    public class ParcelHandler : IRequestHandler<Parcel, Response>
    {
        private readonly IMediator _mediator;

        public ParcelHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Response> Handle(Parcel request, CancellationToken cancellationToken)
        {
            // Using Mediator to split departments logic from distribution logic. 
            Task<Response> result;
            if (request.Value > 1000)
            {
                result = _mediator.Send(new SendToInsuranceRequest() { Parcel = request });

            }
            else if (request.Weight < 1.0)
            {
                result = _mediator.Send(new SendMailRequest() { Parcel = request });
            }
            else if (request.Weight > 10.0 && request.Weight < 100)
            {
                result = _mediator.Send(new SendRegularParcelRequest() { Parcel = request });
            }
            else
            {
                result = _mediator.Send(new SendHeavyParcelRequest() { Parcel = request });
            }

            return result;
        }
    }
}

