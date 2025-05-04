using MediatR;

namespace Graduation.Application.Experts.GetExperts;

public record GetExpertsQuery(
    string Year,
    string? Query,
    Guid SortByCommissionId,
    string? Stage,
    int Page,
    int PageSize) : IRequest<GetExpertsQueryResult>;