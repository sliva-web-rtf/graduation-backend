using MediatR;

namespace ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;

public record GetProfessorScientificPortfolioQuery(Guid Id) : IRequest<GetProfessorScientificPortfolioQueryResult>;