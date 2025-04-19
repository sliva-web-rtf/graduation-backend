using MediatR;

namespace Graduation.Application.Table.GetStudentsTable;

public record GetStudentsTableQuery(
    string Year,
    string Stage,
    int Page,
    int PageSize,
    string? Query) : IRequest<GetStudentsTableQueryResult>;