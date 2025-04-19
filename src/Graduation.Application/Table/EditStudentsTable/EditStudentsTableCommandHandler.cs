using MediatR;

namespace Graduation.Application.Table.EditStudentsTable;

public class EditStudentsTableCommandHandler : IRequestHandler<EditStudentsTableCommand, EditStudentsTableCommandResult>
{
    public Task<EditStudentsTableCommandResult> Handle(EditStudentsTableCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}