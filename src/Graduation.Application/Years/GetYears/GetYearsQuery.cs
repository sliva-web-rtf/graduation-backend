using MediatR;

namespace Graduation.Application.Years.GetYears;

public record GetYearsQuery : IRequest<GetYearsQueryResult>;