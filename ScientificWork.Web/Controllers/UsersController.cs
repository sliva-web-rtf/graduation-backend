using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateStudentStatusCommand;
using ScientificWork.UseCases.Users.UpdateUserPassword;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("api/users")]
[ApiExplorerSettings(GroupName = "users")]
[Authorize(Policy = "RegistrationComplete")]
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

    [HttpPut("update-profile-info")]
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
    [HttpPut("update-user-password")]
    public async Task UpdateUserPassword([FromBody] UpdateUserPasswordCommand command)
    {
        await mediator.Send(command);
    }
}
