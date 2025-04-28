using Graduation.Domain.Common;
using Graduation.Domain.Documents;
using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using Graduation.Domain.Users;

namespace Graduation.Domain.QualificationWorks;

public class QualificationWork : Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public string? Annotation { get; set; }
    public QualificationWorkStatus Status { get; set; }
    public string Year { get; set; }
    public List<Document> Documents { get; set; } = [];
    public List<QualificationWorkStage> Stages { get; set; } = [];
    public string? ExpertComment { get; set; }


    public Guid? SupervisorId { get; set; }
    public User? Supervisor { get; set; }
    public Guid TopicId { get; set; }
    public Guid? QualificationWorkRoleId { get; set; }
    public QualificationWorkRole? QualificationWorkRole { get; set; }
    public string Name { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }

    public QualificationWork(Guid id) : base(id)
    {
        
    }

    private QualificationWork()
    {
        
    }
}