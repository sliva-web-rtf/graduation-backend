using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Students.GetStudentProfileById;
using ScientificWork.UseCases.Students.GetStudents;
using ScientificWork.UseCases.Students.UpdateStudent;
using ScientificWork.UseCases.Users.OnBoarding.CreateStudent;
using ScientificWork.UseCases.Users.OnBoarding.UpdateProfileInfo;
using ScientificWork.UseCases.Users.OnBoarding.UpdateStatusCommand;
using ScientificWork.UseCases.Users.OnBoarding.UpdateStudentScientificPortfolio;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Student controller.
/// </summary>
[ApiController]
[Route("api/student")]
[ApiExplorerSettings(GroupName = "student")]
[Authorize]
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
    /// Create student.
    /// </summary>
    [AllowAnonymous]
    [HttpPost("create-student")]
    public async Task<ActionResult> CreateStudentAsync([FromBody] CreateStudentCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("on-boarding/update-profile-info")]
    public async Task UpdateProfileInfoAsync(UpdateStudentProfileInfoCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    [HttpPut("on-boarding/update-scientific-portfolio")]
    public async Task UpdateScientificPortfolioAsync(UpdateStudentScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("on-boarding/update-status")]
    public async Task UpdateStatusAsync(UpdateStatusCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Update student.
    /// </summary>
    [HttpPut("update-student")]
    public async Task UpdateStudent([FromBody] UpdateStudentCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Student profile by id.
    /// </summary>
    [HttpGet("student-profile-by-id")]
    public async Task GetStudentProfile([FromQuery] GetStudentProfileByIdQuery query)
    {
        await mediator.Send(query);
    }

    /// <summary>
    /// List students.
    /// </summary>
    [HttpGet("list-students")]
    public async Task GetStudents([FromQuery] GetStudentsQuery query)
    {
        await mediator.Send(query);
    }
}
