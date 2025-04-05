using Graduation.Domain.Common;

namespace Graduation.Domain.Stages;

public class QualificationWorkStage : Entity<Guid>
{
    public Guid StageId { get; set; }
    public Guid QualificationWorkId { get; set; }
    public Guid? CommissionId { get; set; }
    public string TopicName { get; set; }
    public string? Result { get; set; }
    public decimal? Mark { get; set; }
    public bool IsCommand { get; set; }
    public string? Comment { get; set; }
    public DateTime Date { get; set; }
}