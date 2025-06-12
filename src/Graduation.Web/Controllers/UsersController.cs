using Graduation.Application.Users.CreateUser;
using Graduation.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = $"{WellKnownRoles.HeadSecretary},{WellKnownRoles.Admin}")]
    [HttpPost]
    [ProducesResponseType<CreateUserCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateUser(CreateUserCommand request)
    {
        return Ok(await mediator.Send(request));
    }
}