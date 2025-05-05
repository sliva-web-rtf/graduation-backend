using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Students.GetCommissionStudentsForStage;

public class GetCommissionStudentsForStageQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetCommissionStudentsForStageQuery, GetCommissionStudentsForStageQueryResult>
{
    public async Task<GetCommissionStudentsForStageQueryResult> Handle(GetCommissionStudentsForStageQuery request,
        CancellationToken cancellationToken)
    {
        var usersCount = await GetStudentsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var students = GetStudentsQuery(request)
            .Include(s => s.User)
            .Include(s => s.CommissionStudents)
            .ThenInclude(s => s.Commission)
            .ThenInclude(c => c!.Secretary)
            .Include(s => s.CommissionStudents)
            .ThenInclude(s => s.Stage)
            .Include(s => s.AcademicGroup)
            .ThenInclude(g => g!.AcademicProgram)
            .Include(s => s.AcademicGroup)
            .ThenInclude(ag => ag!.Commission)
            .ThenInclude(c => c!.Secretary);

        var sortedStudents = await Sort(students, request)
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedStudents = sortedStudents.Select(s =>
            {
                var prevCommission = s.AcademicGroup?.Commission;

                var commission = s.CommissionStudents
                    .FirstOrDefault(cs => cs.Stage!.Name == request.Stage)?.Commission;

                var academicGroup = s.AcademicGroup == null
                    ? null
                    : new GetCommissionStudentsForStageQueryResultAcademicGroup(
                        s.AcademicGroup.Id,
                        s.AcademicGroup.Name);

                var formattedPrevCommission = prevCommission == null
                    ? null
                    : new GetCommissionStudentsForStageQueryResultCommission(
                        prevCommission.Id,
                        $"{prevCommission.Name} ({prevCommission.Secretary!.GetInitials()})");

                var formattedCommission = commission == null
                    ? null
                    : new GetCommissionStudentsForStageQueryResultCommission(
                        commission.Id,
                        $"{commission.Name} ({commission.Secretary!.GetInitials()})");

                var isCurrentCommission = (s.AcademicGroup?.CommissionId == null &&
                               s.CommissionStudents.All(cs => cs.Stage!.Name != request.Stage)) ||
                              s.AcademicGroup!.CommissionId == request.CommissionId ||
                              s.CommissionStudents.Any(cs =>
                                  cs.Stage!.Name == request.Stage && cs.CommissionId == request.CommissionId);

                return new GetCommissionStudentsForStageQueryResultStudent(
                    s.Id,
                    s.User!.FullName,
                    !isCurrentCommission,
                    academicGroup,
                    formattedCommission,
                    formattedPrevCommission
                );
            })
            .ToList();

        return new GetCommissionStudentsForStageQueryResult(formattedStudents, pagesCount);
    }

    private IQueryable<Student> GetStudentsQuery(GetCommissionStudentsForStageQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Students
            .Where(s => s.User!.UserRoles.Any(ur => ur.Year == request.Year && ur.Role!.Name == WellKnownRoles.Student))
            .Where(s => queryParts.All(p =>
                EF.Functions.ILike(s.User!.FirstName!, p) ||
                EF.Functions.ILike(s.User.LastName!, p) ||
                EF.Functions.ILike(s.User.Patronymic!, p)));
    }

    private IQueryable<Student> Sort(IQueryable<Student> query, GetCommissionStudentsForStageQuery request)
    {
        var sorted = query.OrderBy(s => 0);
        foreach (var group in request.SortByAcademicGroups)
            sorted = sorted.ThenByDescending(s => s.AcademicGroup!.Name == group);

        sorted = sorted.ThenByDescending(s => s.CommissionStudents
            .FirstOrDefault(cs => cs.Stage!.Name == request.Stage)!.CommissionId == request.CommissionId);

        return sorted.ThenBy(s => s.User!.LastName)
            .ThenBy(s => s.User!.FirstName)
            .ThenBy(s => s.User!.Patronymic);
    }
}