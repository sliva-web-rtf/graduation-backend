using Graduation.Domain.Common;

namespace Graduation.Domain.ScientificInterest;

public class ScientificInterest : Entity<Guid>
{
    public string Name { get; set; }
    public string? Code { get; set; }
}