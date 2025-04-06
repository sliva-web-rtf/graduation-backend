using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Stages;
using Graduation.Domain.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Students.GetStudentsTable;

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
        var usersCount = await GetStudentsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var stage = await dbContext.Stages.SingleOrDefaultAsync(s => s.Name == request.Stage,
                        cancellationToken)
                    ?? throw new DomainException("Stage not found");

        var studentsQuery = GetStudentsQuery(request)
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .Include(s => s.QualificationWork)
            .ThenInclude(s => s!.Topic)
            .ThenInclude(t => t!.UserRoleTopics)
            .ThenInclude(urt => urt.QualificationWorkRole)
            .Include(s => s.QualificationWork)
            .ThenInclude(s => s!.Supervisor);

        var stagePreparedQuery = PrepareForStage(studentsQuery, stage);

        var students = await stagePreparedQuery.Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedStudents = students.Select(s =>
            {
                var qualificationWork = s.QualificationWork == null
                    ? null
                    : new GetStudentsTableQueryQualificationWork(
                        s.QualificationWork.Id,
                        s.QualificationWork.Name,
                        s.QualificationWork.Status.ToString(),
                        s.QualificationWork.CompanyName,
                        s.QualificationWork.CompanySupervisorName);
                var role = s.QualificationWork?.Topic!.UserRoleTopics
                    .SingleOrDefault(urt => urt.UserId == s.Id)?.QualificationWorkRole?.Role;
                var supervisor = s.QualificationWork?.Supervisor == null
                    ? null
                    : new GetStudentsTableQuerySupervisor(
                        s.QualificationWork.Supervisor.Id,
                        s.QualificationWork.Supervisor.FullName);
                var data = GetStageData(s, stage);

                return new GetStudentsTableQueryStudent(
                    s.Id,
                    s.User!.FullName,
                    s.AcademicGroup?.Name,
                    qualificationWork,
                    role,
                    supervisor,
                    s.Status.ToString(),
                    data
                );
            })
            .ToList();

        return new GetStudentsTableQueryResult(formattedStudents, stage.Type.ToString(), pagesCount);
    }

    private IQueryable<Student> GetStudentsQuery(GetStudentsTableQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Students
            .Where(s => s.User!.UserRoles.Any(ur => ur.Year == request.Year && ur.Role!.Name == WellKnownRoles.Student))
            .Where(s => queryParts.All(p =>
                s.User!.FirstName == null || EF.Functions.ILike(s.User.FirstName, p) ||
                s.User.LastName == null || EF.Functions.ILike(s.User.LastName, p) ||
                s.User.Patronymic == null || EF.Functions.ILike(s.User.Patronymic, p) ||
                s.AcademicGroup == null || EF.Functions.ILike(s.AcademicGroup.Name, p) ||
                s.QualificationWork == null || EF.Functions.ILike(s.QualificationWork.Name, p)
            ));
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

    private IGetStudentsTableQueryStageData GetStageData(Student student, Stage stage)
    {
        var qualificationWorkStage = student.QualificationWork?.Stages.SingleOrDefault();
        var docs = student.QualificationWork?.Documents?
            .Select(d => new GetStudentsTableQueryFormattingReviewStageDataDocument(d.Name, d.Status.ToString()))
            .ToList();
        return stage.Type switch
        {
            StageType.Defence => new GetStudentsTableQueryDefenceStageData(qualificationWorkStage?.Mark,
                qualificationWorkStage?.Result, qualificationWorkStage?.Comment, qualificationWorkStage?.TopicName,
                qualificationWorkStage?.IsCommand),
            StageType.PreDefence => new GetStudentsTableQueryPreDefenceStageData(qualificationWorkStage?.Mark,
                qualificationWorkStage?.Result, qualificationWorkStage?.Comment, qualificationWorkStage?.TopicName,
                qualificationWorkStage?.IsCommand),
            StageType.FormattingReview => new GetStudentsTableQueryFormattingReviewStageData(docs ?? []),
            _ => throw new ArgumentOutOfRangeException(nameof(stage))
        };
    }
}