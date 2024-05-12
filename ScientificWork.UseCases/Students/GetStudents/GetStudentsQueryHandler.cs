using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, GetStudentsResult>
{
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetStudentsQueryHandler(IMapper mapper, UserManager<Student> studentManager,
        ILoggedUserAccessor userAccessor, UserManager<Professor> professorManager)
    {
        this.mapper = mapper;
        this.studentManager = studentManager;
        this.userAccessor = userAccessor;
        this.professorManager = professorManager;
    }

    /// <inheritdoc />
    public async Task<GetStudentsResult> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = studentManager.Users
            .Where(x => x.Id != userAccessor.GetCurrentUserId())
            .Where(x => x.IsRegistrationComplete == true);

        if (request.ScientificAreaSubsections != null)
        {
            students = FilterByScientificAreaSubsections(students, request.ScientificAreaSubsections);
        }

        if (request.ScientificInterests != null)
        {
            students = FilterByScientificInterests(students, request.ScientificInterests);
        }

        var studentsResult = await students
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificWorks)
            .ToListAsync(cancellationToken: cancellationToken);

        var favorites = await GetFavoritesStudentsAsync();

        var studentDto = mapper.Map<List<StudentDto>>(studentsResult)
            .Select(s =>
            {
                s.IsFavorite = favorites.Contains(s.Id);
                return s;
            });

        if (request.IsFavoriteFilterOnly)
        {
            studentDto = studentDto.Where(x => x.IsFavorite);
        }

        if (request.IsFavoriteFilter)
        {
            studentDto = studentDto.OrderByDescending(x => x.IsFavorite);
        }

        var resStudents = PagedListFactory.FromSource(studentDto,
            page: request.Page, pageSize: request.PageSize);

        return new GetStudentsResult { Students = resStudents, Length = resStudents.Count(), Page = request.Page };
    }

    private async Task<HashSet<Guid>> GetFavoritesStudentsAsync()
    {
        var userId = userAccessor.GetCurrentUserId();
        var curUser = await studentManager.FindByIdAsync(userId.ToString());
        var favorites = new HashSet<Guid>();
        if (curUser == null)
        {
            favorites = professorManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.ProfessorFavoriteStudents)
                .SelectMany(s => s.ProfessorFavoriteStudents)
                .Where(x => x.IsActive)
                .Select(s => s.StudentId)
                .ToHashSet();
        }
        else
        {
            favorites = studentManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.StudentFavoriteStudents)
                .SelectMany(s => s.StudentFavoriteStudents)
                .Where(x => x.IsActive)
                .Select(s => s.FavoriteStudentId)
                .ToHashSet();
        }
        return favorites;
    }

    private IQueryable<Student> FilterByScientificAreaSubsections(IQueryable<Student> students, IList<string> scientificAreaSubsections)
    {
        students = students
            .Include(x => x.ScientificAreaSubsections)
            .Where(student => student.ScientificAreaSubsections
                .Any(subsection => scientificAreaSubsections.Contains(subsection.Name)));

        return students;
    }

    private IQueryable<Student> FilterByScientificInterests(IQueryable<Student> students, IList<string> scientificInterests)
    {
        students = students
            .Include(x => x.ScientificInterests)
            .Where(student => student.ScientificInterests
                .Any(interest => scientificInterests.Contains(interest.Name)));

        return students;
    }
}
