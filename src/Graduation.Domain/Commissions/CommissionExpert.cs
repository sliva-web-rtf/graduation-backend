using Graduation.Domain.Common;

namespace Graduation.Domain.Commissions;

public class CommissionExpert : Entity
{
    public Guid UserId { get; set; }
    public Guid CommissionId { get; set; }
    public Guid StageId { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return CommissionId;
        yield return StageId;
    }
}