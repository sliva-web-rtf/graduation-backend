using System.ComponentModel.DataAnnotations;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Topics.GetTopic;
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
    public async Task<IActionResult> GetTopics(
        bool includeOwnedTopics, 
        [Required]
        [Range(0, int.MaxValue)]
        int page,
        [Required]
        [Range(1, 1000)]
        int size,
        string? query)
    {
        var command = new GetTopicsCommand(userAccessor.GetCurrentUserId(), includeOwnedTopics, page, size, query);
        return Ok(await mediator.Send(command));
    }
    
    [Authorize]
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetTopic(Guid id)
    {
        var command = new GetTopicRequest(id);
        return Ok(await mediator.Send(command));
    }
}