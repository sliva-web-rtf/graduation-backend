using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;


public class GetProfessorScientificPortfolioCommandHandler
    : IRequestHandler<GetProfessorScientificPortfolioCommand, GetProfessorScientificPortfolioCommandResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Professor> professorManager;
    private readonly ILoggedUserAccessor userAccessor;

    public GetProfessorScientificPortfolioCommandHandler(IMapper mapper, UserManager<Professor> professorManager, ILoggedUserAccessor userAccessor)
    {
        this.mapper = mapper;
        this.professorManager = professorManager;
        this.userAccessor = userAccessor;
    }

    public async Task<GetProfessorScientificPortfolioCommandResult> Handle(
        GetProfessorScientificPortfolioCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var professor = await GetProfessorByIdAsync(userId, cancellationToken);
        var result = mapper.Map<GetProfessorScientificPortfolioCommandResult>(professor);

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
        var student = await professorManager.Users
            .Where(x => x.Id == id)
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificAreaSubsections)
            .ThenInclude(x => x.ScientificArea)
            .FirstAsync(cancellationToken);

        if (!await professorManager.IsInRoleAsync(student, nameof(Professor).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }
}