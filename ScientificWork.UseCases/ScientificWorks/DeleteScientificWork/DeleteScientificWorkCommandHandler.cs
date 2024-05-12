using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificWorks.DeleteScientificWork;

public class DeleteScientificWorkCommandHandler : IRequestHandler<DeleteScientificWorkCommand>
{
    private readonly IAppDbContext dbContext;

    public DeleteScientificWorkCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Handle(DeleteScientificWorkCommand request, CancellationToken cancellationToken)
    {
        var sw = await dbContext.ScientificWorks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (sw != null)
        {
            dbContext.ScientificWorks.Remove(sw);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
