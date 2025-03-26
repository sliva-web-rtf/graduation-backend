using Graduation.Domain.Common;

namespace Graduation.Domain.Years;

public class Year : Entity
{
    public string YearName { get; set; }

    public bool IsCurrent { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return YearName;
    }
}