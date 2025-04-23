using MediatR;

namespace Graduation.Application.Table.GetStudentsTable;

public record GetStudentsTableQuery(
    string Year,
    string Stage,
    IList<string> Commissions,
    int Page,
    int PageSize,
    string? Query,
    IList<SortStatus> Sort) : IRequest<GetStudentsTableQueryResult>;

public record SortStatus(string Field, string Sort);