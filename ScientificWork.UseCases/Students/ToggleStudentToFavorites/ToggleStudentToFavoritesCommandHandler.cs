using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Favorites.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.ToggleStudentToFavorites;

public class ToggleStudentToFavoritesCommandHandler : IRequestHandler<ToggleStudentToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;

    public ToggleStudentToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    public async Task Handle(ToggleStudentToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();
        var curStudent = await studentManager.Users
            .Where(p => p.Id == studentId)
            .Include(s => s.StudentFavoriteStudents)
            .FirstOrDefaultAsync(cancellationToken);

        if (curStudent != null)
        {
            if (request.ToggleEnum == ToggleEnum.Activate)
            {
                curStudent.AddFavoriteStudent(request.StudentId);
            }
            else
            {
                curStudent.RemoveFavoriteStudent(request.StudentId);
            }
            await studentManager.UpdateAsync(curStudent);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {studentId}");
        }
    }
}
