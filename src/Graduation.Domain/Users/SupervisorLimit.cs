using Graduation.Domain.Common;

namespace Graduation.Domain.Users;

public class SupervisorLimit : Entity
{
    public Guid UserId { get; set; }
    public string Year { get; set; }
    public int Limit { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return Year;
    }
}