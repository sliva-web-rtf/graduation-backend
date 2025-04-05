using MediatR;

namespace Graduation.Application.Topics.GetUserTopics;

public record GetUserTopicsQuery(
    string Year,
    Guid UserId,
    int Page,
    int PageSize,
    string? Query)
    : IRequest<GetUserTopicsQueryResult>;