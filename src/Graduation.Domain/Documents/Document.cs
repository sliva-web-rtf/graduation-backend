using Graduation.Domain.Common;

namespace Graduation.Domain.Documents;

public class Document : Entity<Guid>
{
    public string DocumentPath { get; set; }
    public string Name { get; set; }
    public string FileName { get; set; }
    public Guid QualificationWorkId { get; set; }
    public DateTime UploadedAt { get; set; }
    public DocumentStatus Status { get; set; }
}