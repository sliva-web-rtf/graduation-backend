using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Settings.WebRoot;

namespace ScientificWork.UseCases.Users.RemoveAvatarImage;

public class RemoveAvatarImageCommandHandler : IRequestHandler<RemoveAvatarImageCommand>
{
    private readonly IHostingEnvironment hostingEnvironment;
    private readonly UserManager<User> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    public RemoveAvatarImageCommandHandler(
        UserManager<User> userManager,
        ILoggedUserAccessor userAccessor,
        IHostingEnvironment hostingEnvironment)
    {
        this.userManager = userManager;
        this.userAccessor = userAccessor;
        this.hostingEnvironment = hostingEnvironment;
    }

    public async Task Handle(RemoveAvatarImageCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        if (user.AvatarImagePath is null || user.AvatarImagePath == WebRootConstants.DefaultAvatarPath)
        {
            return;
        }

        var webRootDirectory = hostingEnvironment.WebRootPath.TrimEnd('/');
        var filePath = webRootDirectory + user.AvatarImagePath;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        user.SetAvatarImagePath(WebRootConstants.DefaultAvatarPath);
        await userManager.UpdateAsync(user);
    }
}
