using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Professors;

/// <summary>
/// Professor.
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

    public ICollection<ScientificInterest> ScientificInterests => scientificInterests;

    private readonly List<ScientificArea> scientificAreas = new();

    public ICollection<ScientificArea> ScientificAreas => scientificAreas;

    #region FavoriteStudents

    private readonly List<Student> favoriteStudents = new();

    public ICollection<Student> FavoriteStudents => favoriteStudents;

    private readonly List<ProfessorFavoriteStudent> professorFavoriteStudents = new();

    public ICollection<ProfessorFavoriteStudent> ProfessorFavoriteStudents => professorFavoriteStudents;

    #endregion

    #region FavoriteScientificWorks

    private readonly List<ScientificWorks.ScientificWork> favoriteScientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> FavoriteScientificWorks => favoriteScientificWorks;

    private readonly List<ProfessorFavoriteScientificWork> professorFavoriteScientificWorks = new();

    public ICollection<ProfessorFavoriteScientificWork> ProfessorFavoriteScientificWorks =>
        professorFavoriteScientificWorks;

    #endregion

    public Professor(Guid id) : base(id)
    {
        //TODO
        Email = "test@test.com";
        UserName = Email;
        FirstName = Email;
        LastName = Email;
        EmailConfirmed = true;
    }

    public void AddFavoriteStudent(Guid studentId)
    {
        var professorFavoriteStudent = ProfessorFavoriteStudent.Create(Id, studentId);
        professorFavoriteStudents.Add(professorFavoriteStudent);
    }
}
