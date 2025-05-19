using Graduation.Domain.Students;
using MediatR;

namespace Graduation.Application.Table.GetStudentsTable;

public record GetStudentsTableQuery(
    string Year,
    string Stage,
    DateOnly? FromDate,
    DateOnly? ToDate,
    IList<string> Commissions,
    IList<StudentStatus> StudentStatuses,
    int Page,
    int PageSize,
    string? Query,
    IList<SortStatus> Sort) : IRequest<GetStudentsTableQueryResult>;

public record SortStatus(string Field, string Sort);