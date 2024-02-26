using ScientificWork.Domain.Common;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificWorks;

/// <summary>
/// Scientific work.
/// </summary>
public class ScientificWork : Entity<Guid>
{
    public string Name { get; private set; }

    public string Titile { get; private set; }

    public int Limit { get; private set; }

    public string Problem { get; private set; }

    public string Relevance { get; private set; }

    public int Fullness { get; private set; }

    public WorkStatus WorkStatus { get; private set; }

    public DateTime CreateAt { get; private set; }

    public Guid? ProfessorId { get; private set; }

    public Guid ImageId { get; private set; }

    private readonly List<Student> students = new();

    public ICollection<Student> Students => students;

    private readonly List<ScientificInterest> scientificInterests = new();

    public ICollection<ScientificInterest> ScientificInterests => scientificInterests;

    private readonly List<ScientificArea> scientificAreas = new();

    public ICollection<ScientificArea> ScientificAreas => scientificAreas;

    private readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public ICollection<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections;
}
