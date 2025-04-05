using Graduation.Domain.Common;

namespace Graduation.Domain.Years;

public class Year : Entity
{
    public Year(string year)
    {
        YearName = year;
    }

#pragma warning disable CS8618, CS9264
    private Year()
#pragma warning restore CS8618, CS9264
    {
    }

    public string YearName { get; set; }

    public bool IsCurrent { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return YearName;
    }
}