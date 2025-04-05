using System.ComponentModel.DataAnnotations;
using Graduation.Application.Students.GetStudent;
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
    public async Task<IActionResult> GetStudents(
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetStudentsQuery(page, size, query);
        return Ok(await mediator.Send(request));
    }

    [Authorize]
    [HttpGet("{id:Guid}")]
    [ProducesResponseType<GetStudentQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        var request = new GetStudentQuery(id);
        return Ok(await mediator.Send(request));
    }
}