using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfileById;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileByIdResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Professor> professorManager;
    private readonly UserManager<Student> studentManager;
    private readonly ILoggedUserAccessor userAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetProfileQueryHandler(IMapper mapper, UserManager<Professor> professorManager, ILoggedUserAccessor userAccessor, UserManager<Student> studentManager)
    {
        this.mapper = mapper;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
        this.studentManager = studentManager;
    }

    /// <inheritdoc />
    public async Task<GetProfileByIdResult> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var professor = await GetStudentByIdAsync(request.ProfessorId, cancellationToken);
        var result = mapper.Map<GetProfileByIdResult>(professor);

        var scientificAreasDto = professor.ScientificAreaSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto
            {
                Section = x.Key,
                Subsections = x.Select(s => s.Name).ToList()
            });

        result.ScientificArea.AddRange(scientificAreasDto);


        result.IsFavorite = CheckFavorites(request.ProfessorId);
        result.CanJoin = result.Limit > result.Fullness;
        return result;
    }

    private async Task<Professor> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var professor = await professorManager.Users
            .Where(x => x.IsRegistrationComplete == true)
            .Where(x => x.Id == id)
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificAreaSubsections)
                .ThenInclude(x => x.ScientificArea)
            .FirstAsync(cancellationToken);

        if (!await professorManager.IsInRoleAsync(professor, nameof(Professor).ToLower()))
        {
            throw new Exception();
        }

        return professor;
    }

    private bool CheckFavorites(Guid professorId)
    {
        var userId = userAccessor.GetCurrentUserId();
        var check = studentManager.Users
                .Where(s => s.Id == userId)
                .Include(s => s.StudentFavoriteProfessors)
                .SelectMany(s => s.StudentFavoriteProfessors)
                .Where(x => x.IsActive)
                .Any(s => s.ProfessorId == professorId);

        return check;
    }
}
