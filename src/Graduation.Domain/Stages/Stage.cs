using Graduation.Domain.Common;

namespace Graduation.Domain.Stages;

public class Stage : Entity<Guid>
{
    public string Name { get; set; }
    public DateTime Begins { get; set; }
    public DateTime Ends { get; set; }
    public string Year { get; set; }
}