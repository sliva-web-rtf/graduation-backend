using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Documents;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Table.EditStudentsTable;

public class EditStudentsTableCommandHandler(IAppDbContext dbContext)
    : IRequestHandler<EditStudentsTableCommand, EditStudentsTableCommandResult>
{
    public async Task<EditStudentsTableCommandResult> Handle(EditStudentsTableCommand request,
        CancellationToken cancellationToken)
    {
        var studentsQuery = dbContext.Students
            .Where(s => s.Id == request.StudentId)
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .Include(s => s.QualificationWork!.Documents)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.Supervisor)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.Stage)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.QualificationWorkRole);

        var student = await studentsQuery.SingleOrDefaultAsync(cancellationToken)
                      ?? throw new DomainException("Student not found");

        var stage = await dbContext.Stages.SingleOrDefaultAsync(s => s.Name == request.Stage, cancellationToken)
                    ?? throw new DomainException("Stage not found");
        if (student.QualificationWork != null)
        {
            await SetQualificationWorkAsync(student, request, stage);
            SetStageData(student, request, stage);
        }

        student.Status = request.StudentStatus;
        student.Comment = request.StudentComment;

        await dbContext.SaveChangesAsync(cancellationToken);

        return new EditStudentsTableCommandResult(request.StudentId);
    }

    private async Task SetQualificationWorkAsync(Student student, EditStudentsTableCommand request, Stage stage)
    {
        student.QualificationWork!.Status = request.QualificationWorkStatus;

        var role = await dbContext.QualificationWorkRoles.SingleOrDefaultAsync(r => r.Role == request.Role);

        var qwStage = student.QualificationWork.Stages.FirstOrDefault(s => s.StageId == stage.Id);
        if (qwStage == null)
            return;
        qwStage.QualificationWorkRoleId = role?.Id;
        qwStage.TopicName = request.Topic!;
        qwStage.CompanyName = request.CompanyName;
        qwStage.CompanySupervisorName = request.CompanySupervisorName;
        qwStage.SupervisorId = request.SupervisorId;
    }

    private void SetStageData(Student student, EditStudentsTableCommand request, Stage stage)
    {
        switch (stage.Type)
        {
            case StageType.Defence:
            case StageType.PreDefence:
                SetDefenceData(student, request, stage);
                break;
            case StageType.FormattingReview:
                SetFormattingReviewData(student, request, stage);
                break;
        }
    }

    private void SetDefenceData(Student student, EditStudentsTableCommand request, Stage stage)
    {
        var qualificationWorkStage = student.QualificationWork!.Stages.Single(s => s.StageId == stage.Id);
        qualificationWorkStage.Mark = request.Mark;
        qualificationWorkStage.Result = request.Result;
        qualificationWorkStage.Comment = request.Comment;
        qualificationWorkStage.IsCommand = request.IsCommand;
        qualificationWorkStage.Date = request.Date;
        qualificationWorkStage.Time = request.Time;
        qualificationWorkStage.Location = request.Location;
    }

    private void SetFormattingReviewData(Student student, EditStudentsTableCommand request, Stage stage)
    {
        var qualificationWorkStage = student.QualificationWork!.Stages.Single(s => s.StageId == stage.Id);

        foreach (var document in request.Documents ?? [])
        {
            var doc = student.QualificationWork.Documents.SingleOrDefault(d => d.Name == document.Name);
            if (doc == null)
            {
                doc = new Document(Guid.NewGuid())
                {
                    Name = document.Name,
                    QualificationWorkId = student.QualificationWork.Id
                };
                dbContext.Documents.Add(doc);
            }

            doc.Status = document.DocumentStatus;
        }

        qualificationWorkStage.Result = request.Result;
    }
}