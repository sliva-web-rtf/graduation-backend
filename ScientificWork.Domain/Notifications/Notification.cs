using ScientificWork.Domain.Common;
using ScientificWork.Domain.Notifications.Enums;
using ScientificWork.Domain.Notifications.ValueObjects;
using ScientificWork.Domain.Users;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ScientificWork.Domain.Notifications;

public sealed class Notification : Entity<Guid>
{
    public NotificationType Type { get; private set; }

    public string Message { get; private set; }

    public Attachment? Attachment { get; private set; }

    public Guid ReceiverId { get; private set; }

    public User? Receiver { get; private set; }

    public DateTime? ReadAt { get; private set; }

    private Notification(string message, NotificationType type, Attachment? attachment, Guid receiverId)
    {
        Message = message;
        Type = type;
        Attachment = attachment;
        ReceiverId = receiverId;
    }

    public static Notification Create(string message, NotificationType type, Attachment? attachment, Guid receiverId)
    {
        switch (type)
        {
            case NotificationType.Info:
                attachment = null;
                break;
            case NotificationType.Request:
                if (attachment is null)
                {
                    throw new ArgumentException("You should provide attachment for Notification with request type", nameof(attachment));
                }
                break;
        }

        return new Notification(message, type, attachment, receiverId);
    }

    public void Read()
    {
        ReadAt = DateTime.UtcNow;
    }

    // for EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    // ReSharper disable once UnusedMember.Local
    private Notification()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
