using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Commissions;
using Graduation.Domain.Common;

namespace Graduation.Domain.AcademicGroups;

public class AcademicGroup : Entity<Guid>
{
    public string Name { get; set; }
    public Guid? AcademicProgramId { get; set; }
    public AcademicProgram? AcademicProgram { get; set; }
    public Guid? CommissionId { get; set; }
    public Commission? Commission { get; set; }
    public string Year { get; set; }
}