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
    public string Address { get; private set; }

    public string Degree { get; private set; }

    public int Limit { get; private set; }

    public int Fullness { get; private set; }

    public string Post { get; private set; }

    public int PublicationsCount { get; private set; }

    public int WorkExperienceYears { get; private set; }

    public string Titile { get; private set; }

    public int HIndex { get; private set; }

    public string? ScopusUri { get; private set; }

    public string? RISCUri { get; private set; }

    public string URPUri { get; private set; }

    public string Сontacts { get; private set; }

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    private readonly List<ScientificInterest> scientificInterests = new();

    public ICollection<ScientificInterest> ScientificInterests => scientificInterests;

    private readonly List<ScientificArea> scientificAreas = new();

    public ICollection<ScientificArea> ScientificAreas => scientificAreas;

    public Professor(Guid id) : base(id)
    {
    }
}
