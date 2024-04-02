using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Professors.CreateProfessor;

public record CreateProfessorCommand(
    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    string Email,
    [Required]
    [DataType(DataType.Password)]
    string Password)
    : IRequest;
