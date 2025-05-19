using System.Diagnostics.CodeAnalysis;
using Graduation.Application.Extensions;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Commissions;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Table.GetStudentsTable;

public class GetStudentsTableQueryHandler : IRequestHandler<GetStudentsTableQuery, GetStudentsTableQueryResult>
{
    private readonly IAppDbContext dbContext;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<User> userManager;

    public GetStudentsTableQueryHandler(IAppDbContext dbContext, ILoggedUserAccessor userAccessor,
        UserManager<User> userManager)
    {
        this.dbContext = dbContext;
        this.userAccessor = userAccessor;
        this.userManager = userManager;
    }

    public async Task<GetStudentsTableQueryResult> Handle(GetStudentsTableQuery request,
        CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await userManager.FindByIdAsync(userId.ToString());
        var roles = await userManager.GetRolesAsync(user!);
        if (!roles.Contains(WellKnownRoles.HeadSecretary) && !roles.Contains(WellKnownRoles.Admin))
        {
            request.Commissions.Clear();
            var secretaryCommission =
                await dbContext.Commissions.FirstOrDefaultAsync(c => c.SecretaryId == userId, cancellationToken);
            if (secretaryCommission == null)
                throw new DomainException("Привязанных комиссий не найдено");
            request.Commissions.Add(secretaryCommission.Name);
        }

        var stage = await dbContext.Stages.SingleOrDefaultAsync(s => s.Name == request.Stage,
                        cancellationToken)
                    ?? throw new DomainException("Stage not found");

        var usersCount = await GetStudentsQuery(request, stage).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var studentsQuery = GetStudentsQuery(request, stage)
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .ThenInclude(ag => ag!.Commission)
            .ThenInclude(c => c!.Secretary)
            .Include(s => s.CommissionStudents)
            .ThenInclude(cs => cs.Commission)
            .ThenInclude(c => c!.Secretary)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.Supervisor)
            .Include(s => s.QualificationWork)
            .ThenInclude(qw => qw!.Stages)
            .ThenInclude(s => s.QualificationWorkRole);

        var stagePreparedQuery = PrepareForStage(studentsQuery, stage);
        var sortedQuery = Sort(stagePreparedQuery, request.Sort, stage);

        var students = await sortedQuery.Skip(request.Page * request.PageSize)
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

    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
    private IQueryable<Student> Sort(IQueryable<Student> query, IList<SortStatus> sortStatuses, Stage stage)
    {
        var orderedQuery = query.OrderBy(x => 0);
        foreach (var sortStatus in sortStatuses)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            switch (sortStatus.Field)
            {
                case "student":
                    orderedQuery = orderedQuery.ThenBy(s =>
                        string.Join(' ', s.User!.LastName, s.User.FirstName, s.User.Patronymic), sortStatus.Sort);
                    break;
                case "academicGroup":
                    orderedQuery = orderedQuery
                        .ThenBy(s => s.AcademicGroup!.Name == null)
                        .ThenBy(s => s.AcademicGroup!.Name, sortStatus.Sort);
                    break;
                case "status":
                    orderedQuery = orderedQuery.ThenBy(s => s.Status, sortStatus.Sort);
                    break;
                case "topicStatus":
                    orderedQuery = orderedQuery
                        .ThenBy(s => s.QualificationWork!.Status == null)
                        .ThenBy(s => s.QualificationWork!.Status, sortStatus.Sort);
                    break;
                case "role":
                    orderedQuery = orderedQuery
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.QualificationWorkRole!.Role == null)
                        .ThenBy(s => s.QualificationWork!.Stages
                                .SingleOrDefault(qws => qws.StageId == stage.Id)!.QualificationWorkRole!.Role,
                            sortStatus.Sort);
                    break;
                case "supervisor":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Supervisor ==
                            null)
                        .ThenBy(s =>
                                string.Join(' ',
                                    s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!
                                        .Supervisor!
                                        .LastName,
                                    s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!
                                        .Supervisor!
                                        .FirstName,
                                    s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!
                                        .Supervisor!
                                        .Patronymic)
                            , sortStatus.Sort);
                    break;
                case "date":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Date == null)
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Time == null)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.Date, sortStatus.Sort)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.Time, sortStatus.Sort);
                    break;
                case "time":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Time == null)
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Date == null)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.Time, sortStatus.Sort)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.Date, sortStatus.Sort);
                    break;
                case "isCommand":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.IsCommand ==
                            null)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.IsCommand, sortStatus.Sort);
                    break;
                case "mark":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Mark == null)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.Mark, sortStatus.Sort);
                    break;
                case "result":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.Result == null)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.Result, sortStatus.Sort);
                    break;
                case "topic":
                    orderedQuery = orderedQuery
                        .ThenBy(s =>
                            s.QualificationWork!.Stages.SingleOrDefault(qws => qws.StageId == stage.Id)!.TopicName ==
                            null)
                        .ThenBy(s => s.QualificationWork!.Stages
                            .SingleOrDefault(qws => qws.StageId == stage.Id)!.TopicName, sortStatus.Sort);
                    break;
            }
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
        }

        orderedQuery = orderedQuery.ThenBy(s =>
            string.Join(' ', s.User!.LastName, s.User.FirstName, s.User.Patronymic));

        return orderedQuery;
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
                s.QualificationWork!.Stages.Where(st => st.StageId == stage.Id)
                    .Any(st =>
                        EF.Functions.ILike(st.TopicName, p) ||
                        dbContext.Users
                            .Where(u => u.Id == st.SupervisorId)
                            .Any(u =>
                                EF.Functions.ILike(u.FirstName!, p) ||
                                EF.Functions.ILike(u.LastName!, p) ||
                                EF.Functions.ILike(u.Patronymic!, p)))
            ))
            .Where(s => request.FromDate == null || s.QualificationWork!.Stages.Where(st => st.StageId == stage.Id)
                .Any(st => st.Date >= request.FromDate))
            .Where(s => request.ToDate == null || s.QualificationWork!.Stages.Where(st => st.StageId == stage.Id)
                .Any(st => st.Date <= request.ToDate))
            .Where(s => request.StudentStatuses.Count == 0 || request.StudentStatuses.Any(status => s.Status == status))
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

    private GetStudentsTableQueryCommission GetCommission(Student student, Stage stage, IList<string> commissions)
    {
        var realCommission = student.CommissionStudents.SingleOrDefault(c => c.StageId == stage.Id)?.Commission;
        var academicGroupCommission = student.AcademicGroup?.Commission;

        if (realCommission == null)
            return new GetStudentsTableQueryCommission(
                academicGroupCommission?.Name,
                academicGroupCommission?.Secretary?.GetInitials(),
                academicGroupCommission?.Name,
                academicGroupCommission?.Secretary?.GetInitials(),
                "Default");

        var movementStatus = GetMovementStatus(realCommission, academicGroupCommission, commissions);

        return new GetStudentsTableQueryCommission(
            realCommission.Name,
            realCommission.Secretary?.GetInitials(),
            academicGroupCommission?.Name,
            academicGroupCommission?.Secretary?.GetInitials(),
            movementStatus);
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

        if (commissions.Count == 0 || (commissions.Contains(academicGroupCommission.Name) &&
                                       commissions.Contains(realCommission.Name)))
            return "Transferred";

        return commissions.Contains(realCommission.Name) ? "Ingoing" : "Outgoing";
    }
}