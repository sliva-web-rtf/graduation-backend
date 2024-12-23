using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.UpdateProfileInfo;

public record UpdateProfileInfoCommand : IRequest
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

    public string? Phone { get; set; }

    public string? ContactsTg { get; set; }
    
    public string? CurrentPassword { get; set; }

    public string? NewPassword { get; set; }
}
