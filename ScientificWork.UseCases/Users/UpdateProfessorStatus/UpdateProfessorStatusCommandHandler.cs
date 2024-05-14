using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Professors.ValueObjects;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.UpdateProfessorStatus;

public class UpdateProfessorStatusCommandHandler : IRequestHandler<UpdateProfessorStatusCommand>
{
    private readonly UserManager<Professor> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    public UpdateProfessorStatusCommandHandler(UserManager<Professor> userManager, ILoggedUserAccessor userAccessor)
    {
        this.userManager = userManager;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UpdateProfessorStatusCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var student = await userManager.FindByIdAsync(userId);
        if (student is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        var status = ProfessorSearchStatus.Create(request.Status, request.Limit);
        student.UpdateSearchStatus(status);
        await userManager.UpdateAsync(student);
    }
}
