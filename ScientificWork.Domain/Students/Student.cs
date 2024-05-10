using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Requests;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students.ValueObjects;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.DataAccess.Helpers;

namespace ScientificWork.Domain.Students;

/// <summary>
/// Student.
/// </summary>
public class Student : User
{
    public string? Degree { get; private set; }

    public int Year { get; private set; }

    public int PublicationsCount { get; private set; }

    public int HIndex { get; private set; }

    public StudentSearchStatus? SearchStatus { get; private set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    private readonly List<ScientificInterest> scientificInterests = new();

    public IReadOnlyList<ScientificInterest> ScientificInterests => scientificInterests.AsReadOnly();

    private readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections.AsReadOnly();

    #region FavoriteStudents

    private readonly List<Student> favoriteStudents = new();

    public IReadOnlyList<Student> FavoriteStudents => favoriteStudents.AsReadOnly();

    private readonly List<StudentFavoriteStudent> studentFavoriteStudents = new();

    public IReadOnlyList<StudentFavoriteStudent> StudentFavoriteStudents => studentFavoriteStudents.AsReadOnly();

    #endregion

    #region FavoriteProfessors

    private readonly List<Professor> favoriteProfessors = new();

    public IReadOnlyList<Professor> FavoriteProfessors => favoriteProfessors.AsReadOnly();

    private readonly List<StudentFavoriteProfessor> studentFavoriteProfessors = new();

    public IReadOnlyList<StudentFavoriteProfessor> StudentFavoriteProfessors => studentFavoriteProfessors.AsReadOnly();

    #endregion

    #region FavoriteScientificWorks

    private readonly List<ScientificWorks.ScientificWork> favoriteScientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> FavoriteScientificWorks =>
        favoriteScientificWorks.AsReadOnly();

    private readonly List<StudentFavoriteScientificWork> studentFavoriteScientificWorks = new();

    public IReadOnlyList<StudentFavoriteScientificWork> StudentFavoriteScientificWorks =>
        studentFavoriteScientificWorks.AsReadOnly();

    #endregion

    #region StudentRequestStudent

    private readonly List<StudentRequestStudent> studentRequestStudents = new();

    public IReadOnlyList<StudentRequestStudent> StudentRequestStudents =>
        studentRequestStudents.AsReadOnly();

    #endregion

    #region StudentRequestProfessor

    private readonly List<StudentRequestProfessor> studentRequestProfessors = new();

    public IReadOnlyList<StudentRequestProfessor> StudentRequestProfessors =>
        studentRequestProfessors.AsReadOnly();

    #endregion

    private Student(
        Guid id,
        string userName,
        string email,
        DateTime createdAt,
        DateTime updatedAt)
        : base(id)
    {
        Email = email;
        UserName = userName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Student Create(
        string email)
    {
        return new Student(
            Guid.NewGuid(),
            email,
            email,
            DateTime.UtcNow,
            DateTime.UtcNow);
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

    public void UpdateScientificPortfolio(
        string degree,
        string? about,
        int year)
    {
        Degree = degree;
        About = about;
        Year = year;
    }

    public void UpdateSearchStatus(StudentSearchStatus status)
    {
        SearchStatus = status;
    }

    public bool CompleteRegistration(out List<string> errors)
    {
        var nullErrors = new List<string?>
        {
            CheckUserPortfolioFields() ? null : "user portfolio",
            CheckScientificPortfolioFields() ? null : "scientific portfolio",
            CheckStatusFields() ? null : "search status"
        };

        var notNullErrors = nullErrors.Where(v => v is not null).Select(v => v!).ToList();
        if (notNullErrors.Any())
        {
            errors = notNullErrors;
            return false;
        }

        IsRegistrationComplete = true;
        errors = new List<string>();
        return true;
    }

    private bool CheckUserPortfolioFields()
    {
        return FieldValidator.ValidateNotNull(FirstName, LastName, Email);
    }

    private bool CheckScientificPortfolioFields()
    {
        if (!FieldValidator.ValidateNotNull(Degree)
            || scientificInterests.Count == 0
            || scientificAreaSubsections.Count == 0
            || Year == 0)
        {
            return false;
        }

        return true;
    }

    private bool CheckStatusFields()
    {
        return SearchStatus is not null;
    }

    public void AddFavoriteStudent(Guid studentId)
    {
        var professorFavoriteStudent = StudentFavoriteStudent.Create(Id, studentId);
        studentFavoriteStudents.Add(professorFavoriteStudent);
    }

    public void AddFavoriteScientificWork(Guid scientificWorkId)
    {
        var professorFavoriteStudent = StudentFavoriteScientificWork.Create(Id, scientificWorkId);
        studentFavoriteScientificWorks.Add(professorFavoriteStudent);
    }

    public void AddFavoriteProfessor(Guid professorId)
    {
        var professorFavoriteStudent = StudentFavoriteProfessor.Create(Id, professorId);
        studentFavoriteProfessors.Add(professorFavoriteStudent);
    }
}
