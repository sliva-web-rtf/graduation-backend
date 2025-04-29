using MediatR;

namespace Graduation.Application.Commissions.GetCommission;

public record GetCommissionQuery(Guid Id) : IRequest<GetCommissionQueryResult>;