using Graduation.Domain.Common;
using Graduation.Domain.Students;

namespace Graduation.Domain.Commissions;

public class CommissionStudent : Entity
{
    public Guid UserId { get; set; }
    public Student? Student { get; set; }
    public Guid CommissionId { get; set; }
    public Commission? Commission { get; set; }
    public Guid StageId { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return CommissionId;
        yield return StageId;
    }
}