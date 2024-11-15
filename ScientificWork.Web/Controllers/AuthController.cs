using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Domain.Admins;
using ScientificWork.Infrastructure.Abstractions.DTOs;
using ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;
using ScientificWork.UseCases.Users.AuthenticateUser.RefreshToken;
using ScientificWork.UseCases.Users.GetUserById;
using ScientificWork.Infrastructure.Presentation.Web;
using ScientificWork.UseCases.Professors.CreateProfessor;
using ScientificWork.UseCases.Students.CreateStudent;

namespace ScientificWork.Web.Controllers;

/// <summary>
/// Authentication controller.
/// </summary>
[ApiController]
[Route("api/auth")]
[ApiExplorerSettings(GroupName = "auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    /// <summary>
    /// Register new student by email and password.
    /// </summary>
    /// <param name="command">Create command</param>
    [HttpPost("create-student")]
    public async Task CreateStudent([FromForm] CreateStudentCommand command)
    {
        await mediator.Send(command);
    }
    
    /// <summary>
    /// Register new professor by email and password.
    /// </summary>
    /// <param name="command">Create command</param>
    [HttpPost("create-professor")]
    public async Task CreateProfessor([FromForm] CreateProfessorCommand command)
    {
        await mediator.Send(command);
    }

    /// <summary>
    /// Authenticate user by email and password.
    /// </summary>
    /// <param name="command">Login command.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<TokenModel> Authenticate([Required] LoginUserCommand command, CancellationToken cancellationToken)
    {
        return (await mediator.Send(command, cancellationToken)).TokenModel;
    }

    /// <summary>
    /// Get new token by refresh token.
    /// </summary>
    /// <param name="command">Refresh token command.</param>
    /// <returns>New authentication and refresh tokens.</returns>
    /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public Task<TokenModel> RefreshToken([Required] RefreshTokenCommand command, CancellationToken cancellationToken)
        => mediator.Send(command, cancellationToken);

    /// <summary>
    /// Get current logged user info.
    /// </summary>
    /// <returns>Current logged user info.</returns>
    /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
    [HttpGet]
    [Authorize]
    public async Task<UserDetailsDto> GetMe(CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery
        {
            UserId = User.GetCurrentUserId()
        };
        return await mediator.Send(query, cancellationToken);
    }
}
