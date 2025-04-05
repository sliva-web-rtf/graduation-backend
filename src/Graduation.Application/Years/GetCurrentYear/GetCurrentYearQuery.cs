using MediatR;

namespace Graduation.Application.Years.GetCurrentYear;

public record GetCurrentYearQuery : IRequest<GetCurrentYearQueryResult>;