using System.ComponentModel.DataAnnotations;
using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.ScientificAreas;

public class ScientificAreaSubsection
{
    public Guid Id { get; set; }

    public Guid ScientificAreaId { get;  set; }

    public ScientificArea ScientificArea { get;  set; }

    public string Name { get; set; }

    private readonly List<User> users = new();
    public ICollection<User> Users => users;

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks;
}
