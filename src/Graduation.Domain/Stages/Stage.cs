using Graduation.Domain.Common;

namespace Graduation.Domain.Stages;

public class Stage : Entity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public StageType Type { get; set; }
    public DateOnly Begin { get; set; }
    public DateOnly End { get; set; }
    public string Year { get; set; }
}