using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Favorites.Enums;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Professors.ToggleScientificWorksToFavorites;

public class ToggleScientificWorksToFavoritesCommandHandler : IRequestHandler<ToggleScientificWorksToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Professor> professorManager;

    public ToggleScientificWorksToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Professor> professorManager)
    {
        this.userAccessor = userAccessor;
        this.professorManager = professorManager;
    }

    public async Task Handle(ToggleScientificWorksToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var professorId = userAccessor.GetCurrentUserId();
        var curProfessor = await professorManager.Users
            .Where(p => p.Id == professorId)
            .Include(p => p.ProfessorFavoriteScientificWorks)
            .FirstOrDefaultAsync(cancellationToken);

        if (curProfessor != null)
        {
            if (request.ToggleEnum == ToggleEnum.Activate)
            {
                curProfessor.AddFavoriteScientificWork(request.ScientificWorksId);
            }
            else
            {
                curProfessor.RemoveFavoriteScientificWork(request.ScientificWorksId);
            }
            await professorManager.UpdateAsync(curProfessor);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {professorId}");
        }
    }
}
