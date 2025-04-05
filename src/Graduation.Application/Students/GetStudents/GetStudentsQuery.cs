using MediatR;

namespace Graduation.Application.Students.GetStudents;

public record GetStudentsQuery(
    int Page,
    int PageSize,
    string? Query) : IRequest<GetStudentsQueryResult>;