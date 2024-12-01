using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ScientificWork.Domain.Admins;
using ScientificWork.UseCases.Students.GetStudents;
using ScientificWork.UseCases.Students.UploadStudents;
using ScientificWork.UseCases.Students.GetStudentProfileById;
using ScientificWork.UseCases.Students.ToggleStudentToFavorites;
using ScientificWork.UseCases.Requests.GetStudentRequestsStudent;
using ScientificWork.UseCases.Students.ToggleProfessorToFavorites;
using ScientificWork.UseCases.Requests.GetProfessorRequestsStudent;
using ScientificWork.UseCases.Students.GetStudentScientificPortfolio;
using ScientificWork.UseCases.Students.ToggleScientificWorksToFavorites;
using ScientificWork.Infrastructure.Presentation.Web;

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
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    [HttpGet("student-scientific-portfolio")]
    public async Task<ActionResult> GetStudentScientificPortfolio(Guid id)
    {
        var command = new GetStudentScientificPortfolioQuery(id);
        var res = await mediator.Send(command);
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

    [HttpPost("add-student-to-favorites")]
    public async Task AddStudentToFavorites([FromQuery] ToggleStudentToFavoritesCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    [HttpPost("add-professor-to-favorites")]
    public async Task AddProfessorToFavorites([FromQuery] ToggleProfessorToFavoritesCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    [HttpPost("add-scientific-work-to-favorites")]
    public async Task AddScientificWorksToFavorites([FromQuery] ToggleScientificWorksToFavoritesCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    /// <summary>
    /// List request from student to student .
    /// </summary>
    [HttpGet("list-request-from-student")]
    public async Task<ActionResult> GetStudentRequestStudent([FromQuery] GetStudentRequestsStudentQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    /// <summary>
    /// List request from professor to student .
    /// </summary>
    [HttpGet("list-request-from-professor")]
    public async Task<ActionResult> GetProfessorRequestStudent([FromQuery] GetProfessorRequestsStudentQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }
}