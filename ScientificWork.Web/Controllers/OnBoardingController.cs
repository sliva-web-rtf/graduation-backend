using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Users;
using ScientificWork.UseCases.Students.CompleteOnBoarding;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateStudentStatusCommand;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("api/on-boarding")]
[ApiExplorerSettings(GroupName = "on-boarding")]
[Authorize]
public class OnBoardingController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public OnBoardingController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPut("update-profile-info")]
    public async Task UpdateOnBoardingProfileInfoAsync(UpdateProfileInfoCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-scientific-portfolio")]
    public async Task UpdateOnBoardingScientificPortfolioAsync(UpdateStudentScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-status")]
    public async Task UpdateOnBoardingStatusAsync(UpdateStudentStatusCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPost("complete")]
    public async Task CompleteOnBoardingAsync(CompleteOnBoardingCommand command)
    {
        await mediator.Send(command);
    }
}
