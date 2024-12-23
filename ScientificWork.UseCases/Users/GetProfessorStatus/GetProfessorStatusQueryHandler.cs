using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Professors;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Infrastructure.Tools.Domain.Exceptions;

namespace ScientificWork.UseCases.Users.GetProfessorStatus;

public class GetProfessorStatusQueryHandler(UserManager<Professor> userManager, ILoggedUserAccessor userAccessor)
    : IRequestHandler<GetProfessorStatusQuery, GetProfessorStatusQueryResult>
{
    public async Task<GetProfessorStatusQueryResult> Handle(GetProfessorStatusQuery request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var professor = await userManager.FindByIdAsync(userId);
        if (professor is null || professor.SearchStatus is null)
        {
            throw new NotFoundException($"User {userId} not found or has no search status.");
        }

        var professorStatus = professor.SearchStatus;
        return new GetProfessorStatusQueryResult()
        {
            Status = professorStatus.Status.ToString(),
            Limit = professorStatus.Limit,
        };
    }
}