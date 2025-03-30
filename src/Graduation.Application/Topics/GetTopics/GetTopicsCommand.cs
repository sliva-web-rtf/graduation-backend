using MediatR;

namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsCommand(
    Guid UserId,
    bool IncludeOwnedTopics,
    int Page,
    int PageSize,
    string? Query)
    : IRequest<GetTopicsCommandResult>;