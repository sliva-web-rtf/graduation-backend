using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.CreateStudent;

public record CreateStudentCommand : IRequest<CreateStudentCommandResult>
{
    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    required public string Email { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    required public string Password { get; init; }
}
