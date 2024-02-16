using ScientificWork.Domain.Common;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Notifications;

public class Notification : Entity<Guid>
{
    public int Id { get; private set; }

    public string Message { get; set; }

    public DateTime DateTime { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }
}
