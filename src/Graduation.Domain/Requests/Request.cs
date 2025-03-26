using Graduation.Domain.Common;

namespace Graduation.Domain.Requests;

public class Request : Entity<Guid>
{
    public Guid TopicId { get; set; }
    public Guid SenderId { get; set; }
    public Guid SenderRoleId { get; set; }
    public Guid RecipientId { get; set; }
    public Guid RecipientRoleId { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }
    public string? SenderComment { get; set; }
    public string? RecipientComment { get; set; }
    public RequestStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}