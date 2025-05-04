using MediatR;

namespace Graduation.Application.AcademicGroups.GetAcademicGroups;

public record GetAcademicGroupsQuery(
    string Year,
    string? Query,
    Guid? CommissionId,
    int Page,
    int PageSize) : IRequest<GetAcademicGroupsQueryResult>;