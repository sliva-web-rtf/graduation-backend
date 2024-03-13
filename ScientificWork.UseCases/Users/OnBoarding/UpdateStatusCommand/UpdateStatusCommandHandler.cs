using MediatR;
using Microsoft.AspNetCore.Identity;
using Saritasa.Tools.Domain.Exceptions;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Students.ValueObjects;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.Users.OnBoarding.UpdateStatusCommand;

public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand>
{
    private readonly UserManager<Student> userManager;
    private readonly ILoggedUserAccessor userAccessor;

    public UpdateStatusCommandHandler(UserManager<Student> userManager, ILoggedUserAccessor userAccessor)
    {
        this.userManager = userManager;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        var userId = userAccessor.GetCurrentUserId().ToString();
        var student = await userManager.FindByIdAsync(userId);
        if (student is null)
        {
            throw new NotFoundException($"User with id {userId} not found.");
        }

        var status = StudentSearchStatus.Create(request.Status, request.CommandSearching, request.ProfessorSearching);
        student.UpdateSearchStatus(status);
        await userManager.UpdateAsync(student);
    }
}
