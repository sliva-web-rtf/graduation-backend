using Graduation.Domain.Common;

namespace Graduation.Domain.QualificationWorkRoles;

public class QualificationWorkRole : Entity<Guid>
{
    public string Role { get; set; }
    public string Year { get; set; }
}