using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudentScientificPortfolio;

public class GetStudentScientificPortfolioQueryHandler
    : IRequestHandler<GetStudentScientificPortfolioQuery, GetStudentScientificPortfolioQueryResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Student> studentManager;
    private readonly ILoggedUserAccessor userAccessor;

    public GetStudentScientificPortfolioQueryHandler(
        IMapper mapper,
        UserManager<Student> studentManager,
        ILoggedUserAccessor userAccessor)
    {
        this.mapper = mapper;
        this.studentManager = studentManager;
        this.userAccessor = userAccessor;
    }

    public async Task<GetStudentScientificPortfolioQueryResult> Handle(
        GetStudentScientificPortfolioQuery request,
        CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var student = await GetStudentByIdAsync(userId, cancellationToken);

        var result = mapper.Map<GetStudentScientificPortfolioQueryResult>(student);

        var scientificAreasDto = student.ScientificAreaSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto { Section = x.Key, Subsections = x.Select(s => s.Name).ToList() });

        foreach (var dto in scientificAreasDto)
        {
            result.ScientificArea.Add(dto);
        }

        return result;
    }

    private async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await studentManager.Users
            .Where(x => x.Id == id)
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificAreaSubsections)
            .ThenInclude(x => x.ScientificArea)
            .FirstAsync(cancellationToken);

        if (!await studentManager.IsInRoleAsync(student, nameof(Student).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }
}