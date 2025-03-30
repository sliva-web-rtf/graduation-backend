using MediatR;

namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsQuery(
    Guid UserId,
    bool IncludeOwnedTopics,
    int Page,
    int PageSize,
    string? Query)
    : IRequest<GetTopicsQueryResult>;