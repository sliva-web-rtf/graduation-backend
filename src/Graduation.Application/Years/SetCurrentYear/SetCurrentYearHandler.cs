using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Years.SetCurrentYear;

public class SetCurrentYearHandler : IRequestHandler<SetCurrentYear>
{
    private readonly IAppDbContext dbContext;

    public SetCurrentYearHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Handle(SetCurrentYear request, CancellationToken cancellationToken)
    {
        var year = await dbContext.Years.SingleOrDefaultAsync(y => y.YearName == request.Year, cancellationToken)
                   ?? throw new DomainException("Year does not exist");

        var currentYear = await dbContext.Years.SingleAsync(cancellationToken);

        currentYear.IsCurrent = false;
        year.IsCurrent = true;
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}