using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Favorites.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.ToggleProfessorToFavorites;

public class ToggleProfessorToFavoritesCommandHandler : IRequestHandler<ToggleProfessorToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;

    public ToggleProfessorToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    public async Task Handle(ToggleProfessorToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();
        var curStudent = await studentManager.Users
            .Where(p => p.Id == studentId)
            .FirstOrDefaultAsync(cancellationToken);

        if (curStudent != null)
        {
            if (request.ToggleEnum == ToggleEnum.Activate)
            {
                curStudent.AddFavoriteProfessor(request.ProfessorId);
            }
            else
            {
                curStudent.RemoveFavoriteProfessor(request.ProfessorId);
            }
            await studentManager.UpdateAsync(curStudent);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {studentId}");
        }
    }
}
