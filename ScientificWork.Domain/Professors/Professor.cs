using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.Professors;

/// <summary>
/// Professor.
/// </summary>
public class Professor
{
    [Key]
    [ForeignKey("User")]
    public int Id { get; private set; }

    public User User { get; set; }

    public string Auditorium { get; set; }

    public string Degree { get; set; }

    public int Limit { get; set; }

    public int Fullness { get; set; }

    public string Post { get; set; }

    public string Titile { get; set; }

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks { get; set; }

    public ICollection<Student> FavoriteStudent { get; set; }

    public ICollection<ScientificInterest> ScientificInterests { get; set; }
}
