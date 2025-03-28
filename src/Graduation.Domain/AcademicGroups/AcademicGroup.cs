using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Commissions;
using Graduation.Domain.Common;
using Graduation.Domain.Users;

namespace Graduation.Domain.AcademicGroups;

public class AcademicGroup : Entity<Guid>
{
    public string Name { get; set; }
    public Guid? AcademicProgramId { get; set; }
    public AcademicProgram? AcademicProgram { get; set; }
    public Guid? CommissionId { get; set; }
    public Commission? Commission { get; set; }
    public Guid? FormattingReviewerId { get; set; }
    public User? FormattingReviewer { get; set; }
    public string Year { get; set; }

    public AcademicGroup(Guid id) : base(id)
    {
    }
}