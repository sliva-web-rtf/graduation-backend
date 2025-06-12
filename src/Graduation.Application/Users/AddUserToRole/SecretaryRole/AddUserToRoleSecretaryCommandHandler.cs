using Graduation.Application.Extensions;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Graduation.Application.Users.AddUserToRole.SecretaryRole;

public class AddUserToRoleSecretaryCommandHandler(
    UserManager<User> userManager,
    ILogger<AddUserToRoleSecretaryCommandHandler> logger,
    RoleManager<AppIdentityRole> roleManager)
    : IRequestHandler<AddUserToRoleSecretaryCommand>
{
    private const string RoleName = WellKnownRoles.Secretary;

    public async Task Handle(AddUserToRoleSecretaryCommand request, CancellationToken cancellationToken)
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