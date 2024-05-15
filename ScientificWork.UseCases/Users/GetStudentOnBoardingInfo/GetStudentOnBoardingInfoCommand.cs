using MediatR;

namespace ScientificWork.UseCases.Users.GetStudentOnBoardingInfo;

public record GetStudentOnBoardingInfoCommand() : IRequest<GetStudentOnBoardingInfoCommandResult>;