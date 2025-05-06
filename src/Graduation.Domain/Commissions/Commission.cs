using Graduation.Domain.AcademicGroups;
using Graduation.Domain.Common;
using Graduation.Domain.Users;

namespace Graduation.Domain.Commissions;

public class Commission : Entity<Guid>
{
    public Commission(Guid id) : base(id)
    {
    }

    private Commission()
    {
    }

    public string Name { get; set; }
    public Guid SecretaryId { get; set; }
    public User? Secretary { get; set; }
    public Guid? ChairpersonId { get; set; }
    public User? Chairperson { get; set; }
    public string Year { get; set; }

    public List<AcademicGroup> AcademicGroups { get; set; } = [];
    public List<CommissionStudent> CommissionStudents { get; set; } = [];
    public List<CommissionExpert> CommissionExperts { get; set; } = [];
}