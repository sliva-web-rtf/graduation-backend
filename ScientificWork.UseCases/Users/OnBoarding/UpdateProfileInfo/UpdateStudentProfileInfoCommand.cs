using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.OnBoarding.UpdateProfileInfo;

public record UpdateStudentProfileInfoCommand : IRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Patronymic { get; set; }

    public string Contacts { get; set; }

    public string Phone { get; set; }
}
