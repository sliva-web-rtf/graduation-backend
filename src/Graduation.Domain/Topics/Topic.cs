using Graduation.Domain.Common;

namespace Graduation.Domain.Topics;

public class Topic : Entity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Result { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }
    public string Year { get; set; }
}