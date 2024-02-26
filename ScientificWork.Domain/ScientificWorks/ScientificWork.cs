using ScientificWork.Domain.Common;
using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Professors;
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

    public Guid ProfessorId { get; private set; }

    public Professor Professor { get; private set; }

    public Guid ImageId { get; private set; }

    private readonly List<Student> students = new();

    public IReadOnlyList<Student> Students => students.AsReadOnly();

    private readonly List<ScientificInterest> scientificInterests = new();

    public IReadOnlyList<ScientificInterest> ScientificInterests => scientificInterests.AsReadOnly();

    private readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public ICollection<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections;

    private ScientificWork(
        Guid id,
        Guid professorId)
        : base(id)
    {
        Name = "a";
        Titile = Name;
        Problem = Name;
        Relevance = Name;
        ProfessorId = professorId;
    }

    public static ScientificWork Create(Guid professorId)
    {
        return new ScientificWork(Guid.NewGuid(), professorId);
    }
}
