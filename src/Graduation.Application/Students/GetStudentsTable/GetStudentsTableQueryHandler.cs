using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
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

        var students = await GetStudentsQuery(request)
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .Include(s => s.QualificationWork)
            .ThenInclude(s => s!.Topic)
            .ThenInclude(t => t!.UserRoleTopics)
            .ThenInclude(urt => urt.QualificationWorkRole)
            .Include(s => s.QualificationWork)
            .ThenInclude(s => s!.Supervisor)
            .Skip(request.Page * request.PageSize)
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

                return new GetStudentsTableQueryStudent(
                    s.Id,
                    s.User!.FullName,
                    s.AcademicGroup?.Name,
                    qualificationWork,
                    role,
                    supervisor,
                    s.Status.ToString(),
                    null
                );
            })
            .ToList();

        return new GetStudentsTableQueryResult(formattedStudents, null, pagesCount);
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
}