using Graduation.Application.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [ProducesResponseType<CreateUserCommandResult>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateUser(CreateUserCommand request, [FromHeader(Name = "X-Year")] string year)
    {
        request.Year = year;
        return Ok(await mediator.Send(request));
    }
}