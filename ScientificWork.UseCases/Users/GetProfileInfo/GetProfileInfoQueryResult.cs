using System.ComponentModel.DataAnnotations;

namespace ScientificWork.UseCases.Users.GetProfileInfo;

public record GetProfileInfoQueryResult
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }
    
    public string? Patronymic { get; set; }

    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    public string? Contacts { get; set; }

    public string? Phone { get; set; }
    
    public DateTime? LastPasswordChangedDate { get; set; }
}