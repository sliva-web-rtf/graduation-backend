using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetRecordingSlotById;

public record GetRecordingSlotByIdResult
{
    public Guid Id { get; init; }

    required public string Name { get; init; }

    required public int Limit { get; init; }

    required public int Fullness { get; init; }

    required public WorkStatus WorkStatus { get; init; }

    public Professor? Professor { get; init; }

    public Guid? ImageId { get; init; }

    public List<StudentDto> StudentDtos { get; set; }
}
