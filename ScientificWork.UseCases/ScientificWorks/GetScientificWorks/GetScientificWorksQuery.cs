using MediatR;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorksForProfessor;

public class GetScientificWorksQuery : IRequest<List<ScientificWorkDto>>
{
}
