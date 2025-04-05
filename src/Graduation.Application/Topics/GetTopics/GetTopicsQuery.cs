using MediatR;

namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsQuery(
    int Page,
    int PageSize,
    string? Query)
    : IRequest<GetTopicsQueryResult>;