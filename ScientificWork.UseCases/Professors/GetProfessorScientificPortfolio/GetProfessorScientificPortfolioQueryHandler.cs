using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;


public class GetProfessorScientificPortfolioQueryHandler
    : IRequestHandler<GetProfessorScientificPortfolioQuery, GetProfessorScientificPortfolioQueryResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Professor> professorManager;

    public GetProfessorScientificPortfolioQueryHandler(IMapper mapper, UserManager<Professor> professorManager)
    {
        this.mapper = mapper;
        this.professorManager = professorManager;
    }

    public async Task<GetProfessorScientificPortfolioQueryResult> Handle(
        GetProfessorScientificPortfolioQuery request, CancellationToken cancellationToken)
    {
        var userId = request.Id;
        var professor = await GetProfessorByIdAsync(userId, cancellationToken);
        var result = mapper.Map<GetProfessorScientificPortfolioQueryResult>(professor);

        var scientificAreasDto = professor.ScientificAreaSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto
            {
                Section = x.Key,
                Subsections = x.Select(s => s.Name).ToList()
            });
        
        result.ScientificArea.AddRange(scientificAreasDto);
        
        return result;
    }
    
    private async Task<Professor> GetProfessorByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var professor = await professorManager.Users
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
}