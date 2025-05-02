using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Years.SetCurrentYear;

public class SetCurrentYearHandler(IAppDbContext dbContext, IEventsCreator eventsCreator) : IRequestHandler<SetCurrentYear>
{
    public async Task Handle(SetCurrentYear request, CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried to set current year", request);
        
        var year = await dbContext.Years.SingleOrDefaultAsync(y => y.YearName == request.Year, cancellationToken)
                   ?? throw new DomainException("Year does not exist");

        var currentYear = await dbContext.Years.SingleAsync(y => y.IsCurrent == true, cancellationToken);

        currentYear.IsCurrent = false;
        year.IsCurrent = true;
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}