using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Professors.AddScientificWorksToFavorites;

public class AddScientificWorksToFavoritesCommandHandler : IRequestHandler<AddScientificWorksToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Professor> professorManager;

    public AddScientificWorksToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Professor> professorManager)
    {
        this.userAccessor = userAccessor;
        this.professorManager = professorManager;
    }

    public async Task Handle(AddScientificWorksToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var professorId = userAccessor.GetCurrentUserId();
        var curProfessor = await professorManager.Users
            .Where(p => p.Id == professorId)
            .FirstOrDefaultAsync(cancellationToken);

        if (curProfessor != null)
        {
            curProfessor.AddFavoriteScientificWork(request.ScientificWorksId);
            await professorManager.UpdateAsync(curProfessor);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {professorId}");
        }
    }
}
