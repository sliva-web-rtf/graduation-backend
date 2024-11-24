using MediatR;

namespace ScientificWork.UseCases.Students.GetStudentProfileInfo;

public record GetStudentProfileInfoCommand() : IRequest<GetStudentProfileInfoCommandResult>;