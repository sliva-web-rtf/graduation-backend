using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Professors;

namespace ScientificWork.UseCases.Professors.ConfirmProfessorEmail;

public class ConfirmProfessorEmailCommandHandler(UserManager<Professor> userManager) : IRequestHandler<ConfirmProfessorEmailCommand, ConfirmProfessorEmailCommandResult>
{
    public async Task<ConfirmProfessorEmailCommandResult> Handle(ConfirmProfessorEmailCommand request, CancellationToken cancellationToken)
    {
        var user = userManager.FindByIdAsync(request.UserId!).Result;
        
        ArgumentNullException.ThrowIfNull(user);
        ValidateConfirmCode(request.ConfirmCode);
        
        var result = userManager.ConfirmEmailAsync(user, request.ConfirmCode!).Result;
        
        return await Task.FromResult(new ConfirmProfessorEmailCommandResult
        {
            Succeeded = result.Succeeded,
        });
    }

    private static void ValidateConfirmCode(string? confirmCode)
    {
        ArgumentException.ThrowIfNullOrEmpty(confirmCode);
        if (confirmCode.Length is not 6)
            throw new ArgumentException("Wrong confirm code");
    }
}