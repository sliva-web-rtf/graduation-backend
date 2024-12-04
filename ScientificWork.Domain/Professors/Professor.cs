using ScientificWork.Domain.Favorites;
using ScientificWork.Domain.Helpers;
using ScientificWork.Domain.Professors.ValueObjects;
using ScientificWork.Domain.Requests;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
// ReSharper disable CollectionNeverUpdated.Local

namespace ScientificWork.Domain.Professors;

/// <summary>
/// Professors.
/// </summary>
public sealed class Professor : User
{
    public string? Address { get; private set; }

    public string? Degree { get; private set; }

    public string? Post { get; private set; }

    public ProfessorSearchStatus? SearchStatus { get; private set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    public int? Fullness { get; private set; }

    public int? WorkExperienceYears { get; private set; }

    public string? ScopusUri { get; private set; }

    public string? RISCUri { get; private set; }

    public string? URPUri { get; private set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    #region FavoriteStudents

    private readonly List<Student> favoriteStudents = new();

    public IReadOnlyList<Student> FavoriteStudents => favoriteStudents.AsReadOnly();

    private readonly List<ProfessorFavoriteStudent> professorFavoriteStudents = new();

    public IReadOnlyList<ProfessorFavoriteStudent> ProfessorFavoriteStudents => professorFavoriteStudents.AsReadOnly();

    #endregion

    #region FavoriteScientificWorks

    private readonly List<ScientificWorks.ScientificWork> favoriteScientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> FavoriteScientificWorks =>
        favoriteScientificWorks.AsReadOnly();

    private readonly List<ProfessorFavoriteScientificWork> professorFavoriteScientificWorks = new();

    public IReadOnlyList<ProfessorFavoriteScientificWork> ProfessorFavoriteScientificWorks =>
        professorFavoriteScientificWorks.AsReadOnly();

    #endregion

    #region StudentRequestProfessor

    private readonly List<StudentRequestProfessor> studentRequestProfessors = new();

    public IReadOnlyList<StudentRequestProfessor> StudentRequestProfessors => studentRequestProfessors.AsReadOnly();

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

    public void UpdateSearchStatus(ProfessorSearchStatus status)
    {
        SearchStatus = status;
    }

    public override bool CompleteRegistration(out List<string> errors)
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
            || !WorkExperienceYears.HasValue)
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
        if (professorFavoriteStudents.All(p => p.StudentId != studentId))
        {
            var professorFavoriteStudent = ProfessorFavoriteStudent.Create(Id, studentId);
            professorFavoriteStudents.Add(professorFavoriteStudent);
        }
    }

    public void AddFavoriteScientificWork(Guid scientificWorkId)
    {
        if (professorFavoriteScientificWorks.All(p => p.ScientificWorkId != scientificWorkId))
        {
            var professorFavoriteStudent = ProfessorFavoriteScientificWork.Create(Id, scientificWorkId);
            professorFavoriteScientificWorks.Add(professorFavoriteStudent);
        }
    }

    public void AddScientificAreaSubsections(params ScientificAreaSubsection[] subsection)
    {
        scientificAreaSubsections.AddRange(subsection);
    }

    public void RemoveFavoriteStudent(Guid studentId)
    {
        var pfs = professorFavoriteStudents.FirstOrDefault(x => x.StudentId == studentId);
        if (pfs != null)
        {
            professorFavoriteStudents.Remove(pfs);
        }
    }

    public void RemoveFavoriteScientificWork(Guid scientificWorkId)
    {
        var pfs = professorFavoriteScientificWorks.FirstOrDefault(x => x.ScientificWorkId == scientificWorkId);
        if (pfs != null)
        {
            professorFavoriteScientificWorks.Remove(pfs);
        }
    }

    public void UpdateScientificAreaSubsections(params ScientificAreaSubsection[] subsection)
    {
        scientificAreaSubsections.Clear();
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
        string? scopusUri,
        string? riscUri,
        string? urpUri)
    {
        Degree = degree;
        About = about;
        ScopusUri = scopusUri;
        RISCUri = riscUri;
        URPUri = urpUri;
    }
}
