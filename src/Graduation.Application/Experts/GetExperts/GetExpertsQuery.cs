using MediatR;

namespace Graduation.Application.Experts.GetExperts;

public record GetExpertsQuery(
    string Year,
    string? Query,
    int Page,
    int PageSize) : IRequest<GetExpertsQueryResult>;