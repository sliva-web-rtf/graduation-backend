using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Application.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly UserManager<User> userManager;

    public CreateUserCommandHandler(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(Guid.NewGuid(),
            request.Email,
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
}