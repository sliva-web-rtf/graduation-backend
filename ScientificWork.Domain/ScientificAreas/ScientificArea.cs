using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificAreas;

/// <summary>
/// Scientific area.
/// </summary>
public class ScientificArea : Entity<Guid>
{
    public string Name { get; private set; }

    private readonly List<Student> students = new();

    public IReadOnlyList<Student> Students => students.AsReadOnly();

    private readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections.AsReadOnly();

    private readonly List<Professor> professors = new();

    public IReadOnlyList<Professor> Professors => professors.AsReadOnly();

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();
}
