using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.UseCases.Students.CompleteOnBoarding;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStatusCommand;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateUserPassword;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("api/users")]
[ApiExplorerSettings(GroupName = "users")]
[Authorize]
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
}
