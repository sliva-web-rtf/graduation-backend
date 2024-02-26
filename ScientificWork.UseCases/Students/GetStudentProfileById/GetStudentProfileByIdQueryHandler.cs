using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;
using ScientificWork.UseCases.Common.Dtos;
using ScientificWork.UseCases.Students.Common.Dtos;
using Exception = System.Exception;

namespace ScientificWork.UseCases.Students.GetStudentProfileById;

public class GetStudentProfileByIdQueryHandler : IRequestHandler<GetStudentProfileByIdQuery, StudentDto>
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
    public async Task<StudentDto> Handle(GetStudentProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await GetStudentByIdAsync(request.StudentId, cancellationToken);

        var result = mapper.Map<StudentDto>(student);

        var scientificAreasDto = student.ScientificAreaSubsections
            .GroupBy(x => x.ScientificArea.Name)
            .Select(x => new ScientificAreasDto
            {
                Section = x.Key,
                Subsections = x.Select(s => s.Name).ToList()
            });

        result.ScientificArea.ToList().AddRange(scientificAreasDto);

        return result;
    }

    private async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await userManager.Users
            .Where(x => x.Id == id)
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
