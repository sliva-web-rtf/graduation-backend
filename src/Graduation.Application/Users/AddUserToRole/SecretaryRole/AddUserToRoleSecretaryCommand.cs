using MediatR;

namespace Graduation.Application.Users.AddUserToRole.SecretaryRole;

public record AddUserToRoleSecretaryCommand(Guid UserId) : IRequest;