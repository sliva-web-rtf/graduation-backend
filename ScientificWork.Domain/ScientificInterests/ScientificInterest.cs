using ScientificWork.Domain.Common;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Domain.ScientificInterests;

/// <summary>
/// Scientific interests.
/// </summary>
public class ScientificInterest : Entity<Guid>
{
    public string Name { get; private set; }
    

    private readonly List<User> _users = new();
    public IReadOnlyList<User> Users => _users.AsReadOnly();

    private readonly List<ScientificWorks.ScientificWork> _scientificWorks = new();
    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => _scientificWorks.AsReadOnly();

    public ScientificInterest()
    {
    }

    public ScientificInterest(string name)
    {
        Name = name;
    }
}
