using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificInterests;

/// <summary>
/// Scientific interests.
/// </summary>
public class ScientificInterest : Entity<Guid>
{
    public string Name { get; private set; }

    private readonly List<Student> students = new();

    public IReadOnlyList<Student> Students => students.AsReadOnly();

    private readonly List<Professor> professors = new();

    public IReadOnlyList<Professor> Professors => professors.AsReadOnly();

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();
}
