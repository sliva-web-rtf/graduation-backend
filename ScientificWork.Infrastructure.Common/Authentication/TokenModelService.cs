using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.DTOs;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;
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
    public async Task<TokenModel> Generate(User user, bool rememberMe, TimeSpan? tokenLifetime = null)
    {
        var accessTokenExpirationTime = tokenLifetime ?? (rememberMe
            ? AuthenticationConstants.AccessTokenRememberMeExpirationTime
            : AuthenticationConstants.AccessTokenExpirationTime);
        var token = await GetAuthenticationToken(user, accessTokenExpirationTime);

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

        var refreshTokenWithUserId = $"{user.Id}|{refreshToken}";
        return new TokenModel
        {
            Token = token, ExpiresIn = (int)accessTokenExpirationTime.TotalSeconds, RefreshToken = refreshTokenWithUserId
        };
    }

    private async Task<string> GetAuthenticationToken(User user, TimeSpan accessTokenExpirationTime)
    {
        var claims = await GetUserClaims(user);
        var token = authenticationTokenService.GenerateToken(claims, accessTokenExpirationTime);

        return token;
    }

    private async Task<IEnumerable<Claim>> GetUserClaims(User user)
    {
        var principal = await signInManager.CreateUserPrincipalAsync(user);
        var claims = principal.Claims.ToList();
        var epoch = (long)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
        var iatClaim = new Claim(
            AuthenticationConstants.IatClaimType,
            epoch.ToString(),
            ClaimValueTypes.Integer64);


        var registrationCompleteClaimTypeClaim = new Claim(
            AuthenticationConstants.RegistrationCompleteClaimType,
            user.IsRegistrationComplete.ToString(),
            ClaimValueTypes.Boolean);
        claims.Add(registrationCompleteClaimTypeClaim);
        claims.Add(iatClaim);

        return claims;
    }

    /// <inheritdoc />
    public Task<bool> ValidateRefreshToken(User user, string token)
    {
        var tokenWithoutUserId = token.Split("|").Last();
        return userManager.VerifyUserTokenAsync(
            user,
            AuthenticationConstants.AppLoginProvider,
            AuthenticationConstants.RefreshTokensName,
            tokenWithoutUserId);
    }
}
