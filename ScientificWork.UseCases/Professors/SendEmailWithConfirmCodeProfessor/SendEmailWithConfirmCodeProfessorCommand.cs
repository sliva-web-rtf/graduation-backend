using MediatR;
using System.ComponentModel.DataAnnotations;
using ScientificWork.UseCases.Students.SendEmailWithConfirmCodeStudent;

namespace ScientificWork.UseCases.Professors.SendEmailWithConfirmCodeProfessor;

public class SendEmailWithConfirmCodeProfessorCommand : IRequest<SendEmailWithConfirmCodeProfessorCommandResult>
{
    [Required]
    public string? ProfessorId { get; init; }
    
    [Required]
    public string? Email { get; init; }
}