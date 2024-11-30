using MediatR;

namespace ScientificWork.UseCases.Students.GetStudentScientificPortfolio;

public record GetStudentScientificPortfolioQuery(Guid Id) : IRequest<GetStudentScientificPortfolioQueryResult>;