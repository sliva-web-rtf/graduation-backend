using MediatR;

namespace Graduation.Application.Users.AddUserToRole.AdminRole;

public record AddUserToRoleAdminCommand(Guid UserId) : IRequest;