using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
using Graduation.Domain.QualificationWorks;
using Graduation.Domain.Stages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.QualificationWorks.GetQualificationWork;

public class GetQualificationWorkQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetQualificationWorkQuery, GetQualificationWorkQueryResult>
{
    public async Task<GetQualificationWorkQueryResult> Handle(GetQualificationWorkQuery request,
        CancellationToken cancellationToken)
    {
        var qualificationWork = await dbContext.QualificationWorks
            .Include(qw => qw.Student)
            .ThenInclude(s => s!.AcademicGroup)
            .ThenInclude(ag => ag!.Commission)
            .ThenInclude(c => c!.Secretary)
            .Include(qw => qw.Student)
            .ThenInclude(s => s!.AcademicGroup)
            .ThenInclude(ag => ag!.Commission)
            .ThenInclude(c => c!.Chairperson)
            .Include(qw => qw.Student)
            .ThenInclude(s => s!.AcademicGroup)
            .ThenInclude(ag => ag!.FormattingReviewer)
            .Include(qw => qw.Student)
            .ThenInclude(s => s!.User)
            .Include(qw => qw.Supervisor)
            .Include(qw => qw.QualificationWorkRole)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.Supervisor)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.QualificationWorkRole)
            .Include(qw => qw.Stages).ThenInclude(qws => qws.Commission)
            .Include(qw => qw.Documents)
            .FirstOrDefaultAsync(qw => qw.Id == request.Id, cancellationToken);

        if (qualificationWork == null)
            throw new NotFoundException("Qualification work with given id not found");

        var mainInfo = await GetMainInfo(qualificationWork);
        var stageInfo = await GetStageInfo(qualificationWork, request.Stage);
        var formattingReview = await GetFormattingReview(qualificationWork);

        return new GetQualificationWorkQueryResult(mainInfo, stageInfo, formattingReview);
    }


    private async Task<GetQualificationWorkQueryResultMainInfo> GetMainInfo(QualificationWork qualificationWork)
    {
        var student = new GetQualificationWorkQueryStudent(
            qualificationWork.Student!.Id,
            qualificationWork.Student.User!.FullName,
            qualificationWork.QualificationWorkRole?.Role);

        var supervisor = qualificationWork.Supervisor == null
            ? null
            : new GetQualificationWorkQuerySupervisor(
                qualificationWork.Supervisor.Id,
                qualificationWork.Supervisor.FullName);

        GetQualificationWorkQueryCommission? commission = null;
        if (qualificationWork.Student?.AcademicGroup?.Commission is { } commissionDbo)
        {
            var experts = await dbContext.CommissionExperts
                .Include(c => c.Expert)
                .Where(c => c.CommissionId == commissionDbo.Id)
                .ToListAsync();
            commission = new GetQualificationWorkQueryCommission(
                qualificationWork.Student.AcademicGroup.Commission.Name,
                qualificationWork.Student.AcademicGroup.Commission.Secretary!.FullName,
                qualificationWork.Student.AcademicGroup.Commission.Chairperson?.FullName,
                experts.DistinctBy(e => e.Expert)
                    .Select(e => new GetQualificationWorkQueryCommissionExpert(e.Expert!.FullName, e.IsInvited))
                    .ToList()
            );
        }

        return new GetQualificationWorkQueryResultMainInfo(
            qualificationWork.Status,
            qualificationWork.Name,
            supervisor,
            student,
            qualificationWork.CompanyName,
            qualificationWork.CompanySupervisorName,
            qualificationWork.ExpertComment,
            commission
        );
    }

    private async Task<GetQualificationWorkQueryResultStageInfo?> GetStageInfo(
        QualificationWork qualificationWork,
        string stageName)
    {
        if (await dbContext.Stages.FirstOrDefaultAsync(s => s.Name == stageName) is not { } stage)
            return null;

        if (qualificationWork.Stages.FirstOrDefault(s => s.StageId == stage.Id) is not { } qualificationWorkStage)
            return null;

        var student = new GetQualificationWorkQueryStudent(
            qualificationWork.Student!.Id,
            qualificationWork.Student.User!.FullName,
            qualificationWorkStage.QualificationWorkRole?.Role);

        var supervisor = qualificationWorkStage.Supervisor == null
            ? null
            : new GetQualificationWorkQuerySupervisor(
                qualificationWorkStage.Supervisor.Id,
                qualificationWorkStage.Supervisor.FullName);

        GetQualificationWorkQueryCommission? commission = null;
        if (qualificationWork.Student?.AcademicGroup?.Commission is { } commissionDbo)
        {
            var experts = await dbContext.CommissionExperts
                .Include(c => c.Expert)
                .Where(c => c.CommissionId == commissionDbo.Id && c.StageId == stage.Id)
                .ToListAsync();
            commission = new GetQualificationWorkQueryCommission(
                qualificationWork.Student.AcademicGroup.Commission.Name,
                qualificationWork.Student.AcademicGroup.Commission.Secretary!.FullName,
                qualificationWork.Student.AcademicGroup.Commission.Chairperson?.FullName,
                experts.DistinctBy(e => e.Expert)
                    .Select(e => new GetQualificationWorkQueryCommissionExpert(e.Expert!.FullName, e.IsInvited))
                    .ToList()
            );
        }

        return new GetQualificationWorkQueryResultStageInfo(
            commission,
            supervisor,
            student,
            qualificationWorkStage.TopicName,
            qualificationWorkStage.CompanyName,
            qualificationWorkStage.CompanySupervisorName,
            qualificationWorkStage.Location,
            qualificationWorkStage.Result,
            qualificationWorkStage.Mark,
            qualificationWorkStage.IsCommand,
            qualificationWorkStage.Comment,
            qualificationWorkStage.Date,
            qualificationWorkStage.Time
        );
    }

    private async Task<GetQualificationWorkQueryFormattingReviewStage?> GetFormattingReview(
        QualificationWork qualificationWork)
    {
        if (await dbContext.Stages.FirstOrDefaultAsync(s => s.Type == StageType.FormattingReview) is not { } stage)
            return null;

        var qualificationWorkStage = qualificationWork.Stages.FirstOrDefault(s => s.StageId == stage.Id);

        var documents = qualificationWork.Documents
            .Select(d => new GetQualificationWorkQueryFormattingReviewStageDocument(
                d.Name,
                d.Status.ToString(),
                d.FileName,
                d.DocumentPath,
                d.UploadedAt
            ))
            .ToList();

        return new GetQualificationWorkQueryFormattingReviewStage(
            documents,
            qualificationWork.Annotation,
            qualificationWorkStage?.Result,
            qualificationWork.Student!.AcademicGroup?.FormattingReviewer?.FullName
        );
    }
}