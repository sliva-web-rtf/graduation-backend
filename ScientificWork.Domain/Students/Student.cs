using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students.ValueObjects;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Students;

/// <summary>
/// Student.
/// </summary>
public class Student : User
{
    public string? Degree { get; private set; }

    public int PublicationsCount { get; private set; }

    public int HIndex { get; private set; }

    public string? ScopusUri { get; private set; }

    public string? RISCUri { get; private set; }

    public string? URPUri { get; private set; }

    public string? Contacts { get; private set; }

    public bool IsRegistrationComplete { get; private set; }

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

    public void UpdateProfileInformation(
        string firstName,
        string lastName,
        string patronymic,
        string phoneNumber,
        string contacts)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Contacts = contacts;
    }

    public void UpdateScientificPortfolio(
        string degree,
        string? urpUri,
        string? scopusUri,
        string? riscUri)
    {
        Degree = degree;
        URPUri = urpUri;
        ScopusUri = scopusUri;
        RISCUri = riscUri;
    }

    public void UpdateSearchStatus(StudentSearchStatus status)
    {
        SearchStatus = status;
    }
}
