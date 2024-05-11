using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.CreateStudent;

public record CreateStudentCommand(
    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    string Email,
    [Required]
    [DataType(DataType.Password)]
    string Password
) : IRequest<CreateStudentCommandResult>;
