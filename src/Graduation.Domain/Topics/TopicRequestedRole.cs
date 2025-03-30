using Graduation.Domain.Common;
using Graduation.Domain.QualificationWorkRoles;

namespace Graduation.Domain.Topics;

public class TopicRequestedRole : Entity
{
    public Guid TopicId { get; set; }
    public Guid RoleId { get; set; }
    public int Limit { get; set; }
    
    public Topic? Topic { get; set; } 
    public QualificationWorkRole? Role { get; set; } 
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return TopicId;
        yield return RoleId;
    }
}