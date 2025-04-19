using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Table.GetStudentsTable;
using Graduation.Domain.Exceptions;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Table.EditStudentsTable;

public class EditStudentsTableCommandHandler : IRequestHandler<EditStudentsTableCommand, EditStudentsTableCommandResult>
{
    private readonly IAppDbContext dbContext;

    public EditStudentsTableCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

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
            .ThenInclude(s => s.QualificationWorkRole);

        var student = await studentsQuery.SingleOrDefaultAsync(cancellationToken)
                      ?? throw new DomainException("Student not found");

        await SetQualificationWorkAsync(student, request);

        // var qualificationWorkStage = student.QualificationWork?.Stages.SingleOrDefault(st => st.StageId == stage.Id);
        // var qualificationWork = student.QualificationWork == null
        //     ? null
        //     : new GetStudentsTableQueryQualificationWork(
        //         student.QualificationWork.Id,
        //         qualificationWorkStage?.TopicName,
        //         student.QualificationWork.Status.ToString(),
        //         qualificationWorkStage?.CompanyName,
        //         qualificationWorkStage?.CompanySupervisorName);
        // var role = qualificationWorkStage?.QualificationWorkRole?.Role;
        // var supervisor = qualificationWorkStage?.Supervisor == null
        //     ? null
        //     : new GetStudentsTableQuerySupervisor(
        //         qualificationWorkStage.Supervisor.Id,
        //         qualificationWorkStage.Supervisor.FullName);
        // var data = GetStageData(student, stage, qualificationWorkStage);
        //
        // new GetStudentsTableQueryStudent(
        //     student.Id,
        //     student.User!.FullName,
        //     student.AcademicGroup?.Name,
        //     qualificationWork,
        //     role,
        //     supervisor,
        //     student.Status.ToString(),
        //     data
        // );

        return new EditStudentsTableCommandResult(request.StudentId);
    }

    private async Task SetQualificationWorkAsync(Student student, EditStudentsTableCommand request)
    {
        if (student.QualificationWork is null)
            return;
        var stage = await dbContext.Stages.SingleOrDefaultAsync(s => s.Name == request.Stage)
                    ?? throw new DomainException("Stage not found");
        var qualificationWorkStage = student.QualificationWork?.Stages.SingleOrDefault(st => st.StageId == stage.Id);

        var role = await dbContext.QualificationWorkRoles.FirstOrDefaultAsync(r => r.Role == request.Role);
        qualificationWorkStage.QualificationWorkRoleId = role.Id;

    }

    private IGetStudentsTableQueryStageData GetStageData(
        Student student,
        Stage stage,
        QualificationWorkStage? qualificationWorkStage)
    {
        var docs = student.QualificationWork?.Documents
            .Select(d => new GetStudentsTableQueryFormattingReviewStageDataDocument(d.Name, d.Status.ToString()))
            .ToList();
        return stage.Type switch
        {
            StageType.Defence => new GetStudentsTableQueryDefenceStageData(qualificationWorkStage?.Mark,
                qualificationWorkStage?.Result, qualificationWorkStage?.Comment, qualificationWorkStage?.TopicName,
                qualificationWorkStage?.IsCommand, qualificationWorkStage?.Date, qualificationWorkStage?.Time),
            StageType.PreDefence => new GetStudentsTableQueryPreDefenceStageData(qualificationWorkStage?.Mark,
                qualificationWorkStage?.Result, qualificationWorkStage?.Comment, qualificationWorkStage?.TopicName,
                qualificationWorkStage?.IsCommand, qualificationWorkStage?.Date, qualificationWorkStage?.Time),
            StageType.FormattingReview => new GetStudentsTableQueryFormattingReviewStageData(docs ?? [],
                qualificationWorkStage?.Result),
            _ => throw new ArgumentOutOfRangeException(nameof(stage))
        };
    }
}