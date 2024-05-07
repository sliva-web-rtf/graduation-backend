using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;
using ScientificWork.UseCases.ScientificWorks.GetScientificWorksForProfessor;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorks;

public class GetScientificWorksQueryHandler : IRequestHandler<GetScientificWorksQuery, GetScientificWorksResult>
{
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetScientificWorksQueryHandler(IMapper mapper, ILoggedUserAccessor userAccessor,
        IAppDbContext dbContext, UserManager<Professor> professorManager, UserManager<Student> studentManager)
    {
        this.mapper = mapper;
        this.userAccessor = userAccessor;
        this.dbContext = dbContext;
        this.professorManager = professorManager;
        this.studentManager = studentManager;
    }

    /// <inheritdoc />
    public async Task<GetScientificWorksResult> Handle(GetScientificWorksQuery request, CancellationToken cancellationToken)
    {
        var student = await studentManager.FindByIdAsync(userAccessor.GetCurrentUserId().ToString());
        var result = new List<Domain.ScientificWorks.ScientificWork>();

        if (student == null)
        {
            result.AddRange(professorManager.Users
                .Where(x => x.Id == userAccessor.GetCurrentUserId())
                .Include(x => x.ScientificWorks)
                .Include(x => x.FavoriteScientificWorks)
                .SelectMany(x => x.ScientificWorks));
        }
        else
        {
            result.AddRange(studentManager.Users
                .Where(x => x.Id == userAccessor.GetCurrentUserId())
                .Include(x => x.ScientificWorks)
                .Include(x => x.FavoriteScientificWorks)
                .SelectMany(x => x.ScientificWorks));
        }

        var scientificWorks = dbContext.ScientificWorks
            .Include(x => x.ScientificInterests).AsQueryable();

        if (request.ScientificAreaSubsections != null)
        {
            scientificWorks = FilterByScientificAreaSubsections(scientificWorks, request.ScientificAreaSubsections);
        }

        if (request.ScientificInterests != null)
        {
            scientificWorks = FilterByScientificInterests(scientificWorks, request.ScientificInterests);
        }

        scientificWorks = scientificWorks.OrderBy(x => x.Fullness);

        var favoriteSWIds = new HashSet<Guid>(result.Select(x => x.Id));

        var scientificWorksDto = mapper.Map<List<ScientificWorkDto>>(scientificWorks)
            .Select(s =>
            {
                s.IsFavorite = favoriteSWIds.Contains(s.Id);
                return s;
            });

        if (request.IsFavoriteFilter)
        {
            scientificWorksDto = scientificWorksDto.OrderBy(x => x.IsFavorite);
        }

        var resScientificWorks = PagedListFactory.FromSource(
            mapper.Map<List<ScientificWorkDto>>(scientificWorksDto),
            page: request.Page, pageSize: request.PageSize);

        return new GetScientificWorksResult
        {
            ScientificWorks = resScientificWorks, Page = request.Page, Length = resScientificWorks.Count()
        };
    }

    private IQueryable<Domain.ScientificWorks.ScientificWork> FilterByScientificAreaSubsections(
        IQueryable<Domain.ScientificWorks.ScientificWork> scientificWorks, IList<string> scientificAreaSubsections)
    {
        scientificWorks = dbContext.ScientificWorks
            .Where(x => x.ScientificAreaSubsections
                .Any(subsection => scientificAreaSubsections.Contains(subsection.Name)));

        return scientificWorks;
    }

    private IQueryable<Domain.ScientificWorks.ScientificWork> FilterByScientificInterests(
        IQueryable<Domain.ScientificWorks.ScientificWork> scientificWorks, IList<string> scientificInterests)
    {
        scientificWorks = dbContext.ScientificWorks
            .Where(x => x.ScientificInterests
                .Any(interest => scientificInterests.Contains(interest.Name)));

        return scientificWorks;
    }
}
