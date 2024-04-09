using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfessors;

public class GetProfessorsQueryHandler : IRequestHandler<GetProfessorsQuery, GetProfessorsResult>
{
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetProfessorsQueryHandler(IMapper mapper, UserManager<Professor> professorManager,
        ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.mapper = mapper;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    /// <inheritdoc />
    public async Task<GetProfessorsResult> Handle(GetProfessorsQuery request, CancellationToken cancellationToken)
    {
        var favorites = await GetFavoritesProfessorAsync();

        var professors = professorManager.Users
            .Where(s => !favorites.Contains(s))
            .Where(x => x.IsRegistrationComplete == true)
            .Where(x => x.Id != userAccessor.GetCurrentUserId());

        if (request.ScientificAreaSubsections != null)
        {
            professors = FilterByScientificAreaSubsections(professors, request.ScientificAreaSubsections);
        }

        if (request.ScientificInterests != null)
        {
            professors = FilterByScientificInterests(professors, request.ScientificInterests);
        }

        var studentsResult = await professors
            .Include(x => x.ScientificInterests)
            .ToListAsync(cancellationToken: cancellationToken);

        var resProfessors = PagedListFactory.FromSource(mapper.Map<List<ProfessorDto>>(studentsResult),
            page: request.Page, pageSize: request.PageSize);

        return new GetProfessorsResult { Professors = resProfessors, Length = resProfessors.Count(), Page = request.Page };
    }

    private async Task<List<Professor>> GetFavoritesProfessorAsync()
    {
        var userId = userAccessor.GetCurrentUserId();
        var curUser = await studentManager.FindByIdAsync(userId.ToString());
        var favorites = new List<Professor>();
        if (curUser != null)
        {
            favorites.AddRange(studentManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.FavoriteProfessors)
                .SelectMany(s => s.FavoriteProfessors));
        }

        return favorites;
    }

    private IQueryable<Professor> FilterByScientificAreaSubsections(IQueryable<Professor> professors, IList<string> scientificAreaSubsections)
    {
        professors = professors
            .Include(x => x.ScientificAreasSubsections)
            .Where(student => student.ScientificAreasSubsections
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
