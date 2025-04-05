using MediatR;

namespace Graduation.Application.Supervisors.GetSupervisors;

public record GetSupervisorsQuery(
    string Year,
    int Page,
    int PageSize,
    string? Query) : IRequest<GetSupervisorsQueryResult>;