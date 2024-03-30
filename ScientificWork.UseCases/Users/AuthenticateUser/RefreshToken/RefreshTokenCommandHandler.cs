using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.DTOs;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;

namespace ScientificWork.UseCases.Users.AuthenticateUser.RefreshToken;

/// <summary>
/// Handler for <see cref="RefreshTokenCommand" />.
/// </summary>
internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenModel>
{
    private readonly SignInManager<User> signInManager;
    private readonly ITokenModelService tokenService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RefreshTokenCommandHandler(
        SignInManager<User> signInManager,
        ITokenModelService tokenService)
    {
        this.signInManager = signInManager;
        this.tokenService = tokenService;
    }

    /// <inheritdoc />
    public async Task<TokenModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // Get user.
        var user = await signInManager.UserManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            throw new DomainException($"User with identifier {request.UserId} not found.");
        }

        // Validate token.
        var isRefreshTokenValid = await tokenService.ValidateRefreshToken(user, request.RefreshToken);
        if (!isRefreshTokenValid)
        {
            throw new DomainException("Refresh token is invalid.");
        }

        var tokenModel = await tokenService.Generate(user, true);
        return tokenModel;
    }
}
