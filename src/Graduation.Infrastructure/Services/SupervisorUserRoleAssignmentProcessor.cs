using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Students;
using Graduation.Domain.Users;

namespace Graduation.Infrastructure.Services;

public class SupervisorUserRoleAssignmentProcessor(IAppDbContext dbContext) : IUserRoleAssignmentProcessor
{
    public async Task ProcessAsync(User user)
    {
        // var supervisorLimit = SupervisorLimit.Create(user,) var student = Student.Create(user);
        //
        // dbContext.Students.Add(student);
        //
        // return dbContext.SaveChangesAsync();
    }
}