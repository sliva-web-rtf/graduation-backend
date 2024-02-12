using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificInterests;
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

    public string FieldOfScience { get; set; }

    public int Limit { get; set; }

    public int Fullness { get; set; }

    public bool Approve { get; set; }

    public int Term { get; set; }

    public DateTime CreateAt { get; set; }

    public int ProfessorId { get; set; }

    public ICollection<Student> Students { get; set; }

    public ICollection<ScientificInterest> ScientificInterests { get; set; }
}
