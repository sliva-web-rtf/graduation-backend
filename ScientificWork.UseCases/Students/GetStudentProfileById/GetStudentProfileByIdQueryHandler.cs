using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Dtos;
using Exception = System.Exception;

namespace ScientificWork.UseCases.Students.GetStudentProfileById;

public class GetStudentProfileByIdQueryHandler : IRequestHandler<GetStudentProfileByIdQuery, GetStudentProfileByIdResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;
    private readonly ILoggedUserAccessor userAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetStudentProfileByIdQueryHandler(IMapper mapper, ILoggedUserAccessor userAccessor,
        UserManager<Student> studentManager, UserManager<Professor> professorManager)
    {
        this.mapper = mapper;
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
        this.professorManager = professorManager;
    }

    /// <inheritdoc />
    public async Task<GetStudentProfileByIdResult> Handle(GetStudentProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await GetStudentByIdAsync(request.StudentId, cancellationToken);

        var result = mapper.Map<GetStudentProfileByIdResult>(student);

        var scientificAreasDto = student.ScientificAreaSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto
            {
                Section = x.Key,
                Subsections = x.Select(s => s.Name).ToList()
            });

        foreach (var dto in scientificAreasDto)
        {
            result.ScientificArea.Add(dto);
        }

        result.IsFavorite = await CheckFavoritesStudentsAsync(request.StudentId);
        return result;
    }

    private async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await studentManager.Users
            .Where(x => x.Id == id)
            .Where(x => x.IsRegistrationComplete == true)
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificAreaSubsections)
                .ThenInclude(x => x.ScientificArea)
            .FirstAsync(cancellationToken);

        if (!await studentManager.IsInRoleAsync(student, nameof(Student).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }

    private async Task<bool> CheckFavoritesStudentsAsync(Guid studentId)
    {
        var userId = userAccessor.GetCurrentUserId();
        var curUser = await studentManager.FindByIdAsync(userId.ToString());
        bool check;

        if (curUser == null)
        {
            check = professorManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.ProfessorFavoriteStudents)
                .SelectMany(s => s.ProfessorFavoriteStudents)
                .Where(x => x.IsActive)
                .Any(s => s.StudentId == studentId);
        }
        else
        {
            check = studentManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.StudentFavoriteStudents)
                .SelectMany(s => s.StudentFavoriteStudents)
                .Where(x => x.IsActive)
                .Any(s => s.FavoriteStudentId == studentId);
        }

        return check;
    }
}
