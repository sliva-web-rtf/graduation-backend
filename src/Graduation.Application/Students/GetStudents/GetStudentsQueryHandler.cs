using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Students.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, GetStudentsQueryResult>
{
    private readonly IAppDbContext dbContext;
    private readonly ICurrentYearProvider currentYearProvider;

    public GetStudentsQueryHandler(IAppDbContext dbContext, ICurrentYearProvider currentYearProvider)
    {
        this.dbContext = dbContext;
        this.currentYearProvider = currentYearProvider;
    }

    public async Task<GetStudentsQueryResult> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();
        var students = await dbContext.Students
            .Include(s => s.User)
            .Include(s => s.AcademicGroup)
            .ThenInclude(g => g!.AcademicProgram)
            .Where(s => s.User.UserRoles.Any(ur => ur.Year == year && ur.Role!.Name == WellKnownRoles.Student))
            .Where(s => queryParts.All(p =>
                s.User.FirstName == null || EF.Functions.ILike(s.User.FirstName, p) ||
                s.User.LastName == null || EF.Functions.ILike(s.User.LastName, p) ||
                s.User.Patronymic == null || EF.Functions.ILike(s.User.Patronymic, p)))
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedStudents = students.Select(s => new GetStudentsQueryStudent(
                s.Id,
                s.User.FullName,
                s.AcademicGroup?.Name,
                s.AcademicGroup?.AcademicProgram?.Name,
                s.User.About
            ))
            .ToList();

        return new GetStudentsQueryResult(formattedStudents);
    }
}