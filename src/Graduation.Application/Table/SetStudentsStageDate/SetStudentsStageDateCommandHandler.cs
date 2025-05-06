using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Table.SetStudentsStageDate;

public class SetStudentsStageDateCommandHandler(IAppDbContext dbContext, IEventsCreator eventsCreator)
    : IRequestHandler<SetStudentsStageDateCommand>
{
    public async Task Handle(SetStudentsStageDateCommand request, CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried to set defence date", request);

        var stage = await dbContext.Stages.SingleOrDefaultAsync(s => s.Name == request.Stage, cancellationToken)
                    ?? throw new DomainException("Stage not found");

        var students = dbContext.Students
            .Where(s => request.StudentIds.Contains(s.Id))
            .Include(s => s.QualificationWork)
            .ThenInclude(s => s.Stages);

        foreach (var student in students)
        {
            var qwStage = student.QualificationWork?.Stages.FirstOrDefault(s => s.StageId == stage.Id);
            if (qwStage is null)
                continue;

            qwStage.Date = request.Date;
            qwStage.Location = request.Location;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}