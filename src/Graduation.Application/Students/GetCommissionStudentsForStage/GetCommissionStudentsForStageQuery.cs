using MediatR;

namespace Graduation.Application.Students.GetCommissionStudentsForStage;

public record GetCommissionStudentsForStageQuery(
    string Year,
    string Stage,
    string? Query,
    Guid CommissionId,
    int Page,
    int PageSize,
    IList<string> SortByAcademicGroups
) : IRequest<GetCommissionStudentsForStageQueryResult>;