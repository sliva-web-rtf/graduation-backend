using Graduation.Application.Extensions;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.Users.AddUserToRole.HeadSecretaryRole;

public class AddUserToRoleHeadSecretaryCommandHandler(
    UserManager<User> userManager,
    ILogger<AddUserToRoleHeadSecretaryCommandHandler> logger,
    RoleManager<AppIdentityRole> roleManager)
    : IRequestHandler<AddUserToRoleHeadSecretaryCommand>
{
    private const string RoleName = WellKnownRoles.HeadSecretary;

    public async Task Handle(AddUserToRoleHeadSecretaryCommand request, CancellationToken cancellationToken)
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