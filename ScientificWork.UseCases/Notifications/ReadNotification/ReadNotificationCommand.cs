using MediatR;

namespace ScientificWork.UseCases.Notifications.ReadNotification;

public record ReadNotificationCommand(Guid NotificationId) : IRequest;
