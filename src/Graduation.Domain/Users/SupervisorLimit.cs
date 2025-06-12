using Graduation.Domain.Common;

namespace Graduation.Domain.Users;

public class SupervisorLimit : Entity
{
    public SupervisorLimit(User user)
    {
    }

    public SupervisorLimit()
    {
    }

    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string Year { get; set; }
    public int Limit { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return Year;
    }

    public static SupervisorLimit Create(User user, string year, int limit)
    {
        var supervisorLimit = new SupervisorLimit(user)
        {
            Year = year,
            Limit = limit
        };
        return supervisorLimit;
    }
}