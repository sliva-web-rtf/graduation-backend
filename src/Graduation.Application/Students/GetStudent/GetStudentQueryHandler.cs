using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Students.GetStudent;

public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, GetStudentQueryResult>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<User> userManager;

    public GetStudentQueryHandler(IAppDbContext dbContext, UserManager<User> userManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
    }

    public async Task<GetStudentQueryResult> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString())
                   ?? throw new DomainException("User not found");
        if (!await userManager.IsInRoleAsync(user, WellKnownRoles.Student))
            throw new DomainException("User is not student");

        var student = await dbContext.Students
            .Where(s => s.Id == request.Id)
            .Include(s => s.User)
            .Include(s => s.QualificationWork)
            .Include(s => s.AcademicGroup)
            .ThenInclude(s => s!.AcademicProgram)
            .FirstAsync(cancellationToken);

        var result = new GetStudentQueryResult(
            student.User!.FullName,
            student.AcademicGroup?.Name,
            student.AcademicGroup?.AcademicProgram?.Name,
            student.User.Contacts,
            student.User.About,
            student.QualificationWork?.Id);

        return result;
    }
}