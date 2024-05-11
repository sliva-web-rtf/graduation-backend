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

    public string? Post { get; private set; }

    public int Limit { get; private set; }

    public int Fullness { get; private set; }

    public int WorkExperienceYears { get; private set; }

    public string? ScopusUri { get; private set; }

    public string? RISCUri { get; private set; }

    public string? URPUri { get; private set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    private readonly List<ScientificInterest> scientificInterests = new();

    public IReadOnlyList<ScientificInterest> ScientificInterests => scientificInterests.AsReadOnly();

    private readonly List<ScientificAreaSubsection> scientificAreaSubsections = new();

    public IReadOnlyList<ScientificAreaSubsection> ScientificAreaSubsections => scientificAreaSubsections.AsReadOnly();

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

    private Professor(
        Guid id,
        string userName,
        string email,
        string avatarImagePath,
        DateTime createdAt,
        DateTime updatedAt)
        : base(id)
    {
        Email = email;
        UserName = userName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsRegistrationComplete = true;
        AvatarImagePath = avatarImagePath;
    }

    public static Professor Create(
        string email,
        string avatarImagePath)
    {
        return new Professor(
            Guid.NewGuid(),
            email,
            email,
            avatarImagePath,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

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
        string? post,
        string? about,
        string? address,
        int limit,
        int workExperienceYears,
        string? scopusUri,
        string? riscUri,
        string? urpUri)
    {
        Degree = degree;
        Post = post;
        About = about;
        Address = address;
        Limit = limit;
        WorkExperienceYears = workExperienceYears;
        ScopusUri = scopusUri;
        RISCUri = riscUri;
        URPUri = urpUri;
    }
}
