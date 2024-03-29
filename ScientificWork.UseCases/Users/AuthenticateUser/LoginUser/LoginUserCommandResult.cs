using ScientificWork.Infrastructure.Abstractions.DTOs;

namespace ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;

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
    required public TokenModel TokenModel { get; set; }
}
