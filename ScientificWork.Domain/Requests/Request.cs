using ScientificWork.Domain.Common;

namespace ScientificWork.Domain.Requests;

public class Request : Entity<Guid>
{
    public DateTime AddedAt { get; protected set; }

    public bool IsActive { get; protected set; } = true;

    public string Message { get; protected set; }

    public void Respond()
    {
        IsActive = false;
    }
}
