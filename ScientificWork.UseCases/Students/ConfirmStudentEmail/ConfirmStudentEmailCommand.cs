using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.ConfirmStudentEmail;

public class ConfirmStudentEmailCommand : IRequest<ConfirmStudentEmailCommandResult>
{
    [Required]
    public string? UserId { get; init; }
    [Required]
    public string? ConfirmCode { get; init; }
}