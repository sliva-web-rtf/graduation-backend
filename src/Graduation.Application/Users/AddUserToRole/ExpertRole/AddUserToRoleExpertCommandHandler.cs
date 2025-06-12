using Graduation.Application.Extensions;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.Users.AddUserToRole.ExpertRole;

public class AddUserToRoleExpertCommandHandler(
    UserManager<User> userManager,
    ILogger<AddUserToRoleExpertCommandHandler> logger,
    RoleManager<AppIdentityRole> roleManager)
    : IRequestHandler<AddUserToRoleExpertCommand>
{
    private const string RoleName = WellKnownRoles.Expert;

    public async Task Handle(AddUserToRoleExpertCommand request, CancellationToken cancellationToken)
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
    }
}