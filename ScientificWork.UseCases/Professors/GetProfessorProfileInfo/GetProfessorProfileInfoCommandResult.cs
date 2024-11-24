namespace ScientificWork.UseCases.Professors.GetProfessorProfileInfo;

public class GetProfessorProfileInfoCommandResult
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    required public string Email { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    public string? ContactsTg { get; init; }
    
    public string? Status { get; set; }
}