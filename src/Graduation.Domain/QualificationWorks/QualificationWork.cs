using Graduation.Domain.Common;
using Graduation.Domain.Documents;
using Graduation.Domain.Stages;

namespace Graduation.Domain.QualificationWorks;

public class QualificationWork : Entity<Guid>
{
    public Guid StudentId { get; set; }
    public string? Annotation { get; set; }
    public QualificationWorkStatus Status { get; set; }
    public string Year { get; set; }
    public List<Document> Documents { get; set; } = [];
    public List<QualificationWorkStage> Stages { get; set; } = [];
    public string? ExpertComment { get; set; }


    public Guid? SupervisorId { get; set; }
    public Guid TopicId { get; set; }
    public Guid? QualificationWorkRoleId { get; set; }
    public string Name { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }
}