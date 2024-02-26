using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificAreas;

public class ScientificAreaSubsection : Entity<Guid>
{
    public Guid ScientificAreaId { get;  set; }

    public ScientificArea ScientificArea { get;  set; }

    public string Name { get; set; }

    private readonly List<Student> students = new();

    public ICollection<Student> Students => students;

    private readonly List<Professor> professors = new();

    public ICollection<Professor> Professors => professors;

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks;
}
