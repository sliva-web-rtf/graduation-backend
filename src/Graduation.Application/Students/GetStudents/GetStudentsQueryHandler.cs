using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Students.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, GetStudentsQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetStudentsQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetStudentsQueryResult> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var usersCount = await GetStudentsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var students = await GetStudentsQuery(request)
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .ThenInclude(g => g!.AcademicProgram)
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedStudents = students.Select(s => new GetStudentsQueryStudent(
                s.Id,
                s.User!.FullName,
                s.AcademicGroup?.Name,
                s.AcademicGroup?.AcademicProgram?.Name,
                s.User.About
            ))
            .ToList();

        return new GetStudentsQueryResult(formattedStudents, pagesCount);
    }

    private IQueryable<Student> GetStudentsQuery(GetStudentsQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Students
            .Where(s => s.User!.UserRoles.Any(ur => ur.Year == request.Year && ur.Role!.Name == WellKnownRoles.Student))
            .Where(s => queryParts.All(p =>
                EF.Functions.ILike(s.User!.FirstName!, p) ||
                EF.Functions.ILike(s.User.LastName!, p) ||
                EF.Functions.ILike(s.User.Patronymic!, p)));
    }
}