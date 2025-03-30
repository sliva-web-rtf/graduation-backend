using Graduation.Domain.Common;

namespace Graduation.Domain.AcademicPrograms;

public class AcademicProgram : Entity<Guid>
{
    public string Name { get; set; }
    public string Year { get; set; }
}