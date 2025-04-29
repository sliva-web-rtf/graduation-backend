using MediatR;

namespace Graduation.Application.AcademicGroups.GetAcademicGroups;

public record GetAcademicGroupsQuery(
    string Year,
    string? Query,
    int Page,
    int PageSize) : IRequest<GetAcademicGroupsQueryResult>;