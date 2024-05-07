namespace ScientificWork.UseCases.Common.Settings.Authentication;

/// <summary>
/// Shared constants for authentication.
/// </summary>
public static class AuthenticationConstants
{
    /// <summary>
    /// Name of login provider used to keep refresh token for ASP.NET Identity.
    /// </summary>
    public const string AppLoginProvider = "RefreshTokenProvider";

    /// <summary>
    /// Refresh token purpose name for ASP.NET Identity.
    /// </summary>
    public const string RefreshTokensName = "RefreshToken";

    /// <summary>
    /// Issued at date/time claim. https://tools.ietf.org/html/rfc7519#page-10 .
    /// </summary>
    public const string IatClaimType = "iat";

    /// <summary>
    /// Issued at date/time claim. https://tools.ietf.org/html/rfc7519#page-10 .
    /// </summary>
    public const string RegistrationCompleteClaimType = "registrationComplete";

    /// <summary>
    /// Refresh token when RememberMe clicked expiration time.
    /// </summary>
    public static readonly TimeSpan RefreshTokenExpire = TimeSpan.FromDays(30);

    /// <summary>
    /// Access token when RememberMe clicked expiration time.
    /// </summary>
    public static readonly TimeSpan AccessTokenExpirationTime = TimeSpan.FromDays(1);
}
