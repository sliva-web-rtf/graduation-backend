using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Students;

/// <summary>
/// Student.
/// </summary>
public class Student : User
{
    [Key]
    [ForeignKey("User")]
    public int Id { get; private set; }

    public User User { get; set; }

    public string? Degree { get; set; }

    public int PublicationsCount { get; set; }

    public int HIndex { get; set; }

    public string? ScopusUri { get; set; }

    public string? RISCUri { get; set; }

    public string URPUri { get; set; }

    public string Сontacts { get; set; }

    private readonly List<Professor> favoriteProfessors = new();

    public ICollection<Professor> FavoriteProfessors => favoriteProfessors;

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks;

    private readonly List<ScientificInterest> scientificInterests = new();

    public ICollection<ScientificInterest> ScientificInterests => scientificInterests;

    private readonly List<ScientificArea> scientificAreas = new();

    public ICollection<ScientificArea> ScientificAreas => scientificAreas;
}
