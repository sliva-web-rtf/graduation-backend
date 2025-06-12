using Graduation.Application.Interfaces.Services;
using Graduation.Domain;

namespace Graduation.Infrastructure.Services;

public class UserRoleAssignmentProcessorProvider(
    StudentUserRoleAssignmentProcessor studentUserRoleAssignmentProcessor,
    SupervisorUserRoleAssignmentProcessor supervisorUserRoleAssignmentProcessor)
    : IUserRoleAssignmentProcessorProvider
{
    public IUserRoleAssignmentProcessor? GetProcessor(string role)
    {
        return role switch
        {
            WellKnownRoles.Student => studentUserRoleAssignmentProcessor,
            WellKnownRoles.Supervisor => supervisorUserRoleAssignmentProcessor,
            _ => null
        };
    }
}