using Graduation.Domain.Common;

namespace Graduation.Domain.Skills;

public class Skill : Entity<Guid>
{
    public string Name { get; set; }
}