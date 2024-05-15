using ScientificWork.Domain.Common;
using ScientificWork.Domain.Users;
// ReSharper disable CollectionNeverUpdated.Local

namespace ScientificWork.Domain.ScientificInterests;

/// <summary>
/// Scientific interests.
/// </summary>
public class ScientificInterest : Entity<Guid>
{
    public string Name { get; private set; }
    
    private readonly List<User> users = new();
    public IReadOnlyList<User> Users => users.AsReadOnly();

    private readonly List<ScientificWorks.ScientificWork> scientificWorks = new();
    public IReadOnlyList<ScientificWorks.ScientificWork> ScientificWorks => scientificWorks.AsReadOnly();

    public ScientificInterest()
    {
    }

    public ScientificInterest(string name)
    {
        Name = name;
    }
}
