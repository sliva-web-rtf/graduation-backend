using MediatR;
using ScientificWork.Domain.Notifications.Enums;

namespace ScientificWork.UseCases.Notifications.SendNotification;

public record SendNotificationCommand(
    Guid ReceiverId,
    string Text,
    NotificationType Type,
    string? AgreeLink = null,
    string? DisagreeLink = null) : IRequest;
