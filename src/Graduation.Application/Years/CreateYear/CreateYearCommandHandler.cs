using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain.Years;
using MediatR;

namespace Graduation.Application.Years.CreateYear;

public class CreateYearCommandHandler : IRequestHandler<CreateYearCommand>
{
    private readonly IAppDbContext dbContext;

    public CreateYearCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Handle(CreateYearCommand request, CancellationToken cancellationToken)
    {
        var year = new Year(request.Year);
        dbContext.Years.Add(year);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}