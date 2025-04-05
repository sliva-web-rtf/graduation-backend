using MediatR;

namespace Graduation.Application.Supervisors.GetSupervisor;

public record GetSupervisorQuery(string Year, Guid Id) : IRequest<GetSupervisorQueryResult>;