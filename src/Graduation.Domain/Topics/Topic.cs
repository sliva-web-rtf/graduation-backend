using Graduation.Domain.AcademicPrograms;
using Graduation.Domain.Common;
using Graduation.Domain.Users;

namespace Graduation.Domain.Topics;

public class Topic : Entity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Result { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
    public string Year { get; set; }
    
    public List<AcademicProgram> AcademicPrograms { get; set; } = [];
}