using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.SendEmailWithConfirmCodeStudent;

public class SendEmailWithConfirmCodeStudentCommand : IRequest<SendEmailWithConfirmCodeStudentCommandResult>
{
    [Required]
    public string? StudentId { get; init; }
    
    [Required]
    public string? Email { get; init; }
}