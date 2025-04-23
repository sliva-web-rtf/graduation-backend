using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Commissions;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Table.GetStudentsTable;

public class GetStudentsTableQueryHandler : IRequestHandler<GetStudentsTableQuery, GetStudentsTableQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetStudentsTableQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetStudentsTableQueryResult> Handle(GetStudentsTableQuery request,
        CancellationToken cancellationToken)
    {
        var stage = await dbContext.Stages.SingleOrDefaultAsync(s => s.Name == request.Stage,
                        cancellationToken)
                    ?? throw new DomainException("Stage not found");

        var usersCount = await GetStudentsQuery(request, stage).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var studentsQuery = GetStudentsQuery(request, stage)
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .Include(s => s.CommissionStudents)
            .ThenInclude(cs => cs.Commission)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.Supervisor)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.QualificationWorkRole);

        var stagePreparedQuery = PrepareForStage(studentsQuery, stage);

        var students = await stagePreparedQuery.Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedStudents = students.Select(s =>
            {
                var qualificationWorkStage = s.QualificationWork?.Stages.SingleOrDefault(st => st.StageId == stage.Id);
                var qualificationWork = s.QualificationWork == null
                    ? null
                    : new GetStudentsTableQueryQualificationWork(
                        s.QualificationWork.Id,
                        qualificationWorkStage?.TopicName,
                        s.QualificationWork.Status.ToString(),
                        qualificationWorkStage?.CompanyName,
                        qualificationWorkStage?.CompanySupervisorName);
                var role = qualificationWorkStage?.QualificationWorkRole?.Role;
                var supervisor = qualificationWorkStage?.Supervisor == null
                    ? null
                    : new GetStudentsTableQuerySupervisor(
                        qualificationWorkStage.Supervisor.Id,
                        qualificationWorkStage.Supervisor.FullName);
                var data = GetStageData(s, stage, qualificationWorkStage);
                var commission = GetCommission(s, stage, request.Commissions);

                return new GetStudentsTableQueryStudent(
                    s.Id,
                    s.User!.FullName,
                    s.AcademicGroup?.Name,
                    qualificationWork,
                    role,
                    supervisor,
                    s.Status.ToString(),
                    commission,
                    s.Comment,
                    data
                );
            })
            .ToList();

        return new GetStudentsTableQueryResult(formattedStudents, stage.Type.ToString(), pagesCount);
    }

    private IQueryable<Student> GetStudentsQuery(GetStudentsTableQuery request, Stage stage)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Students
            .Where(s => s.User!.UserRoles.Any(ur => ur.Year == request.Year && ur.Role!.Name == WellKnownRoles.Student))
            .Where(s => queryParts.All(p =>
                EF.Functions.ILike(s.User!.FirstName!, p) ||
                EF.Functions.ILike(s.User.LastName!, p) ||
                EF.Functions.ILike(s.User.Patronymic!, p) ||
                EF.Functions.ILike(s.AcademicGroup!.Name, p) ||
                s.QualificationWork!.Stages.Any(st => st.StageId == stage.Id && EF.Functions.ILike(st.TopicName, p))
            ))
            .Where(s => request.Commissions.Count == 0 || request.Commissions
                .Any(c => s.AcademicGroup!.Commission!.Name == c ||
                          s.CommissionStudents.Any(st => st.StageId == stage.Id && st.Commission!.Name == c)));
    }

    private IQueryable<Student> PrepareForStage(IQueryable<Student> query, Stage stage)
    {
        query = stage.Type switch
        {
            StageType.FormattingReview => query.Include(s => s.QualificationWork!.Documents),
            StageType.PreDefence => query.Include(s =>
                s.QualificationWork!.Stages.Where(qws => qws.StageId == stage.Id)),
            StageType.Defence => query.Include(s =>
                s.QualificationWork!.Stages.Where(qws => qws.StageId == stage.Id)),
            _ => query
        };

        return query;
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
                qualificationWorkStage?.IsCommand, qualificationWorkStage?.Location, qualificationWorkStage?.Date,
                qualificationWorkStage?.Time),
            StageType.PreDefence => new GetStudentsTableQueryPreDefenceStageData(qualificationWorkStage?.Mark,
                qualificationWorkStage?.Result, qualificationWorkStage?.Comment, qualificationWorkStage?.TopicName,
                qualificationWorkStage?.IsCommand, qualificationWorkStage?.Location, qualificationWorkStage?.Date,
                qualificationWorkStage?.Time),
            StageType.FormattingReview => new GetStudentsTableQueryFormattingReviewStageData(docs ?? [],
                qualificationWorkStage?.Result),
            _ => throw new ArgumentOutOfRangeException(nameof(stage))
        };
    }

    private GetStudentsTableQueryCommission? GetCommission(Student student, Stage stage, IList<string> commissions)
    {
        var realCommission = student.CommissionStudents.SingleOrDefault(c => c.StageId == stage.Id)?.Commission;
        var academicGroupCommission = student.AcademicGroup?.Commission;

        if (realCommission == null)
            return null;

        var movementStatus = commissions.Count > 0 
            ? GetMovementStatus(realCommission, academicGroupCommission, commissions) 
            : "Default";

        return new GetStudentsTableQueryCommission(realCommission.Name, movementStatus);
    }

    private string GetMovementStatus(
        Commission realCommission,
        Commission? academicGroupCommission,
        IList<string> commissions)
    {
        if (academicGroupCommission is null)
            return "Ingoing";

        if (realCommission.Name == academicGroupCommission.Name)
            return "Default";

        if (commissions.Contains(academicGroupCommission.Name) && commissions.Contains(realCommission.Name))
            return "Default";

        return commissions.Contains(realCommission.Name) ? "Ingoing" : "Outgoing";
    }
}