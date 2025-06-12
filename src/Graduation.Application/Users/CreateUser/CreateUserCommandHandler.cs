using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Application.Users.AddUserToRole.AdminRole;
using Graduation.Application.Users.AddUserToRole.ExpertRole;
using Graduation.Application.Users.AddUserToRole.HeadSecretaryRole;
using Graduation.Application.Users.AddUserToRole.SecretaryRole;
using Graduation.Application.Users.AddUserToRole.StudentRole;
using Graduation.Application.Users.AddUserToRole.SupervisorRole;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Users.CreateUser;

public class CreateUserCommandHandler(
    UserManager<User> userManager,
    IAppDbContext appDbContext,
    IEventsCreator eventsCreator,
    ISender sender)
    : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried create user", request with { Password = string.Empty });

        await ValidateRequest(request);
        
        if (request.Roles.Any(r => !WellKnownRoles.Roles.Contains(r)))
            throw new DomainException($"{request.Roles.Except(WellKnownRoles.Roles)} - roles not found");

        var userId = Guid.NewGuid();
        var user = User.Create(userId,
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

        foreach (var role in request.Roles) await AddToRole(role, request, userId);

        return new CreateUserCommandResult(user.Id);
    }

    private async Task ValidateRequest(CreateUserCommand request)
    {
        if ((request.Roles.Contains(WellKnownRoles.Student) &&
             !request.AcademicGroupId.HasValue) ||
            await appDbContext.AcademicGroups
                .FirstOrDefaultAsync(group => group.Id == request.AcademicGroupId) is not { } academicGroup)
            throw new DomainException("Academic group not found");
        if (request.Roles.Contains(WellKnownRoles.Supervisor) && !request.SupervisorLimits.HasValue)
            throw new DomainException("Limits not set");
    }

    private async Task<string> GenerateUserName(CreateUserCommand request)
    {
        var fullName = request.LastName.Replace(" ", "") +
                       request.FirstName.Replace(" ", "") +
                       request.Patronymic.Replace(" ", "");
        if (request.Roles.Contains(WellKnownRoles.Student) && request.Roles.Count == 1)
        {
            if (!request.AcademicGroupId.HasValue || await appDbContext.AcademicGroups
                    .FirstOrDefaultAsync(group => group.Id == request.AcademicGroupId) is not { } academicGroup)
                throw new DomainException("Academic group not found");
            fullName += academicGroup.Name.Replace("-", "");
        }

        return fullName;
    }

    private async Task AddToRole(string role, CreateUserCommand request, Guid userId)
    {
        switch (role)
        {
            case WellKnownRoles.Student:
                await sender.Send(new AddUserToRoleStudentCommand(userId));
                break;
            case WellKnownRoles.Supervisor:
                await sender.Send(new AddUserToRoleSupervisorCommand(userId,
                    request.Year,
                    request.SupervisorLimits!.Value));
                break;
            case WellKnownRoles.Secretary:
                await sender.Send(new AddUserToRoleSecretaryCommand(userId));
                break;
            case WellKnownRoles.HeadSecretary:
                await sender.Send(new AddUserToRoleHeadSecretaryCommand(userId));
                break;
            case WellKnownRoles.Admin:
                await sender.Send(new AddUserToRoleAdminCommand(userId));
                break;
            case WellKnownRoles.Expert:
                await sender.Send(new AddUserToRoleExpertCommand(userId));
                break;
        }
    }
}