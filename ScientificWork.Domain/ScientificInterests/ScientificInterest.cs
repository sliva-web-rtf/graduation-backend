using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificInterests;

/// <summary>
/// Scientific interests.
/// </summary>
public class ScientificInterest
{
    public int Id { get; private set; }

    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }

    public ICollection<Professor> Professors { get; set; }

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks { get; set; }
}
