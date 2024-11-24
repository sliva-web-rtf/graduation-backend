using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Professors.GetProfessorProfileInfo;
using ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;
using ScientificWork.UseCases.Students.GetStudentProfileInfo;
using ScientificWork.UseCases.Students.GetStudentScientificPortfolio;
using ScientificWork.UseCases.Users.CompleteOnBoarding;
using ScientificWork.UseCases.Users.GetProfessorOnBoardingInfo;
using ScientificWork.UseCases.Users.GetStudentOnBoardingInfo;
using ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateProfessorStatus;
using ScientificWork.UseCases.Users.UpdateProfileInfo;
using ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;
using ScientificWork.UseCases.Users.UpdateStudentStatus;

namespace ScientificWork.Web.Controllers;

[ApiController]
[Route("api/on-boarding")]
[ApiExplorerSettings(GroupName = "on-boarding")]
[Authorize(Policy = "RegistrationNotComplete")]
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
    [Authorize(Roles = nameof(Student))]
    public async Task UpdateOnBoardingScientificPortfolioAsync(UpdateStudentScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-status")]
    [Authorize(Roles = nameof(Student))]
    public async Task UpdateOnBoardingStatusAsync(UpdateStudentStatusCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-professor-scientific-portfolio")]
    [Authorize(Roles = nameof(Professor))]
    public async Task UpdateProfessorOnBoardingScientificPortfolioAsync(
        UpdateProfessorScientificPortfolioCommand command)
    {
        await mediator.Send(command);
    }

    [HttpPut("update-professor-status")]
    [Authorize(Roles = nameof(Professor))]
    public async Task UpdateProfessorOnBoardingStatusAsync(UpdateProfessorStatusCommand command)
    {
        await mediator.Send(command);
    }

    [HttpGet("student-profile-info")]
    [Authorize(Roles = nameof(Student))]
    public async Task<ActionResult> GetStudentProfileInfo()
    {
        var command = new GetStudentProfileInfoCommand();
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpGet("student-scientific-portfolio")]
    [Authorize(Roles = nameof(Student))]
    public async Task<ActionResult> GetStudentScientificPortfolio()
    {
        var command = new GetStudentScientificPortfolioCommand();
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpGet("student-profile")]
    [Authorize(Roles = nameof(Student))]
    public async Task<ActionResult> GetStudentProfile()
    {
        var command = new GetStudentOnBoardingInfoCommand();
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpGet("professor-profile-info")]
    [Authorize(Roles = nameof(Professor))]
    public async Task<ActionResult> GetProfessorProfileInfo()
    {
        var command = new GetProfessorProfileInfoCommand();
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpGet("professor-scientific-portfolio")]
    [Authorize(Roles = nameof(Professor))]
    public async Task<ActionResult> GetProfessorScientificPortfolio()
    {
        var command = new GetProfessorScientificPortfolioCommand();
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpGet("professor-profile")]
    [Authorize(Roles = nameof(Professor))]
    public async Task<ActionResult> GetProfessorProfile()
    {
        var command = new GetProfessorOnBoardingInfoCommand();
        var res = await mediator.Send(command);
        return Ok(res);
    }

    [HttpPost("complete")]
    public async Task CompleteOnBoardingAsync(CompleteOnBoardingCommand command)
    {
        await mediator.Send(command);
    }
}