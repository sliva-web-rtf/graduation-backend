using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ScientificWork.UseCases.Professors.ConfirmProfessorEmail;

public class ConfirmProfessorEmailCommand : IRequest<ConfirmProfessorEmailCommandResult>
{
    [Required]
    public string? UserId { get; init; }
    [Required]
    public string? ConfirmCode { get; init; }
}