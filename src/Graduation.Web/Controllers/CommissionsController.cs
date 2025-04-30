using System.ComponentModel.DataAnnotations;
using Graduation.Application.Commissions.CreateCommission;
using Graduation.Application.Commissions.EditCommissionCommand;
using Graduation.Application.Commissions.GetCommission;
using Graduation.Application.Commissions.GetCommissions;
using Graduation.Application.Commissions.GetCommissionsForEditing;
using Graduation.Application.Students.GetCommissionStudentsForStage;
using Graduation.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("commissions")]
[ApiExplorerSettings(GroupName = "commissions")]
public class CommissionsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetCommissionsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCommissions([FromHeader(Name = "X-Year")] string year)
    {
        var request = new GetCommissionsQuery(year);
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpGet("students")]
    [ProducesResponseType<GetCommissionStudentsForStageQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudents(
        [FromHeader(Name = "X-Year")] string year,
        [Required] string stage,
        string? query,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        [FromQuery] List<string> sortByAcademicGroups)
    {
        var request = new GetCommissionStudentsForStageQuery(year, stage, query, page, size, sortByAcademicGroups);
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost]
    [ProducesResponseType<CreateCommissionCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateCommission(CreateCommissionCommand request)
    {
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPut]
    [ProducesResponseType<EditCommissionCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> EditCommission(EditCommissionCommand request)
    {
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpGet("{id:guid}")]
    [ProducesResponseType<GetCommissionQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCommission(Guid id)
    {
        var request = new GetCommissionQuery(id);
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpGet("for-editing")]
    [ProducesResponseType<GetCommissionsForEditingQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCommissionsForEditing(
        [FromHeader(Name = "X-Year")] string year)
    {
        var request = new GetCommissionsForEditingQuery(year);
        return Ok(await mediator.Send(request));
    }
}