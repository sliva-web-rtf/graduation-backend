using MediatR;

namespace Graduation.Application.Commissions.GetCommissionsForEditing;

public record GetCommissionsForEditingQuery(string Year) : IRequest<GetCommissionsForEditingQueryResult>;