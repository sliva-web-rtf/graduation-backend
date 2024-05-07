using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.AddProfessorToFavorites;

public class AddProfessorToFavoritesCommandHandler : IRequestHandler<AddProfessorToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;

    public AddProfessorToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    public async Task Handle(AddProfessorToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();
        // var student = await studentManager.FindByIdAsync(request.StudentId.ToString());
        var curStudent = await studentManager.Users
            .Where(p => p.Id == studentId)
            //.Include(x => x.FavoriteStudents)
            .FirstOrDefaultAsync(cancellationToken);

        if (curStudent != null)
        {
            curStudent.AddFavoriteStudent(request.ProfessorId);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {studentId}");
        }
    }
}
