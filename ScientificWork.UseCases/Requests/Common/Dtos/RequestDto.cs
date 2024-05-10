using ScientificWork.Domain.Requests.Enums;

namespace ScientificWork.UseCases.Requests.Common.Dtos;

public record RequestDto
{
    public Guid Id { get; init; }

    public Guid ScientificWorkId { get; init; }

    public Guid UserFrom { get; init; }

    public string Message { get; init; }
}
