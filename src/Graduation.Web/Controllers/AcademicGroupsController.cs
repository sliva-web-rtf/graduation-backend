using System.ComponentModel.DataAnnotations;
using Graduation.Application.AcademicGroups.GetAcademicGroups;
using Graduation.Application.AcademicGroups.GetFormattingReviewers;
using Graduation.Application.AcademicGroups.SetFormattingReviewer;
using Graduation.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("academic-groups")]
[ApiExplorerSettings(GroupName = "academic-groups")]
public class AcademicGroupsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetAcademicGroupsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAcademicGroups(
        [FromHeader(Name = "X-Year")] string year,
        string? query,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        Guid? commissionId)
    {
        var request = new GetAcademicGroupsQuery(year, query, commissionId, page, size);
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost("formatting-reviewers")]
    [ProducesResponseType<SetFormattingReviewerCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetFormattingReviewer(SetFormattingReviewerCommand request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [Authorize]
    [HttpGet("formatting-reviewers")]
    [ProducesResponseType<GetFormattingReviewersQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFormattingReviewers(
        [FromHeader(Name = "X-Year")] string year,
        string? query,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size)
    {
        var request = new GetFormattingReviewersQuery(year, query, page, size);
        return Ok(await mediator.Send(request));
    }
}