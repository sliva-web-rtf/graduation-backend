using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Tools.Common.Pagination;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.ScientificWorks.Enums;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

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
        HashSet<Guid> favoriteId;
        HashSet<Guid> swUser;
        var scientificWorks = dbContext.ScientificWorks
            .Include(x => x.ScientificInterests)
            .Where(x => x.WorkStatus != WorkStatus.Сompleted);

        if (student == null)
        {
            var p = professorManager.Users
                .Where(x => x.Id == userAccessor.GetCurrentUserId())
                .Include(x => x.ScientificWorks)
                .Include(x => x.ProfessorFavoriteScientificWorks);
            favoriteId =
            [
                ..p
                    .SelectMany(x => x.ProfessorFavoriteScientificWorks)
                    .Where(x => x.IsActive)
                    .Select(x => x.ScientificWorkId)
            ];
            scientificWorks = scientificWorks
                .Where(x => x.WorkStatus == WorkStatus.NotConfirmed);
        }
        else
        {
            var s = studentManager.Users
                .Where(x => x.Id == userAccessor.GetCurrentUserId())
                .Include(x => x.ScientificWorks)
                .Include(x => x.StudentFavoriteScientificWorks);
            favoriteId =
            [
                ..s
                    .SelectMany(x => x.StudentFavoriteScientificWorks)
                    .Where(x => x.IsActive)
                    .Select(x => x.ScientificWorkId)
            ];
        }

        if (request.ScientificAreaSubsections != null)
        {
            scientificWorks = FilterByScientificAreaSubsections(scientificWorks, request.ScientificAreaSubsections);
        }

        if (request.ScientificInterests != null)
        {
            scientificWorks = FilterByScientificInterests(scientificWorks, request.ScientificInterests);
        }

        scientificWorks = scientificWorks.OrderBy(x => x.Limit - x.Fullness);

        var scientificWorksDto = mapper.Map<List<ScientificWorkDto>>(scientificWorks)
            .Select(s =>
            {
                s.IsFavorite = favoriteId.Contains(s.Id);
                s.CanJoin = s.Fullness < s.Limit;
                return s;
            });

        if (request.IsFavoriteFilterOnly)
        {
            scientificWorksDto = scientificWorksDto.Where(x => x.IsFavorite);
        }

        if (request.IsFavoriteFilter)
        {
            scientificWorksDto = scientificWorksDto.OrderByDescending(x => x.IsFavorite);
        }

        var resScientificWorks = PagedListFactory.FromSource(scientificWorksDto,
            page: request.Page, pageSize: request.PageSize);

        return new GetScientificWorksResult
        {
            ScientificWorks = resScientificWorks, Page = request.Page, Length = scientificWorksDto.Count()
        };
    }

    private IQueryable<Domain.ScientificWorks.ScientificWork> FilterByScientificAreaSubsections(
        IQueryable<Domain.ScientificWorks.ScientificWork> scientificWorks, IList<string> scientificAreaSubsections)
    {
        scientificWorks = scientificWorks
            .Where(x => x.ScientificAreaSubsections
                .Any(subsection => scientificAreaSubsections.Contains(subsection.Name)));

        return scientificWorks;
    }

    private IQueryable<Domain.ScientificWorks.ScientificWork> FilterByScientificInterests(
        IQueryable<Domain.ScientificWorks.ScientificWork> scientificWorks, IList<string> scientificInterests)
    {
        scientificWorks = scientificWorks
            .Where(x => x.ScientificInterests
                .Any(interest => scientificInterests.Contains(interest.Name)));

        return scientificWorks;
    }
}
