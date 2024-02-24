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

    public string? Сontacts { get; private set; }

    public StudentSearchStatus? SearchStatus { get; private set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks;

    private readonly List<ScientificInterest> scientificInterests = new();

    public ICollection<ScientificInterest> ScientificInterests => scientificInterests;

    private readonly List<ScientificArea> scientificAreas = new();

    public ICollection<ScientificArea> ScientificAreas => scientificAreas;

    #region FavoriteStudents

    private readonly List<Student> favoriteStudents = new();

    public ICollection<Student> FavoriteStudents => favoriteStudents;

    private readonly List<StudentFavoriteStudent> studentFavoriteStudents = new();

    public ICollection<StudentFavoriteStudent> StudentFavoriteStudents => studentFavoriteStudents;

    #endregion

    #region FavoriteProfessors

    private readonly List<Professor> favoriteProfessors = new();

    public ICollection<Professor> FavoriteProfessors => favoriteProfessors;

    private readonly List<StudentFavoriteProfessor> studentFavoriteProfessors = new();

    public ICollection<StudentFavoriteProfessor> StudentFavoriteProfessors => studentFavoriteProfessors;

    #endregion

    #region FavoriteScientificWorks

    private readonly List<ScientificWorks.ScientificWork> favoriteScientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> FavoriteScientificWorks => favoriteScientificWorks;

    private readonly List<StudentFavoriteScientificWork> studentFavoriteScientificWorks = new();

    public ICollection<StudentFavoriteScientificWork> StudentFavoriteScientificWorks => studentFavoriteScientificWorks;

    #endregion

    public Student(Guid id) : base(id)
    {
        //TODO
        Email = "test2@test.com";
        UserName = Email;
        FirstName = Email;
        LastName = Email;
        EmailConfirmed = true;
    }
}
