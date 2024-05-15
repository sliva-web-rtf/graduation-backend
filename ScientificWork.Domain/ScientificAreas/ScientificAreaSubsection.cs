using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.ScientificAreas;

public class ScientificAreaSubsection
{
    public Guid Id { get; set; }

    public Guid ScientificAreaId { get;  set; }

    public ScientificArea ScientificArea { get; set; } = null!;

    public string Name { get; set; } = null!;

    private readonly List<User> users = new();
    public ICollection<User> Users => users;

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();

    public ICollection<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks;
}
