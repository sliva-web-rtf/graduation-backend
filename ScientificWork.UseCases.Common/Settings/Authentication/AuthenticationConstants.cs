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
    /// Refresh token expiration time.
    /// </summary>
    public static readonly TimeSpan RefreshTokenRememberMeExpire = TimeSpan.FromMinutes(2);

    /// <summary>
    /// Refresh token when RememberMe clicked expiration time.
    /// </summary>
    public static readonly TimeSpan RefreshTokenExpire = TimeSpan.FromSeconds(90);

    /// <summary>
    /// Access token expiration time.
    /// </summary>
    public static readonly TimeSpan AccessTokenRememberMeExpirationTime = -TimeSpan.FromMinutes(4);

    /// <summary>
    /// Access token when RememberMe clicked expiration time.
    /// </summary>
    public static readonly TimeSpan AccessTokenExpirationTime = -TimeSpan.FromSeconds(270);
}
