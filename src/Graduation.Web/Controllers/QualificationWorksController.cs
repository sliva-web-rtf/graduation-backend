using Graduation.Application.QualificationWorks.GetQualificationWork;
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
}