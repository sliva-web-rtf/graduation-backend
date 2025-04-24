using Graduation.Application.Years.CreateYear;
using Graduation.Application.Years.GetCurrentYear;
using Graduation.Application.Years.GetYears;
using Graduation.Application.Years.SetCurrentYear;
using Graduation.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("years")]
[ApiExplorerSettings(GroupName = "years")]
public class YearsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetYearsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetYears()
    {
        var request = new GetYearsQuery();
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateYear(CreateYearCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }

    [Authorize]
    [HttpGet("current")]
    [ProducesResponseType<GetCurrentYearQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetYear()
    {
        var request = new GetCurrentYearQuery();
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost("current")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetYear(SetCurrentYear request)
    {
        await mediator.Send(request);
        return Ok();
    }
}