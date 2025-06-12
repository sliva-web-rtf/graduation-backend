using Graduation.Application.Extensions;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Students;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.Users.AddUserToRole.StudentRole;

public class AddUserToRoleStudentCommandHandler(
    UserManager<User> userManager,
    ILogger<AddUserToRoleStudentCommandHandler> logger,
    RoleManager<AppIdentityRole> roleManager,
    IAppDbContext appDbContext)
    : IRequestHandler<AddUserToRoleStudentCommand>
{
    private const string RoleName = WellKnownRoles.Student;

    public async Task Handle(AddUserToRoleStudentCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
        {
            logger.LogInformation($"User not found. id: {request.UserId}.");
            throw new DomainException("User not found.");
        }

        if (!await roleManager.RoleExistsAsync(RoleName))
        {
            var roleCreationResult = await roleManager.CreateAsync(new AppIdentityRole(RoleName));
            roleCreationResult.ThrowOnError();
        }

        var result = await userManager.AddToRoleAsync(user, RoleName);
        result.ThrowOnError();

        var student = Student.Create(user);

        appDbContext.Students.Add(student);

        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}