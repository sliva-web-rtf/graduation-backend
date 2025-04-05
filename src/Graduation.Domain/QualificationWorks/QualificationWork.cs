using Graduation.Domain.Common;

namespace Graduation.Domain.QualificationWorks;

public class QualificationWork : Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid? SupervisorId { get; set; }
    public Guid TopicId { get; set; }
    public Guid QualificationWorkRoleId { get; set; }
    public string? ExpertComment { get; set; }
    public string Name { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }
    public string? Annotation { get; set; }
    public QualificationWorkStatus Status { get; set; }
    public string Year { get; set; }
}