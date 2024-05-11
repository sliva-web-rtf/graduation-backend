using MediatR;

namespace ScientificWork.UseCases.Notifications.GetNotifications;

public record GetNotificationsCommand : IRequest<GetNotifiactaionsCommandResult>;
