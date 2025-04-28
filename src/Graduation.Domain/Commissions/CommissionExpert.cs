using Graduation.Domain.Common;
using Graduation.Domain.Users;

namespace Graduation.Domain.Commissions;

public class CommissionExpert : Entity
{
    public Guid UserId { get; set; }
    public User? Expert { get; set; }
    public Guid CommissionId { get; set; }
    public Guid StageId { get; set; }
    public bool IsInvited { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return CommissionId;
        yield return StageId;
    }
}