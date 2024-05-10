using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;
using ScientificWork.UseCases.Professors.AddScientificWorksToFavorites;
using ScientificWork.UseCases.Professors.AddStudentToFavorites;
using ScientificWork.UseCases.Professors.GetProfessors;
using ScientificWork.UseCases.Professors.GetProfileById;
using ScientificWork.UseCases.Professors.UplaodProfessors;
using ScientificWork.UseCases.Requests.GetProfessorRequestsStudent;
using ScientificWork.UseCases.Requests.GetStudentRequestsProfessor;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Professors controller.
/// </summary>
[ApiController]
[Route("api/professor")]
[ApiExplorerSettings(GroupName = "professor")]
[Authorize(Policy = "RegistrationComplete")]
public class ProfessorController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ProfessorController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Professor profile by id.
    /// </summary>
    [HttpGet("profile-by-id")]
    public async Task<ActionResult> GetProfessorProfile([FromQuery] GetProfileQuery query)
    {
        var res = await mediator.Send(query);
        return Ok(res);
    }

    /// <summary>
    /// List professor.
    /// </summary>
    [HttpGet("list-professor")]
    public async Task<ActionResult> GetProfessors([FromQuery] GetProfessorsQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    [HttpPost("upload-professors")]
    [Authorize(Roles = nameof(SystemAdmin))]
    public async Task UploadProfessors([FromForm] UploadProfessorsCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPost("add-student-to-favorites")]
    public async Task AddStudentToFavorites([FromQuery] AddStudentToFavoritesCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    [HttpPost("add-scientific-work-to-favorites")]
    public async Task AddScientificWorksToFavorites([FromQuery] AddScientificWorksToFavoritesCommand command)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(command);
    }

    /// <summary>
    /// List request from student to professor.
    /// </summary>
    [HttpGet("list-request-from-student")]
    public async Task GetProfessorRequestStudent([FromQuery] GetStudentRequestsProfessorQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(query);
    }
}
