using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Settings.WebRoot;

namespace ScientificWork.UseCases.Users.GetAvatarImage;

public class GetAvatarImageRequestHandler : IRequestHandler<GetAvatarImageCommand, GetAvatarImageCommandResult>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<User> userManager;

    public GetAvatarImageRequestHandler(ILoggedUserAccessor userAccessor, UserManager<User> userManager)
    {
        this.userAccessor = userAccessor;
        this.userManager = userManager;
    }

    public async Task<GetAvatarImageCommandResult> Handle(GetAvatarImageCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        return new GetAvatarImageCommandResult(user.AvatarImagePath ?? WebRootConstants.DefaultAvatarPath);
    }
}
