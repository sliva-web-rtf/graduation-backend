using System.ComponentModel.DataAnnotations;
using Graduation.Application.AcademicGroups.GetAcademicGroups;
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
}