using Graduation.Application.Users.CreateUser;
using Graduation.Application.Users.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web.Controllers;

[ApiController]
[Route("test")]
[ApiExplorerSettings(GroupName = "test")]
public class TestController : ControllerBase
{
    private readonly IMediator mediator;

    public TestController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        return Ok(await mediator.Send(command));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("check")]
    [Authorize]
    public async Task<IActionResult> Check()
    {
        return Ok();
    }
}