using Graduation.Application.Topics.GetTopics;
using MediatR;

namespace Graduation.Application.Topics.GetUserTopics;

public record GetUserTopicsQuery(
    Guid UserId,
    int Page,
    int PageSize,
    string? Query)
    : IRequest<GetUserTopicsQueryResult>;