using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.Domain.Students;

namespace ScientificWork.Domain.ScientificWorks;

/// <summary>
/// Scientific work.
/// </summary>
public class ScientificWork
{
    public int Id { get; private set; }

    public string Name { get; set; }

    public string Titile { get; set; }

    public int Limit { get; set; }

    public string Problem { get; set; }

    public string Relevance { get; set; }

    public int Fullness { get; set; }

    public WorkStatus WorkStatus { get; set; }

    public DateTime CreateAt { get; set; }

    public int? ProfessorId { get; set; }

    public int ImageId { get; set; }

    public ICollection<Student> Students { get; set; }

    public ICollection<ScientificInterest> ScientificInterests { get; set; }

    public ICollection<ScientificArea> ScientificAreas { get; set; }
}
