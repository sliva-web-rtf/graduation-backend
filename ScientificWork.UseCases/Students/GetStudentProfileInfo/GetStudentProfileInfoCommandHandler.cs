using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Students.GetStudentProfileInfo;

public class GetStudentProfileInfoCommandHandler 
    : IRequestHandler<GetStudentProfileInfoCommand, GetStudentProfileInfoCommandResult>
{
    private readonly IMapper mapper;
    private readonly UserManager<Student> studentManager;
    private readonly ILoggedUserAccessor userAccessor;

    public GetStudentProfileInfoCommandHandler(IMapper mapper, UserManager<Student> studentManager, ILoggedUserAccessor userAccessor)
    {
        this.mapper = mapper;
        this.studentManager = studentManager;
        this.userAccessor = userAccessor;
    }

    public async Task<GetStudentProfileInfoCommandResult> Handle(
        GetStudentProfileInfoCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId();
        var student = await GetStudentByIdAsync(userId, cancellationToken);

        var result = mapper.Map<GetStudentProfileInfoCommandResult>(student);

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