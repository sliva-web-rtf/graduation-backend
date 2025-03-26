using Graduation.Domain.Common;

namespace Graduation.Domain.ScientificInterest;

public class UserScientificInterest : Entity
{
    public Guid UserId { get; set; }
    public Guid ScientificInterestId { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return ScientificInterestId;
    }
}