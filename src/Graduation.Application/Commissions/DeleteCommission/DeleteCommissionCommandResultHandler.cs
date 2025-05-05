using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.DeleteCommission;

public class DeleteCommissionCommandResultHandler(IAppDbContext dbContext, IEventsCreator eventsCreator)
    : IRequestHandler<DeleteCommissionCommand, DeleteCommissionCommandResult>
{
    public async Task<DeleteCommissionCommandResult> Handle(DeleteCommissionCommand request,
        CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried to delete commission", request);
        
        var commission = await dbContext.Commissions
                             .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                         ?? throw new NotFoundException("Commission not found");

        dbContext.Commissions.Remove(commission);
        var academicGroups = await dbContext.AcademicGroups
            .Where(ag => ag.CommissionId == request.Id)
            .ToListAsync(cancellationToken);

        foreach (var academicGroup in academicGroups)
        {
            academicGroup.CommissionId = null;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteCommissionCommandResult(commission.Id);
    }
}