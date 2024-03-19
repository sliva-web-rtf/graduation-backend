using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Students.GetStudentProfileById;
using ScientificWork.UseCases.Students.GetStudents;
using ScientificWork.UseCases.Users.CompleteOnBoarding;
using ScientificWork.UseCases.Users.CreateStudent;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStatusCommand;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateUserPassword;
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
    public async Task UpdateOnBoardingProfileInfoAsync(UpdateStudentProfileInfoCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    [HttpPut("on-boarding/update-scientific-portfolio")]
    public async Task UpdateOnBoardingScientificPortfolioAsync(UpdateStudentScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("on-boarding/update-status")]
    public async Task UpdateOnBoardingStatusAsync(UpdateStatusCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPost("on-boarding/complete")]
    public async Task CompleteOnBoardingAsync(CompleteOnBoardingCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-profile-info")]
    public async Task UpdateProfileInfoAsync(UpdateStudentProfileInfoCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    [HttpPut("update-scientific-portfolio")]
    public async Task UpdateScientificPortfolioAsync(UpdateStudentScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-status")]
    public async Task UpdateStatusAsync(UpdateStatusCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Update password.
    /// </summary>
    [HttpPut("update-user-password")]
    public async Task UpdateStudent([FromBody] UpdateUserPasswordCommand command)
    {
        await mediator.Send(command);
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
        var res = await mediator.Send(query);
        return Ok(res);
    }
}
