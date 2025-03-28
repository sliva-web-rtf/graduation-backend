using Graduation.Application.Extensions;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.Users.AddUserToRole;

public class AddUserToRoleCommandHandler(
    UserManager<User> userManager,
    ILogger<AddUserToRoleCommandHandler> logger,
    RoleManager<AppIdentityRole> roleManager,
    IUserRoleAssignmentProcessorProvider roleAssignmentProcessorProvider)
    : IRequestHandler<AddUserToRoleCommand>
{
    public async Task Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
        {
            logger.LogInformation($"User not found. id: {request.UserId}.");
            throw new DomainException("User not found.");
        }

        if (!await roleManager.RoleExistsAsync(request.RoleName))
        {
            var roleCreationResult = await roleManager.CreateAsync(new AppIdentityRole(request.RoleName));
            roleCreationResult.ThrowOnError();
        }

        var result = await userManager.AddToRoleAsync(user, request.RoleName);
        result.ThrowOnError();

        var roleAssignmentProcessor = roleAssignmentProcessorProvider.GetProcessor(request.RoleName);
        if (roleAssignmentProcessor is not null)
            await roleAssignmentProcessor.ProcessAsync(user);
    }
}