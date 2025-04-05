using Graduation.Application.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Years.GetYears;

public class GetYearsQueryHandler : IRequestHandler<GetYearsQuery, GetYearsQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetYearsQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetYearsQueryResult> Handle(GetYearsQuery request, CancellationToken cancellationToken)
    {
        var years = await dbContext.Years
            .Select(y => y.YearName)
            .ToListAsync(cancellationToken);

        return new GetYearsQueryResult(years);
    }
}