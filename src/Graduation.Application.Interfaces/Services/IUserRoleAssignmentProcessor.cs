using Graduation.Domain.Users;

namespace Graduation.Application.Interfaces.Services;

public interface IUserRoleAssignmentProcessor
{
    Task ProcessAsync(User user);
}