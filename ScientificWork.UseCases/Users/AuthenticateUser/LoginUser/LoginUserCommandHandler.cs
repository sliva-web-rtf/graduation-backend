using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ScientificWork.UseCases.Common.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;

namespace ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;

/// <summary>
/// Handler for <see cref="LoginUserCommand"/>.
/// </summary>
internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResult>
{
    private readonly SignInManager<User> signInManager;
    private readonly ITokenModelService tokenService;
    private readonly ILogger<LoginUserCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="signInManager">Sign in manager.</param>
    /// <param name="tokenService">Token service.</param>
    /// <param name="logger">Logger.</param>
    public LoginUserCommandHandler(
        SignInManager<User> signInManager,
        ITokenModelService tokenService,
        ILogger<LoginUserCommandHandler> logger)
    {
        this.signInManager = signInManager;
        this.tokenService = tokenService;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<LoginUserCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Password sign in.
        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, 
            false, false);
        ValidateSignInResult(result, request.Email);

        // Get user and log.
        var user = await signInManager.UserManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new NotFoundException($"User with email {request.Email} not found.");
        }
        logger.LogInformation("User with email {email} has logged in.", user.Email);

        // Update last login date.
        user.UpdateLastLogin();
        await signInManager.UserManager.UpdateAsync(user);
        var token = await tokenService.Generate(user);
        // Give token.
        return new LoginUserCommandResult
        {
            UserId = user.Id,
            TokenModel = token
        };
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
