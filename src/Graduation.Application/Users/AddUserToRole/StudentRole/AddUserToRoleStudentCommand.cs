using MediatR;

namespace Graduation.Application.Users.AddUserToRole.StudentRole;

public record AddUserToRoleStudentCommand(Guid UserId) : IRequest;