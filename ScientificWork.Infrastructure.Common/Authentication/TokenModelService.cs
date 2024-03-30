using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.DTOs;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;
using ScientificWork.UseCases.Common.Settings;
using ScientificWork.UseCases.Common.Settings.Authentication;

namespace ScientificWork.UseCases.Users.AuthenticateUser;

/// <summary>
/// Helper to generate <see cref="TokenModel" />.
/// </summary>
public class TokenModelService : ITokenModelService
{
    private readonly IAuthenticationTokenService authenticationTokenService;
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;
    private readonly RefreshTokenCreationOptions creationOptions;

    public TokenModelService(
        IAuthenticationTokenService authenticationTokenService,
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        RefreshTokenCreationOptions creationOptions)
    {
        this.authenticationTokenService = authenticationTokenService;
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.creationOptions = creationOptions;
    }

    /// <summary>
    /// Common code to generate token and fill with claims.
    /// </summary>
    /// <returns>Token model.</returns>
    public async Task<TokenModel> Generate(User user, bool rememberMe)
    {
        var principal = await signInManager.CreateUserPrincipalAsync(user);
        var claims = principal.Claims;
        var epoch = (long)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
        var iatClaim = new Claim(
            AuthenticationConstants.IatClaimType,
            epoch.ToString(),
            ClaimValueTypes.Integer64);

        var accessTokenExpirationTime = rememberMe
            ? AuthenticationConstants.AccessTokenRememberMeExpirationTime
            : AuthenticationConstants.AccessTokenExpirationTime;

        var token = authenticationTokenService.GenerateToken(
            claims.Union(new[] { iatClaim }),
            accessTokenExpirationTime);

        // add 5 min because of jwt realization
        accessTokenExpirationTime += TimeSpan.FromMinutes(5);

        if (!rememberMe)
        {
            creationOptions.TokenLifespan = AuthenticationConstants.RefreshTokenExpire;
        }

        var refreshToken = await userManager.GenerateUserTokenAsync(
            user,
            AuthenticationConstants.AppLoginProvider,
            AuthenticationConstants.RefreshTokensName);

        return new TokenModel
        {
            Token = token, ExpiresIn = (int)accessTokenExpirationTime.TotalSeconds, RefreshToken = refreshToken
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
