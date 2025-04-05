using System.ComponentModel.DataAnnotations;
using Graduation.Application.Supervisors.GetSupervisor;
using Graduation.Application.Supervisors.GetSupervisors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("supervisors")]
[ApiExplorerSettings(GroupName = "supervisors")]
public class SupervisorsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetSupervisorsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSupervisors(
        [FromHeader(Name = "X-Year")] string year,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetSupervisorsQuery(year, page, size, query);
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpGet("{id:Guid}")]
    [ProducesResponseType<GetSupervisorQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSupervisor(
        [FromHeader(Name = "X-Year")] string year,
        Guid id)
    {
        var request = new GetSupervisorQuery(year, id);
        return Ok(await mediator.Send(request));
    }
}