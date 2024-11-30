using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;

namespace ScientificWork.UseCases.Students.GetStudentProfileInfo;

public class GetStudentProfileInfoQueryHandler 
    : IRequestHandler<GetStudentProfileInfoQuery, GetStudentProfileInfoQueryResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Student> studentManager;

    public GetStudentProfileInfoQueryHandler(IMapper mapper, UserManager<Student> studentManager)
    {
        this.mapper = mapper;
        this.studentManager = studentManager;
    }

    public async Task<GetStudentProfileInfoQueryResult> Handle(
        GetStudentProfileInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = request.Id;
        var student = await GetStudentByIdAsync(userId, cancellationToken);

        var result = mapper.Map<GetStudentProfileInfoQueryResult>(student);

        return result;
    }
    
    private async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await studentManager.Users
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        if (!await studentManager.IsInRoleAsync(student, nameof(Student).ToLower()))
        {
            throw new Exception();
        }

        return student;
    }
}