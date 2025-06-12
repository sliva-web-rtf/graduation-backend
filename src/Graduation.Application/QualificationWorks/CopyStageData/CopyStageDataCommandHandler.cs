using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Stages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.QualificationWorks.CopyStageData;

public class CopyStageDataCommandHandler(IAppDbContext appDbContext, IEventsCreator eventsCreator)
    : IRequestHandler<CopyStageDataCommand, CopyStageDataCommandResult>
{
    public async Task<CopyStageDataCommandResult> Handle(CopyStageDataCommand request,
        CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried to copy stage data", request);

        var stageTo = await appDbContext.Stages.FirstOrDefaultAsync(s => s.Name == request.StageTo, cancellationToken)
                      ?? throw new NotFoundException("StageTo not found");

        var stageFrom = await appDbContext.Stages
                            .FirstOrDefaultAsync(s => s.Name == request.StageFrom, cancellationToken)
                        ?? throw new NotFoundException("StageFrom not found");

        var works = await appDbContext.QualificationWorks
            .Where(qw => qw.Year == request.Year)
            .Include(w => w.Stages)
            .ToListAsync(cancellationToken);

        foreach (var qualificationWork in works)
        {
            if (qualificationWork.Stages.Any(s => s.StageId == stageTo.Id))
                continue;

            var oldQwStage = qualificationWork.Stages.FirstOrDefault(s => s.StageId == stageFrom.Id);
            if (oldQwStage == null)
                continue;

            var qwStage = new QualificationWorkStage(Guid.NewGuid())
            {
                StageId = stageTo.Id,
                QualificationWorkId = qualificationWork.Id,
                CommissionId = oldQwStage.CommissionId,
                TopicId = qualificationWork.TopicId,
                SupervisorId = qualificationWork.SupervisorId,
                QualificationWorkRoleId = qualificationWork.QualificationWorkRoleId,
                TopicName = qualificationWork.Name,
                CompanyName = qualificationWork.CompanyName,
                CompanySupervisorName = qualificationWork.CompanySupervisorName,
                IsCommand = oldQwStage.IsCommand
            };
            appDbContext.QualificationWorkStages.Add(qwStage);
        }

        var count = await appDbContext.SaveChangesAsync(cancellationToken);

        return new CopyStageDataCommandResult(count);
    }
}