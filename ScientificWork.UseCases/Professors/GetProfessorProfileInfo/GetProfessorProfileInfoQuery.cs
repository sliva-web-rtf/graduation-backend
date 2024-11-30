using MediatR;

namespace ScientificWork.UseCases.Professors.GetProfessorProfileInfo;

public record GetProfessorProfileInfoQuery(Guid Id) : IRequest<GetProfessorProfileInfoQueryResult>;