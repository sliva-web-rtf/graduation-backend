using Graduation.Application.Stages.GetStages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("stages")]
[ApiExplorerSettings(GroupName = "stages")]
public class StagesController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetStagesQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStages()
    {
        var request = new GetStagesQuery();
        return Ok(await mediator.Send(request));
    }
}