using ScientificWork.Domain.Notifications.Enums;

namespace ScientificWork.UseCases.Notifications.GetNotifications;

public record GetNotifiactaionsCommandResult(List<NotificationCommandResult> Notifications);

public record NotificationCommandResult(
    Guid NotificationId,
    string Text,
    NotificationType Type,
    DateTime? ReadAt,
    string? AgreeLink,
    string? DisagreeLink);
