using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.UpdateProfileInfo;

public record UpdateStudentProfileInfoCommand : IRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Patronymic { get; set; }

    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public string Contacts { get; set; }

    public string Phone { get; set; }
}
