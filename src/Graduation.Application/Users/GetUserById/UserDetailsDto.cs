namespace Graduation.Application.Users.GetUserById;

public record UserDetailsDto(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? Patronymic,
    string Email
)
{
    public required Guid? QualificationWorkId { get; set; }
    public required IList<string> Roles { get; set; }
}