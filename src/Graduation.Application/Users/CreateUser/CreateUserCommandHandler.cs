using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Users.CreateUser;

public class CreateUserCommandHandler(UserManager<User> userManager, IAppDbContext appDbContext)
    : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Roles.Any(r => !WellKnownRoles.Roles.Contains(r)))
            throw new DomainException($"{request.Roles.Except(WellKnownRoles.Roles)} - roles not found");

        var user = User.Create(Guid.NewGuid(),
            await GenerateUserName(request),
            null,
            request.FirstName,
            request.LastName,
            request.Patronymic,
            request.Contacts,
            request.About);

        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .ToDictionary(grouping => grouping.Code, grouping => grouping.Description);
            throw new ValidationException(errors);
        }

        return new CreateUserCommandResult(user.Id);
    }

    private async Task<string> GenerateUserName(CreateUserCommand request)
    {
        var fullName = request.LastName.Remove(' ') + request.FirstName.Remove(' ') + request.Patronymic.Remove(' ');
        if (request.Roles.Contains(WellKnownRoles.Student) && request.Roles.Count == 1)
        {
            if (!request.AcademicGroupId.HasValue || await appDbContext.AcademicGroups
                    .FirstOrDefaultAsync(group => group.Id == request.AcademicGroupId) is not { } academicGroup)
                throw new DomainException("Academic group not found");
            fullName += academicGroup.Name.Remove('-');
        }

        return fullName;
    }
}