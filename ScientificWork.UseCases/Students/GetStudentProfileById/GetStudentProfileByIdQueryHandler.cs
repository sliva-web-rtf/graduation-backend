using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Common.Dtos;
using Exception = System.Exception;

namespace ScientificWork.UseCases.Students.GetStudentProfileById;

public class GetStudentProfileByIdQueryHandler : IRequestHandler<GetStudentProfileByIdQuery, GetStudentProfileByIdResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Student> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetStudentProfileByIdQueryHandler(IMapper mapper, UserManager<Student> userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public async Task<GetStudentProfileByIdResult> Handle(GetStudentProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await GetStudentByIdAsync(request.StudentId, cancellationToken);

        var result = mapper.Map<GetStudentProfileByIdResult>(student);

        var scientificAreasDto = student.ScientificAreaSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto
            {
                Section = x.Key,
                Subsections = x.Select(s => s.Name).ToList()
            });

        foreach (var dto in scientificAreasDto)
        {
            result.ScientificArea.Add(dto);
        }

        return result;
    }

    private async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await userManager.Users
            .Where(x => x.Id == id)
            .Where(x => x.IsRegistrationComplete == true)
            .Include(x => x.ScientificInterests)
            .Include(x => x.ScientificAreaSubsections)
                .ThenInclude(x => x.ScientificArea)
            .FirstAsync(cancellationToken);

        if (!await userManager.IsInRoleAsync(student, nameof(Student).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }
}
