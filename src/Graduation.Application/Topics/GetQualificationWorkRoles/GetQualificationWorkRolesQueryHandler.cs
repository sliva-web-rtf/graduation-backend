using Graduation.Application.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetQualificationWorkRoles;

public class GetQualificationWorkRolesQueryHandler
    : IRequestHandler<GetQualificationWorkRolesQuery, GetQualificationWorkRolesQueryResult>
{
    private readonly IAppDbContext appDbContext;

    public GetQualificationWorkRolesQueryHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<GetQualificationWorkRolesQueryResult> Handle(GetQualificationWorkRolesQuery request,
        CancellationToken cancellationToken)
    {
        var academicPrograms = await appDbContext.QualificationWorkRoles
            .Select(p => p.Role)
            .ToListAsync(cancellationToken);

        return new GetQualificationWorkRolesQueryResult(academicPrograms);
    }
}