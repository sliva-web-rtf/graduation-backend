using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Favorites.Enums;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Professors.ToggleStudentToFavorites;

public class ToggleStudentToFavoritesCommandHandler : IRequestHandler<ToggleStudentToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;

    public ToggleStudentToFavoritesCommandHandler(UserManager<Student> studentManager, UserManager<Professor> professorManager, ILoggedUserAccessor userAccessor)
    {
        this.studentManager = studentManager;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(ToggleStudentToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var professorId = userAccessor.GetCurrentUserId();
        var curProfessor = await professorManager.Users
            .Where(p => p.Id == professorId)
            .Include(p => p.ProfessorFavoriteStudents)
            .FirstOrDefaultAsync(cancellationToken);

        if (curProfessor != null)
        {
            if (request.ToggleEnum == ToggleEnum.Activate)
            {
                curProfessor.AddFavoriteStudent(request.StudentId);
            }
            else
            {
                curProfessor.RemoveFavoriteStudent(request.StudentId);
            }
            await professorManager.UpdateAsync(curProfessor);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {professorId}");
        }
    }
}
