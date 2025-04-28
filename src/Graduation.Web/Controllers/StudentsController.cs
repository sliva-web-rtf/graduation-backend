using System.ComponentModel.DataAnnotations;
using Graduation.Application.Students.GetStudent;
using Graduation.Application.Students.GetStudents;
using Graduation.Application.Table.EditStudentsTable;
using Graduation.Application.Table.GetStudentsTable;
using Graduation.Application.Table.SetStudentsStageDate;
using Graduation.Domain;
using Graduation.Domain.Students;
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
        [FromHeader(Name = "X-Year")] string year,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query)
    {
        var request = new GetStudentsQuery(year, page, size, query);
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

    [Authorize(Roles = $"{WellKnownRoles.Secretary},{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost("table")]
    [ProducesResponseType<GetStudentsTableQueryResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudentsTable(
        [FromHeader(Name = "X-Year")] string year,
        [Required] string stage,
        [FromQuery] List<string> commissions,
        [FromQuery] List<StudentStatus> studentStatuses,
        [Required] [Range(0, int.MaxValue)] int page,
        [Required] [Range(1, 1000)] int size,
        string? query,
        [FromBody] List<SortStatus> sort)
    {
        var request = new GetStudentsTableQuery(year, stage, commissions, studentStatuses, page, size, query, sort);
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.Secretary},{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPut("table")]
    [ProducesResponseType<EditStudentsTableCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> EditStudentsTable(EditStudentsTableCommand request)
    {
        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = $"{WellKnownRoles.Secretary},{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPut("table/date")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetStudentsTableStageDate(SetStudentsStageDateCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }
}