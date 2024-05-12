using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorksByUserId;

public class GetScientificWorksByUserIdQueryHandler : IRequestHandler<GetScientificWorksByUserIdQuery, List<ScientificWorkDto>>
{
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetScientificWorksByUserIdQueryHandler(UserManager<Student> studentManager, IMapper mapper, UserManager<Professor> professorManager, ILoggedUserAccessor userAccessor)
    {
        this.studentManager = studentManager;
        this.studentManager = studentManager;
        this.mapper = mapper;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
    }

    /// <inheritdoc />
    public async Task<List<ScientificWorkDto>> Handle(GetScientificWorksByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await studentManager.FindByIdAsync(request.UserId.ToString());
        var result = new List<Domain.ScientificWorks.ScientificWork>();
        if (user == null)
        {
            result.AddRange(professorManager.Users
                .Where(x => x.Id == request.UserId)
                .Include(x => x.ScientificWorks)
                .SelectMany(x => x.ScientificWorks)
                .Include(x => x.ScientificInterests));
        }
        else
        {
            result.AddRange(studentManager.Users
                .Where(x => x.Id == request.UserId)
                .Include(x => x.ScientificWorks)
                .SelectMany(x => x.ScientificWorks)
                .Include(x => x.ScientificInterests));
        }

        var res = mapper.Map<List<ScientificWorkDto>>(result);
        var favorites = await CheckFavoritesAsync();
        foreach (var sw in res)
        {
            sw.IsFavorite = favorites.Contains(sw.Id);
        }

        return res;
    }

    private async Task<HashSet<Guid>> CheckFavoritesAsync()
    {
        var userId = userAccessor.GetCurrentUserId();
        var curUser = await studentManager.FindByIdAsync(userId.ToString());
        var favorites = new HashSet<Guid>();

        if (curUser == null)
        {
            favorites = professorManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.ProfessorFavoriteScientificWorks)
                .SelectMany(s => s.ProfessorFavoriteScientificWorks)
                .Where(x => x.IsActive)
                .Select(s => s.ScientificWorkId)
                .ToHashSet();
        }
        else
        {
            favorites = studentManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.StudentFavoriteScientificWorks)
                .SelectMany(s => s.StudentFavoriteScientificWorks)
                .Where(x => x.IsActive)
                .Select(s => s.ScientificWorkId)
                .ToHashSet();
        }

        return favorites;
    }
}
