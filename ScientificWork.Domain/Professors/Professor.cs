using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScientificWork.Domain.ScientificAreas;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Professors;

/// <summary>
/// Professor.
/// </summary>
public class Professor : User
{
    public string Address { get; set; }

    public string Degree { get; set; }

    public int Limit { get; set; }

    public int Fullness { get; set; }

    public string Post { get; set; }

    public int PublicationsCount { get; set; }

    public int WorkExperienceYears { get; set; }

    public string Titile { get; set; }

    public int HIndex { get; set; }

    public string? ScopusUri { get; set; }

    public string? RISCUri { get; set; }

    public string URPUri { get; set; }

    public string Сontacts { get; set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    private readonly List<ScientificInterest> scientificInterests = new();

    public ICollection<ScientificInterest> ScientificInterests => scientificInterests;

    private readonly List<ScientificArea> scientificAreas = new();

    public ICollection<ScientificArea> ScientificAreas => scientificAreas;
}
