using Graduation.Domain.Common;

namespace Graduation.Domain.Topics;

public class UserRoleTopic : Entity
{
    public Guid QualificationWorkRoleId { get; set; }
    public Guid TopicId { get; set; }
    public Guid UserId { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return QualificationWorkRoleId;
        yield return TopicId;
        yield return UserId;
    }
}