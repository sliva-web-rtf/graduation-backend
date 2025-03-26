using Graduation.Domain.Common;

namespace Graduation.Domain.Requests;

public class TopicChangeRequest : Entity<Guid>
{
    public Guid QualificationWorkId { get; set; }
    public string OldTopic { get; set; }
    public string NewTopic { get; set; }
    public string? Message { get; set; }
    public TopicChangeRequestStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}