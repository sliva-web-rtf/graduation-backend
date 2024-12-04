using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.UpdateProfileInfo;

public class UpdateProfileInfoCommandHandler : IRequestHandler<UpdateProfileInfoCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<User> userManager;

    public UpdateProfileInfoCommandHandler(ILoggedUserAccessor userAccessor, UserManager<User> userManager)
    {
        this.userAccessor = userAccessor;
        this.userManager = userManager;
    }

    public async Task Handle(UpdateProfileInfoCommand request,
        CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        await userManager.SetUserNameAsync(user, request.Email);
        await userManager.SetEmailAsync(user, request.Email);
        await userManager.UpdateAsync(user);

        user.UpdateProfileInformation(
            firstName: request.FirstName,
            lastName: request.LastName,
            patronymic: request.Patronymic,
            phoneNumber: request.Phone,
            contacts: request.ContactsTg);

        await userManager.UpdateAsync(user);
    }
}
