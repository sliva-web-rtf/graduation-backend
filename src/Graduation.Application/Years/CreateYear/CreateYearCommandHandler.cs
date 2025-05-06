using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Years;
using MediatR;

namespace Graduation.Application.Years.CreateYear;

public class CreateYearCommandHandler(IAppDbContext dbContext, IEventsCreator eventsCreator) : IRequestHandler<CreateYearCommand>
{
    public async Task Handle(CreateYearCommand request, CancellationToken cancellationToken)
    {
        await eventsCreator.Create("User tried to create year", request);
        
        var year = new Year(request.Year);
        dbContext.Years.Add(year);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}