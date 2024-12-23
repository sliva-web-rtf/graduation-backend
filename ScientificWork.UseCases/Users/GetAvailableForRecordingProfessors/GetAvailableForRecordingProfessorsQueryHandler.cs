using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Tools.Common.Pagination;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Users.GetAvailableForRecordingProfessors;

public class GetAvailableForRecordingProfessorsQueryHandler : IRequestHandler<GetAvailableForRecordingProfessorsQuery, GetAvailableForRecordingProfessorsQueryResult>
{
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAvailableForRecordingProfessorsQueryHandler(IMapper mapper, UserManager<Professor> professorManager,
        ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.mapper = mapper;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    /// <inheritdoc />
    public async Task<GetAvailableForRecordingProfessorsQueryResult> Handle(GetAvailableForRecordingProfessorsQuery request, CancellationToken cancellationToken)
    {
        var professors = professorManager.Users
            .Where(x => x.IsRegistrationComplete)
            .Where(x => x.Id != userAccessor.GetCurrentUserId());

        if (request.ScientificAreaSubsections != null)
        {
            professors = FilterByScientificAreaSubsections(professors, request.ScientificAreaSubsections);
        }

        if (request.ScientificInterests != null)
        {
            professors = FilterByScientificInterests(professors, request.ScientificInterests);
        }

        var professorsResult = await professors
            .Include(x => x.ScientificInterests)
            .ToListAsync(cancellationToken: cancellationToken);

        var favorites = await GetFavoritesProfessorAsync();

        var professorDto = mapper.Map<List<ProfessorDto>>(professorsResult)
            .Select(s =>
            {
                s.IsFavorite = favorites.Contains(s.Id);
                s.CanJoin = s.Limit > s.Fullness;
                return s;
            });

        if (request.IsFavoriteFilterOnly)
        {
            professorDto = professorDto.Where(x => x.IsFavorite);
        }

        if (request.IsFavoriteFilter)
        {
            professorDto = professorDto.OrderByDescending(x => x.IsFavorite);
        }

        var resProfessors = PagedListFactory.FromSource(professorDto.OrderBy(x => x.Limit - x.Fullness),
            page: request.Page, pageSize: request.PageSize);

        return new GetAvailableForRecordingProfessorsQueryResult { Professors = resProfessors, Length = professorDto.Count(), Page = request.Page };
    }

    private async Task<HashSet<Guid>> GetFavoritesProfessorAsync()
    {
        var userId = userAccessor.GetCurrentUserId();
        var curUser = await studentManager.FindByIdAsync(userId.ToString());
        var favorites = new HashSet<Guid>();
        if (curUser != null)
        {
            favorites = studentManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.StudentFavoriteProfessors)
                .SelectMany(s => s.StudentFavoriteProfessors)
                .Where(x => x.IsActive)
                .Select(s => s.ProfessorId)
                .ToHashSet();
        }

        return favorites;
    }

    private IQueryable<Professor> FilterByScientificAreaSubsections(IQueryable<Professor> professors, IList<string> scientificAreaSubsections)
    {
        professors = professors
            .Include(x => x.ScientificAreaSubsections)
            .Where(student => student.ScientificAreaSubsections
                .Any(subsection => scientificAreaSubsections.Contains(subsection.Name)));

        return professors;
    }

    private IQueryable<Professor> FilterByScientificInterests(IQueryable<Professor> professors, IList<string> scientificInterests)
    {
        professors = professors
            .Include(x => x.ScientificInterests)
            .Where(student => student.ScientificInterests
                .Any(interest => scientificInterests.Contains(interest.Name)));

        return professors;
    }
}
