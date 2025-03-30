using Graduation.Domain.Common;

namespace Graduation.Domain.AcademicPrograms;

public class TopicAcademicProgram : Entity
{
    public Guid TopicId { get; set; }
    public Guid AcademicProgramId { get; set; }
    
    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return TopicId;
        yield return AcademicProgramId;
    }
}