using Graduation.Domain.Common;
using Graduation.Domain.QualificationWorkRoles;
using Graduation.Domain.Topics;
using Graduation.Domain.Users;

namespace Graduation.Domain.Stages;

public class QualificationWorkStage : Entity<Guid>
{
    public QualificationWorkStage(Guid id) : base(id)
    {
    }

    private QualificationWorkStage()
    {
    }

    public Guid StageId { get; set; }
    public Stage Stage { get; set; }
    public Guid QualificationWorkId { get; set; }
    public Guid? CommissionId { get; set; }
    public Guid? SupervisorId { get; set; }
    public User? Supervisor { get; set; }
    public Guid? TopicId { get; set; }
    public Topic? Topic { get; set; }
    public Guid? QualificationWorkRoleId { get; set; }
    public QualificationWorkRole? QualificationWorkRole { get; set; }
    public required string TopicName { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanySupervisorName { get; set; }
    public string? Location { get; set; }
    public string? Result { get; set; }
    public decimal? Mark { get; set; }
    public bool IsCommand { get; set; }
    public string? Comment { get; set; }
    public DateOnly? Date { get; set; }
    public TimeOnly? Time { get; set; }
}