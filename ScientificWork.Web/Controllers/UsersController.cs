using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Users.AddAvatarImage;
using ScientificWork.UseCases.Users.GetAvatarImage;
using ScientificWork.UseCases.Users.GetProfessorStatus;
using ScientificWork.UseCases.Users.GetProfileInfo;
using ScientificWork.UseCases.Users.GetStudentStatus;
using ScientificWork.UseCases.Users.RemoveAvatarImage;
using ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateProfessorStatus;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateStudentStatus;
using ScientificWork.UseCases.Users.UpdateUserPassword;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("api/users")]
[ApiExplorerSettings(GroupName = "users")]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("get-profile-info")]
    [Authorize(Policy = "RegistrationComplete")]
    [ProducesResponseType<GetProfileInfoQueryResult>(200)]
    public async Task<IActionResult> GetProfileInfo()
    {
        var result = await mediator.Send(new GetProfileInfoQuery());
        return Ok(result);
    }

    /// <summary>
    /// List researchers students.
    /// </summary>
    [HttpGet("get-researchers-students")]
    public async Task<ActionResult> GetResearchersStudents([FromQuery] GetStudentsQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    /// <summary>
    /// List research topics.
    /// </summary>
    [HttpGet("get-research-topics")]
    public async Task<ActionResult> GetFavoritesResearchTopics([FromQuery] GetScientificWorksQuery query)
    {
        HttpContext.Items.Add("userId", User.GetCurrentUserId());
        var res = await mediator.Send(query);
        return Ok(res);
    }

    [HttpGet("get-avatar-image")]
    [Authorize]
    public async Task<ActionResult> GetAvatarImage()
    {
        var result = await mediator.Send(new GetAvatarImageCommand());
        return Ok(result);
    }
    
    [HttpGet("student-status")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Student))]
    [ProducesResponseType<GetStudentStatusQueryResult>(200)]
    public async Task<IActionResult> GetStudentStatus()
    {
        var result = await mediator.Send(new GetStudentStatusQuery());
        return Ok(result);
    }
    
    [HttpGet("professor-status")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Professor))]
    [ProducesResponseType<GetProfessorStatusQueryResult>(200)]
    public async Task<IActionResult> GetProfessorStatus()
    {
        var result = await mediator.Send(new GetProfessorStatusQuery());
        return Ok(result);
    }
    
    [HttpPut("student-status")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Student))]
    public async Task UpdateStudentStatus(UpdateStudentStatusCommand command)
    {
         await mediator.Send(command);
    }
    
    [HttpPut("professor-status")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Professor))]
    public async Task UpdateProfessorStatus(UpdateProfessorStatusCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-profile-info")]
    [Authorize(Policy = "RegistrationComplete")]
    public async Task UpdateProfileInfoAsync(UpdateProfileInfoCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-student-scientific-portfolio")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Student))]
    public async Task UpdateStudentScientificPortfolioAsync(UpdateStudentScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-status")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Student))]
    public async Task UpdateStatusAsync(UpdateStudentStatusCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-professor-scientific-portfolio")]
    [Authorize(Policy = "RegistrationComplete", Roles = nameof(Professor))]
    public async Task UpdateProfessorScientificPortfolioAsync(UpdateProfessorScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Update password.
    /// </summary>
    [Authorize(Policy = "RegistrationComplete")]
    [HttpPut("update-user-password")]
    public async Task UpdateUserPassword([FromBody] UpdateUserPasswordCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPost("add-avatar-image")]
    [Authorize]
    public async Task AddAvatarImage(IFormFile file)
    {
        await using var fileStream = file.OpenReadStream();
        var command = new AddAvatarImageCommand
        {
            Data = fileStream, FileName = file.FileName, ContentType = file.ContentType
        };
        await mediator.Send(command);
    }

    [HttpDelete("remove-avatar-image")]
    [Authorize]
    public async Task RemoveAvatarImage()
    {
        await mediator.Send(new RemoveAvatarImageCommand());
    }

    [HttpGet("get-avatar-image")]
    [Authorize]
    public async Task<ActionResult> GetAvatarImage()
    {
        var result = await mediator.Send(new GetAvatarImageCommand());
        return Ok(result);
    }
}
