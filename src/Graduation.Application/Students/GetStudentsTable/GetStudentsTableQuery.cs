using MediatR;

namespace Graduation.Application.Students.GetStudentsTable;

public record GetStudentsTableQuery(
    string Year,
    string Stage,
    int Page,
    int PageSize,
    string? Query) : IRequest<GetStudentsTableQueryResult>;