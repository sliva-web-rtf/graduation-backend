using Graduation.Domain.Common;

namespace Graduation.Domain.Topics;

public class TopicRequestedRole : Entity
{
    public Guid TopicId { get; set; }
    public Guid RoleId { get; set; }
    public int Limit { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return TopicId;
        yield return RoleId;
    }
}