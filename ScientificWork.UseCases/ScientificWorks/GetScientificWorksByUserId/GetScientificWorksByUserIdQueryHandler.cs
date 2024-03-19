using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorksByUserId;

public class GetScientificWorksByUserIdQueryHandler : IRequestHandler<GetScientificWorksByUserIdQuery, List<ScientificWorkDto>>
{
    private readonly UserManager<Student> studentManager;
    private readonly UserManager<Professor> professorManager;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetScientificWorksByUserIdQueryHandler(UserManager<Student> studentManager, IMapper mapper, UserManager<Professor> professorManager)
    {
        this.studentManager = studentManager;
        this.studentManager = studentManager;
        this.mapper = mapper;
        this.professorManager = professorManager;
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

        return mapper.Map<List<ScientificWorkDto>>(result);
    }
}
