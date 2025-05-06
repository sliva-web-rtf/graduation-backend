using System.ComponentModel.DataAnnotations;
using Graduation.Application.Secretaries.GetSecretaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("secretaries")]
[ApiExplorerSettings(GroupName = "secretaries")]
public class SecretariesController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetSecretariesQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSecretaries(
        [FromHeader(Name = "X-Year")] string year,
        string? query,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size)
    {
        var request = new GetSecretariesQuery(year, query, page, size);
        return Ok(await mediator.Send(request));
    }
}