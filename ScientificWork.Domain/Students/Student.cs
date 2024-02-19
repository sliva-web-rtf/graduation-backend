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
public class Student
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

    public string? URPUri { get; set; }

    public string Сontacts { get; set; }

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks { get; set; }

    public ICollection<ScientificInterest> ScientificInterests { get; set; }

    public ICollection<ScientificArea> ScientificAreas { get; set; }
}
