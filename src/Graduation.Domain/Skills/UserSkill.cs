using Graduation.Domain.Common;

namespace Graduation.Domain.Skills;

public class UserSkill : Entity
{
    public Guid UserId { get; set; }
    public Guid SkillId { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return SkillId;
    }
}