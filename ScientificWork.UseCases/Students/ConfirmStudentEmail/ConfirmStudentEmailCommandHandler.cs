using MediatR;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Students;

namespace ScientificWork.UseCases.Students.ConfirmStudentEmail;

public class ConfirmStudentEmailCommandHandler(UserManager<Student> userManager) : IRequestHandler<ConfirmStudentEmailCommand, ConfirmStudentEmailCommandResult>
{
    public async Task<ConfirmStudentEmailCommandResult> Handle(ConfirmStudentEmailCommand request, CancellationToken cancellationToken)
    {
        var user = userManager.FindByIdAsync(request.UserId!).Result;
        
        ArgumentNullException.ThrowIfNull(user);
        ValidateConfirmCode(request.ConfirmCode);
        
        var result = userManager.ConfirmEmailAsync(user, request.ConfirmCode!).Result;
        
        return await Task.FromResult(new ConfirmStudentEmailCommandResult
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