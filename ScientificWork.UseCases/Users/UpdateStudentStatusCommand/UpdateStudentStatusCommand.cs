using MediatR;
using ScientificWork.Domain.Students.Enums;

namespace ScientificWork.UseCases.Users.UpdateStudentStatusCommand;

public class UpdateStudentStatusCommand : IRequest
{
    public SearchStatus Status { get; set; }

    public bool CommandSearching { get; set; }

    public bool ProfessorSearching { get; set; }
}
