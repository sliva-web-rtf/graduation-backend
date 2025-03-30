using Graduation.Application.Users.AddUserToRole;
using Graduation.Application.Users.CreateUser;
using MediatR;
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
    public async Task<IActionResult> CreateUser(CreateUserCommand request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPost("add-torole")]
    public async Task<IActionResult> AddToRole(AddUserToRoleCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }
}