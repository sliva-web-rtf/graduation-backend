using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Favorites.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.ToggleScientificWorksToFavorites;

public class ToggleScientificWorksToFavoritesCommandHandler : IRequestHandler<ToggleScientificWorksToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;

    public ToggleScientificWorksToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    public async Task Handle(ToggleScientificWorksToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();
        var curStudent = await studentManager.Users
            .Where(p => p.Id == studentId)
            .Include(s => s.StudentFavoriteScientificWorks)
            .FirstOrDefaultAsync(cancellationToken);

        if (curStudent != null)
        {
            if (request.ToggleEnum == ToggleEnum.Activate)
            {
                curStudent.AddFavoriteScientificWork(request.ScientificWorksId);
            }
            else
            {
                curStudent.RemoveFavoriteScientificWork(request.ScientificWorksId);
            }
            await studentManager.UpdateAsync(curStudent);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {studentId}");
        }
    }
}
