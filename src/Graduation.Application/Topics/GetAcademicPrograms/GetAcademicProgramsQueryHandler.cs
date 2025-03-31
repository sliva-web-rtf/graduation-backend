using Graduation.Application.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Topics.GetAcademicPrograms;

public class GetAcademicProgramsQueryHandler : IRequestHandler<GetAcademicProgramsQuery, GetAcademicProgramsQueryResult>
{
    private readonly IAppDbContext appDbContext;

    public GetAcademicProgramsQueryHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<GetAcademicProgramsQueryResult> Handle(GetAcademicProgramsQuery request,
        CancellationToken cancellationToken)
    {
        var academicPrograms = await appDbContext.AcademicPrograms
            .Select(p => p.Name)
            .ToListAsync(cancellationToken);

        return new GetAcademicProgramsQueryResult(academicPrograms);
    }
}