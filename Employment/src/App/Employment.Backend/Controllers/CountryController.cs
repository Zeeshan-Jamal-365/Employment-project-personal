using Employment.Core.Country.Command;
using Employment.Core.Country.Query;
using Employment.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CountryController : ControllerBase
{

    private readonly IMediator _mediator;
    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet]
    public async Task<ActionResult<VmCountry>> Get()
    {
        var data = await _mediator.Send(new GetAllCountryQuery());
        return Ok(data);
    }

    [HttpGet("{id:int}")]


    public async Task<ActionResult<VmCountry>> Get(int id)
    {
        var data = await _mediator.Send(new GetCountryById(id));

        return Ok(data);
    }

    [HttpPost]

    public async Task<ActionResult<VmCountry>> PostAsync([FromBody] VmCountry vmCountry)
    {
        var data = await _mediator.Send(new CreateCountry(vmCountry));
        return Ok(data);
    }


    [HttpPut("{id:int}")]

    public async Task<ActionResult<VmCountry>> PutAsync(int id, [FromBody] VmCountry vmCountry)
    {
        var data = await _mediator.Send(new UpdateCountry(id, vmCountry));
        return Ok(data);
    }

    [HttpDelete("{id:int}")]

    public async Task<ActionResult<VmCountry>> DeleteAsync(int id)
    {
        var data = await _mediator.Send(new DeleteCountry(id));
        return Ok(data);
    }


}
