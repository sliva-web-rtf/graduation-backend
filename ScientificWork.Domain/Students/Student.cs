using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScientificWork.Domain.Professors;
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

    public ICollection<Professor> FavoriteProfessors { get; set; }

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks { get; set; }

    public ICollection<ScientificInterest> ScientificInterests { get; set; }
}
