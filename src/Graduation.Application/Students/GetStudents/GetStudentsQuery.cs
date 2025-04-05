using MediatR;

namespace Graduation.Application.Students.GetStudents;

public record GetStudentsQuery(
    string Year,
    int Page,
    int PageSize,
    string? Query) : IRequest<GetStudentsQueryResult>;