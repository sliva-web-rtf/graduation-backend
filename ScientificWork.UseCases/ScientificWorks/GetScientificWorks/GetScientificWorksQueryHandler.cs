using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorksForProfessor;

public class GetScientificWorksQueryHandler : IRequestHandler<GetScientificWorksQuery, List<ScientificWorkDto>>
{
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly IAppDbContext dbContext;
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetScientificWorksQueryHandler(IMapper mapper, ILoggedUserAccessor userAccessor, IAppDbContext dbContext, UserManager<Professor> professorManager, UserManager<Student> studentManager)
    {
        this.mapper = mapper;
        this.userAccessor = userAccessor;
        this.dbContext = dbContext;
        this.professorManager = professorManager;
        this.studentManager = studentManager;
    }

    /// <inheritdoc />
    public async Task<List<ScientificWorkDto>> Handle(GetScientificWorksQuery request, CancellationToken cancellationToken)
    {
        var student = await studentManager.FindByIdAsync(userAccessor.GetCurrentUserId().ToString());
        var result = new List<Domain.ScientificWorks.ScientificWork>();

        if (student == null)
        {
            result.AddRange(professorManager.Users
                .Where(x => x.Id == userAccessor.GetCurrentUserId())
                .Include(x => x.ScientificWorks)
                .SelectMany(x => x.ScientificWorks));
        }
        else
        {
            result.AddRange(studentManager.Users
                .Where(x => x.Id == userAccessor.GetCurrentUserId())
                .Include(x => x.ScientificWorks)
                .SelectMany(x => x.ScientificWorks));
        }

        var scientificWorks = await dbContext.ScientificWorks
            .Include(x => x.ScientificInterests)
            .Where(x => !result.Contains(x))
            .OrderBy(x => x.Fullness)
            .ToListAsync(cancellationToken);

        return mapper.Map<List<ScientificWorkDto>>(scientificWorks);
    }
}
