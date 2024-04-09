using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfileById;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileByIdResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Professor> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetProfileQueryHandler(IMapper mapper, UserManager<Professor> userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public async Task<GetProfileByIdResult> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var professor = await GetStudentByIdAsync(request.ProfessorId, cancellationToken);
        var result = mapper.Map<GetProfileByIdResult>(professor);

        var scientificAreasDto = professor.ScientificAreasSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto
            {
                Section = x.Key,
                Subsections = x.Select(s => s.Name).ToList()
            });

        result.ScientificArea.ToList().AddRange(scientificAreasDto);

        return result;
    }

    private async Task<Professor> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await userManager.Users
            .Where(x => x.IsRegistrationComplete == true)
            .Where(x => x.Id == id)
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificAreasSubsections)
                .ThenInclude(x => x.ScientificArea)
            .FirstAsync(cancellationToken);

        if (!await userManager.IsInRoleAsync(student, nameof(Professor).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }
}
