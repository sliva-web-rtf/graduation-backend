using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Table.SetStudentsStageDate;

public class SetStudentsStageDateCommandHandler : IRequestHandler<SetStudentsStageDateCommand>
{
    private readonly IAppDbContext dbContext;

    public SetStudentsStageDateCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Handle(SetStudentsStageDateCommand request, CancellationToken cancellationToken)
    {
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
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}