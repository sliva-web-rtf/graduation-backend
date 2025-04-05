using MediatR;

namespace Graduation.Application.Topics.GetTopics;

public record GetTopicsQuery(
    string Year,
    int Page,
    int PageSize,
    string? Query)
    : IRequest<GetTopicsQueryResult>;