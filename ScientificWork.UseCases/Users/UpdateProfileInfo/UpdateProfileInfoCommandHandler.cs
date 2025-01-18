using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;
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

        if (user.Email != request.Email)
        {
            // когда реально будем отправлять код юзеру, нужно сначала проверить, что юзера с таким имейлом нет
            var token = await userManager.GenerateChangeEmailTokenAsync(user, request.Email);
            ValidateResult(await userManager.ChangeEmailAsync(user, request.Email, token));
            ValidateResult(await userManager.SetUserNameAsync(user, request.Email));
        }

        user.UpdateProfileInformation(
            firstName: request.FirstName,
            lastName: request.LastName,
            patronymic: request.Patronymic,
            phoneNumber: request.Phone,
            contacts: request.ContactsTg);

        await userManager.UpdateAsync(user);
    }

    private void ValidateResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = result.Errors
                .ToDictionary(grouping => grouping.Code, grouping => grouping.Description);
            throw new ValidationException(errors);
        }
    }
}