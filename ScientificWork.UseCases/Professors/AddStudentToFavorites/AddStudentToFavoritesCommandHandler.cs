using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Professors.AddStudentToFavorites;

public class AddStudentToFavoritesCommandHandler : IRequestHandler<AddStudentToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;

    public AddStudentToFavoritesCommandHandler(UserManager<Student> studentManager, UserManager<Professor> professorManager, ILoggedUserAccessor userAccessor)
    {
        this.studentManager = studentManager;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(AddStudentToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var professorId = userAccessor.GetCurrentUserId();
        // var student = await studentManager.FindByIdAsync(request.StudentId.ToString());
        var curProfessor = await professorManager.Users
            .Where(p => p.Id == professorId)
            //.Include(x => x.FavoriteStudents)
            .FirstOrDefaultAsync(cancellationToken);

        if (curProfessor != null)
        {
            curProfessor.AddFavoriteStudent(request.StudentId);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {professorId}");
        }
    }
}
