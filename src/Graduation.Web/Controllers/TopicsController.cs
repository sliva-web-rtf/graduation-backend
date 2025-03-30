using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Topics.GetTopics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("topics")]
[ApiExplorerSettings(GroupName = "topics")]
public class TopicsController(IMediator mediator, ILoggedUserAccessor userAccessor) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetTopics(bool includeOwnedTopics, int page, int size, string? query)
    {
        var command = new GetTopicsCommand(userAccessor.GetCurrentUserId(), includeOwnedTopics, page, size, query);
        return Ok(await mediator.Send(command));
    }
}