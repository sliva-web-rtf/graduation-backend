using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Graduation.Application.Users.LoginUser;

/// <summary>
/// Login user command.
/// </summary>
public record LoginUserCommand : IRequest<LoginUserCommandResult>
{
    /// <summary>
    /// Email.
    /// </summary>
    [Required]
    public required string UserName { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}
