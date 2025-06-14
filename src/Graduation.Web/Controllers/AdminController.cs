using System.ComponentModel.DataAnnotations;
using Graduation.Application.Admin.GetApplicationEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("admin")]
[ApiExplorerSettings(GroupName = "admin")]
public class AdminController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet("events")]
    [ProducesResponseType<GetApplicationEventsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEvents(
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetApplicationEventsQuery(query, page, size);
        return Ok(await mediator.Send(request));
    }
}