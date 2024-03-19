using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Professors;

/// <summary>
/// Professors.
/// </summary>
public class Professor : User
{
    public string? Address { get; private set; }

    public string? Degree { get; private set; }

    public int Limit { get; private set; }

    public int Fullness { get; private set; }

    public string? Post { get; private set; }

    public int PublicationsCount { get; private set; }

    public int WorkExperienceYears { get; private set; }

    public string? Titile { get; private set; }

    public int HIndex { get; private set; }

    public string? ScopusUri { get; private set; }

    public string? RISCUri { get; private set; }

    public string? URPUri { get; private set; }

    public string? Сontacts { get; private set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    private readonly List<ScientificInterest> scientificInterests = new();

    public IReadOnlyList<ScientificInterest> ScientificInterests => scientificInterests.AsReadOnly();

    private readonly List<ScientificAreaSubsection> scientificAreasSubsections = new();

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreasSubsections => scientificAreasSubsections.AsReadOnly();

    #region FavoriteStudents

    private readonly List<Student> favoriteStudents = new();

    public IReadOnlyList<Student> FavoriteStudents => favoriteStudents.AsReadOnly();

    private readonly List<ProfessorFavoriteStudent> professorFavoriteStudents = new();

    public IReadOnlyList<ProfessorFavoriteStudent> ProfessorFavoriteStudents => professorFavoriteStudents.AsReadOnly();

    #endregion

    #region FavoriteScientificWorks

    private readonly List<ScientificWorks.ScientificWork> favoriteScientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> FavoriteScientificWorks => favoriteScientificWorks.AsReadOnly();

    private readonly List<ProfessorFavoriteScientificWork> professorFavoriteScientificWorks = new();

    public IReadOnlyList<ProfessorFavoriteScientificWork> ProfessorFavoriteScientificWorks =>
        professorFavoriteScientificWorks.AsReadOnly();

    #endregion

    public void AddFavoriteStudent(Guid studentId)
    {
        var professorFavoriteStudent = ProfessorFavoriteStudent.Create(Id, studentId);
        professorFavoriteStudents.Add(professorFavoriteStudent);
    }

    public void AddFavoriteScientificWork(Guid scientificWorkId)
    {
        var professorFavoriteStudent = ProfessorFavoriteScientificWork.Create(Id, scientificWorkId);
        professorFavoriteScientificWorks.Add(professorFavoriteStudent);
    }
}
