using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Settings.WebRoot;

namespace ScientificWork.UseCases.Users.AddAvatarImage;

public class AddAvatarImageCommandHandler : IRequestHandler<AddAvatarImageCommand>
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<User> userManager;

    public AddAvatarImageCommandHandler(IHostingEnvironment hostingEnvironment, ILoggedUserAccessor userAccessor,
        UserManager<User> userManager)
    {
        _hostingEnvironment = hostingEnvironment;
        this.userAccessor = userAccessor;
        this.userManager = userManager;
    }

    public async Task Handle(AddAvatarImageCommand request, CancellationToken cancellationToken)
    {
        if (request.FileName.Split(".").Length < 2)
        {
            throw new DomainException("Неправильный формат картинки.");
        }

        var extension = request.FileName.Split(".").Last();
        var allowedFormats =
            new List<(string ContentType, string Extension)> { ("image/jpeg", "jpg"), ("image/png", "png"), ("image/jpeg", "jpeg") };
        if (!allowedFormats.Any(f => f.Extension == extension && f.ContentType == request.ContentType))
        {
            throw new DomainException("Неправильный формат картинки.");
        }

        // 3mb
        if (request.Data.Length > 3_000_000)
        {
            throw new DomainException("Размер картинки слишком велик.");
        }

        var userId = userAccessor.GetCurrentUserId();
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        var webRootDirectory = _hostingEnvironment.WebRootPath.TrimEnd('/');
        var path = $"{WebRootConstants.AvatarsDirectory}/{Guid.NewGuid()}.{extension}";
        var filePath = webRootDirectory + path;

        await using var fileStream = File.Create(filePath);
        request.Data.Seek(0, SeekOrigin.Begin);
        await request.Data.CopyToAsync(fileStream, cancellationToken);

        user.SetAvatarImagePath(path);
        await userManager.UpdateAsync(user);
    }
}
