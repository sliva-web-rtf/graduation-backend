using MediatR;

namespace Graduation.Application.Commissions.GetCommissions;

public record GetCommissionsQuery(string Year) : IRequest<GetCommissionsQueryResult>;