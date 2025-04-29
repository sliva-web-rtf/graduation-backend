using System.ComponentModel.DataAnnotations;
using Graduation.Application.Experts.GetExperts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("experts")]
[ApiExplorerSettings(GroupName = "experts")]
public class ExpertsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetExpertsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExperts(
        [FromHeader(Name = "X-Year")] string year,
        string? query,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size)
    {
        var request = new GetExpertsQuery(year, query, page, size);
        return Ok(await mediator.Send(request));
    }
}