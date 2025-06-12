using System.ComponentModel.DataAnnotations;
using Graduation.Application.QualificationWorks.CopyStageData;
using Graduation.Application.QualificationWorks.GetQualificationWork;
using Graduation.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("qualification-works")]
[ApiExplorerSettings(GroupName = "qualification-works")]
public class QualificationWorksController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet("{id:guid}")]
    [ProducesResponseType<GetQualificationWorkQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetQualificationWork(Guid id, string stage)
    {
        var request = new GetQualificationWorkQuery(id, stage);
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost("copy-stage-data")]
    [ProducesResponseType<CopyStageDataCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CopyStageData(
        [FromHeader(Name = "X-Year")] string year,
        [Required] string stageFrom,
        [Required] string stageTo)
    {
        var request = new CopyStageDataCommand(year, stageFrom, stageTo);
        return Ok(await mediator.Send(request));
    }
}