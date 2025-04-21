using MediatR;

namespace Graduation.Application.Table.GetStudentsTable;

public record GetStudentsTableQuery(
    string Year,
    string Stage,
    string? CommissionName,
    int Page,
    int PageSize,
    string? Query) : IRequest<GetStudentsTableQueryResult>;