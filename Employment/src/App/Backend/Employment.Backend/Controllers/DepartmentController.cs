using Employment.Core.Department.Command;
using Employment.Core.Department.Query;
using Employment.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DepartmentController : ControllerBase
{

    private readonly IMediator _mediator;
    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet]
    public async Task<ActionResult<VmDepartment>> Get()
    {
        var data = await _mediator.Send(new GetAllDepartmentQuery());
        return Ok(data);
    }



    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmDepartment>> Get(int id)
    {
        var data = await _mediator.Send(new GetDepartmentById(id));

        return Ok(data);
    }

    [HttpPost]

    public async Task<ActionResult<VmDepartment>> PostAsync([FromBody] VmDepartment vmDepartment)
    {
        var data = await _mediator.Send(new CreateDepartment(vmDepartment));
        return Ok(data);
    }


    [HttpPut("{id:int}")]

    public async Task<ActionResult<VmDepartment>> PutAsync(int id, [FromBody] VmDepartment vmDepartment)
    {
        var data = await _mediator.Send(new UpdateDepartment(id, vmDepartment));
        return Ok(data);
    }

    [HttpDelete("{id:int}")]

    public async Task<ActionResult<VmDepartment>> DeleteAsync(int id)
    {
        var data = await _mediator.Send(new DeleteDepartment(id));
        return Ok(data);
    }


}
