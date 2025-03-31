using System.ComponentModel.DataAnnotations;
using Graduation.Application.Users.GetUserById;
using Graduation.Application.Users.LoginUser;
using Graduation.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("auth")]
[ApiExplorerSettings(GroupName = "auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType<LoginUserCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Authenticate([Required] LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(request, cancellationToken));
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType<UserDetailsDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMe(CancellationToken cancellationToken)
    {
        var request = new GetUserByIdQuery
        {
            UserId = User.GetCurrentUserId()
        };
        return Ok(await mediator.Send(request, cancellationToken));
    }
}