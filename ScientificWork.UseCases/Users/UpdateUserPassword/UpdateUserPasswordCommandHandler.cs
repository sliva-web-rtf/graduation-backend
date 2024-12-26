using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<User> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateUserPasswordCommandHandler(IAppDbContext dbContext, UserManager<User> userManager,
        ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.userAccessor = userAccessor;
    }

    /// <inheritdoc />
    public async Task Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId,
            cancellationToken: cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        if (string.IsNullOrWhiteSpace(request.CurrentPassword) || string.IsNullOrWhiteSpace(request.NewPassword))
        {
            throw new DomainException("Password and new password are required.");
        }

        var task = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!task.Succeeded)
        {
            var message = task.Errors.FirstOrDefault()?.Description ?? "Current password or new password not valid.";
            throw new DomainException(message);
        }

        user.UpdateLastPasswordChange();
        await userManager.UpdateAsync(user);
    }
}
