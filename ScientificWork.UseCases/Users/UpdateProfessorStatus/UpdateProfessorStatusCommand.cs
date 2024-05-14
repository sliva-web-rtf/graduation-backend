using MediatR;
using ScientificWork.Domain.Students.Enums;

namespace ScientificWork.UseCases.Users.UpdateProfessorStatus;

public class UpdateProfessorStatusCommand : IRequest
{
    public SearchStatus Status { get; set; }

    public int Limit { get; set; }
}
