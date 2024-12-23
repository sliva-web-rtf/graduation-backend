namespace ScientificWork.UseCases.Users.GetStudentStatus;

public class GetStudentStatusQueryResult
{
    public required string Status { get; set; }

    public required bool CommandSearching { get; set; }

    public required bool ProfessorSearching { get; set; }
}