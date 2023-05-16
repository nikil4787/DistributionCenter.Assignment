using DistributionCenter.Handlers;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;
using Moq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistributionCenter.Tests
{

    [TestClass]
    public class ParcelHandlerTests
    {

        private readonly Mock<IMediator> _mediator;
        private readonly ParcelHandler _parcelHandler;

        public ParcelHandlerTests()
        {
            _mediator = new Mock<IMediator>();
            _parcelHandler = new ParcelHandler(_mediator.Object);
        }

        [TestMethod]
        public void ValidTest_Mail()
        {
            var mail = new Parcel
            {
                Receipient = new Person(),
                Sender = new Company(),
                Value = 1,
                Weight = 0.1
            };
            _mediator.Setup(x => x.Send(It.IsAny<SendMailRequest>(), CancellationToken.None)).ReturnsAsync(new Response("Mail received at Mail Department Handler"));

            var result = _parcelHandler.Handle(mail, CancellationToken.None).Result;
            _mediator.Verify(x => x.Send(It.IsAny<SendMailRequest>(), CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(new Response("Mail received at Mail Department Handler"));
        }

        [TestMethod]
        public void ValidTest_Insurance()
        {
            var insurance = new Parcel
            {
                Receipient = new Person(),
                Sender = new Company(),
                Value = 10002,
                Weight = 0.1
            };
            _mediator.Setup(x => x.Send(It.IsAny<SendToInsuranceRequest>(), CancellationToken.None)).ReturnsAsync(new Response("Insurance received at Insurance Department Handler"));

            var result = _parcelHandler.Handle(insurance, CancellationToken.None).Result;
            _mediator.Verify(x => x.Send(It.IsAny<SendToInsuranceRequest>(), CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(new Response("Insurance received at Insurance Department Handler"));
        }

        [TestMethod]
        public void ValidTest_Heavy()
        {
            var heavy = new Parcel
            {
                Receipient = new Person(),
                Sender = new Company(),
                Value = 1,
                Weight = 123
            };
            _mediator.Setup(x => x.Send(It.IsAny<SendHeavyParcelRequest>(), CancellationToken.None)).ReturnsAsync(new Response("Heavy parcel received at heavy parcel Department Handler"));

            var result = _parcelHandler.Handle(heavy, CancellationToken.None).Result;
            _mediator.Verify(x => x.Send(It.IsAny<SendHeavyParcelRequest>(), CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(new Response("Heavy parcel received at heavy parcel Department Handler"));
        }

        [TestMethod]
        public void ValidTest_Regular()
        {
           
            var regular = new Parcel
            {
                Receipient = new Person(),
                Sender = new Company(),
                Value = 1,
                Weight = 19
            };
          
            _mediator.Setup(x => x.Send(It.IsAny<SendRegularParcelRequest>(), CancellationToken.None)).ReturnsAsync(new Response("Regular Parcel received at Regular parcel Department Handler"));

            var result = _parcelHandler.Handle(regular, CancellationToken.None).Result;
            _mediator.Verify(x => x.Send(It.IsAny<SendRegularParcelRequest>(), CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(new Response("Regular Parcel received at Regular parcel Department Handler"));
        }

    }
}
