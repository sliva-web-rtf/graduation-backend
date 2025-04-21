using Graduation.Application.Commissions.GetCommissions;
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
    [ProducesResponseType<GetCommissionsQuery>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCommissions([FromHeader(Name = "X-Year")] string year)
    {
        var request = new GetCommissionsQuery(year);
        return Ok(await mediator.Send(request));
    }
}