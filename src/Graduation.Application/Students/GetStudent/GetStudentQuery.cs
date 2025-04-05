using MediatR;

namespace Graduation.Application.Students.GetStudent;

public record GetStudentQuery(Guid Id) : IRequest<GetStudentQueryResult>;