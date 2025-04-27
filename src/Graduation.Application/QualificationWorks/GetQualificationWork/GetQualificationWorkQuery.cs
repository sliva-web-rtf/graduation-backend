using MediatR;

namespace Graduation.Application.QualificationWorks.GetQualificationWork;

public record GetQualificationWorkQuery(Guid Id, string Stage) : IRequest<GetQualificationWorkQueryResult>;