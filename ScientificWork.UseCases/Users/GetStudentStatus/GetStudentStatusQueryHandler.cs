using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Students;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;

namespace ScientificWork.UseCases.Users.GetStudentStatus;

public class GetStudentStatusQueryHandler(UserManager<Student> userManager, ILoggedUserAccessor userAccessor)
    : IRequestHandler<GetStudentStatusQuery, GetStudentStatusQueryResult>
{
    public async Task<GetStudentStatusQueryResult> Handle(GetStudentStatusQuery request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var student = await userManager.FindByIdAsync(userId);
        if (student is null || student.SearchStatus is null)
        {
            throw new NotFoundException($"User {userId} not found or has no search status.");
        }

        var studentStatus = student.SearchStatus;
        return new GetStudentStatusQueryResult()
        {
            Status = studentStatus.Status.ToString(),
            ProfessorSearching = studentStatus.ProfessorSearching,
            CommandSearching = studentStatus.CommandSearching,
        };
    }
}