using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Students.CreateStudent;
using ScientificWork.UseCases.Students.GetStudentProfileById;
using ScientificWork.UseCases.Students.GetStudents;
using ScientificWork.UseCases.Students.UpdateStudent;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Student controller.
/// </summary>
[ApiController]
[Route("api/student")]
[ApiExplorerSettings(GroupName = "student")]
public class StudentController
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public StudentController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Create student.
    /// </summary>
    [HttpPost("create-student")]
    public async Task CreateStudent([FromBody] CreateStudentCommand command)
        => await mediator.Send(command);

    /// <summary>
    /// Update student.
    /// </summary>
    [HttpPut("update-student")]
    public async Task UpdateStudent([FromBody] UpdateStudentCommand command)
        => await mediator.Send(command);

    /// <summary>
    /// Student profile by id.
    /// </summary>
    [HttpGet("student-profile-by-id")]
    public async Task GetStudentProfile([FromQuery] GetStudentProfileByIdQuery query)
        => await mediator.Send(query);

    /// <summary>
    /// List students.
    /// </summary>
    [HttpGet("list-students")]
    public async Task GetStudents([FromQuery] GetStudentsQuery query)
        => await mediator.Send(query);
}
