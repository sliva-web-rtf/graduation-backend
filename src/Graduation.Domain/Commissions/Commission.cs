using Graduation.Domain.Common;

namespace Graduation.Domain.Commissions;

public class Commission : Entity<Guid>
{
    public string Name { get; set; }
    public Guid SecretaryId { get; set; }
    public string Year { get; set; }
}