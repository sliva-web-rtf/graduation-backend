using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Notifications.GetNotifications;

public class GetNotificationsCommandHandler : IRequestHandler<GetNotificationsCommand, GetNotifiactaionsCommandResult>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly IAppDbContext dbContext;

    public GetNotificationsCommandHandler(ILoggedUserAccessor userAccessor, IAppDbContext dbContext)
    {
        this.userAccessor = userAccessor;
        this.dbContext = dbContext;
    }

    public async Task<GetNotifiactaionsCommandResult> Handle(
        GetNotificationsCommand request,
        CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var notifications = await dbContext.Notifications
            .Where(n => n.ReceiverId == userId)
            .Include(n => n.Attachment)
            .ToListAsync(cancellationToken: cancellationToken);

        var notificationResults = notifications
            .Select(n => new NotificationCommandResult(
                    n.Id,
                    n.Message,
                    n.Type,
                    n.ReadAt,
                    n.Attachment?.AgreeLink,
                    n.Attachment?.DisagreeLink))
            .ToList();

        return new GetNotifiactaionsCommandResult(notificationResults);
    }
}
