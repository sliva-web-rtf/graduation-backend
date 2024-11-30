using MediatR;

namespace ScientificWork.UseCases.Students.GetStudentProfileInfo;

public record GetStudentProfileInfoQuery(Guid Id) : IRequest<GetStudentProfileInfoQueryResult>;