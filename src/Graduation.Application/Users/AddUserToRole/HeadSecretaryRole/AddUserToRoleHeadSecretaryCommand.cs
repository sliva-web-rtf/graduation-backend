using MediatR;

namespace Graduation.Application.Users.AddUserToRole.HeadSecretaryRole;

public record AddUserToRoleHeadSecretaryCommand(Guid UserId) : IRequest;