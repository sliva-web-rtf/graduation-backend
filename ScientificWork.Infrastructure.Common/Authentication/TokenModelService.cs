using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.DTOs;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;

namespace ScientificWork.UseCases.Users.AuthenticateUser;

/// <summary>
/// Helper to generate <see cref="TokenModel" />.
/// </summary>
public class TokenModelService : ITokenModelService
{
    private readonly IAuthenticationTokenService authenticationTokenService;
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;

    public TokenModelService(
        IAuthenticationTokenService authenticationTokenService,
        SignInManager<User> signInManager,
        UserManager<User> userManager)
    {
        this.authenticationTokenService = authenticationTokenService;
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    /// <summary>
    /// Common code to generate token and fill with claims.
    /// </summary>
    /// <returns>Token model.</returns>
    public async Task<TokenModel> Generate(User user)
    {
        var principal = await signInManager.CreateUserPrincipalAsync(user);
        var claims = principal.Claims;
        var epoch = (long)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
        var iatClaim = new Claim(
            AuthenticationConstants.IatClaimType,
            epoch.ToString(),
            ClaimValueTypes.Integer64);

        var refreshToken = await userManager.GenerateUserTokenAsync(
            user,
            AuthenticationConstants.AppLoginProvider,
            AuthenticationConstants.RefreshTokensName);

        var token = authenticationTokenService.GenerateToken(
            claims.Union(new[] { iatClaim }),
            AuthenticationConstants.AccessTokenExpirationTime);

        // add 5 min because of jwt realization
        var accessTokenExpirationTime = AuthenticationConstants.AccessTokenExpirationTime.Add(TimeSpan.FromMinutes(5));

        return new TokenModel
        {
            Token = token,
            ExpiresIn = (int)accessTokenExpirationTime.TotalSeconds,
            RefreshToken = refreshToken
        };
    }

    /// <inheritdoc />
    public Task<bool> ValidateRefreshToken(User user, string token)
    {
        return userManager.VerifyUserTokenAsync(
            user,
            AuthenticationConstants.AppLoginProvider,
            AuthenticationConstants.RefreshTokensName,
            token);
    }
}
