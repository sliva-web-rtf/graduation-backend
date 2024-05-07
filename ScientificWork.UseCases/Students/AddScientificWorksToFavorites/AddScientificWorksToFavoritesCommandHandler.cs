using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.AddScientificWorksToFavorites;

public class AddScientificWorksToFavoritesCommandHandler : IRequestHandler<AddScientificWorksToFavoritesCommand>
{
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;

    public AddScientificWorksToFavoritesCommandHandler(ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    public async Task Handle(AddScientificWorksToFavoritesCommand request, CancellationToken cancellationToken)
    {
        var studentId = userAccessor.GetCurrentUserId();
        // var student = await studentManager.FindByIdAsync(request.StudentId.ToString());
        var curStudent = await studentManager.Users
            .Where(p => p.Id == studentId)
            //.Include(x => x.FavoriteStudents)
            .FirstOrDefaultAsync(cancellationToken);

        if (curStudent != null)
        {
            curStudent.AddFavoriteStudent(request.ScientificWorksId);
        }
        else
        {
            throw new Exception($"Нет профессора с таким id: {studentId}");
        }
    }
}
