using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.DTOs;

namespace ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;

public interface ITokenModelService
{
    Task<TokenModel> Generate(User user);

    Task<bool> ValidateRefreshToken(User user, string token);
}
