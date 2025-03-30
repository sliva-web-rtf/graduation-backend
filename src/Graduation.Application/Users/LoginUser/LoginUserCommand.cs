using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Graduation.Application.Users.LoginUser;

public record LoginUserCommand : IRequest<LoginUserCommandResult>
{
    [Required]
    public required string UserName { get; init; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; init; }
}