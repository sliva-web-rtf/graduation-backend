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

    public string Description { get; private set; }

    public int Limit { get; private set; }

    public string Result { get; private set; }

    public int Fullness { get; private set; }

    public WorkStatus WorkStatus { get; private set; }

    public DateTime CreateAt { get; private set; }

    public Guid? ProfessorId { get; private set; }

    public Professor? Professor { get; private set; }

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
        Description = Name;
        Result = Name;
        ProfessorId = professorId;
    }

    public static ScientificWork Create(Guid professorId)
    {
        return new ScientificWork(Guid.NewGuid(), professorId);
    }

    public ScientificWork CreateForStudent(string name, string title, string problem, int limit, Student student)
    {
        Name = name;
        Description = title;
        Result = problem;
        Limit = limit;
        CreateAt = DateTime.UtcNow;
        students.Add(student);
        WorkStatus = WorkStatus.NotConfirmed;
        Fullness = 1;
        return this;
    }

    public void AddScientificAreaSubsections(params ScientificAreaSubsection[] subsection)
    {
        scientificAreaSubsections.AddRange(subsection);
    }

    public void UpdateScientificAreaSubsections(params ScientificAreaSubsection[] subsection)
    {
        scientificInterests.Clear();
        AddScientificAreaSubsections(subsection);
    }

    public void AddScientificInterest(params ScientificInterest[] subsection)
    {
        scientificInterests.AddRange(subsection);
    }

    public void UpdateScientificInterest(params ScientificInterest[] subsection)
    {
        scientificInterests.Clear();
        AddScientificInterest(subsection);
    }

    public ScientificWork CreateForProfessor(string name, string title, string problem, int limit, Guid professorId, Professor professor)
    {
        Name = name;
        Description = title;
        Result = problem;
        Limit = limit;
        ProfessorId = professorId;
        CreateAt = DateTime.UtcNow;
        Professor = professor;
        WorkStatus = WorkStatus.Confirmed;
        Fullness = 0;
        return this;
    }

    public ScientificWork Update(string name, string title, string problem, int limit)
    {
        Name = name;
        Description = title;
        Result = problem;
        Limit = limit;
        return this;
    }

    public ScientificWork()
    {

    }
}
