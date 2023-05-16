using DistributionCenter.Models;
using MediatR;

namespace DistributionCenter.Requests
{
    public class Parcel :IRequest<Response>
    {
        public double Weight { get; set; }
        public Company Sender { get; set; }
        public Person Receipient { get; set; }
        public double Value { get; set; }
    }
}