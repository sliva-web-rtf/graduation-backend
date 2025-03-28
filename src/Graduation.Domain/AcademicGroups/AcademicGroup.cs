using Graduation.Domain.Common;

namespace Graduation.Domain.AcademicGroups;

public class AcademicGroup : Entity<Guid>
{
    public string Name { get; set; }
    public Guid? AcademicProgramId { get; set; }
    public Guid? CommissionId { get; set; }
    public string Year { get; set; }

    public AcademicGroup(Guid id) : base(id)
    {
    }
}