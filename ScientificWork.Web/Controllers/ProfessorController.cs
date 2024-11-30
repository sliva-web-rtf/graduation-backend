using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ScientificWork.Domain.Admins;
using ScientificWork.UseCases.Professors.GetProfessors;
using ScientificWork.UseCases.Professors.GetProfileById;
using ScientificWork.UseCases.Professors.UploadProfessors;
using ScientificWork.UseCases.Professors.ToggleStudentToFavorites;
using ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;
using ScientificWork.UseCases.Professors.ToggleScientificWorksToFavorites;
using ScientificWork.UseCases.Requests.GetStudentRequestsProfessor;
using ScientificWork.Infrastructure.Presentation.Web;

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
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    [HttpGet("{id:guid}/professor-scientific-portfolio")]
    [Authorize(Policy = "RegistrationComplete")]
    public async Task<ActionResult> GetProfessorScientificPortfolio(Guid id)
    {
        var command = new GetProfessorScientificPortfolioQuery(id);
        var res = await mediator.Send(command);
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
    public async Task AddStudentToFavorites([FromQuery] ToggleStudentToFavoritesCommand command)
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
    /// List request from student to professor.
    /// </summary>
    [HttpGet("list-request-from-student")]
    public async Task GetProfessorRequestStudent([FromQuery] GetStudentRequestsProfessorQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        await mediator.Send(query);
    }
}