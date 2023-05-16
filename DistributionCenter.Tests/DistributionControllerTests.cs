using DistributionCenter.Handlers;
using DistributionCenter.Models;
using DistributionCenter.Requests;
using MediatR;
using Moq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistributionCenter.Controllers;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using DistributionCenter.Validators;

namespace DistributionCenter.Tests
{

    [TestClass]
    public class DistributionControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<DistributionController>> _logger;
        private readonly ParcelListValidator _validator;
        private readonly DistributionController _controller;

        public DistributionControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<DistributionController>>();
            _validator = new ParcelListValidator();
            _controller = new DistributionController(_logger.Object, _mediator.Object, _validator);
        }

        /// <summary>
        /// Tested Valid Parcel
        /// </summary>
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
            var mailList = new List<Parcel> { mail };
            _mediator.Setup(x => x.Send(It.IsAny<Parcel>(), CancellationToken.None)).ReturnsAsync(new Response("Mail received at Mail Department Handler"));

            var result = _controller.Post(mailList);
            _mediator.Verify(x => x.Send(It.IsAny<Parcel>(), CancellationToken.None), Times.Once);


        }

        /// <summary>
        /// Tested Invalid format for parcels. More of a test on validator
        /// </summary>
        [TestMethod]
        public void InValidTest_Mail()
        {
            var mail = new Parcel
            {
                Receipient = null,
                Sender = new Company(),
                Value = 1,
                Weight = 0.1
            };
            var mailList = new List<Parcel> {  mail };
            _mediator.Setup(x => x.Send(It.IsAny<Parcel>(), CancellationToken.None)).ReturnsAsync(new Response("Mail received at Mail Department Handler"));

            var result = _controller.Post(mailList);
            _mediator.Verify(x => x.Send(It.IsAny<Parcel>(), CancellationToken.None), Times.Never);


        }
    }
}