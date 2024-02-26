using MediatR;

namespace ScientificWork.UseCases.Students.UpdateStudent;

public record UpdateStudentCommand : IRequest
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Email { get; init; }

    public string? Сontacts { get; init; }

    public string? CurrentPassword { get; init; }

    public string? NewPassword { get; init; }

    public string? Degree { get; init; }

    public IList<string>? ScientificAreaSubsections { get; init; }

    public IList<string>? ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }
}
