using Graduation.Application.Interfaces.Authentication;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.Users.LoginUser;

/// <summary>
/// Handler for <see cref="LoginUserCommand"/>.
/// </summary>
internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResult>
{
    private readonly SignInManager<User> signInManager;
    private readonly IAuthenticationService authService;
    private readonly ILogger<LoginUserCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="signInManager">Sign in manager.</param>
    /// <param name="authService">Token service.</param>
    /// <param name="logger">Logger.</param>
    public LoginUserCommandHandler(
        SignInManager<User> signInManager,
        IAuthenticationService authService,
        ILogger<LoginUserCommandHandler> logger)
    {
        this.signInManager = signInManager;
        this.authService = authService;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<LoginUserCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Password sign in.
        var result = await signInManager.PasswordSignInAsync(request.UserName, request.Password,
            false, false);
        ValidateSignInResult(result, request.UserName);

        // Get user and log.
        var user = await signInManager.UserManager.FindByNameAsync(request.UserName);
        if (user == null)
        {
            throw new NotFoundException($"User with email {request.UserName} not found.");
        }

        logger.LogInformation("User with Id {Id} has logged in.", user.Id);

        var token = await authService.GenerateAuthenticationToken(user);
        return new LoginUserCommandResult { UserId = user.Id, Token = token };
    }

    private void ValidateSignInResult(SignInResult signInResult, string email)
    {
        if (!signInResult.Succeeded)
        {
            if (signInResult.IsNotAllowed)
            {
                throw new DomainException($"User {email} is not allowed to Sign In.");
            }

            if (signInResult.IsLockedOut)
            {
                throw new DomainException($"User {email} is locked out.");
            }

            throw new DomainException("Email or password is incorrect.");
        }
    }
}