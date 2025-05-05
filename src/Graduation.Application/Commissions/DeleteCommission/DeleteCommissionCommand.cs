using MediatR;

namespace Graduation.Application.Commissions.DeleteCommission;

public record DeleteCommissionCommand(Guid Id) : IRequest<DeleteCommissionCommandResult>;