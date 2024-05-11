using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Notifications.ReadNotification;

public class ReadNotificationCommandHandler : IRequestHandler<ReadNotificationCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly IAppDbContext dbContext;

    public ReadNotificationCommandHandler(IAppDbContext dbContext, ILoggedUserAccessor userAccessor)
    {
        this.dbContext = dbContext;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(ReadNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = await dbContext.Notifications
            .FirstOrDefaultAsync(f => f.Id == request.NotificationId, cancellationToken: cancellationToken);
        var userId = userAccessor.GetCurrentUserId();

        if (notification is null || notification.ReceiverId != userId)
        {
            throw new NotFoundException($"Уведомления с ID: {request.NotificationId} не найдено.");
        }

        notification.Read();

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
