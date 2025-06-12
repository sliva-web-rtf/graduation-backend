using MediatR;

namespace Graduation.Application.Users.AddUserToRole.ExpertRole;

public record AddUserToRoleExpertCommand(Guid UserId) : IRequest;