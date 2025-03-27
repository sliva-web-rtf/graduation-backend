namespace Graduation.Infrastructure.Authentication;

/// <summary>
/// Shared constants for authentication.
/// </summary>
public static class AuthenticationConstants
{
    /// <summary>
    /// Issued at date/time claim. https://tools.ietf.org/html/rfc7519#page-10 .
    /// </summary>
    public const string IatClaimType = "iat";

    /// <summary>
    /// Access token when RememberMe clicked expiration time.
    /// </summary>
    public static readonly TimeSpan AccessTokenExpirationTime = TimeSpan.FromDays(30);
}
