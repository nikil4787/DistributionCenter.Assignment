using Microsoft.AspNetCore.Mvc;
using MediatR;
using DistributionCenter.Requests;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace DistributionCenter.Controllers;

[ApiController]
[Route("[controller]")]
public class DistributionController : ControllerBase
{
    private readonly ILogger<DistributionController> _logger;
    private readonly IMediator _mediator;
    private readonly AbstractValidator<List<Parcel>> _validator;

    public DistributionController(ILogger<DistributionController> logger, IMediator mediator, AbstractValidator<List<Parcel>> validators)
    {
        _logger = logger;
        _mediator = mediator;
        _validator = validators;
    }


    /// <summary>
    /// POST request that accepts the list of parcels and proceess them 
    /// </summary>
    /// <param name="parcels">List of Parcels to be processed</param>
    /// <returns>List<string> Status of tr</string></returns>
    [HttpPost]
    public IActionResult Post([FromBody]List<Parcel> parcels)
    {
        var result = _validator.Validate(parcels.ToList());
        if (!result.IsValid)
        {
            return BadRequest();
        }

        var results = new List<string>();
        parcels.ToList().ForEach(async t => results.Add((await _mediator.Send(t)).Message));
        return Ok(results);
    }
}
