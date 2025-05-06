using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.GetCommissionsForEditing;

public class GetCommissionsForEditingQueryHandler(
    IAppDbContext dbContext,
    ILoggedUserAccessor userAccessor,
    UserManager<User> userManager)
    : IRequestHandler<GetCommissionsForEditingQuery, GetCommissionsForEditingQueryResult>
{
    public async Task<GetCommissionsForEditingQueryResult> Handle(GetCommissionsForEditingQuery request,
        CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var user = await userManager.FindByIdAsync(userId.ToString());
        var userRoles = await userManager.GetRolesAsync(user!);
        var isSecretary = !userRoles.Any(r => r is WellKnownRoles.HeadSecretary or WellKnownRoles.Admin);

        var commissions = await dbContext.Commissions
            .Include(c => c.Secretary)
            .Include(c => c.Chairperson)
            .Include(c => c.AcademicGroups)
            .Where(c => c.Year == request.Year)
            .Where(c => !isSecretary || c.SecretaryId == userId)
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);

        var formattedCommissions = commissions
            .Select(c =>
                new GetCommissionsForEditingQueryResultCommission(
                    c.Id,
                    c.Name,
                    c.Secretary!.FullName,
                    c.Chairperson?.FullName,
                    c.AcademicGroups.Select(ag => ag.Name).ToList()))
            .ToList();

        return new GetCommissionsForEditingQueryResult(formattedCommissions);
    }
}