using Graduation.Domain.Common;
using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.Users;

namespace Graduation.Domain.Topics;

public class UserRoleTopic : Entity
{
    public Guid? QualificationWorkRoleId { get; set; }
    public Guid TopicId { get; set; }
    public Guid UserId { get; set; }
    
    public QualificationWorkRole? QualificationWorkRole { get; set; }
    public User? User { get; set; }
    public Topic? Topic { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return QualificationWorkRoleId;
        yield return TopicId;
        yield return UserId;
    }
}