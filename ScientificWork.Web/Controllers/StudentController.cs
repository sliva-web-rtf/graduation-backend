using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;
using ScientificWork.UseCases.Students.GetStudentProfileById;
using ScientificWork.UseCases.Students.GetStudents;
using ScientificWork.UseCases.Students.UploadStudents;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Student controller.
/// </summary>
[ApiController]
[Route("api/student")]
[ApiExplorerSettings(GroupName = "student")]
[Authorize(Policy = "RegistrationComplete")]
public class StudentController : ControllerBase
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
    /// Student profile by id.
    /// </summary>
    [HttpGet("student-profile-by-id")]
    public async Task<ActionResult> GetStudentProfile([FromQuery] GetStudentProfileByIdQuery query)
    {
        var res = await mediator.Send(query);
        return Ok(res);
    }

    /// <summary>
    /// List students.
    /// </summary>
    [HttpGet("list-students")]
    public async Task<ActionResult> GetStudents([FromQuery] GetStudentsQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    [HttpPost("upload-students")]
    [Authorize(Roles = nameof(SystemAdmin))]
    public async Task UploadStudents([FromForm] UploadStudentsCommand command)
    {
        await mediator.Send(command);
    }
}
