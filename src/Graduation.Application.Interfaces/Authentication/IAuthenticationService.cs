using Graduation.Domain.Users;

namespace Graduation.Application.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<string> GenerateAuthenticationToken(User user);
}