namespace Graduation.Application.Interfaces.Services;

public interface IUserRoleAssignmentProcessorProvider
{
    public IUserRoleAssignmentProcessor? GetProcessor(string role);
}