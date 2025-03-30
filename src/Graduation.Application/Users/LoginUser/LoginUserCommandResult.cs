namespace Graduation.Application.Users.LoginUser;

public class LoginUserCommandResult
{
    public Guid UserId { get; set; }

    public required string Token { get; set; }
}