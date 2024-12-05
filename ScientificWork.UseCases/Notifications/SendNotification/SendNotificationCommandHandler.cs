using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;
using ScientificWork.Domain.Notifications;
using ScientificWork.Domain.Notifications.Enums;
using ScientificWork.Domain.Notifications.ValueObjects;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Notifications.SendNotification;

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<User> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    public SendNotificationCommandHandler(UserManager<User> userManager, ILoggedUserAccessor userAccessor, IAppDbContext dbContext)
    {
        this.userManager = userManager;
        this.userAccessor = userAccessor;
        this.dbContext = dbContext;
    }

    public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        Attachment? attachment = null;
        if (request.Type == NotificationType.Request)
        {
            attachment = Attachment.Create(request.AgreeLink!, request.DisagreeLink!);
        }

        var notification = Notification.Create(request.Text, request.Type, attachment, request.ReceiverId);
        dbContext.Notifications.Add(notification);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
