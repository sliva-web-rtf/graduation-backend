using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Dtos;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, StudentDto>
{
    private readonly IMapper mapper;
    private readonly UserManager<Student> userManager;
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetStudentsQueryHandler(IMapper mapper, UserManager<Student> userManager, IAppDbContext dbContext)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<StudentDto> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var studentsRole = await userManager.GetUsersInRoleAsync(nameof(Student).ToLower());
        var students = userManager.Users
            .Where(student => studentsRole.Contains(student));

        if (request.ScientificAreaSubsections != null)
        {
            students = students
                .Include(x => x.ScientificAreaSubsections)
                .Where(student => student.ScientificAreaSubsections
                    .Any(subsection => request.ScientificAreaSubsections.Contains(subsection.Name)));
        }

        if (request.ScientificInterests != null)
        {
            students = students
                .Include(x => x.ScientificInterests)
                .Where(student => student.ScientificInterests
                    .Any(interest => request.ScientificInterests.Contains(interest.Name)));
        }

        var studentsPaged = PagedListFactory.FromSource(students,
            page: request.Page, pageSize: request.PageSize);

        return mapper.Map<StudentDto>(studentsPaged);
    }
}
