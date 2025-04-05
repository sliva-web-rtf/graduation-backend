using System.ComponentModel.DataAnnotations;
using Graduation.Application.Students.GetStudents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("students")]
[ApiExplorerSettings(GroupName = "students")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet]
    [ProducesResponseType<GetStudentsQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTopics(
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetStudentsQuery(page, size, query);
        return Ok(await mediator.Send(request));
    }
}