using System.Security.Claims;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<User> signInManager;
    private readonly IAuthenticationTokenService authenticationTokenService;

    public AuthenticationService(SignInManager<User> signInManager,
        IAuthenticationTokenService authenticationTokenService)
    {
        this.signInManager = signInManager;
        this.authenticationTokenService = authenticationTokenService;
    }

    public async Task<string> GenerateAuthenticationToken(User user)
    {
        var claims = await GetUserClaims(user);
        return authenticationTokenService.GenerateToken(claims, AuthenticationConstants.AccessTokenExpirationTime);
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
        
        claims.Add(iatClaim);

        return claims;
    }
}