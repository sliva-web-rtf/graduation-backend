namespace ScientificWork.UseCases.Users.GetProfessorStatus;

public class GetProfessorStatusQueryResult
{
    public required string Status { get; set; }

    public required int Limit { get; set; }
}