using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.OnBoarding.CreateStudent;

public record CreateStudentCommand : IRequest
{
    [Required]
    required public string FirstName { get; init; }

    [Required]
    required public string LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    [EmailAddress]
    [Required]
    [DataType(DataType.EmailAddress)]
    required public string Email { get; init; }

    public string? Сontacts { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    required public string Password { get; init; }

    public string Degree { get; init; }

    public IList<string>? ScientificAreaSubsections { get; init; }

    public IList<string>? ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public int PublicationsCount { get; init; }

    public int HIndex { get; init; }
}
