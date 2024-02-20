using ScientificWork.Domain.Common;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Notifications;

public class Notification : Entity<Guid>
{
    public string Message { get; set; }

    public DateTime DateTime { get; set; }

    public Guid ReceiverId { get; set; }

    public User Receiver { get; set; }
}
