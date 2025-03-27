namespace Graduation.Application.Users.LoginUser;

/// <summary>
/// Represents user login attempt to system.
/// </summary>
public class LoginUserCommandResult
{
    /// <summary>
    /// Logged user id (if success).
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// New refresh token.
    /// </summary>
    public required string Token { get; set; }
}
