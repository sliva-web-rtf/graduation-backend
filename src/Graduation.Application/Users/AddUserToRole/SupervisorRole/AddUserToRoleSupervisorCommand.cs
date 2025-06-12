using MediatR;

namespace Graduation.Application.Users.AddUserToRole.SupervisorRole;

public record AddUserToRoleSupervisorCommand(Guid UserId, string Year, int Limits) : IRequest;