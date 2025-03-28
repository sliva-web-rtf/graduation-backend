using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Students;
using Graduation.Domain.Users;

namespace Graduation.Infrastructure.Services;

public class StudentUserRoleAssignmentProcessor(IAppDbContext dbContext) : IUserRoleAssignmentProcessor
{
    public Task ProcessAsync(User user)
    {
        var student = Student.Create(user);
        
        dbContext.Students.Add(student);
        
        return dbContext.SaveChangesAsync();
    }
}