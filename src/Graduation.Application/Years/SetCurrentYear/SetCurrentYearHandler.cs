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
        var year = dbContext.Years.SingleOrDefault(y => y.YearName == request.Year)
                   ?? throw new DomainException("Year does not exist");

        year.IsCurrent = true;

        var currentYear = await dbContext.Years.SingleAsync(cancellationToken);
        currentYear.IsCurrent = false;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}